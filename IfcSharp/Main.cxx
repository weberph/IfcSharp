#include <algorithm>
#include <cassert>
#include <cstdlib>
#include <deque>
#include <filesystem>
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

#include <File.hxx>
#include <EnumToString.hxx>
#include <GetStringView.hxx>
#include <IfcReader.hxx>
#include <Query.hxx>

#include <ifc/reader.hxx>
#include <ifc/util.hxx>
#include <ifc/dom/node.hxx>
#include <ifc/index-utils.hxx>
#include <ifc/abstract-sgraph.hxx>

#include <gsl/span>

#pragma comment(lib, "bcrypt.lib")

#pragma warning( disable : 26440 ) // ... can be declared 'noexcept' (f.6).
#pragma warning( disable : 26446 ) // Prefer to use gsl::at() instead of unchecked subscript operator (bounds.4).

using namespace ifchelper;

template<index_like::Algebra T>
struct std::hash<T>
{
    std::size_t operator()( const T index ) const noexcept
    {
        return std::bit_cast<uint32_t>( index );
    }
};

template<>
struct std::hash<ifc::symbolic::FundamentalType>
{
    std::size_t operator()( const ifc::symbolic::FundamentalType fundamentalType ) const noexcept
    {
        return std::bit_cast<uint32_t>( fundamentalType );
    }
};

namespace
{
    // XXX workaround
    std::string_view registerString( std::string str )
    {
        static std::deque<std::string> gStringTable;

        return gStringTable.emplace_back( std::move( str ) );
    }

    template<index_like::MultiSorted T>
    void print( const std::string& prefix, const T t )
    {
        std::cout << prefix << ifchelper::to_string( t.sort() ) << std::endl;
    }

    template<class... Ts>
    struct overloaded : Ts...
    {
        using Ts::operator()...;
    };

    constexpr std::array<char, 16> HexChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

    template<class T, size_t Extent>
        requires ( sizeof( T ) == 1 )
    constexpr std::string toHex( const std::span<const T, Extent> span )
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

    std::string_view getIdentity( const ifc::Reader& reader, const ifc::DeclIndex declIndex )
    {
        const Query query( reader, declIndex );
        switch ( declIndex.sort() )
        {
            case ifc::DeclSort::Enumeration:
                return query.identity( &ifc::symbolic::EnumerationDecl::identity );

            case ifc::DeclSort::Scope:
                return query.identity( &ifc::symbolic::ScopeDecl::identity );

            case ifc::DeclSort::Alias:
                return query.identity( &ifc::symbolic::AliasDecl::identity );

            case ifc::DeclSort::Enumerator:
                return query.identity( &ifc::symbolic::EnumeratorDecl::identity );

            case ifc::DeclSort::Template:
                return query.identity<ifc::symbolic::TemplateDecl>( &ifc::symbolic::Template::identity );

            case ifc::DeclSort::Parameter:
                return query.identity( &ifc::symbolic::ParameterDecl::identity );

            case ifc::DeclSort::Bitfield:
                return query.identity( &ifc::symbolic::BitfieldDecl::identity );

            default:
                print( "getIdentity not implemented: ", declIndex );
                assert( false );
                break;
        }

        throw std::runtime_error( "getIdentity: DeclSort not implemented" );
    }

    int64_t getLiteralValue( const ifc::Reader& reader, const ifc::symbolic::LiteralExpr literalExpr )
    {
        switch ( literalExpr.value.sort() )
        {
            case ifc::LiteralSort::Immediate: return ifc::to_underlying( literalExpr.value.index() );
            case ifc::LiteralSort::Integer: return reader.get<int64_t>( literalExpr.value );
            default: throw std::runtime_error( "Unexpected literal type" );
        }
    }

    int64_t getLiteralValue( const ifc::Reader& reader, const ifc::ExprIndex literalExprIndex )
    {
        return getLiteralValue( reader, Query( reader, literalExprIndex ).get<ifc::symbolic::LiteralExpr>() );
    }

    struct Declarator;

    using TypeTemplateArgument = std::variant<Declarator, ifc::symbolic::LiteralExpr>;

    enum class ReferenceType
    {
        LValueReference, RValueReference
    };

    struct Declarator
    {
        std::variant<ifc::DeclIndex, ifc::symbolic::FundamentalType> type{};
        std::string_view identity{};
        std::vector<TypeTemplateArgument> templateArgs{};
        std::optional<size_t> arrayBound{};
        size_t indirections{};
        std::optional<ReferenceType> referenceType{};
        std::optional<ifc::DeclIndex> containingType{};
        size_t templateParamCount{};

        ifc::DeclIndex index() const
        {
            return std::get<ifc::DeclIndex>( type );
        }

        ifc::symbolic::FundamentalType fundamental() const
        {
            return std::get<ifc::symbolic::FundamentalType>( type );
        }

        bool isFundamental() const noexcept
        {
            return std::holds_alternative<ifc::symbolic::FundamentalType>( type );
        }
    };

    enum class AliasPolicy
    {
        Identity,
        Aliasee
    };

    class DeclaratorVisitor
    {
    public:
        explicit DeclaratorVisitor( const ifc::Reader& reader, const AliasPolicy aliasPolicy = AliasPolicy::Aliasee )
            : mReader( reader )
            , mAliasPolicy( aliasPolicy )
        {
        }

        static Declarator createDeclarator( const ifc::Reader& reader, const ifc::ExprIndex index )
        {
            DeclaratorVisitor visitor( reader );
            visitor.dispatchExprIndex( index );
            return visitor.declarator();
        }

