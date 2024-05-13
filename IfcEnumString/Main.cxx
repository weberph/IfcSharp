#include <algorithm>
#include <cassert>
#include <cstdlib>
#include <deque>
#include <filesystem>
#include <format>
#include <fstream>
#include <functional>
#include <iostream>
#include <map>
#include <memory>
#include <optional>
#include <ranges>
#include <stdexcept>
#include <string_view>
#include <string>
#include <unordered_map>
#include <variant>
#include <vector>

#include <IfcHelper.hxx>
#include <EnumToString.hxx>
#include <Query.hxx>
#include <GetStringView.hxx>

#include <ifc/reader.hxx>
#include <ifc/util.hxx>
#include <ifc/dom/node.hxx>
#include <ifc/index-utils.hxx>
#include <ifc/abstract-sgraph.hxx>

#include <gsl/span>

#pragma comment(lib, "bcrypt.lib")

using namespace ifchelper;

namespace
{
    // XXX workaround
    std::deque<std::string> gStringTable;

    std::string_view registerString( std::string str )
    {
        return gStringTable.emplace_back( std::move( str ) );
    }

    template<class T>
    void print( const std::string& prefix, const T t )
    {
        std::cout << prefix << ifchelper::to_string( t ) << std::endl;
    }

    std::string join( const std::vector<std::string_view>& strings, const std::string& delimiter )
    {
        return strings | std::views::join_with( delimiter ) | std::ranges::to<std::string>();
    }

    std::string join( const std::vector<std::string>& strings, const std::string& delimiter )
    {
        return strings | std::views::join_with( delimiter ) | std::ranges::to<std::string>();
    }

    template<class... Ts>
    struct overloaded : Ts...
    {
        using Ts::operator()...;
    };

    constexpr std::array<char, 16> HexChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

    template<class T, size_t Extent>
        requires ( sizeof( T ) == 1 )
    constexpr std::string toHex( const std::span<const T, Extent> span ) noexcept
    {
        std::string result( span.size() * 2, '\0' );
        for ( size_t index = 0; const auto t : span )
        {
            const auto b = static_cast<uint8_t>( t );
            result[index++] = HexChars[( b >> 4 ) & 0xF];
            result[index++] = HexChars[b & 0xF];
        }
        return result;
    }

    /// Returns true if the file has been changed.
    bool updateFileWithHash( const std::string& outputFile, const std::string& content )
    {
        const auto contentSpan = std::as_bytes( std::span{ content } );
        const auto hash = ifc::hash_bytes( contentSpan.data(), contentSpan.data() + contentSpan.size() );
        const auto hashHex = toHex( std::as_bytes( std::span{ hash.value } ) );

        if ( std::filesystem::is_regular_file( outputFile ) )
        {
            if ( std::ifstream ifs( outputFile, std::ios::binary ); ifs )
            {
                std::string firstLine;
                std::getline( ifs, firstLine );

                if ( const auto hashPos = firstLine.find( "hash: " ); hashPos != std::string::npos )
                {
                    if ( const auto fileHash = firstLine.substr( hashPos + 6 ); fileHash.starts_with( hashHex ) )
                    {
                        return false;
                    }
                }
            }
        }

        if ( std::ofstream ofs( outputFile, std::ios::binary | std::ios::trunc ); ofs )
        {
            ofs << "// hash: " << hashHex << std::endl << std::endl;
            ofs.write( content.data(), content.size() );
            return true;
        }

        throw std::runtime_error( "Failed to open output file for writing. " + outputFile );
    }
}

std::string literalToString( const ifc::Reader& reader, const ifc::symbolic::LiteralExpr literalEx );

std::string getTypeName( const ifc::Reader& reader, const ifc::TypeIndex typeIndex );

std::string_view getTypeName( const ifc::Reader& reader, const ifc::DeclIndex declIndex )
{
    switch ( declIndex.sort() )
    {
        case ifc::DeclSort::Enumeration:
            return getStringView( reader, reader.get<ifc::symbolic::EnumerationDecl>( declIndex ).identity );

        case ifc::DeclSort::Scope:
            return getStringView( reader, reader.get<ifc::symbolic::ScopeDecl>( declIndex ).identity );

        case ifc::DeclSort::Alias:
            return getStringView( reader, reader.get<ifc::symbolic::AliasDecl>( declIndex ).identity ); // XXX: or check aliasee?

        case ifc::DeclSort::Enumerator:
            return getStringView( reader, reader.get<ifc::symbolic::EnumeratorDecl>( declIndex ).identity );

        default:
            assert( false );
            break;
    }

    throw std::runtime_error( "getTypeName: DeclSort not implemented" );
}

std::string getNamedDecl( const ifc::Reader& reader, const ifc::symbolic::NamedDeclExpr& namedDeclExpr )
{
    return getTypeName( reader, namedDeclExpr.type ) + "::" + std::string( getTypeName( reader, namedDeclExpr.decl ) );
}

std::vector<std::string> getTypeArgumentList( const ifc::Reader& reader, const ifc::ExprIndex exprIndex )
{
    std::vector<std::string> typeNameList;
    if ( exprIndex.sort() == ifc::ExprSort::Empty )
    {
        return typeNameList;
    }

    assert( exprIndex.sort() == ifc::ExprSort::Type
        || exprIndex.sort() == ifc::ExprSort::Tuple
        || exprIndex.sort() == ifc::ExprSort::NamedDecl );

    if ( exprIndex.sort() == ifc::ExprSort::Type )
    {
        const auto& typeExpr = reader.get<ifc::symbolic::TypeExpr>( exprIndex );

        typeNameList.emplace_back( getTypeName( reader, typeExpr.denotation ) );
    }
    else if ( exprIndex.sort() == ifc::ExprSort::Tuple )
    {
        const auto& tupleExpr = reader.get<ifc::symbolic::TupleExpr>( exprIndex );
        for ( const auto& tupleItem : reader.sequence( tupleExpr ) )
        {
            assert( tupleItem.sort() == ifc::ExprSort::Type
                || tupleItem.sort() == ifc::ExprSort::PackedTemplateArguments
                || tupleItem.sort() == ifc::ExprSort::NamedDecl
                || tupleItem.sort() == ifc::ExprSort::Literal );

            if ( tupleItem.sort() == ifc::ExprSort::Type )
            {
                const auto& typeExpr = reader.get<ifc::symbolic::TypeExpr>( tupleItem );
                typeNameList.emplace_back( getTypeName( reader, typeExpr.denotation ) );
            }
            else if ( tupleItem.sort() == ifc::ExprSort::PackedTemplateArguments )
            {
                const auto& packedTypeExpr = reader.get<ifc::symbolic::PackedTemplateArgumentsExpr>( tupleItem );
                for ( auto&& str : getTypeArgumentList( reader, packedTypeExpr.arguments ) )
                {
                    typeNameList.emplace_back( std::move( str ) );
                }
            }
            else if ( tupleItem.sort() == ifc::ExprSort::Literal )
            {
                const auto& literalEx = reader.get<ifc::symbolic::LiteralExpr>( tupleItem );
                typeNameList.emplace_back( literalToString( reader, literalEx ) );
            }
            else if ( tupleItem.sort() == ifc::ExprSort::NamedDecl )
            {
                typeNameList.emplace_back( getNamedDecl( reader, reader.get<ifc::symbolic::NamedDeclExpr>( tupleItem ) ) );
            }
        }
    }
    else if ( exprIndex.sort() == ifc::ExprSort::NamedDecl )
    {
        typeNameList.emplace_back( getNamedDecl( reader, reader.get<ifc::symbolic::NamedDeclExpr>( exprIndex ) ) );
    }

    return typeNameList;
}

std::string_view getSyntacticTemplateName( const ifc::Reader& reader, const ifc::ExprIndex primaryTemplate )
{
    return Query( reader, primaryTemplate )
        .get( &ifc::symbolic::NamedDeclExpr::decl )
        .either<ifc::symbolic::TemplateDecl>( &ifc::symbolic::TemplateDecl::identity, &ifc::symbolic::AliasDecl::identity )
        .visit( overloaded{
            [&]( const ifc::symbolic::Identity<ifc::NameIndex>& identity ) { return getStringView( reader, identity ); },
            [&]( const ifc::symbolic::Identity<ifc::TextOffset>& identity ) { return getStringView( reader, identity ); }
        } );
}

std::string getFullTypeNameFromSyntacticTemplate( const ifc::Reader& reader, const ifc::TypeIndex syntacticIndex ) // incomplete/best-effort
{
    const auto& templateIdExpr = Query( reader, syntacticIndex )
        .get( &ifc::symbolic::SyntacticType::expr ).get<ifc::symbolic::TemplateIdExpr>();

    const auto name = getSyntacticTemplateName( reader, templateIdExpr.primary_template );

    const std::string typeArgs = "<" + join( getTypeArgumentList( reader, templateIdExpr.arguments ), ", " ) + ">";
    return std::string( name ) + typeArgs;
}

std::string literalToString( const ifc::Reader& reader, const ifc::symbolic::LiteralExpr literalEx )
{
    switch ( literalEx.value.sort() )
    {
        case ifc::LiteralSort::Immediate:
            return std::to_string( ifc::to_underlying( literalEx.value.index() ) );
        case ifc::LiteralSort::Integer:
            return std::to_string( reader.get<int64_t>( literalEx.value ) );
        case ifc::LiteralSort::FloatingPoint:
            return std::to_string( reader.get<double>( literalEx.value ) );
    }

    throw std::runtime_error( "literalToString: LiteralSort not implemented" );
}

std::string getArrayTypeAndBound( const ifc::Reader& reader, const ifc::symbolic::ArrayType arrayType )
{
    std::string bound;
    switch ( arrayType.bound.sort() )
    {
        case ifc::ExprSort::Literal:
        {
            const auto& literalEx = reader.get<ifc::symbolic::LiteralExpr>( arrayType.bound );
            bound = literalToString( reader, literalEx );
        }
        break;
        default:
            assert( false );
            break;
    }

    return getTypeName( reader, arrayType.element ) + "[" + bound + "]";
}

std::vector<std::string> getTypeListNames( const ifc::Reader& reader, const ifc::TypeIndex typeIndex )
{
    std::vector<std::string> typeNameList;

    switch ( typeIndex.sort() )
    {
        case ifc::TypeSort::Base:
            typeNameList.emplace_back( getTypeName( reader, reader.get<ifc::symbolic::BaseType>( typeIndex ).type ) );
            break;

        case ifc::TypeSort::Tuple:
            for ( const auto& tupleItem : reader.sequence( reader.get<ifc::symbolic::TupleType>( typeIndex ) ) )
            {
                typeNameList.emplace_back( getTypeName( reader, tupleItem ) );
            }
            break;

        default:
            print( "Assert: ", typeIndex.sort() );
            assert( false );
            throw std::runtime_error( "getTypeListNames: TypeSort not implemented" );
            //typeNameList.emplace_back( "(TODO: " + to_string( typeIndex.sort() ) + ")" );
            break;
    }

    return typeNameList;
}