        static Declarator createDeclarator( const ifc::Reader& reader, const ifc::TypeIndex index )
        {
            DeclaratorVisitor visitor( reader );
            visitor.dispatchTypeIndex( index );
            return visitor.declarator();
        }

        static std::vector<TypeTemplateArgument> getTypeArgumentList( const ifc::Reader& reader, const ifc::ExprIndex exprIndex )
        {
            return DeclaratorVisitor( reader ).getTypeArgumentList( exprIndex );
        }

        const Declarator& declarator() const noexcept
        {
            return mDeclarator;
        }

        void postConditions() const
        {
            assert( mDeclarator.isFundamental() || not index_like::null( mDeclarator.index() ) );
            assert( mDeclarator.isFundamental() || not mDeclarator.identity.empty() );
            assert( mDeclarator.templateParamCount == 0 );
        }

        void visitFundamental( const ifc::symbolic::FundamentalType fundamentalType )
        {
            mDeclarator.type = fundamentalType;
        }

        void visitDesignated( const ifc::symbolic::DesignatedType designatedType )
        {
            if ( mAliasPolicy == AliasPolicy::Aliasee && designatedType.decl.sort() == ifc::DeclSort::Alias )
            {
                visitAlias( query( designatedType.decl ).get<ifc::symbolic::AliasDecl>() );
            }
            else
            {
                mDeclarator.type = designatedType.decl;
                mDeclarator.identity = getIdentity( mReader, designatedType.decl );
            }

            postConditions();
        }

        void visitNamedDecl( const ifc::symbolic::NamedDeclExpr namedDeclExpr )
        {
            if ( mAliasPolicy == AliasPolicy::Aliasee && namedDeclExpr.decl.sort() == ifc::DeclSort::Alias )
            {
                visitAlias( query( namedDeclExpr.decl ).get<ifc::symbolic::AliasDecl>() );
            }
            else
            {
                mDeclarator.type = namedDeclExpr.decl;
                mDeclarator.identity = getIdentity( mReader, namedDeclExpr.decl );
            }

            if ( not index_like::null( namedDeclExpr.type ) )
            {
                DeclaratorVisitor containingTypeVisitor( mReader );
                containingTypeVisitor.dispatchTypeIndex( namedDeclExpr.type );
                mDeclarator.containingType = containingTypeVisitor.declarator().index();
            }

            postConditions();
        }

        std::optional<Declarator> currentAlias;
        void visitAlias( const ifc::symbolic::AliasDecl& aliasDecl )
        {
            assert( not currentAlias.has_value() );
            currentAlias = mDeclarator;
            mDeclarator = {};
            dispatchTypeIndex( aliasDecl.aliasee );
            currentAlias.reset();
        }

        void visitArray( const ifc::symbolic::ArrayType arrayType )
        {
            assert( arrayType.bound.sort() == ifc::ExprSort::Literal );

            mDeclarator.arrayBound = getLiteralValue( mReader, arrayType.bound );
            dispatchTypeIndex( arrayType.element );
        }

        void visitSyntactic( const ifc::symbolic::SyntacticType syntacticType )
        {
            assert( syntacticType.expr.sort() == ifc::ExprSort::TemplateId );

            const auto& templateIdExpr = query( syntacticType.expr ).get<ifc::symbolic::TemplateIdExpr>();

            assert( templateIdExpr.primary_template.sort() == ifc::ExprSort::NamedDecl );

            assert( mDeclarator.templateArgs.empty() );
            mDeclarator.templateArgs = getTypeArgumentList( templateIdExpr.arguments );

            visitNamedDecl( query( templateIdExpr.primary_template ).get<ifc::symbolic::NamedDeclExpr>() );
        }

        void visitForallType( const ifc::symbolic::ForallType forallType )
        {
            dispatchTypeIndex( forallType.subject );

            const auto& chart = query( forallType.chart ).get<ifc::symbolic::UnilevelChart>();
            mDeclarator.templateParamCount = gsl::narrow_cast<size_t>( chart.cardinality );

            if ( mDeclarator.templateParamCount > 0 )
            {
                assert( currentAlias.has_value() );

                const auto& outerArgs = currentAlias.value().templateArgs;
                const auto& aliasArgs = mDeclarator.templateArgs;

                assert( mDeclarator.templateParamCount <= outerArgs.size() );
                assert( mDeclarator.templateParamCount <= aliasArgs.size() );

                assert( outerArgs.size() == mDeclarator.templateParamCount ); // if this does not hold, we are probably visiting a template argument (not implemented)

                std::vector<TypeTemplateArgument> merged{};
                merged.resize( aliasArgs.size() );

                // find the template arguments of the alias
                size_t parametersFound = 0; // for validation
                for ( size_t i = 0; i < aliasArgs.size(); ++i )
                {
                    if ( not std::holds_alternative<ifc::symbolic::LiteralExpr>( aliasArgs[i] ) )
                    {
                        const auto& declarator = std::get<Declarator>( aliasArgs[i] );
                        if ( not declarator.isFundamental() )
                        {
                            if ( const auto& parameterDecl = query( declarator.index() ).tryGet<ifc::symbolic::ParameterDecl>() )
                            {
                                ++parametersFound;
                                const ifc::symbolic::ParameterDecl& parameter = parameterDecl.value();
                                assert( parameter.position - 1 == i ); // assume parameters are in order
                                merged[i] = outerArgs.at( gsl::narrow_cast<size_t>( parameter.position ) - 1 );
                                continue;
                            }
                        }
                    }

                    merged[i] = aliasArgs[i];
                }

                assert( mDeclarator.templateParamCount == parametersFound );
                mDeclarator.templateParamCount = 0;

                mDeclarator.templateArgs = merged;
            }
        }

        void dispatchTypeIndex( const ifc::TypeIndex typeIndex )
        {
            const ifc::Reader& reader = mReader;
            switch ( typeIndex.sort() )
            {
                case ifc::TypeSort::Designated:
                    visitDesignated( query( typeIndex ).get<ifc::symbolic::DesignatedType>() );
                    break;

                case ifc::TypeSort::Fundamental:
                    visitFundamental( reader.get<ifc::symbolic::FundamentalType>( typeIndex ) );
                    break;

                case ifc::TypeSort::Syntactic:
                    visitSyntactic( reader.get<ifc::symbolic::SyntacticType>( typeIndex ) );
                    break;

                case ifc::TypeSort::Array:
                    visitArray( reader.get<ifc::symbolic::ArrayType>( typeIndex ) );
                    break;

                case ifc::TypeSort::Base:
                    dispatchTypeIndex( reader.get<ifc::symbolic::BaseType>( typeIndex ).type );
                    break;

                case ifc::TypeSort::Qualified:
                    dispatchTypeIndex( reader.get<ifc::symbolic::QualifiedType>( typeIndex ).unqualified_type ); // const, etc discarded
                    break;

                case ifc::TypeSort::Pointer:
                    ++mDeclarator.indirections;
                    dispatchTypeIndex( reader.get<ifc::symbolic::PointerType>( typeIndex ).pointee );
                    break;

                case ifc::TypeSort::LvalueReference:
                    mDeclarator.referenceType = ReferenceType::LValueReference;
                    dispatchTypeIndex( reader.get<ifc::symbolic::LvalueReferenceType>( typeIndex ).referee );
                    break;

                case ifc::TypeSort::Forall:
                    visitForallType( reader.get<ifc::symbolic::ForallType>( typeIndex ) );
                    break;

                default:
                    print( "TypeSort not implemented: ", typeIndex );
                    throw std::runtime_error( "dispatchTypeIndex: TypeSort not implemented" );
            }
        }

        void dispatchExprIndex( const ifc::ExprIndex exprIndex )
        {
            switch ( exprIndex.sort() )
            {
                case ifc::ExprSort::Type:
                    dispatchTypeIndex( query( exprIndex ).get<ifc::symbolic::TypeExpr>().denotation ); // "type" discarded
                    break;

                case ifc::ExprSort::NamedDecl:
                    visitNamedDecl( query( exprIndex ).get<ifc::symbolic::NamedDeclExpr>() );
                    break;

                default:
                    print( "ExprIndex not implemented: ", exprIndex );
                    throw std::runtime_error( "dispatchExprIndex: ExprIndex not implemented" );
            }
        }

        void getTypeArgumentList( const ifc::ExprIndex exprIndex, std::vector<TypeTemplateArgument>& args )
        {
            const ifc::Reader& reader = mReader;

            if ( exprIndex.sort() == ifc::ExprSort::Empty )
            {
                return;
            }

            if ( exprIndex.sort() == ifc::ExprSort::Literal )
            {
                args.emplace_back( reader.get<ifc::symbolic::LiteralExpr>( exprIndex ) );
            }
            else if ( exprIndex.sort() == ifc::ExprSort::Type || exprIndex.sort() == ifc::ExprSort::NamedDecl )
            {
                DeclaratorVisitor visitor( mReader );
                visitor.dispatchExprIndex( exprIndex ); // need to pass current template args?
                args.emplace_back( visitor.declarator() );
            }
            else if ( exprIndex.sort() == ifc::ExprSort::Tuple )
            {
                const auto& tupleExpr = reader.get<ifc::symbolic::TupleExpr>( exprIndex );
                for ( const auto& tupleItem : reader.sequence( tupleExpr ) )
                {
                    getTypeArgumentList( tupleItem, args );
                }
            }
            else if ( exprIndex.sort() == ifc::ExprSort::PackedTemplateArguments )
            {
                getTypeArgumentList( reader.get<ifc::symbolic::PackedTemplateArgumentsExpr>( exprIndex ).arguments, args );
            }
            else
            {
                print( "ExprIndex not implemented: ", exprIndex );
                throw std::runtime_error( "getTypeArgumentList: ExprIndex not implemented" );
            }
        }

        std::vector<TypeTemplateArgument> getTypeArgumentList( const ifc::ExprIndex exprIndex )
        {
            std::vector<TypeTemplateArgument> typeNameList;
            getTypeArgumentList( exprIndex, typeNameList );
            return typeNameList;
        }

    private:
        template<index_like::MultiSorted TIndex>
        Query<TIndex> query( const TIndex index ) const noexcept
        {
            return { mReader, index };
        }

        Declarator mDeclarator{};
        std::reference_wrapper<const ifc::Reader> mReader;
        AliasPolicy mAliasPolicy{};
    };

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
                        return "bool";

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
        std::print( os, "public enum {}", typeName );

        if ( const auto base = fundamentalToCS( Query( reader, baseIndex ).get<ifc::symbolic::FundamentalType>() ); base != "int" )
        {
            std::print( os, " : {}", base );
        }

        std::println( os, "\n{{" );

        bool first = true;
        bool printExplicitValues = false;
        int64_t index = 0;
        for ( const auto& val : reader.sequence( initializer ) ) // XXX: not const?
        {
            if ( not std::exchange( first, false ) )
            {
                std::println( os, "," );
            }

            const auto value = getLiteralValue( reader, val.initializer );
            printExplicitValues |= value != index++;

            if ( printExplicitValues )
            {
                std::print( os, "    {} = {}", getStringView( reader, val.identity ), value );
            }
            else
            {
                std::print( os, "    {}", getStringView( reader, val.identity ) );
            }
        }