std::string getTypeName( const ifc::Reader& reader, const ifc::TypeIndex typeIndex, bool )
{
    switch ( typeIndex.sort() )
    {
        case ifc::TypeSort::Designated:
            return std::string( getTypeName( reader, reader.get<ifc::symbolic::DesignatedType>( typeIndex ).decl ) );

        case ifc::TypeSort::Fundamental:
            return std::string( ifchelper::to_string( reader.get<ifc::symbolic::FundamentalType>( typeIndex ).basis ) );

        case ifc::TypeSort::Syntactic:
            return getFullTypeNameFromSyntacticTemplate( reader, typeIndex );

        case ifc::TypeSort::Array:
            return getArrayTypeAndBound( reader, reader.get<ifc::symbolic::ArrayType>( typeIndex ) );

        case ifc::TypeSort::Base:
            return getTypeName( reader, reader.get<ifc::symbolic::BaseType>( typeIndex ).type );

        case ifc::TypeSort::Qualified:
            return getTypeName( reader, reader.get<ifc::symbolic::QualifiedType>( typeIndex ).unqualified_type ); // const, etc discarded

        case ifc::TypeSort::Pointer:
            return getTypeName( reader, reader.get<ifc::symbolic::PointerType>( typeIndex ).pointee ) + "*";

        case ifc::TypeSort::LvalueReference:
            return getTypeName( reader, reader.get<ifc::symbolic::LvalueReferenceType>( typeIndex ).referee ) + "&";

        case ifc::TypeSort::Forall:
            return getTypeName( reader, reader.get<ifc::symbolic::ForallType>( typeIndex ).subject ); // ?

        default:
            print( "Assert: ", typeIndex.sort() );
            assert( false );
    }

    throw std::runtime_error( "getTypeName: TypeSort not implemented" );
}

std::string getTypeName( const ifc::Reader& reader, const ifc::TypeIndex typeIndex )
{
    const std::string typeName = getTypeName( reader, typeIndex, false );
    //if ( typeName == "MsvcTraitSort" )
    //{
    //    std::cout << "";
    //}
    return typeName;
}

constexpr size_t fundamentalBitWidth( const ifc::symbolic::FundamentalType& type )
{
    switch ( type.precision )
    {
        case ifc::symbolic::TypePrecision::Default:
            switch ( type.basis )
            {
                case ifc::symbolic::TypeBasis::Bool:
                case ifc::symbolic::TypeBasis::Char:
                    return 8;

                case ifc::symbolic::TypeBasis::Wchar_t:
                    return 16;

                case ifc::symbolic::TypeBasis::Float:
                case ifc::symbolic::TypeBasis::Int:
                    return 32;

                case ifc::symbolic::TypeBasis::Double:
                    return 64;

                default: throw std::runtime_error( "unexpected fundamental type" );
            }

        case ifc::symbolic::TypePrecision::Bit8:
            return 8;

        case ifc::symbolic::TypePrecision::Short:
        case ifc::symbolic::TypePrecision::Bit16:
            return 16;

        case ifc::symbolic::TypePrecision::Long:
        case ifc::symbolic::TypePrecision::Bit32:
            return 32;

        case ifc::symbolic::TypePrecision::Bit64:
            return 64;

        case ifc::symbolic::TypePrecision::Bit128:
            return 128;

        default: throw std::runtime_error( "unexpected fundamental type" );
    }
}

constexpr std::string_view fundamentalToCS( const ifc::symbolic::FundamentalType& type )
{
    const bool isSigned = type.sign != ifc::symbolic::TypeSign::Unsigned;
    switch ( type.precision )
    {
        case ifc::symbolic::TypePrecision::Default:
            switch ( type.basis )
            {
                case ifc::symbolic::TypeBasis::Bool:
                case ifc::symbolic::TypeBasis::Char:
                    return type.sign == ifc::symbolic::TypeSign::Unsigned ? "byte" : "sbyte";

                case ifc::symbolic::TypeBasis::Int:
                    return type.sign == ifc::symbolic::TypeSign::Unsigned ? "uint" : "int";

                case ifc::symbolic::TypeBasis::Wchar_t:
                    return "char";

                case ifc::symbolic::TypeBasis::Float:
                    return "float";

                case ifc::symbolic::TypeBasis::Double:
                    return "double";

                default: throw std::runtime_error( "unexpected fundamental type" );
            }

        case ifc::symbolic::TypePrecision::Bit8:
            return isSigned ? "sbyte" : "byte";

        case ifc::symbolic::TypePrecision::Short:
        case ifc::symbolic::TypePrecision::Bit16:
            return isSigned ? "short" : "ushort";

        case ifc::symbolic::TypePrecision::Long:
        case ifc::symbolic::TypePrecision::Bit32:
            return isSigned ? "int" : "uint";

        case ifc::symbolic::TypePrecision::Bit64:
            return isSigned ? "long" : "ulong";

        case ifc::symbolic::TypePrecision::Bit128:
        default: throw std::runtime_error( "unexpected fundamental type" );
    }
}

void enumToCS( ifc::Reader& reader,
    const std::string_view typeName,
    ifc::Sequence<ifc::symbolic::EnumeratorDecl> initializer,
    const ifc::TypeIndex baseIndex,
    std::ostream& os )
{
    os << "public enum " << typeName;

    if ( not index_like::null( baseIndex ) )
    {
        if ( baseIndex.sort() != ifc::TypeSort::Fundamental ) throw std::runtime_error( "unexpected enum base" );
        if ( const auto base = fundamentalToCS( reader.get<ifc::symbolic::FundamentalType>( baseIndex ) ); base != "int" )
        {
            os << " : " << base;
        }
    }

    os << std::endl << "{" << std::endl;

    bool first = true;
    bool printExplicitValues = false;
    size_t index = 0;
    for ( const auto& val : reader.sequence( initializer ) ) // XXX: not const?
    {
        if ( first )
        {
            first = false;
        }
        else
        {
            os << ',' << std::endl;
        }

        os << "    " << getStringView( reader, val.identity );

        if ( val.initializer.sort() == ifc::ExprSort::Literal )
        {
            const auto& literalEx = reader.get<ifc::symbolic::LiteralExpr>( val.initializer );
            const uint64_t value = literalEx.value.sort() == ifc::LiteralSort::Immediate ? ifc::to_underlying( literalEx.value.index() ) : reader.get<int64_t>( literalEx.value );

            printExplicitValues |= value != index;

            if ( printExplicitValues )
            {
                os << " = " << static_cast<int64_t>( value );
            }
        }
        else
        {
            assert( false );
        }

        ++index;
    }

    if ( !first )
    {
        os << std::endl;
    }

    os << '}' << std::endl << std::endl;
}

template<class T>
    requires requires( T t )
{
    t.identity;
    t.basic_spec;
}
bool isUnwrittenScope( const T& decl )
{
    return index_like::null( decl.identity.locus.line )
        || ( ifc::to_underlying( decl.basic_spec ) & ifc::to_underlying( ifc::BasicSpecifiers::IsMemberOfGlobalModule ) ) != 0;
}

template<>
struct std::hash<ifc::DeclIndex>
{
    std::size_t operator()( const ifc::DeclIndex& s ) const noexcept
    {
        static_assert( sizeof( ifc::DeclIndex ) == sizeof( uint32_t ) );
        return *reinterpret_cast<const uint32_t*>( &s );
    }
};

template<class T>
concept HasIdentityAndHomescope = requires( T t )
{
    t.identity;
    t.home_scope;
};

struct Scope;

using ScopeRef = std::reference_wrapper<Scope>;

struct Scope
{
    std::string_view Name{};
    ifc::DeclIndex Index{};
    bool IsNamespace{};
    std::optional<ScopeRef> Parent{};
    std::optional<ScopeRef> TopLevelParent{};
    std::vector<ScopeRef> Children{};

    bool hasTopLevel( const std::string_view name ) const noexcept
    {
        return TopLevelParent.has_value() ? TopLevelParent->get().Name == name : Name == name;
    }
};

bool operator==( const Scope& a, const Scope& b ) noexcept
{
    return a.Index == b.Index;
}

bool operator!=( const Scope& a, const Scope& b ) noexcept
{
    return a.Index != b.Index;
}

bool isNamespace( const ifc::Reader& reader, const ifc::TypeIndex typeIndex )
{
    return reader.get<ifc::symbolic::FundamentalType>( typeIndex ).basis == ifc::symbolic::TypeBasis::Namespace;
}

bool isNamespace( const ifc::Reader& reader, const ifc::symbolic::ScopeDecl& scopeDecl )
{
    return isNamespace( reader, scopeDecl.type );
}

bool isNamespace( const ifc::Reader& reader, const ifc::DeclIndex index )
{
    return index.sort() == ifc::DeclSort::Scope && isNamespace( reader, reader.get<ifc::symbolic::ScopeDecl>( index ) );
}

template<HasIdentityAndHomescope T>
std::tuple<std::string_view, ifc::DeclIndex, bool> getNameAndHomeScope( const ifc::Reader& reader, const ifc::DeclIndex declIndex )
{
    const auto& decl = reader.get<T>( declIndex );
    if constexpr ( std::same_as<T, ifc::symbolic::ScopeDecl> )
    {
        return std::make_tuple( getStringView( reader, decl.identity ), decl.home_scope, isNamespace( reader, decl ) );
    }

    return std::make_tuple( getStringView( reader, decl.identity ), decl.home_scope, false );
}

std::tuple<std::string_view, ifc::DeclIndex, bool> getNameAndHomeScope( const ifc::Reader& reader, const ifc::DeclIndex declIndex )
{
    switch ( declIndex.sort() )
    {
        case ifc::DeclSort::Scope: return getNameAndHomeScope<ifc::symbolic::ScopeDecl>( reader, declIndex );
        case ifc::DeclSort::Template: return getNameAndHomeScope<ifc::symbolic::TemplateDecl>( reader, declIndex );
        case ifc::DeclSort::PartialSpecialization: return getNameAndHomeScope<ifc::symbolic::PartialSpecializationDecl>( reader, declIndex );
        case ifc::DeclSort::Function: return getNameAndHomeScope<ifc::symbolic::FunctionDecl>( reader, declIndex );
        case ifc::DeclSort::Method: return getNameAndHomeScope<ifc::symbolic::NonStaticMemberFunctionDecl>( reader, declIndex );
        case ifc::DeclSort::Specialization: return getNameAndHomeScope( reader, reader.get<ifc::symbolic::SpecializationDecl>( declIndex ).decl );
        default: throw std::runtime_error( "getIdAndScope: sort not implemented" );
    }
}

class ScopeInfo
{
    using ScopeMap = std::unordered_map<ifc::DeclIndex, Scope>; // rehash could invalidate refs?

public:
    ScopeInfo()
        : mNamespaces( std::make_unique<ScopeMap>() )
        , mTypeScopes( std::make_unique<ScopeMap>() )
    {
    }

    std::optional<ScopeRef> find( const ifc::DeclIndex index, const bool isNamespace ) const
    {
        auto& map = isNamespace ? *mNamespaces : *mTypeScopes;
        const auto it = map.find( index );
        return it != map.end() ? it->second : std::optional<ScopeRef>{};
    }

    std::optional<ScopeRef> find( const ifc::DeclIndex index ) const
    {
        return find( index, true ).or_else( [&] { return find( index, false ); } );
    }