        std::println( os, "{}}}\n", first ? "" : "\n" );
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
        else
        {
            return std::make_tuple( getStringView( reader, decl.identity ), decl.home_scope, false );
        }
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

    class StructInfo;
    class InfoBase;

    class QualifiedNameTable
    {
    public:
        void add( const ifc::DeclIndex declIndex, const Scope& scope )
        {
            auto& nameList = mNamesByIndex[declIndex];
            if ( nameList.empty() )
            {
                buildNameList( scope, nameList );
            }
        }

        std::span<const std::string_view> getRefereeQualifier( const StructInfo& referer, const InfoBase& referee ) const;

    private:
        void buildNameList( const Scope& scope, std::vector<std::string_view>& list ) const
        {
            if ( scope.Parent.has_value() )
            {
                buildNameList( scope.Parent.value(), list );
            }

            list.emplace_back( scope.Name );
        }

        std::unordered_map<ifc::DeclIndex, std::vector<std::string_view>> mNamesByIndex;
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

        InfoBaseType type() const noexcept override
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

    private:
        ifc::symbolic::FundamentalType mFundamental{};
    };

    class TemplateInfo : public InfoBaseT<ifc::symbolic::TemplateDecl, InfoBaseType::Template>
    {
    public:
        struct TemplateField
        {
            std::variant<Declarator, ifc::symbolic::ParameterDecl> param{};
            std::string_view fieldName{};
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

    bool isStructClassOrUnion( const ifc::Reader& reader, const ifc::TypeIndex type, bool& isUnion )
    {
        if ( type.sort() != ifc::TypeSort::Fundamental )
        {
            return false;
        }

        const auto& typeOfType = reader.get<ifc::symbolic::FundamentalType>( type );
        isUnion = typeOfType.basis == ifc::symbolic::TypeBasis::Union;
        return typeOfType.basis == ifc::symbolic::TypeBasis::Class || typeOfType.basis == ifc::symbolic::TypeBasis::Struct || isUnion;
    }

    bool reservedTypeNameCS( const std::string_view& typeName )
    {
        static const std::set<std::string_view> reserved = {
            "string", "base"
        };

        return reserved.contains( typeName );
    }

    struct CsIdentifier
    {
        std::string_view identifier{};
    };

    static std::ostream& operator<<( std::ostream& os, const CsIdentifier csIdentifier )
    {
        if ( reservedTypeNameCS( csIdentifier.identifier ) )
        {
            os << '@';
        }

        os << csIdentifier.identifier;
        return os;
    }

    template<index_like::MultiSorted T>
    std::tuple<size_t, size_t> getMultisortedTagIndexPrecision()
    {
        return { index_like::tag_precision<typename T::SortType>, index_like::index_precision<typename T::SortType> };
    }

    std::tuple<size_t, size_t> getMultisortedTagIndexPrecision( const std::string_view name )
    {
        static std::unordered_map<std::string_view, std::tuple<size_t, size_t>> map = {
            { "StringIndex", getMultisortedTagIndexPrecision<ifc::StringIndex>() },
            { "NameIndex", getMultisortedTagIndexPrecision<ifc::NameIndex>() },
            { "ChartIndex", getMultisortedTagIndexPrecision<ifc::ChartIndex>() },
            { "DeclIndex", getMultisortedTagIndexPrecision<ifc::DeclIndex>() },
            { "TypeIndex", getMultisortedTagIndexPrecision<ifc::TypeIndex>() },
            { "SyntaxIndex", getMultisortedTagIndexPrecision<ifc::SyntaxIndex>() },
            { "LitIndex", getMultisortedTagIndexPrecision<ifc::LitIndex>() },
            { "StmtIndex", getMultisortedTagIndexPrecision<ifc::StmtIndex>() },
            { "ExprIndex", getMultisortedTagIndexPrecision<ifc::ExprIndex>() },
            { "MacroIndex", getMultisortedTagIndexPrecision<ifc::MacroIndex>() },
            { "PragmaIndex", getMultisortedTagIndexPrecision<ifc::PragmaIndex>() },
            { "AttrIndex", getMultisortedTagIndexPrecision<ifc::AttrIndex>() },
            { "DirIndex", getMultisortedTagIndexPrecision<ifc::DirIndex>() },
            { "UnitIndex", getMultisortedTagIndexPrecision<ifc::UnitIndex>() },
            { "FormIndex", getMultisortedTagIndexPrecision<ifc::FormIndex>() }
        };

        return map.at( name );
    }

    class StructInfo;

    class StructInfo : public InfoBaseT<ifc::symbolic::ScopeDecl, InfoBaseType::Struct>
    {
    public:
        using InfoBaseT::InfoBaseT;

        static std::string_view getCsTypeName( const ifc::Reader& reader, const Declarator& declarator )
        {
            return declarator.isFundamental() ? fundamentalToCS( declarator.fundamental() ) : getIdentity( reader, declarator.index() );
        }

        static void printTemplateArgumentList( const ifc::Reader& reader, std::ostream& os, const Declarator& declarator )
        {
            for ( size_t i = 0; i < declarator.templateArgs.size(); ++i )
            {
                if ( i == 0 )
                {
                    os << '<';
                }

                os << getCsTypeName( reader, std::get<Declarator>( declarator.templateArgs[0] ) );

                if ( i != declarator.templateArgs.size() - 1 )
                {
                    os << ", ";
                }
                else
                {
                    os << '>';
                }
            }
        }