    std::optional<ScopeRef> findOrAdd( const ifc::Reader& reader, const ifc::DeclIndex homeScope )
    {
        return find( homeScope ).or_else( [&] { return collect( reader, homeScope ); } );
    }

    std::optional<ScopeRef> collect( const ifc::Reader& reader, const ifc::DeclIndex homeScope )
    {
        if ( index_like::null( homeScope ) )
        {
            return {};
        }

        const auto [parentName, parentHomeScope, parentIsNamespace] = getNameAndHomeScope( reader, homeScope );
        return collect( reader, homeScope, parentName, parentHomeScope, parentIsNamespace );
    }

    Scope& collect( const ifc::Reader& reader, const ifc::DeclIndex index, const std::string_view name, const ifc::DeclIndex homeScope, const bool isNamespace )
    {
        const auto inserter = [&]() -> std::optional<ScopeRef> {
            auto& map = isNamespace ? *mNamespaces : *mTypeScopes;
            return std::ref( map.emplace( index, Scope{ name, index, isNamespace } ).first->second );
        };

        Scope& self = find( index ).or_else( inserter ).value();

        // create and register with parent
        if ( not index_like::null( homeScope ) )
        {
            if ( const auto parentOpt = find( homeScope ) )
            {
                Scope& parent = parentOpt.value();
                parent.Children.emplace_back( self );
                self.Parent = parent;
                self.TopLevelParent = parent.TopLevelParent.value_or( parent );
            }
            else
            {
                const auto [parentName, parentHomeScope, parentIsNamespace] = getNameAndHomeScope( reader, homeScope );
                auto& parent = collect( reader, homeScope, parentName, parentHomeScope, parentIsNamespace );
                parent.Children.emplace_back( self );
                self.Parent = parent;
                self.TopLevelParent = parent.TopLevelParent.value_or( parent );
            }
        }
        else
        {
            mTopLevel.emplace_back( self );
        }

        return self;
    }

    void collect( ifc::Reader& reader, bool onlyNamespaces )
    {
        for ( const auto& decl : reader.partition<ifc::symbolic::ScopeDecl>() )
        {
            if ( decl.type.sort() == ifc::TypeSort::Fundamental )
            {
                if ( not onlyNamespaces || reader.get<ifc::symbolic::FundamentalType>( decl.type ).basis == ifc::symbolic::TypeBasis::Namespace )
                {
                    const auto index = reader.index_of<ifc::DeclIndex>( decl );
                    collect( reader, index, getStringView( reader, decl.identity ), decl.home_scope, true );
                }
            }
        }
    }

    const std::vector<ScopeRef>& topLevel() const noexcept
    {
        return mTopLevel;
    }

    using Visitor = std::function<void( const Scope&, size_t, const std::string&, bool )>;

    void scopeVisitor( const Visitor& visitor, const Scope& current, const size_t level, const std::string& qualifiedName ) const
    {
        visitor( current, level, qualifiedName, true );
        for ( const Scope& nested : current.Children )
        {
            if ( nested.IsNamespace )
            {
                const auto nestedQualifiedName = std::string( nested.Name );
                scopeVisitor( visitor, nested, level + 1, qualifiedName.empty() ? nestedQualifiedName : ( qualifiedName + "::" + nestedQualifiedName ) );
            }
        }
        visitor( current, level, qualifiedName, false );
    }

    void visit( const Visitor& visitor ) const
    {
        for ( const Scope& topLevel : mTopLevel )
        {
            scopeVisitor( visitor, topLevel, 1, "" );
        }
    }

    void print( std::ostream& os ) const
    {
        visit( [&]( const Scope&, const size_t level, const std::string& qualifiedName, const bool enter ) {
            if ( enter )
            {
                os << std::string( level * 2, ' ' ) << qualifiedName << std::endl;
            }
        } );
    }

private:
    std::unique_ptr<ScopeMap> mNamespaces;
    std::unique_ptr<ScopeMap> mTypeScopes;
    std::vector<ScopeRef> mTopLevel;
};

enum class InfoBaseType
{
    Struct, Enum, Template, Alias
};

class InfoBase
{
public:
    InfoBase( ifc::Reader& reader, const std::string_view name, const ifc::DeclIndex index, std::optional<ScopeRef> scope )
        : mReader( reader )
        , mName( name )
        , mIndex( index )
        , mScope( scope )
    {
    }

    virtual ~InfoBase() = default;

    virtual InfoBaseType type() const noexcept = 0;

    template<std::derived_from<InfoBase> U>
    const U& as() const
    {
        if ( type() != U::Type )
        {
            throw std::runtime_error( "bad InfoBase cast" );
        }

        return dynamic_cast<const U&>( *this );
    }

    std::string_view name() const noexcept
    {
        return mName;
    }

    const std::optional<ScopeRef>& scope() const noexcept
    {
        return mScope;
    }

    ifc::DeclIndex index() const noexcept
    {
        return mIndex;
    }

protected:
    std::reference_wrapper<ifc::Reader> mReader;
    std::string_view mName;
    ifc::DeclIndex mIndex{};
    std::optional<ScopeRef> mScope;
};

using InfoBaseRef = std::reference_wrapper<const InfoBase>;

template<class T, InfoBaseType InfoType>
class InfoBaseT : public InfoBase
{
public:
    static constexpr InfoBaseType Type = InfoType;

    InfoBaseT( ifc::Reader& reader, const T& decl, std::optional<ScopeRef> scope )
        : InfoBase( reader, getStringView( reader, decl.identity ), reader.index_of<ifc::DeclIndex>( decl ), scope )
        , mDecl( decl )
    {
    }

    virtual InfoBaseType type() const noexcept
    {
        return InfoType;
    }

    const T& decl() const noexcept
    {
        return mDecl;
    }

protected:
    std::reference_wrapper<const T> mDecl;
};

class EnumInfo : public InfoBaseT<ifc::symbolic::EnumerationDecl, InfoBaseType::Enum>
{
public:
    using InfoBaseT::InfoBaseT;

    void writeCS( std::ostream& os ) const
    {
        enumToCS( mReader, mName, decl().initializer, decl().base, os );
    }
};

class TemplateInfo : public InfoBaseT<ifc::symbolic::TemplateDecl, InfoBaseType::Template>
{
public:
    struct TemplateField
    {
        std::string TypeName; // TODO: string_view
        std::string_view FieldName;
        std::optional<size_t> ParameterIndex;
    };

    TemplateInfo( ifc::Reader& reader, const ifc::symbolic::TemplateDecl& decl, std::optional<ScopeRef> scope, const size_t argumentCount, std::vector<TemplateField> fields )
        : InfoBaseT( reader, decl, scope )
        , mArgumentCount( argumentCount )
        , mFields( std::move( fields ) )
    {
    }

    size_t argumentCount() const noexcept
    {
        return mArgumentCount;
    }

    const std::vector<TemplateField>& fields() const noexcept
    {
        return mFields;
    }

    void writeCS( std::ostream& ) const
    {
        // TODO?
    }

private:
    size_t mArgumentCount;
    std::vector<TemplateField> mFields;
};

int64_t getLiteralValue( const ifc::Reader& reader, const ifc::ExprIndex literalExprIndex )
{
    const auto visitor = [&]( const ifc::LitIndex index ) {
        return index.sort() == ifc::LiteralSort::Immediate ? ifc::to_underlying( index.index() ) : gsl::narrow_cast<uint32_t>( reader.get<int64_t>( index ) );
    };

    return Query( reader, literalExprIndex ).get( &ifc::symbolic::LiteralExpr::value ).visit( visitor );
}

template<class F>
concept FlatTemplateArgumentListVisitor =
/* */ std::invocable<F, ifc::ExprIndex, const ifc::symbolic::TypeExpr&, size_t> and
/* */ std::invocable<F, ifc::ExprIndex, const ifc::symbolic::NamedDeclExpr&, size_t> and
/* */ std::invocable<F, ifc::ExprIndex, const ifc::symbolic::LiteralExpr&, size_t>;

struct FlatTemplateArgumentList
{
    std::vector<ifc::ExprIndex> exprs; // contains Type, NamedDecl or Literal

    /// <param name="exprIndex">Typically TemplateIdExpr::arguments</param>
    void extract( const ifc::Reader& reader, const ifc::ExprIndex exprIndex )
    {
        if ( exprIndex.sort() == ifc::ExprSort::Type
            or exprIndex.sort() == ifc::ExprSort::NamedDecl
            or exprIndex.sort() == ifc::ExprSort::Literal )
        {
            exprs.emplace_back( exprIndex );
            return;
        }

        const Query query( reader, exprIndex );
        if ( exprIndex.sort() == ifc::ExprSort::Tuple )
        {
            const auto tuple = query.sequence<ifc::symbolic::TupleExpr>();
            for ( const auto nestedExprIndex : tuple.span )
            {
                extract( reader, nestedExprIndex );
            }
        }
        else if ( exprIndex.sort() == ifc::ExprSort::PackedTemplateArguments )
        {
            const auto& packed = query.get<ifc::symbolic::PackedTemplateArgumentsExpr>();
            extract( reader, packed.arguments );
        }
        else if ( exprIndex.sort() == ifc::ExprSort::Empty )
        {
            // nothing to do
        }
        else
        {
            assert( false );
        }
    }

    template<FlatTemplateArgumentListVisitor F>
    void visit( const ifc::Reader& reader, F&& visitor )
    {
        for ( size_t i = 0; i < exprs.size(); ++i )
        {
            const auto exprIndex = exprs[i];
            if ( exprIndex.sort() == ifc::ExprSort::Type )
            {
                visitor( exprIndex, reader.get<ifc::symbolic::TypeExpr>( exprIndex ), i );
            }
            else if ( exprIndex.sort() == ifc::ExprSort::NamedDecl )
            {
                visitor( exprIndex, reader.get<ifc::symbolic::NamedDeclExpr>( exprIndex ), i );
            }
            else if ( exprIndex.sort() == ifc::ExprSort::Literal )
            {
                visitor( exprIndex, reader.get<ifc::symbolic::LiteralExpr>( exprIndex ), i );
            }
            else
            {
                assert( false ); // missing case; check extract method
            }
        }
    }
};

struct StdArrayArguments
{
    size_t Bound{};
    std::string_view TypeName{};

    static StdArrayArguments extract( const ifc::Reader& reader, const ifc::ExprIndex templateIdExprArguments )
    {
        const auto tuple = Query( reader, templateIdExprArguments ).sequence<ifc::symbolic::TupleExpr>();
        if ( tuple.span.size() == 2 )
        {
            const auto bound = gsl::narrow_cast<size_t>( getLiteralValue( reader, tuple[1].index ) );

            const auto typeDecl = tuple[0]
                .get( &ifc::symbolic::TypeExpr::denotation )
                .get( &ifc::symbolic::DesignatedType::decl );

            if ( typeDecl.index.sort() == ifc::DeclSort::Alias )
            {
                const auto alias = typeDecl.identity( &ifc::symbolic::AliasDecl::identity );
                return { bound, alias };
            }
            else
            {
                assert( false );
            }
        }
        else
        {
            assert( false );
        }

        throw "TODO";
    }
};