        void renameUnnamedUnion( const std::string_view newName )
        {
            mName = newName;
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

        struct OverBase
        {
            EnumerationIndexAndName tagType{};
        };

        struct SpecialBaseTypes
        {
            std::optional<OverBase> Over;
            std::optional<EnumeratorIndexAndName> Tag;
            std::optional<std::tuple<StructIndexAndName, std::optional<EnumeratorIndexAndName>>> Sequence;
            std::vector<std::tuple<std::string_view, std::string_view>> MembersToInline; // XXX no type, only name

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

            void collect( const ifc::Reader& reader, const std::unordered_map<ifc::DeclIndex, InfoBaseRef>& infoByIndex, const ifc::symbolic::BaseType& baseType )
            {
                if ( baseType.type.sort() != ifc::TypeSort::Syntactic )
                {
                    const auto declarator = DeclaratorVisitor::createDeclarator( reader, baseType.type );
                    const auto name = getIdentity( reader, declarator.index() );

                    MembersToInline.emplace_back( name, name ); // XXX possible name collision, wrong capitalization, no cs name lookup, could be the only base class
                    return;
                }
                else
                {
                    const auto declarator = DeclaratorVisitor::createDeclarator( reader, baseType.type );
                    const auto foundIt = infoByIndex.find( declarator.index() );
                    if ( foundIt == infoByIndex.end() or foundIt->second.get().type() != InfoBaseType::Template )
                    {
                        const auto templateName = getIdentity( reader, declarator.index() );

                        if ( templateName == "Over" )
                        {
                            // special handling: Over is in index_like which is currently ignored
                            const auto enumerationIndex = std::get<Declarator>( declarator.templateArgs.at( 0 ) ).index();
                            Over.emplace( OverBase{ enumerationIndex, getIdentity( reader, enumerationIndex ) } );
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

                        if ( templateName == "Tag" or templateName == "TraitTag" or templateName == "Location" or templateName == "LocationAndType" )
                        {
                            const auto& enumerator = std::get<Declarator>( declarator.templateArgs.at( 0 ) );
                            const auto enumerationDeclIndex = enumerator.containingType.value();
                            Tag.emplace( EnumeratorIndexAndName{ { enumerationDeclIndex, getIdentity( reader, enumerationDeclIndex ) }, enumerator.index(), getIdentity( reader, enumerator.index() ) } );
                        }

                        if ( not templateInfo.fields().empty() )
                        {
                            // TODO: emit templates so that they don't need to be inlined
                            for ( const auto& field : templateInfo.fields() )
                            {
                                if ( std::holds_alternative<ifc::symbolic::ParameterDecl>( field.param ) )
                                {
                                    const auto argIndex = gsl::narrow_cast<size_t>( std::get<ifc::symbolic::ParameterDecl>( field.param ).position ) - 1;
                                    const auto& argExpr = declarator.templateArgs.at( argIndex ); // XXX unsure about ordering/indexing
                                    const auto& fieldDeclarator = std::get<Declarator>( argExpr );

                                    const auto typeName = getCsTypeName( reader, fieldDeclarator );
                                    std::ostringstream oss;
                                    oss << typeName;
                                    printTemplateArgumentList( reader, oss, fieldDeclarator );
                                    MembersToInline.emplace_back( registerString( oss.str() ), field.fieldName );
                                }
                                else
                                {
                                    MembersToInline.emplace_back( getCsTypeName( reader, std::get<Declarator>( field.param ) ), field.fieldName );
                                }
                            }
                        }
                        else
                        {
                            if ( templateName == "constant_traits" )
                            {
                                // TODO emit tag?
                            }
                            else
                            {
                                assert( templateName == "Tag" or templateName == "TraitTag" ); // new type?
                            }
                        }
                    }
                }
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
            const QualifiedNameTable& nameTable,
            const std::unordered_map<ifc::DeclIndex, InfoBaseRef>& infoByIndex,
            const std::function<void( std::ostream& )> writeNested )
        {
            auto& reader = mReader.get();

            const bool isUnion = reader.get<ifc::symbolic::FundamentalType>( decl().type ).basis == ifc::symbolic::TypeBasis::Union;

            std::set<std::tuple<std::string, std::string_view, size_t>> inlineArrays; // helperTypeName, typeName, bound
            SpecialBaseTypes baseTypes;

            if ( not index_like::null( decl().base ) )
            {
                assert( not isUnion );

                baseTypes.collect( reader, infoByIndex, decl().base );

                if ( baseTypes.Over.has_value() )
                {
                    os << "[Over<" << baseTypes.Over.value().tagType.name << ">]" << std::endl;
                }

                if ( baseTypes.Tag.has_value() )
                {
                    const auto& tag = baseTypes.Tag.value();
                    os << "[Tag<" << tag.parent.name << ">(" << tag.parent.name << '.' << tag.name << ")]" << std::endl;
                }
            }

            const bool isReadonlyStruct = mName != "TableOfContents";

            if ( isUnion )
            {
                os << "[StructLayout(LayoutKind.Explicit)]" << std::endl;
            }
            else
            {
                // note: alignment is ignored
                if ( const auto packSize = ifc::to_underlying( decl().pack_size ); packSize != 0 && packSize != 16 )
                {
                    os << "[StructLayout(LayoutKind.Sequential, Pack = " << ifc::to_underlying( decl().pack_size ) << ")]" << std::endl;
                }
            }

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
                os << " : IHasSort<" << baseTypes.Tag.value().parent.name << '>';
            }

            if ( baseTypes.Over.has_value() )
            {
                os << " : IOver<" << baseTypes.Over.value().tagType.name << '>';
            }

            os << std::endl << "{" << std::endl;

            if ( insertStaticSortGetter )
            {
                const auto& tag = baseTypes.Tag.value();
                os << "    public static int Sort => (int)" << tag.parent.name << '.' << tag.name << ";" << std::endl;
                os << "    public static SortType Type => SortType." << ( tag.parent.name.substr( 0, tag.parent.name.size() - 4 ) ) << ';' << std::endl << std::endl;
            }

            if ( writeNested )
            {
                writeNested( os );
            }

            if ( baseTypes.Over.has_value() ) // XXX: assumed to be the first base
            {
                const auto& over = baseTypes.Over.value();
                const auto [tagPrecision, valuePrecision] = getMultisortedTagIndexPrecision( mName );
                assert( tagPrecision + valuePrecision == 32 );
                os << "    private readonly uint IndexAndSort;" << std::endl;
                os << "    public Index Index => (Index)(IndexAndSort >> " << tagPrecision << ");" << std::endl;
                os << "    public " << over.tagType.name << " Sort => (" << over.tagType.name << ")(IndexAndSort & 0b" << std::string( tagPrecision, '1' ) << ");" << std::endl;
                os << "    public bool IsNull => IndexAndSort == 0;" << std::endl;
                os << "    public static SortType Type => SortType." << ( over.tagType.name.substr( 0, over.tagType.name.size() - 4 ) ) << ';' << std::endl;
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

            const auto printQualifiedTypePrefix = [&]( const Declarator& d ) {
                if ( not d.isFundamental() )
                {
                    if ( const auto foundIt = infoByIndex.find( d.index() ); foundIt != infoByIndex.end() )
                    {
                        const auto qualifiers = nameTable.getRefereeQualifier( *this, foundIt->second.get() );
                        for ( const auto refereeQualifier : qualifiers )
                        {
                            os << refereeQualifier << ".";
                        }
                    }
                }
            };

            struct BitfieldMember
            {
                std::string_view typeName{};
                std::string_view fieldName{};
                size_t width{};
                size_t shift{}; // # of unused bits to the right
                std::string_view bitfieldFieldName{}; // + "_bitfield" suffix
            };

            struct BitfieldTracker
            {
                std::vector<BitfieldMember> fields;
                ifc::symbolic::FundamentalType type{};
                size_t remainingBits{};
                std::string_view fieldName{}; // + "_bitfield" suffix
            } tracker{};

            if ( const auto* initScope = reader.try_get( decl().initializer ); initScope and not baseTypes.Sequence.has_value() ) // TODO: sequence is currently inlined
            {
                for ( const auto& innerDeclaration : reader.sequence( *initScope ) )
                {
                    if ( innerDeclaration.index.sort() == ifc::DeclSort::Field )
                    {
                        tracker.type = {};
                        tracker.remainingBits = 0;
                        tracker.fieldName = {};

                        if ( isUnion )
                        {
                            os << "[FieldOffset(0)]" << std::endl;
                        }

                        const auto& innerDecl = reader.get<ifc::symbolic::FieldDecl>( innerDeclaration.index );
                        assert( index_like::null( innerDecl.alignment ) );

                        DeclaratorVisitor visitor( reader );
                        visitor.dispatchTypeIndex( innerDecl.type );
                        const auto& declarator = visitor.declarator();

                        std::string_view typeName = getCsTypeName( reader, declarator );
                        if ( typeName == "bool" )
                        {
                            std::println( os, "[MarshalAs(UnmanagedType.U1)]" );
                        }

                        os << "    public ";
                        if ( isReadonlyStruct )
                        {
                            os << "readonly ";
                        }

                        if ( typeName == "basic_string_view" || typeName == "Pathname" )
                        {
                            typeName = "string";
                        }

                        if ( declarator.arrayBound.has_value() )
                        {
                            assert( typeName != "array" );

                            std::string helperTypeName = std::string( typeName ) + "_Array" + std::to_string( declarator.arrayBound.value() );
                            os << helperTypeName;
                            inlineArrays.emplace( std::move( helperTypeName ), typeName, declarator.arrayBound.value() );
                        }
                        else if ( typeName == "array" )
                        {
                            assert( declarator.templateArgs.size() >= 2 );

                            DeclaratorVisitor retry( reader );
                            retry.dispatchTypeIndex( innerDecl.type );

                            const auto bound = getLiteralValue( reader, std::get<ifc::symbolic::LiteralExpr>( declarator.templateArgs.at( 1 ) ) );
                            typeName = getCsTypeName( reader, std::get<Declarator>( declarator.templateArgs.at( 0 ) ) );

                            std::string helperTypeName = std::string( typeName ) + "_Array" + std::to_string( bound );
                            os << helperTypeName;
                            inlineArrays.emplace( std::move( helperTypeName ), typeName, bound );
                        }
                        else
                        {
                            printQualifiedTypePrefix( declarator );
                            os << typeName;
                            printTemplateArgumentList( reader, os, declarator );
                        }

                        os << ' ';

                        const auto fieldName = getStringView( mReader, innerDecl.identity );

                        os << CsIdentifier{ fieldName } << ";" << std::endl;

                        if ( isUnion )
                        {
                            mUnionMembers.emplace_back( typeName, fieldName, declarator );
                        }
                    }
                    else if ( innerDeclaration.index.sort() == ifc::DeclSort::Bitfield )
                    {
                        assert( not isUnion );

                        const auto& [type, bitfield] = Query( reader, innerDeclaration.index ).getWithQuery( &ifc::symbolic::BitfieldDecl::type );

                        const auto width = gsl::narrow_cast<size_t>( getLiteralValue( reader, bitfield.width ) );
                        const auto fieldName = getStringView( mReader, bitfield.identity );

                        assert( width > 0 );
                        assert( index_like::null( bitfield.initializer ) );

                        DeclaratorVisitor visitor( reader );
                        visitor.dispatchTypeIndex( type.index );
                        const auto fundamentalType = visitor.declarator().fundamental();

                        assert( fundamentalType.sign == ifc::symbolic::TypeSign::Unsigned );

                        const auto fundamentalTypeName = fundamentalToCS( fundamentalType );

                        if ( width <= tracker.remainingBits && tracker.type == fundamentalType )
                        {
                            // no new field required
                            tracker.remainingBits -= width;

                            os << "    // " << fundamentalTypeName << ' ' << fieldName << " (bitfield continuation)" << std::endl;

                            tracker.fields.emplace_back(
                                fundamentalTypeName, fieldName, gsl::narrow_cast<size_t>( width ), tracker.remainingBits, tracker.fieldName
                            );
                        }
                        else
                        {
                            const auto typeWidth = fundamentalBitWidth( fundamentalType );
                            assert( width <= typeWidth );

                            tracker.remainingBits = typeWidth - width;
                            tracker.type = fundamentalType;
                            tracker.fieldName = fieldName;

                            tracker.fields.emplace_back(
                                fundamentalTypeName, fieldName, gsl::narrow_cast<size_t>( width ), tracker.remainingBits, fieldName
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
                    else if ( innerDeclaration.index.sort() == ifc::DeclSort::Scope )
                    {
                        const auto& [scopeIndex, scope] = Query( reader, innerDeclaration.index ).getWithIndex<ifc::symbolic::ScopeDecl>();

                        bool isUnionArg{};
                        const bool isUnionDeclaration = isStructClassOrUnion( reader, scope.type, isUnionArg ) && isUnionArg;
                        assert( isUnionDeclaration );

                        const auto& unionInfo = infoByIndex.at( scopeIndex ).get().as<StructInfo>();

                        os << "    private ";
                        if ( isReadonlyStruct )
                        {
                            os << "readonly ";
                        }

                        assert( std::isupper( unionInfo.mName[0] ) );
                        os << unionInfo.mName << ' ' << gsl::narrow_cast<char>( std::tolower( unionInfo.mName[0] ) ) << unionInfo.mName.substr( 1 ) << ';' << std::endl;

                        assert( not unionInfo.mUnionMembers.empty() ); // assumes that nested unions are emitted first

                        for ( const auto& member : unionInfo.mUnionMembers )
                        {
                            os << "    public ";
                            printQualifiedTypePrefix( member.declarator );
                            os << member.typeName << ' ' << CsIdentifier{ member.fieldName } << " => "
                                << gsl::narrow_cast<char>( std::tolower( unionInfo.mName[0] ) ) << unionInfo.mName.substr( 1 )
                                << '.' << CsIdentifier{ member.fieldName } << ';' << std::endl;
                        }
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

            for ( const auto& [typeName, fieldName, width, shift, containigFieldName] : tracker.fields )
            {
                os << "    public " << typeName << ' ' << CsIdentifier{ fieldName } << " => ";
                if ( typeName != "uint" )
                {
                    os << "(" << typeName << ")";
                }
                os << "((" << containigFieldName << "_bitfield >> " << shift << ") & 0b" << std::string( width, '1' ) << ");" << std::endl;
            }

            os << "}" << std::endl << std::endl;

            for ( const auto& [helperTypeName, typeName, bound] : inlineArrays )
            {
                os << "[System.Runtime.CompilerServices.InlineArray(" << bound << ")]" << std::endl;
                os << "public struct " << helperTypeName << std::endl << '{' << std::endl;
                os << "    private " << typeName << ' ' << "_element;" << std::endl << '}' << std::endl;
            }
        }

    private:
        struct UnionMember
        {
            std::string_view typeName{};
            std::string_view fieldName{};
            Declarator declarator{};
        };

        std::vector<UnionMember> mUnionMembers;
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
namespace IfcSharpLib
{
    public static partial class IfcSizeValidation
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

    std::span<const std::string_view> QualifiedNameTable::getRefereeQualifier( const StructInfo& referer, const InfoBase& referee ) const
    {
        if ( referer.scope() == referee.scope() || referer.index() == referee.scope().value().get().Index )
        {
            return {};
        }

        const std::span refererNames( mNamesByIndex.at( referer.index() ) );
        const std::span refereeNames( mNamesByIndex.at( referee.index() ) );
        const auto skipCount = std::ranges::distance( std::views::zip( refererNames, refereeNames )
            | std::views::take_while( []( const auto& t ) { return std::get<0>( t ) == std::get<1>( t ); } ) );
        return refereeNames.subspan( skipCount );
    }

    constexpr std::string_view IfcSharpOutDir = IFCSHARP_OUTDIR;
    constexpr std::string_view IfcSharpRepoDir = IFCSHARP_REPODIR;
}

int main()
{
    const std::filesystem::path ifcSharpOutDir( IfcSharpOutDir );
    const auto ifcInputFile = ifcSharpOutDir / "IfcTestData" / "IfcHeaderUnit.ixx.ifc";
    const auto validationInputFile = ifcSharpOutDir / "IfcTestData" / "IfcSizeValidation.ixx.ifc";

    const std::filesystem::path ifcSharpRepoDir( IfcSharpRepoDir );
    const auto validationOutputFile = ifcSharpRepoDir / "IfcSharpLib" / "IfcSizeValidation.Generated.cs";
    const auto ifcOutputFile = ifcSharpRepoDir / "IfcSharpLib" / "Ifc.Generated.cs";

    const auto testOutputFile = ifcSharpRepoDir / "IfcTestData" / "IfcSizeValidation.ixx";

    updateValidationData( validationInputFile.string(), validationOutputFile.string() );

    auto ifc = ifchelper::IfcReader::loadFile( ifcInputFile.string() );
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

    QualifiedNameTable nameTable;

    std::unordered_map<ifc::DeclIndex, ScopeContent> infoByScope;
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

    const auto templateDecls = reader.partition<ifc::symbolic::TemplateDecl>();
    for ( const auto& tdecl : templateDecls | std::views::filter( std::not_fn( isUnwrittenScope<ifc::symbolic::TemplateDecl> ) ) )
    {
        bool isUnion{};
        if ( isStructClassOrUnion( reader, tdecl.type, isUnion ) )
        {
            const auto& scope = scopeInfo.findOrAdd( reader, tdecl.home_scope );
            if ( inIfcNamespace( scope ) )
            {
                assert( not isUnion );

                std::vector<TemplateInfo::TemplateField> fields;

                StructFieldEnumerator fieldEnumerator{ tdecl.entity.decl };
                fieldEnumerator.visit( reader, overloaded{
                    [&]( const ifc::DeclIndex, const ifc::symbolic::FieldDecl& field ) {
                        const auto fieldName = getStringView( reader, field.identity );

                        const auto& param = Query( reader, field.type ).tryGet( &ifc::symbolic::DesignatedType::decl ).tryGet<ifc::symbolic::ParameterDecl>();
                        if ( param.has_value() )
                        {
                            fields.emplace_back( param.value(), fieldName );
                        }
                        else
                        {
                            DeclaratorVisitor visitor( reader );
                            visitor.dispatchTypeIndex( field.type );
                            fields.emplace_back( visitor.declarator(), fieldName );
                        }
                    },

                    []( const ifc::DeclIndex, const ifc::symbolic::BitfieldDecl& ) {
                        assert( false ); // TODO?
                    }
                    } );

                const auto argumentCount = gsl::narrow_cast<size_t>( reader.get<ifc::symbolic::UnilevelChart>( tdecl.chart ).cardinality );

                const auto& templateInfo = infoByScope[scope->get().Index].templates.emplace_back( reader, tdecl, scope.value(), argumentCount, std::move( fields ) );
                infoByIndex.emplace( templateInfo.index(), templateInfo );
                nameTable.add( templateInfo.index(), scope.value() );

                std::cout << "Template: " << templateInfo.name() << std::endl;
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
            nameTable.add( enumInfo.index(), scope.value() );
        }
    }

    std::unordered_map<ifc::DeclIndex, size_t> unionCounterByScope;
    auto types = reader.partition<ifc::symbolic::ScopeDecl>();
    for ( const auto& decl : types | std::views::filter( std::not_fn( isUnwrittenScope<ifc::symbolic::ScopeDecl> ) ) )
    {
        bool isUnion{};
        if ( isStructClassOrUnion( reader, decl.type, isUnion ) )
        {
            auto scopeOpt = scopeInfo.findOrAdd( reader, decl.home_scope );
            if ( inIfcNamespace( scopeOpt ) )
            {
                Scope& scope = scopeOpt.value();
                auto& structInfo = infoByScope[scope.Index].structs.emplace_back( reader, decl, scope );
                infoByIndex.emplace( structInfo.index(), structInfo );
                if ( structInfo.name().starts_with( "<unnamed" ) )
                {
                    assert( isUnion );
                    assert( not scope.IsNamespace );
                    structInfo.renameUnnamedUnion( registerString( "UnnamedUnion" + std::to_string( ++unionCounterByScope[scope.Index] ) ) );
                }

                nameTable.add( structInfo.index(), scope );
            }
        }
    }

    std::ostringstream osCode;

    osCode << "using System.Runtime.InteropServices;" << std::endl << std::endl;
    osCode << "#pragma warning disable CS0649 // Field '...' is never assigned to, and will always have its default value 0" << std::endl << std::endl;
    osCode << "namespace ifc" << std::endl << '{' << std::endl;
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

            for ( auto& structInfo : foundIt->second.structs | std::views::filter( std::not_fn( ignoreTypeByName ) ) )
            {
                structInfo.writeCS( osCode, namesForSizeValidation, nameTable, infoByIndex, [&]( std::ostream& os ) {
                    // write nested
                    if ( const auto nestedIt = infoByScope.find( structInfo.index() ); nestedIt != infoByScope.end() )
                    {
                        for ( const auto& nestedEnumInfo : nestedIt->second.enums )
                        {
                            nestedEnumInfo.writeCS( os );
                        }

                        for ( auto& nestedStructInfo : nestedIt->second.structs )
                        {
                            nestedStructInfo.writeCS( os, namesForSizeValidation, nameTable, infoByIndex, {} );
                        }
                    }
                } );
            }
        }
    } );

    std::cout << std::endl << std::string( 80, '=' ) << std::endl << std::endl;

    if ( updateFileWithHash( ifcOutputFile.string(), osCode.str() ) )
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

    if ( updateFileWithHash( testOutputFile.string(), osTest.str() ) )
    {
        std::cout << "### Test output file changed ###" << std::endl;
    }
    else
    {
        std::cout << "No change in test output file" << std::endl;
    }
}