struct UntemplatedStructType // something that can be a base type which is not a template
{
    ifc::DeclIndex DeclIndex{};
    std::string_view Name{};

    [[nodiscard]] bool extract( const ifc::Reader& reader, const ifc::DeclIndex declIndex )
    {
        if ( declIndex.sort() == ifc::DeclSort::Scope )
        {
            DeclIndex = declIndex;
            Name = Query( reader, declIndex ).identity( &ifc::symbolic::ScopeDecl::identity );
            return true;
        }
        else
        {
            print( "TODO: ", declIndex.sort() );
            assert( false );
            //return extract( reader, designated.index );
        }

        return false;
    }

    [[nodiscard]] bool extract( const ifc::Reader& reader, const ifc::TypeIndex nonSyntacticTypeIndex )
    {
        Query query( reader, nonSyntacticTypeIndex );
        if ( const auto designated = query.tryGet( &ifc::symbolic::DesignatedType::decl ) )
        {
            return extract( reader, designated.index );
        }

        print( "TODO: ", nonSyntacticTypeIndex.sort() );
        assert( false );
        return false;
    }
};

struct TemplatedAliasType
{
    ifc::DeclIndex TemplateDeclIndex{};
    std::string_view AliasName{};
    FlatTemplateArgumentList Arguments{}; // mixed list of types and parameters
    size_t TemplateArgumentCount{}; // less or equal than the number of Arguments

    void extractAlias( const ifc::Reader& reader, const ifc::DeclIndex aliasIndex )
    {
        const auto alias = reader.get<ifc::symbolic::AliasDecl>( aliasIndex );
        const auto forall = reader.get<ifc::symbolic::ForallType>( alias.aliasee );

        AliasName = getStringView( reader, alias.identity );
        TemplateArgumentCount = gsl::narrow_cast<size_t>( reader.get<ifc::symbolic::UnilevelChart>( forall.chart ).cardinality ); // parameter information is lost

        const auto aliasedTemplateExpr = Query( reader, forall.subject )
            .get( &ifc::symbolic::SyntacticType::expr )
            .get<ifc::symbolic::TemplateIdExpr>();

        const auto aliasedTemplateDecl = Query( reader, aliasedTemplateExpr.primary_template )
            .get( &ifc::symbolic::NamedDeclExpr::decl );

        TemplateDeclIndex = aliasedTemplateDecl.index;
        Arguments.extract( reader, aliasedTemplateExpr.arguments );
    }
};

struct TemplatedStructType;

using TemplateArgument = std::variant<ifc::DeclIndex, TemplatedStructType>;

struct TemplatedStructType
{
    ifc::DeclIndex TemplateDeclIndex{};
    std::optional<std::string_view> AliasName{};
    FlatTemplateArgumentList Arguments{};
    std::string_view TemplateBaseName{}; // name without arguments

    [[nodiscard]] bool extract( const ifc::Reader& reader, const ifc::TypeIndex syntacticTypeIndex )
    {
        const auto& templateIdExpr = Query( reader, syntacticTypeIndex )
            .get( &ifc::symbolic::SyntacticType::expr ).get<ifc::symbolic::TemplateIdExpr>();

        // const auto name = getSyntacticTemplateName( reader, templateIdExpr.primary_template ); // for debugging

        const auto templateOrAlias = Query( reader, templateIdExpr.primary_template ).get( &ifc::symbolic::NamedDeclExpr::decl );

        ifc::DeclIndex templateIndex{};
        if ( templateOrAlias.index.sort() == ifc::DeclSort::Template )
        {
            TemplateDeclIndex = templateOrAlias.index;
            Arguments.extract( reader, templateIdExpr.arguments );
        }
        else if ( templateOrAlias.index.sort() == ifc::DeclSort::Alias )
        {
            TemplatedAliasType templatedAlias;
            templatedAlias.extractAlias( reader, templateOrAlias.index );

            AliasName = templatedAlias.AliasName;
            TemplateDeclIndex = templatedAlias.TemplateDeclIndex;

            FlatTemplateArgumentList localArgs;
            localArgs.extract( reader, templateIdExpr.arguments );

            // merge the local arguments with the arguments from the alias
            std::vector<ifc::ExprIndex> mergedExprs;

            const auto& aliasArgs = templatedAlias.Arguments;

            if ( localArgs.exprs.size() != templatedAlias.TemplateArgumentCount )
            {
                assert( localArgs.exprs.size() < templatedAlias.TemplateArgumentCount ); // logic error on assert
                assert( localArgs.exprs.size() != templatedAlias.TemplateArgumentCount ); // not a TemplatedStructType because not all arguments are provided
                return false;
            }

            mergedExprs.resize( aliasArgs.exprs.size() );

            // find the template arguments of the alias
            size_t parametersFound = 0; // for validation
            for ( size_t i = 0; i < aliasArgs.exprs.size(); ++i )
            {
                const auto parameterOpt = Query( reader, aliasArgs.exprs[i] )
                    .tryGet( &ifc::symbolic::TypeExpr::denotation )
                    .tryGet( &ifc::symbolic::DesignatedType::decl )
                    .tryGet<ifc::symbolic::ParameterDecl>();

                if ( parameterOpt )
                {
                    ++parametersFound;
                    const ifc::symbolic::ParameterDecl& parameter = parameterOpt.value();
                    assert( parameter.position - 1 == i ); // assume parameters are in order
                    mergedExprs[i] = localArgs.exprs.at( parameter.position - 1 );
                }
                else
                {
                    mergedExprs[i] = aliasArgs.exprs[i];
                }
            }

            Arguments = FlatTemplateArgumentList{ mergedExprs };

            assert( parametersFound == templatedAlias.TemplateArgumentCount ); // ensure all ParameterDecls have been found
        }
        else
        {
            return false;
        }

        TemplateBaseName = getStringView( reader, reader.get<ifc::symbolic::TemplateDecl>( TemplateDeclIndex ).identity );
        return true;
    }
};

std::string_view getTypeForFieldFromTemplateArgument( const ifc::Reader& reader, const ifc::ExprIndex exprIndex )
{
    // the exprIndex comes from a FlatTemplateArgumentList and should only contain TypeExpr/NamedDeclExpr/LiteralExpr
    Query query( reader, exprIndex );

    if ( const auto denotation = query.tryGet( &ifc::symbolic::TypeExpr::denotation ) )
    {
        if ( const auto designated = denotation.tryGet( &ifc::symbolic::DesignatedType::decl ) )
        {
            if ( designated.index.sort() == ifc::DeclSort::Scope or designated.index.sort() == ifc::DeclSort::Enumeration )
            {
                return designated.value()
                    .either( &ifc::symbolic::ScopeDecl::identity, &ifc::symbolic::EnumerationDecl::identity )
                    .visit( getStringView );
            }
            else if ( designated.index.sort() == ifc::DeclSort::Alias )
            {
                // TODO? implement proper alias lookup

                const auto& alias = designated.value().get<ifc::symbolic::AliasDecl>();
                if ( alias.aliasee.sort() == ifc::TypeSort::Fundamental )
                {
                    // e.g. uint64_t
                    return getStringView( reader, alias.identity );
                }
                else
                {
                    const auto aliasName = getStringView( reader, alias.identity );
                    print( "alias: ", alias.aliasee.sort() );
                    assert( false ); // remove?
                    return aliasName; // return alias name or recursion?
                }
            }

            print( "TODO: designated: ", designated.index.sort() );
            assert( false );
        }
        else if ( denotation.index.sort() == ifc::TypeSort::Syntactic )
        {
            TemplatedStructType templatedStructType;
            if ( not templatedStructType.extract( reader, denotation.index ) )
            {
                assert( false );
            }

            assert( not templatedStructType.AliasName.has_value() ); // not implemented (need merging as implemented elsewhere)

            if ( templatedStructType.Arguments.exprs.empty() )
            {
                return templatedStructType.TemplateBaseName;
            }

            std::string fullTypeName( templatedStructType.TemplateBaseName );
            fullTypeName += '<';
            for ( size_t i = 0; i < templatedStructType.Arguments.exprs.size(); ++i )
            {
                // XXX recursion here initially not intended -> rename function?
                fullTypeName += getTypeForFieldFromTemplateArgument( reader, templatedStructType.Arguments.exprs[i] );
                if ( i != templatedStructType.Arguments.exprs.size() - 1 )
                {
                    fullTypeName += ", ";
                }
            }
            fullTypeName += '>';

            return registerString( fullTypeName );
        }

        print( "TODO: denotation: ", denotation.index.sort() );
        assert( false );
    }

    print( "TODO: not denotation: ", exprIndex.sort() );
    assert( false );
    return "### ? ###"; // TODO
}

const ifc::symbolic::FundamentalType& getTypeForBitfield( const ifc::Reader& reader, const ifc::TypeIndex bitfieldDeclType );

const ifc::symbolic::FundamentalType& getTypeForBitfield( const ifc::Reader& reader, const ifc::DeclIndex declIndex )
{
    Query query( reader, declIndex );
    if ( const auto result = query.tryGet<ifc::symbolic::AliasDecl>() )
    {
        return getTypeForBitfield( reader, result.value().aliasee );
    }

    print( "TODO: ", declIndex.sort() );
    throw std::runtime_error( "Failed to find bitfield type" );
}

const ifc::symbolic::FundamentalType& getTypeForBitfield( const ifc::Reader& reader, const ifc::TypeIndex bitfieldDeclType )
{
    Query query( reader, bitfieldDeclType );
    if ( const auto result = query.tryGet<ifc::symbolic::FundamentalType>() )
    {
        return result.value();
    }

    if ( const auto result = query.tryGet<ifc::symbolic::DesignatedType>() )
    {
        return getTypeForBitfield( reader, result.value().decl );
    }

    print( "TODO: ", bitfieldDeclType.sort() );
    throw std::runtime_error( "Failed to find bitfield type" );
}

class StructInfo;

class StructInfo : public InfoBaseT<ifc::symbolic::ScopeDecl, InfoBaseType::Struct>
{
public:
    using InfoBaseT::InfoBaseT;

    std::optional<std::string_view> primitiveTypeNameCS( const std::string& typeName ) const
    {
        static const std::unordered_map<std::string, std::string_view> mapping = {
            //{ "bool", "bool" }, // bool has 4 bytes
            //{ "Bool", "bool" }, // TODO: requires [MarshalAs(UnmanagedType.U1)] until then: use byte
            { "bool", "byte" },
            { "Bool", "byte" },
            { "uint8_t", "byte" },
            { "uint16_t", "ushort" },
            { "uint32_t", "uint" },
            { "uint64_t", "ulong" },
            { "Double", "Double" },
            { "basic_string_view<Char, char_traits<Char>>", "string" }
        };

        if ( const auto foundIt = mapping.find( typeName ); foundIt != mapping.end() )
        {
            return foundIt->second;
        }

        return {};
    }

    bool reservedTypeNameCS( const std::string_view& typeName ) const
    {
        static const std::set<std::string_view> reserved = {
            "string", "base"
        };

        return reserved.contains( typeName );
    }

    struct EnumerationIndexAndName
    {
        ifc::DeclIndex index{};
        std::string_view name{};
    };

    struct EnumeratorIndexAndName
    {
        EnumerationIndexAndName parent{};
        ifc::DeclIndex index{};
        std::string_view name{};
    };

    struct StructIndexAndName
    {
        ifc::DeclIndex index{};
        std::string_view name{};
    };

    struct SpecialBaseTypes
    {
        std::optional<EnumerationIndexAndName> Over;
        std::optional<EnumeratorIndexAndName> Tag;
        std::optional<std::tuple<StructIndexAndName, std::optional<EnumeratorIndexAndName>>> Sequence;
        std::vector<std::tuple<std::string_view, std::string_view>> MembersToInline; // XXX no type, only name

        EnumerationIndexAndName extractEnumerationIndexAndName( const ifc::Reader& reader, const ifc::ExprIndex expr )
        {
            const auto tagArgTypeDecl = Query( reader, expr )
                .get( &ifc::symbolic::TypeExpr::denotation )
                .get( &ifc::symbolic::DesignatedType::decl );

            const auto tagArgTypeName = tagArgTypeDecl.identity( &ifc::symbolic::EnumerationDecl::identity );

            return { tagArgTypeDecl.index, tagArgTypeName };
        }

        EnumeratorIndexAndName extractEnumeratorIndexAndName( const ifc::Reader& reader, const ifc::ExprIndex expr )
        {
            const auto& tagArgNamedDeclExpr = reader.get<ifc::symbolic::NamedDeclExpr>( expr );

            const auto tagArgTypeDecl = Query( reader, tagArgNamedDeclExpr.type )
                .get( &ifc::symbolic::DesignatedType::decl );

            const auto tagArgTypeName = tagArgTypeDecl.identity( &ifc::symbolic::EnumerationDecl::identity );

            const auto tagArgEnumeratorName = Query( reader, tagArgNamedDeclExpr.decl )
                .identity( &ifc::symbolic::EnumeratorDecl::identity );

            return { { tagArgTypeDecl.index, tagArgTypeName }, tagArgNamedDeclExpr.decl, tagArgEnumeratorName };
        }

        StructIndexAndName extractSequenceType( const ifc::Reader& reader, const ifc::ExprIndex expr )
        {
            const auto tagArgTypeDecl = Query( reader, expr )
                .get( &ifc::symbolic::TypeExpr::denotation )
                .get( &ifc::symbolic::DesignatedType::decl );

            const auto tagArgTypeName = tagArgTypeDecl.identity( &ifc::symbolic::ScopeDecl::identity );

            return { tagArgTypeDecl.index, tagArgTypeName };
        }

        void collect( const ifc::Reader& reader, const std::unordered_map<ifc::DeclIndex, InfoBaseRef>& infoByIndex, const ifc::symbolic::BaseType& baseType )
        {
            if ( baseType.type.sort() != ifc::TypeSort::Syntactic )
            {
                UntemplatedStructType untemplatedStructType;
                const auto success = untemplatedStructType.extract( reader, baseType.type );
                assert( success );

                MembersToInline.emplace_back( untemplatedStructType.Name, untemplatedStructType.Name ); // XXX possible name collision
                return;
            }
            else
            {
                TemplatedStructType templatedStructType;
                if ( not templatedStructType.extract( reader, baseType.type ) )
                {
                    assert( false );
                }

                const auto foundIt = infoByIndex.find( templatedStructType.TemplateDeclIndex );
                if ( foundIt == infoByIndex.end() or foundIt->second.get().type() != InfoBaseType::Template )
                {
                    const auto templateName = Query( reader, templatedStructType.TemplateDeclIndex )
                        .identity<ifc::symbolic::TemplateDecl>( &ifc::symbolic::TemplateDecl::identity );

                    if ( templateName == "Over" )
                    {
                        // special handling: Over is in index_like which is currently ignored
                        Over.emplace( extractEnumerationIndexAndName( reader, templatedStructType.Arguments.exprs.at( 0 ) ) );
                    }
                    else
                    {
                        assert( false );
                    }
                }
                else
                {
                    const auto& templateInfo = foundIt->second.get().as<TemplateInfo>();
                    const auto templateName = templateInfo.name();

                    if ( templateInfo.fields().empty() )
                    {
                        if ( templateName == "Tag" or templateName == "TraitTag" or templateName == "Location" or templateName == "LocationAndType" )
                        {
                            Tag.emplace( extractEnumeratorIndexAndName( reader, templatedStructType.Arguments.exprs.at( 0 ) ) ); // TODO: differentiate between Tag and TraitTag
                        }
                        else
                        {
                            if ( templateName == "constant_traits" )
                            {
                                // TODO emit tag?
                            }
                            else
                            {
                                assert( false ); // new type?
                            }
                        }
                    }
                    else
                    {
                        // TODO: emit templates so that they don't need to be inlined
                        const auto templateArgs = templatedStructType.Arguments.exprs;
                        for ( const auto& field : templateInfo.fields() )
                        {
                            if ( field.ParameterIndex.has_value() )
                            {
                                const auto& argExpr = templateArgs.at( field.ParameterIndex.value() ); // XXX unsure about ordering/indexing
                                const auto typeName = getTypeForFieldFromTemplateArgument( reader, argExpr );
                                MembersToInline.emplace_back( typeName, field.FieldName );
                            }
                            else
                            {
                                MembersToInline.emplace_back( registerString( field.TypeName ), field.FieldName );
                            }
                        }

                        //constexpr std::string_view nameTodo = "TODO_Name_Of_Template";
                        //MembersToInline.emplace_back( templateInfo.name(), nameTodo ); // XXX possible name collision
                    }
                }
            }

#if 0
            const auto& templateIdExpr = Query( reader, baseType.type )
                .get( &ifc::symbolic::SyntacticType::expr ).get<ifc::symbolic::TemplateIdExpr>();

            const auto name = getSyntacticTemplateName( reader, templateIdExpr.primary_template );

            const auto templateOrAlias = Query( reader, templateIdExpr.primary_template ).get( &ifc::symbolic::NamedDeclExpr::decl );

            bool inlineMembers = true; // XXX default false

            // XXX: variant with string_view is used for primitive types as a shortcut because there is no InfoBase object for them.
            std::unordered_map<size_t, std::variant<std::string_view, InfoBaseRef>> materializedFields;

            ifc::DeclIndex templateIndex{};
            if ( templateOrAlias.index.sort() == ifc::DeclSort::Template )
            {
                templateIndex = templateOrAlias.index;
            }
            else if ( templateOrAlias.index.sort() == ifc::DeclSort::Alias )
            {
                const auto forall = templateOrAlias
                    .get( &ifc::symbolic::AliasDecl::aliasee )
                    .get<ifc::symbolic::ForallType>();

                const auto& chart = reader.get<ifc::symbolic::UnilevelChart>( forall.chart );

                const auto aliasedTemplateExpr = Query( reader, forall.subject )
                    .get( &ifc::symbolic::SyntacticType::expr )
                    .get<ifc::symbolic::TemplateIdExpr>();

                const auto aliasedTemplateDecl = Query( reader, aliasedTemplateExpr.primary_template )
                    .get( &ifc::symbolic::NamedDeclExpr::decl );

                const auto aliasedTemplateInfoIt = infoByIndex.find( aliasedTemplateDecl.index );
                if ( aliasedTemplateInfoIt == infoByIndex.end() )
                {
                    throw "TODO";
                }

                const auto& aliasedTemplateInfo = dynamic_cast<const TemplateInfo&>( aliasedTemplateInfoIt->second.get() );

                const auto tuple = Query( reader, aliasedTemplateExpr.arguments ).sequence<ifc::symbolic::TupleExpr>(); // TODO: use FlatTemplateArgumentList
                assert( aliasedTemplateInfo.argumentCount() == tuple.span.size() );

                size_t currentTupleIndex = 0;
                for ( const auto& argument : tuple.span )
                {
                    const auto argTypeIndex = Query( reader, argument ).get( &ifc::symbolic::TypeExpr::denotation ).get( &ifc::symbolic::DesignatedType::decl );
                    if ( argTypeIndex.index.sort() == ifc::DeclSort::Parameter )
                    {
                        // nothing to do

                        //const auto& param = argTypeIndex.get<ifc::symbolic::ParameterDecl>();
                        //const auto paramName = getStringView( reader, param.identity );
                        //std::cout << paramName << std::endl;
                    }
                    else if ( argTypeIndex.index.sort() == ifc::DeclSort::Scope )
                    {
                        const auto foundIt = infoByIndex.find( argTypeIndex.index );
                        if ( foundIt == infoByIndex.end() )
                        {
                            const auto argTypeIndexName = argTypeIndex.identity( &ifc::symbolic::ScopeDecl::identity );
                            throw std::runtime_error( "Type in alias not found: " + std::string( argTypeIndexName ) );
                        }

                        materializedFields.emplace( currentTupleIndex, foundIt->second );
                    }
                    else
                    {
                        assert( false ); // TODO: e.g. Enum
                    }

                    ++currentTupleIndex;
                }

                std::cout << "";

                const auto aliasedTemplate = Query( reader, aliasedTemplateExpr.primary_template )
                    .get( &ifc::symbolic::NamedDeclExpr::decl );

                templateIndex = aliasedTemplate.index;
                //auto tn = getTypeName( reader, reader.get<ifc::symbolic::AliasDecl>( namedDecl.index ).aliasee );
                std::cout << "";
            }

            if ( templateIndex.sort() == ifc::DeclSort::Template )
            {
                const Query query( reader, templateIndex );
                const auto templateName = query.identity<ifc::symbolic::TemplateDecl>( &ifc::symbolic::TemplateDecl::identity );

                if ( templateName == "Over" )
                {
                    // special handling: Over is in index_like which is currently ignored
                    Over.emplace( extractEnumerationIndexAndName( reader, templateIdExpr.arguments ) );
                }
                else
                {
                    const auto templateInfoIt = infoByIndex.find( query.index );
                    if ( templateInfoIt == infoByIndex.end() )
                    {
                        // new type? might require special handling; see handling of "Over"
                        throw std::runtime_error( "Template not found: " + std::string( templateName ) );
                    }

                    const auto& templateInfo = dynamic_cast<const TemplateInfo&>( templateInfoIt->second.get() );

                    FlatTemplateArgumentList flatArgs;
                    flatArgs.extract( reader, templateIdExpr.arguments );

                    if ( templateInfo.name() == "Sequence" )
                    {
                        std::cout << "";
                    }

                    flatArgs.visit( reader, overloaded //
                        {
                            [&]( const ifc::ExprIndex, const ifc::symbolic::TypeExpr& typeExpr, const size_t argIndex ) //
                            {
                                if ( typeExpr.denotation.sort() == ifc::TypeSort::Syntactic )
                                {
                                    const auto primaryTemplate = Query( reader, typeExpr.denotation )
                                        .get( &ifc::symbolic::SyntacticType::expr ).get( &ifc::symbolic::TemplateIdExpr::primary_template );
                                    const auto syntacticName = getSyntacticTemplateName( reader, primaryTemplate.index ); // XXX: shortcut - need recursion
                                    const auto insertionResult = materializedFields.emplace( argIndex, syntacticName );
                                    assert( insertionResult.second ); // should not be present already
                                    return;
                                }

                                const auto argTypeDeclIndex = Query( reader, typeExpr.denotation ).get( &ifc::symbolic::DesignatedType::decl );
                                if ( argTypeDeclIndex.index.sort() == ifc::DeclSort::Scope or argTypeDeclIndex.index.sort() == ifc::DeclSort::Enumeration )
                                {
                                    const auto foundIt = infoByIndex.find( argTypeDeclIndex.index );
                                    if ( foundIt == infoByIndex.end() )
                                    {
                                        const auto name = argTypeDeclIndex
                                            .either( &ifc::symbolic::ScopeDecl::identity, &ifc::symbolic::EnumerationDecl::identity )
                                            .visit( getStringView );

                                        throw std::runtime_error( "Type in template argument not found: " + std::string( name ) );
                                    }

                                    const auto insertionResult = materializedFields.emplace( argIndex, foundIt->second );
                                    assert( insertionResult.second ); // should not be present already
                                }
                                else if ( argTypeDeclIndex.index.sort() == ifc::DeclSort::Alias )
                                {
                                    // TODO? implement proper alias lookup

                                    const auto& alias = argTypeDeclIndex.get<ifc::symbolic::AliasDecl>();
                                    if ( alias.aliasee.sort() == ifc::TypeSort::Fundamental )
                                    {
                                        // e.g. uint64_t
                                        const auto insertionResult = materializedFields.emplace( argIndex, getStringView( reader, alias.identity ) );
                                        assert( insertionResult.second ); // should not be present already
                                    }
                                    else
                                    {
                                        const auto aliasName = getStringView( reader, alias.identity );
                                        print( "alias: ", alias.aliasee.sort() );
                                        assert( false );
                                    }
                                }
                                else
                                {
                                    print( "argTypeDeclIndex: ", argTypeDeclIndex.index.sort() );
                                    assert( false );
                                }
                            },

                            [&]( const ifc::ExprIndex, const ifc::symbolic::NamedDeclExpr& namedDecl, const size_t ) //
                            {
                                if ( namedDecl.decl.sort() == ifc::DeclSort::Enumerator )
                                {
                                    // TODO: emit SequenceTag attribute (see HeapSort::Type argument @ TupleType)
                                }
                                else
                                {
                                    print( "namedDecl: ", namedDecl.decl.sort() );
                                    assert( false ); // required?
                                }
                            },

                            [&]( const ifc::ExprIndex, const ifc::symbolic::LiteralExpr&, const size_t ) //
                            {
                                assert( false ); // required?
                            }
                        } );

                    if ( templateInfo.name() == "Sequence" )
                    {
                        const auto tuple = Query( reader, templateIdExpr.arguments ).sequence<ifc::symbolic::TupleExpr>();

                        if ( tuple.span.size() == 2 )
                        {
                            const auto enumeratorIndex = tuple[1].get( &ifc::symbolic::PackedTemplateArgumentsExpr::arguments ).index;
                            std::optional<EnumeratorIndexAndName> enumerator;
                            if ( enumeratorIndex.sort() != ifc::ExprSort::Empty )
                            {
                                enumerator = extractEnumeratorIndexAndName( reader, enumeratorIndex );
                            }

                            Sequence.emplace( extractSequenceType( reader, tuple.span[0] ), enumerator );
                        }
                        else
                        {
                            assert( false );
                        }
                    }
                    else if ( name == "Tag" or name == "TraitTag" or name == "Location" or name == "LocationAndType" )
                    {
                        Tag.emplace( extractEnumeratorIndexAndName( reader, templateIdExpr.arguments ) ); // TODO: differentiate between Tag and TraitTag
                    }
                    else if ( name == "constant_traits" or name == "AssociatedTrait" or name == "AttributeAssociation" )
                    {
                        // nothing to do
                    }
                    else
                    {
                        assert( false );
                    }

                    if ( inlineMembers ) // may not be required if all types are emitted
                    {
                        for ( const auto& field : templateInfo.fields() )
                        {
                            if ( field.ParameterIndex.has_value() )
                            {
                                const auto foundIt = materializedFields.find( field.ParameterIndex.value() );
                                if ( foundIt != materializedFields.end() )
                                {
                                    const auto memberTypeName = std::visit( overloaded{
                                        []( const std::string_view str ) { return str; },
                                        []( const InfoBase& infoBase ) { return infoBase.name(); },
                                        }, foundIt->second );
                                    MembersToInline.emplace_back( memberTypeName, field.FieldName );
                                }
                                else
                                {
                                    bool isGeneric = true;
                                    assert( false ); // currently not required?
                                }
                            }
                            else
                            {
                                MembersToInline.emplace_back( field.TypeName, field.FieldName );
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                assert( false );
            }
#endif
        }

        void collect( const ifc::Reader& reader, const std::unordered_map<ifc::DeclIndex, InfoBaseRef>& infoByIndex, const ifc::symbolic::TupleType& tupleType )
        {
            for ( const auto& base : reader.sequence( tupleType ) )
            {
                collect( reader, infoByIndex, reader.get<ifc::symbolic::BaseType>( base ) );
            }
        }

        void collect( const ifc::Reader& reader, const std::unordered_map<ifc::DeclIndex, InfoBaseRef>& infoByIndex, ifc::TypeIndex baseIndex )
        {
            if ( baseIndex.sort() == ifc::TypeSort::Base )
            {
                collect( reader, infoByIndex, reader.get<ifc::symbolic::BaseType>( baseIndex ) );
            }
            else if ( baseIndex.sort() == ifc::TypeSort::Tuple )
            {
                collect( reader, infoByIndex, reader.get<ifc::symbolic::TupleType>( baseIndex ) );
            }
            else
            {
                assert( false );
            }
        }
    };

    void writeCS( std::ostream& os,
        std::set<ifc::DeclIndex>& structsForSizeValidation,
        const std::unordered_map<ifc::DeclIndex, std::vector<std::string_view>>& namesByIndex,
        const std::unordered_map<ifc::DeclIndex, InfoBaseRef>& infoByIndex,
        const std::function<std::span<std::string_view>( const StructInfo& referer, const InfoBase& referee )> getRefereeQualifier,
        const std::function<void( std::ostream& )> writeNested ) const
    {
        auto& reader = mReader.get();

        std::set<std::tuple<std::string, size_t>> inlineArrays;
        SpecialBaseTypes baseTypes;

        if ( not index_like::null( decl().base ) )
        {
            baseTypes.collect( reader, infoByIndex, decl().base );

            if ( baseTypes.Over.has_value() )
            {
                os << "[Over<" << baseTypes.Over.value().name << ">]" << std::endl;
            }

            if ( baseTypes.Tag.has_value() )
            {
                const auto& tag = baseTypes.Tag.value();
                os << "[Tag<" << tag.parent.name << ">(" << tag.parent.name << '.' << tag.name << ")]" << std::endl;
            }
        }

        const bool isReadonlyStruct = mName != "TableOfContents";

        os << "public ";
        if ( isReadonlyStruct )
        {
            os << "readonly ";
        }
        os << "struct " << mName;

        structsForSizeValidation.insert( mIndex );

        bool insertStaticSortGetter = false;
        if ( baseTypes.Tag.has_value() )
        {
            insertStaticSortGetter = true;
            os << " : StructFromSpanTest.IHasSort<" << baseTypes.Tag.value().parent.name << '>';
        }

        os << std::endl << "{" << std::endl;

        if ( insertStaticSortGetter )
        {
            os << "    public static int Sort => (int)" << baseTypes.Tag.value().parent.name << '.' << baseTypes.Tag.value().name << ";" << std::endl << std::endl;
        }

        if ( writeNested )
        {
            writeNested( os );
        }

        if ( baseTypes.Over.has_value() ) // XXX: assumed to be the first base
        {
            os << "    public readonly uint IndexAndSort;" << std::endl;
        }

        for ( const auto& member : baseTypes.MembersToInline )
        {
            os << "    public ";
            if ( isReadonlyStruct )
            {
                os << "readonly ";
            }
            os << std::get<0>( member ) << ' ' << std::get<1>( member ) << ';' << std::endl;;
        }

        struct BitfieldMember
        {
            std::string_view fieldName{};
            std::string_view typeName{};
            size_t width{};
            size_t shift{}; // # of unused bits to the right
            std::string_view bitfieldFieldName{}; // + "_bitfield" suffix
        };

        struct BitfieldTracker
        {
            std::vector<BitfieldMember> fields;
            ifc::symbolic::FundamentalType currentType{};
            size_t currentRemainingBits{};
            std::string_view currentBitfieldFieldName{}; // + "_bitfield" suffix
        } bitfieldTracker{};

        if ( const auto* initScope = reader.try_get( decl().initializer ); initScope and not baseTypes.Sequence.has_value() ) // TODO: sequence is currently inlined
        {
            for ( const auto& innerDeclaration : reader.sequence( *initScope ) )
            {
                if ( innerDeclaration.index.sort() == ifc::DeclSort::Field )
                {
                    bitfieldTracker.currentType = {};
                    bitfieldTracker.currentRemainingBits = 0;
                    bitfieldTracker.currentBitfieldFieldName = {};

                    os << "    public ";
                    if ( isReadonlyStruct )
                    {
                        os << "readonly ";
                    }

                    const auto& innerDecl = reader.get<ifc::symbolic::FieldDecl>( innerDeclaration.index );
                    const std::string typeName = getTypeName( mReader, innerDecl.type );

                    assert( index_like::null( innerDecl.alignment ) );

                    bool isDesignated{};
                    bool found{};
                    ifc::DeclIndex refereeDecl{};
                    std::optional<std::string> translatedTypeName;
                    if ( innerDecl.type.sort() == ifc::TypeSort::Designated )
                    {
                        isDesignated = true;

                        refereeDecl = reader.get<ifc::symbolic::DesignatedType>( innerDecl.type ).decl;
                        if ( const auto foundIt = infoByIndex.find( refereeDecl ); foundIt != infoByIndex.end() )
                        {
                            const auto& qualifiers = getRefereeQualifier( *this, foundIt->second.get() );
                            for ( const auto& refereeQualifier : qualifiers )
                            {
                                os << refereeQualifier << "::";
                            }
                            found = true;
                        }
                    }
                    else if ( innerDecl.type.sort() == ifc::TypeSort::Array )
                    {
                        const auto arrayType = reader.get<ifc::symbolic::ArrayType>( innerDecl.type );
                        const auto bound = getLiteralValue( reader, arrayType.bound );

                        const auto arrayTypeName = getTypeName( reader, arrayType.element );
                        translatedTypeName = arrayTypeName + std::to_string( bound );

                        inlineArrays.emplace( arrayTypeName, bound );
                        found = true;
                    }
                    else if ( innerDecl.type.sort() == ifc::TypeSort::Syntactic )
                    {
                        const auto& templateIdExpr = Query( reader, innerDecl.type )
                            .get( &ifc::symbolic::SyntacticType::expr ).get<ifc::symbolic::TemplateIdExpr>();

                        const auto name = getSyntacticTemplateName( reader, templateIdExpr.primary_template );
                        if ( name == "array" )
                        {
                            const auto [bound, stdArraytypeName] = StdArrayArguments::extract( reader, templateIdExpr.arguments );
                            const auto arrayTypeName = std::string( primitiveTypeNameCS( std::string( stdArraytypeName ) ).value_or( stdArraytypeName ) );

                            translatedTypeName = arrayTypeName + std::to_string( bound );

                            inlineArrays.emplace( arrayTypeName, bound );
                            found = true;

                        }
                        else if ( name == "basic_string_view" )
                        {
                            translatedTypeName = "string";
                            found = true;
                        }
                        else if ( name == "Identity" or name == "Sequence" )
                        {
                            // nothing to do
                        }
                        else
                        {
                            assert( false ); // new type added?
                        }
                    }

                    if ( typeName == "Pathname" )
                    {
                        translatedTypeName = "string";
                    }

                    if ( not found )
                    {
                        translatedTypeName = primitiveTypeNameCS( typeName );
                        found = translatedTypeName.has_value();
                    }

                    const auto fieldName = getStringView( mReader, innerDecl.identity );
                    const bool escapeFieldName = reservedTypeNameCS( fieldName );

                    os << translatedTypeName.value_or( typeName ) << " ";
                    if ( escapeFieldName )
                    {
                        os << '@';
                    }
                    os << fieldName << ";";
                    if ( not isDesignated && not translatedTypeName.has_value() )
                    {
                        os << " // TODO verify";
                    }

                    if ( not found )
                    {
                        os << " // Type not found: " << typeName;
                    }

                    os << std::endl;
                }
                else if ( innerDeclaration.index.sort() == ifc::DeclSort::Bitfield )
                {
                    const auto name = mName; // debug

                    //Query query( reader, innerDeclaration.index ).map<ifc::symbolic::BitfieldDecl>();

                    const auto& [type, bitfield] = Query( reader, innerDeclaration.index ).getWithQuery( &ifc::symbolic::BitfieldDecl::type );

                    //const auto innerDecl = Query( reader, innerDeclaration.index ).map<ifc::symbolic::BitfieldDecl>();
                    const auto width = getLiteralValue( reader, bitfield.width );
                    const auto fieldName = getStringView( mReader, bitfield.identity );

                    assert( width > 0 );
                    assert( index_like::null( bitfield.initializer ) );

                    const auto& fundamentalType = getTypeForBitfield( reader, type.index );

                    assert( fundamentalType.sign == ifc::symbolic::TypeSign::Unsigned );

                    const auto fundamentalTypeName = fundamentalToCS( fundamentalType );

                    if ( width <= bitfieldTracker.currentRemainingBits && bitfieldTracker.currentType == fundamentalType )
                    {
                        // no new field required
                        bitfieldTracker.currentRemainingBits -= width;

                        os << "    // " << fundamentalTypeName << ' ' << fieldName << " (bitfield continuation)" << std::endl;

                        bitfieldTracker.fields.emplace_back(
                            fundamentalTypeName, fieldName, gsl::narrow_cast<size_t>( width ), bitfieldTracker.currentRemainingBits, bitfieldTracker.currentBitfieldFieldName
                        );
                    }
                    else
                    {
                        const auto typeWidth = fundamentalBitWidth( fundamentalType );
                        assert( width <= typeWidth );

                        bitfieldTracker.currentRemainingBits = typeWidth - width;
                        bitfieldTracker.currentType = fundamentalType;
                        bitfieldTracker.currentBitfieldFieldName = fieldName;

                        bitfieldTracker.fields.emplace_back(
                            fundamentalTypeName, fieldName, gsl::narrow_cast<size_t>( width ), bitfieldTracker.currentRemainingBits, fieldName
                        );

                        os << "    private ";
                        if ( isReadonlyStruct )
                        {
                            os << "readonly ";
                        }

                        os << fundamentalTypeName << ' ' << fieldName << "_bitfield;" << std::endl;
                    }

                    std::cout << "";
                }
                else
                {
                    // ignore other (e.g. Constructor)
                }
            }
        }
        else
        {
            assert( baseTypes.Sequence.has_value() );
        }

        for ( const auto& [typeName, fieldName, width, shift, containigFieldName] : bitfieldTracker.fields )
        {
            // TODO 64 bit and omit cast if bitfield type is equal to typeName
            os << "    public " << typeName << ' ' << fieldName << " => (" << typeName << ")((" << containigFieldName << "_bitfield >> " << shift << ") & 0b" << std::string( width, '1' ) << ");" << std::endl;
        }

        os << "}" << std::endl << std::endl;

        for ( const auto& [name, bound] : inlineArrays )
        {
            os << "[System.Runtime.CompilerServices.InlineArray(" << bound << ")]" << std::endl;
            os << "public struct " << name << bound << std::endl << '{' << std::endl;
            os << "    private " << name << ' ' << "_element;" << std::endl << '}' << std::endl;
        }
    }
};

void updateValidationData( const std::string& validationInputFile, const std::string& validationOutputFile )
{
    std::ostringstream os;

    auto ifc = ifchelper::IfcReader::loadFile( validationInputFile );
    auto& reader = ifc.reader();

    ScopeInfo scopeInfo;
    scopeInfo.collect( reader, true );
    scopeInfo.print( std::cout );


    constexpr std::string_view templateCode = R"(
namespace StructFromSpanTest
{
    internal static partial class IfcSizeValidation
    {
        static partial void ExecuteTest()
        {
            >
        }
    }
}
)";

    const std::span templateSpan{ templateCode };
    const auto insertionPosition = templateCode.find( '>' );
    const auto indentationCount = insertionPosition - templateCode.rfind( '\n', insertionPosition ) - 1;

    const std::string indent( indentationCount, ' ' );

    os.write( templateCode.data(), insertionPosition - indentationCount );

    const auto writeNamespaces = [&]( this const auto& self, const Scope& scope ) -> void {
        if ( scope.Parent.has_value() )
        {
            self( scope.Parent.value() );
        }

        os << scope.Name << '.';
    };

    const auto decls = reader.partition<ifc::symbolic::VariableDecl>();
    for ( const auto& decl : decls )
    {
        const auto& scope = scopeInfo.findOrAdd( reader, decl.home_scope );
        if ( scope.has_value() and scope.value().get().hasTopLevel( "ifc" ) )
        {
            const auto sizeName = std::string( getStringView( reader, decl.identity ) );
            if ( sizeName.ends_with( "Size" ) )
            {
                const auto typeName = sizeName.substr( 0, sizeName.size() - 4 );

                const auto value = getLiteralValue( reader, decl.initializer );

                os << indent << "AssertSize<";
                writeNamespaces( scope.value() );
                os << typeName << ">(" << value << ");" << std::endl;
            }
        }
    }

    const auto end = templateSpan.subspan( insertionPosition + 1 );
    os.write( end.data(), end.size() );
    os.flush();

    updateFileWithHash( validationOutputFile, os.str() );
}

template<class F>
concept StructFieldVisitor = std::invocable<F, ifc::DeclIndex, const ifc::symbolic::FieldDecl&> and std::invocable<F, ifc::DeclIndex, const ifc::symbolic::BitfieldDecl&>;

struct StructFieldEnumerator
{
    ifc::DeclIndex ScopeIndex{};

    template<StructFieldVisitor F>
    void visit( ifc::Reader& reader, F&& f )
    {
        const auto& scope = reader.get<ifc::symbolic::ScopeDecl>( ScopeIndex );

        if ( const auto* initScope = reader.try_get( scope.initializer ) )
        {
            for ( const auto& innerDeclaration : reader.sequence( *initScope ) )
            {
                if ( innerDeclaration.index.sort() == ifc::DeclSort::Field )
                {
                    f( innerDeclaration.index, reader.get<ifc::symbolic::FieldDecl>( innerDeclaration.index ) );
                }
                else if ( innerDeclaration.index.sort() == ifc::DeclSort::Bitfield )
                {
                    f( innerDeclaration.index, reader.get<ifc::symbolic::BitfieldDecl>( innerDeclaration.index ) );
                }
            }
        }
    }
};

bool isStructOrClass( const ifc::Reader& reader, const ifc::TypeIndex type )
{
    if ( type.sort() != ifc::TypeSort::Fundamental )
    {
        return false;
    }

    const auto& typeOfType = reader.get<ifc::symbolic::FundamentalType>( type );
    return typeOfType.basis == ifc::symbolic::TypeBasis::Class || typeOfType.basis == ifc::symbolic::TypeBasis::Struct;
}

int main() // TODO: unions and bitfields, LiteralReal pragma pack(push, 4), why byte must be used for of bool (bool as last member makes the structs bigger)
{
    const std::string ifcFile = R"(d:\.projects\.unsorted\2024\CppEnumString\IfcTestData\x64\Debug\IfcHeaderUnit.ixx.ifc)";
    const std::string validationInputFile = R"(d:\.projects\.unsorted\2024\CppEnumString\IfcTestData\x64\Debug\IfcSizeValidation.ixx.ifc)";
    const std::string validationOutputFile = R"(d:\.projects\.unsorted\2024\StructFromSpanTest\StructFromSpanTest\IfcSizeValidation_Generated.cs)";

    updateValidationData( validationInputFile, validationOutputFile );

    auto ifc = ifchelper::IfcReader::loadFile( ifcFile );
    auto& reader = ifc.reader();

    ScopeInfo scopeInfo;
    scopeInfo.collect( reader, true );
    scopeInfo.print( std::cout );

    struct ScopeContent
    {
        std::deque<EnumInfo> enums;
        std::deque<StructInfo> structs;
        std::deque<TemplateInfo> templates;
    };

    std::unordered_map<ifc::DeclIndex, ScopeContent> infoByScope;
    std::unordered_map<ifc::DeclIndex, std::vector<std::string_view>> namesByIndex;
    std::unordered_map<ifc::DeclIndex, InfoBaseRef> infoByIndex;

    const auto inIfcNamespace = []( const std::optional<ScopeRef>& scope ) {
        return scope.has_value() and scope.value().get().hasTopLevel( "ifc" );
    };

    const auto ignoreTypeByName = []( const InfoBase& info ) {
        static const std::set<std::string_view> excluded = {
            "Pathname", "InputIfc", "Reader", "NodeKey", "Node", "Loader", "UnexpectedVisitor", "Extension", "IfcArchMismatch", "IfcReadFailure", "InvalidPartitionName"
        };

        return info.name().starts_with( '?' ) or info.name().starts_with( '_' ) or info.name().starts_with( '<' ) or excluded.contains( info.name() );
    };

    const auto buildNameList = []( this const auto& self, const Scope& scope, std::vector<std::string_view>& list ) -> void {
        if ( scope.Parent.has_value() )
        {
            self( scope.Parent.value(), list );
        }

        list.emplace_back( scope.Name );
    };

    const auto templateDecls = reader.partition<ifc::symbolic::TemplateDecl>();
    for ( const auto& tdecl : templateDecls | std::views::filter( std::not_fn( isUnwrittenScope<ifc::symbolic::TemplateDecl> ) ) )
    {
        if ( isStructOrClass( reader, tdecl.type ) )
        {
            const auto& scope = scopeInfo.findOrAdd( reader, tdecl.home_scope );
            if ( inIfcNamespace( scope ) )
            {
                std::vector<TemplateInfo::TemplateField> fields;

                if ( getStringView( reader, tdecl.identity ) == "Sequence" )
                {
                    std::cout << "";
                }

                StructFieldEnumerator fieldEnumerator{ tdecl.entity.decl };
                fieldEnumerator.visit( reader, overloaded{
                    [&]( const ifc::DeclIndex, const ifc::symbolic::FieldDecl& field ) {
                        const auto fieldName = getStringView( reader, field.identity );

                        const auto& param = Query( reader, field.type ).tryGet( &ifc::symbolic::DesignatedType::decl ).tryGet<ifc::symbolic::ParameterDecl>();
                        if ( param.has_value() )
                        {
                            const auto paramName = getStringView( reader, param.value().get().identity );
                            fields.emplace_back( std::string( paramName ), fieldName, gsl::narrow_cast<size_t>( param.value().get().position - 1 ) );
                        }
                        else
                        {
                            const auto typeName = getTypeName( reader, field.type ); // TODO: don't use getTypeName
                            fields.emplace_back( typeName, fieldName, std::optional<size_t>{} );
                        }
                    },

                    []( const ifc::DeclIndex, const ifc::symbolic::BitfieldDecl& ) {} // TODO
                    } );

                const auto argumentCount = gsl::narrow_cast<size_t>( reader.get<ifc::symbolic::UnilevelChart>( tdecl.chart ).cardinality );

                const auto& templateInfo = infoByScope[scope->get().Index].templates.emplace_back( reader, tdecl, scope.value(), argumentCount, std::move( fields ) );
                infoByIndex.emplace( templateInfo.index(), templateInfo );
                auto& nameList = namesByIndex[templateInfo.index()];
                buildNameList( scope.value(), nameList );
            }
        }
    }

    const auto enumDecls = reader.partition<ifc::symbolic::EnumerationDecl>();
    for ( const auto& decl : enumDecls | std::views::filter( std::not_fn( isUnwrittenScope<ifc::symbolic::EnumerationDecl> ) ) )
    {
        const auto& scope = scopeInfo.findOrAdd( reader, decl.home_scope );
        if ( inIfcNamespace( scope ) )
        {
            const auto& enumInfo = infoByScope[scope->get().Index].enums.emplace_back( reader, decl, scope );
            infoByIndex.emplace( enumInfo.index(), enumInfo );
            auto& nameList = namesByIndex[enumInfo.index()];
            buildNameList( scope.value(), nameList );
        }
    }

    auto typeCount = 0;
    auto types = reader.partition<ifc::symbolic::ScopeDecl>();
    for ( const auto& decl : types | std::views::filter( std::not_fn( isUnwrittenScope<ifc::symbolic::ScopeDecl> ) ) )
    {
        if ( isStructOrClass( reader, decl.type ) )
        {
            const auto scope = scopeInfo.findOrAdd( reader, decl.home_scope );
            if ( inIfcNamespace( scope ) )
            {
                const auto& structInfo = infoByScope[scope->get().Index].structs.emplace_back( reader, decl, scope );
                infoByIndex.emplace( structInfo.index(), structInfo );
                auto& nameList = namesByIndex[structInfo.index()];
                buildNameList( scope.value(), nameList );
            }

            ++typeCount;
        }
    }

    // --

    struct AliasInfo
    {
        bool isInfoBase() const noexcept
        {
            return std::holds_alternative<InfoBaseRef>( mKnownType );
        }

        bool isTemplate() const noexcept
        {
            return isInfoBase() and infoBase().type() == InfoBaseType::Template;
        }

        const InfoBase& infoBase() const
        {
            return std::get<InfoBaseRef>( mKnownType );
        }

        std::string_view mName;
        std::variant<ifc::symbolic::TypeBasis, InfoBaseRef> mKnownType;
    };

    std::vector<AliasInfo> aliasInfos;

    const auto extractAlias = [&]( this const auto& self, const ifc::TypeIndex aliaseeIndex, const std::string_view name ) -> bool {
        Query aliasee( reader, aliaseeIndex );
        if ( const auto forall = aliasee.tryGet( &ifc::symbolic::ForallType::subject ) )
        {
            if ( const auto syntactic = forall.tryGet( &ifc::symbolic::SyntacticType::expr ) )
            {
                const auto aliasedTemplateExpr = syntactic.value().get<ifc::symbolic::TemplateIdExpr>();

                const auto aliasedTemplateDecl = Query( reader, aliasedTemplateExpr.primary_template )
                    .get( &ifc::symbolic::NamedDeclExpr::decl );

                if ( const auto knownType = infoByIndex.find( aliasedTemplateDecl.index ); knownType != infoByIndex.end() )
                {
                    aliasInfos.emplace_back( name, knownType->second );
                    return true;
                }
            }
            else
            {
                return self( forall.index, name ); // XXX type argument (ForallType::chart) information is lost
            }
        }
        else if ( const auto basis = aliasee.tryGet( &ifc::symbolic::FundamentalType::basis ) )
        {
            aliasInfos.emplace_back( name, basis.value() );
            return true;
        }

        return false;
    };

    auto aliases = reader.partition<ifc::symbolic::AliasDecl>();
    for ( const auto& decl : aliases )
    {
        if ( const auto scope = scopeInfo.find( decl.home_scope ); inIfcNamespace( scope ) )
        {
            if ( not extractAlias( decl.aliasee, getStringView( reader, decl.identity ) ) )
            {
                std::cout << "Ignoring unsupported alias of type " << to_string( decl.aliasee.sort() ) << ": " << getStringView( reader, decl.identity ) << std::endl;
            }
        }
    }

    // ---

    const auto getRefereeQualifier = [&]( const StructInfo& referer, const InfoBase& referee ) -> std::span<std::string_view> {
        if ( referer.scope() == referee.scope() || referer.index() == referee.scope().value().get().Index )
        {
            return {};
        }

        const std::span refererNames( namesByIndex.at( referer.index() ) );
        const std::span refereeNames( namesByIndex.at( referee.index() ) );
        const auto skipCount = std::ranges::distance( std::views::zip( refererNames, refereeNames )
            | std::views::take_while( []( const auto& t ) { return std::get<0>( t ) == std::get<1>( t ); } ) );
        return refereeNames.subspan( skipCount );
    };

    std::ostringstream osCode;

    osCode << "namespace ifc" << std::endl << '{' << std::endl;
    osCode << "public enum Index : uint { }" << std::endl << std::endl;

    osCode << "public class OverAttribute : Attribute { }" << std::endl << std::endl;
    osCode << "public class OverAttribute<T> : OverAttribute { }" << std::endl << std::endl;
    osCode << "public class TagAttribute : Attribute { }" << std::endl << std::endl;
    osCode << "public class TagAttribute<T>(T sort) : TagAttribute { }" << std::endl << std::endl;
    osCode << "public readonly struct Sequence<T> { public readonly Index start; public readonly Cardinality cardinality; }" << std::endl << std::endl;
    osCode << "public readonly struct Identity<T> { public readonly T name; public readonly symbolic.SourceLocation locus; }" << std::endl << std::endl;
    osCode << '}' << std::endl << std::endl;

    std::set<ifc::DeclIndex> namesForSizeValidation;

    const auto scopeVisitorWithNamespace = [&]( std::ostream& os, const std::function<void( const Scope&, const std::string& )>& f ) {
        int currentLevel = 0;
        scopeInfo.visit( [&]( const Scope& current, const size_t level, const std::string& qualifiedName, const bool enter ) {
            if ( not current.hasTopLevel( "ifc" ) ) return;

            if ( not enter )
            {
                os << '}' << std::endl << std::endl;
                --currentLevel;
                return;
            }

            if ( currentLevel < level )
            {
                assert( currentLevel + 1 == level );

                os << "namespace " << current.Name << std::endl << '{' << std::endl;
                ++currentLevel;
            }

            f( current, qualifiedName );
        } );
    };

    scopeVisitorWithNamespace( osCode, [&]( const Scope& current, const std::string& ) {
        if ( const auto foundIt = infoByScope.find( current.Index ); foundIt != infoByScope.end() )
        {
            for ( const auto& enumInfo : foundIt->second.enums | std::views::filter( std::not_fn( ignoreTypeByName ) ) )
            {
                if ( enumInfo.scope().value().get().IsNamespace )
                {
                    enumInfo.writeCS( osCode );
                }
            }

            for ( const auto& structInfo : foundIt->second.structs | std::views::filter( std::not_fn( ignoreTypeByName ) ) )
            {
                structInfo.writeCS( osCode, namesForSizeValidation, namesByIndex, infoByIndex, getRefereeQualifier, [&]( std::ostream& os ) {
                    // write nested
                    if ( const auto nestedIt = infoByScope.find( structInfo.index() ); nestedIt != infoByScope.end() )
                    {
                        for ( const auto& nestedEnumInfo : nestedIt->second.enums )
                        {
                            nestedEnumInfo.writeCS( os );
                        }

                        for ( const auto& nestedStructInfo : nestedIt->second.structs )
                        {
                            nestedStructInfo.writeCS( os, namesForSizeValidation, namesByIndex, infoByIndex, getRefereeQualifier, {} );
                        }
                    }
                } );
            }
        }
    } );

    std::cout << std::endl << std::string( 80, '=' ) << std::endl << std::endl;

    const std::string outputFile = R"(d:\.projects\.unsorted\2024\StructFromSpanTest\StructFromSpanTest\Ifc.cs)";
    if ( updateFileWithHash( outputFile, osCode.str() ) )
    {
        std::cout << "### Output file changed ###" << std::endl;
    }
    else
    {
        std::cout << "No change in output file" << std::endl;
    }

    // Generate validation code

    std::ostringstream osTest;

    osTest << "module;" << std::endl << std::endl;
    osTest << "#include <ifc/abstract-sgraph.hxx>" << std::endl << std::endl;
    osTest << "export module IfcSizeValidation;" << std::endl << std::endl;
    osTest << "export {" << std::endl;
    scopeVisitorWithNamespace( osTest, [&]( const Scope& current, const std::string& q ) {
        if ( const auto foundIt = infoByScope.find( current.Index ); foundIt != infoByScope.end() )
        {
            for ( const StructInfo& structInfo : foundIt->second.structs )
            {
                if ( const auto it = namesForSizeValidation.extract( structInfo.index() ); it )
                {
                    const auto name = infoByIndex.at( it.value() ).get().name();

                    osTest << "// " << current.Name << " - " << q << std::endl;
                    osTest << "constexpr inline size_t " << name << "Size = sizeof(" << name << ");" << std::endl;
                }
            }
        }
    } );
    osTest << '}' << std::endl; // close export

    const std::string testOutputFile = R"(d:\.projects\.unsorted\2024\CppEnumString\IfcTestData\IfcSizeValidation.ixx)";
    if ( updateFileWithHash( testOutputFile, osTest.str() ) )
    {
        std::cout << "### Test output file changed ###" << std::endl;
    }
    else
    {
        std::cout << "No change in test output file" << std::endl;
    }
}
