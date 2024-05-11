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

#include <ifc/reader.hxx>
#include <ifc/util.hxx>
#include <ifc/dom/node.hxx>
#include <ifc/index-utils.hxx>

#include <gsl/span>

#pragma comment(lib, "bcrypt.lib")

constexpr std::string to_string( const ifc::TypeSort val ) noexcept
{
    switch ( val )
    {
        case ifc::TypeSort::VendorExtension: return "VendorExtension";
        case ifc::TypeSort::Fundamental: return "Fundamental";
        case ifc::TypeSort::Designated: return "Designated";
        case ifc::TypeSort::Tor: return "Tor";
        case ifc::TypeSort::Syntactic: return "Syntactic";
        case ifc::TypeSort::Expansion: return "Expansion";
        case ifc::TypeSort::Pointer: return "Pointer";
        case ifc::TypeSort::PointerToMember: return "PointerToMember";
        case ifc::TypeSort::LvalueReference: return "LvalueReference";
        case ifc::TypeSort::RvalueReference: return "RvalueReference";
        case ifc::TypeSort::Function: return "Function";
        case ifc::TypeSort::Method: return "Method";
        case ifc::TypeSort::Array: return "Array";
        case ifc::TypeSort::Typename: return "Typename";
        case ifc::TypeSort::Qualified: return "Qualified";
        case ifc::TypeSort::Base: return "Base";
        case ifc::TypeSort::Decltype: return "Decltype";
        case ifc::TypeSort::Placeholder: return "Placeholder";
        case ifc::TypeSort::Tuple: return "Tuple";
        case ifc::TypeSort::Forall: return "Forall";
        case ifc::TypeSort::Unaligned: return "Unaligned";
        case ifc::TypeSort::SyntaxTree: return "SyntaxTree";
        case ifc::TypeSort::Count: return "Count";

        default: return "<unnamed>";
    }
}

constexpr std::string_view to_string( const ifc::DeclSort val ) noexcept
{
    switch ( val )
    {
        case ifc::DeclSort::VendorExtension: return "VendorExtension";
        case ifc::DeclSort::Enumerator: return "Enumerator";
        case ifc::DeclSort::Variable: return "Variable";
        case ifc::DeclSort::Parameter: return "Parameter";
        case ifc::DeclSort::Field: return "Field";
        case ifc::DeclSort::Bitfield: return "Bitfield";
        case ifc::DeclSort::Scope: return "Scope";
        case ifc::DeclSort::Enumeration: return "Enumeration";
        case ifc::DeclSort::Alias: return "Alias";
        case ifc::DeclSort::Temploid: return "Temploid";
        case ifc::DeclSort::Template: return "Template";
        case ifc::DeclSort::PartialSpecialization: return "PartialSpecialization";
        case ifc::DeclSort::Specialization: return "Specialization";
        case ifc::DeclSort::DefaultArgument: return "DefaultArgument";
        case ifc::DeclSort::Concept: return "Concept";
        case ifc::DeclSort::Function: return "Function";
        case ifc::DeclSort::Method: return "Method";
        case ifc::DeclSort::Constructor: return "Constructor";
        case ifc::DeclSort::InheritedConstructor: return "InheritedConstructor";
        case ifc::DeclSort::Destructor: return "Destructor";
        case ifc::DeclSort::Reference: return "Reference";
        case ifc::DeclSort::Using: return "Using";
        case ifc::DeclSort::UnusedSort0: return "UnusedSort0";
        case ifc::DeclSort::Friend: return "Friend";
        case ifc::DeclSort::Expansion: return "Expansion";
        case ifc::DeclSort::DeductionGuide: return "DeductionGuide";
        case ifc::DeclSort::Barren: return "Barren";
        case ifc::DeclSort::Tuple: return "Tuple";
        case ifc::DeclSort::SyntaxTree: return "SyntaxTree";
        case ifc::DeclSort::Intrinsic: return "Intrinsic";
        case ifc::DeclSort::Property: return "Property";
        case ifc::DeclSort::OutputSegment: return "OutputSegment";
        case ifc::DeclSort::Count: return "Count";

        default: return "<unnamed>";
    }
}

constexpr std::string_view to_string( const ifc::ExprSort val ) noexcept
{
    switch ( val )
    {
        case ifc::ExprSort::VendorExtension: return "VendorExtension";
        case ifc::ExprSort::Empty: return "Empty";
        case ifc::ExprSort::Literal: return "Literal";
        case ifc::ExprSort::Lambda: return "Lambda";
        case ifc::ExprSort::Type: return "Type";
        case ifc::ExprSort::NamedDecl: return "NamedDecl";
        case ifc::ExprSort::UnresolvedId: return "UnresolvedId";
        case ifc::ExprSort::TemplateId: return "TemplateId";
        case ifc::ExprSort::UnqualifiedId: return "UnqualifiedId";
        case ifc::ExprSort::SimpleIdentifier: return "SimpleIdentifier";
        case ifc::ExprSort::Pointer: return "Pointer";
        case ifc::ExprSort::QualifiedName: return "QualifiedName";
        case ifc::ExprSort::Path: return "Path";
        case ifc::ExprSort::Read: return "Read";
        case ifc::ExprSort::Monad: return "Monad";
        case ifc::ExprSort::Dyad: return "Dyad";
        case ifc::ExprSort::Triad: return "Triad";
        case ifc::ExprSort::String: return "String";
        case ifc::ExprSort::Temporary: return "Temporary";
        case ifc::ExprSort::Call: return "Call";
        case ifc::ExprSort::MemberInitializer: return "MemberInitializer";
        case ifc::ExprSort::MemberAccess: return "MemberAccess";
        case ifc::ExprSort::InheritancePath: return "InheritancePath";
        case ifc::ExprSort::InitializerList: return "InitializerList";
        case ifc::ExprSort::Cast: return "Cast";
        case ifc::ExprSort::Condition: return "Condition";
        case ifc::ExprSort::ExpressionList: return "ExpressionList";
        case ifc::ExprSort::SizeofType: return "SizeofType";
        case ifc::ExprSort::Alignof: return "Alignof";
        case ifc::ExprSort::Label: return "Label";
        case ifc::ExprSort::UnusedSort0: return "UnusedSort0";
        case ifc::ExprSort::Typeid: return "Typeid";
        case ifc::ExprSort::DestructorCall: return "DestructorCall";
        case ifc::ExprSort::SyntaxTree: return "SyntaxTree";
        case ifc::ExprSort::FunctionString: return "FunctionString";
        case ifc::ExprSort::CompoundString: return "CompoundString";
        case ifc::ExprSort::StringSequence: return "StringSequence";
        case ifc::ExprSort::Initializer: return "Initializer";
        case ifc::ExprSort::Requires: return "Requires";
        case ifc::ExprSort::UnaryFold: return "UnaryFold";
        case ifc::ExprSort::BinaryFold: return "BinaryFold";
        case ifc::ExprSort::HierarchyConversion: return "HierarchyConversion";
        case ifc::ExprSort::ProductTypeValue: return "ProductTypeValue";
        case ifc::ExprSort::SumTypeValue: return "SumTypeValue";
        case ifc::ExprSort::UnusedSort1: return "UnusedSort1";
        case ifc::ExprSort::ArrayValue: return "ArrayValue";
        case ifc::ExprSort::DynamicDispatch: return "DynamicDispatch";
        case ifc::ExprSort::VirtualFunctionConversion: return "VirtualFunctionConversion";
        case ifc::ExprSort::Placeholder: return "Placeholder";
        case ifc::ExprSort::Expansion: return "Expansion";
        case ifc::ExprSort::Generic: return "Generic";
        case ifc::ExprSort::Tuple: return "Tuple";
        case ifc::ExprSort::Nullptr: return "Nullptr";
        case ifc::ExprSort::This: return "This";
        case ifc::ExprSort::TemplateReference: return "TemplateReference";
        case ifc::ExprSort::Statement: return "Statement";
        case ifc::ExprSort::TypeTraitIntrinsic: return "TypeTraitIntrinsic";
        case ifc::ExprSort::DesignatedInitializer: return "DesignatedInitializer";
        case ifc::ExprSort::PackedTemplateArguments: return "PackedTemplateArguments";
        case ifc::ExprSort::Tokens: return "Tokens";
        case ifc::ExprSort::AssignInitializer: return "AssignInitializer";
        case ifc::ExprSort::Count: return "Count";

        default: return "<unnamed>";
    }
}

constexpr std::string_view to_string( const ifc::symbolic::TypeBasis val ) noexcept
{
    switch ( val )
    {
        case ifc::symbolic::TypeBasis::Void: return "Void";
        case ifc::symbolic::TypeBasis::Bool: return "Bool";
        case ifc::symbolic::TypeBasis::Char: return "Char";
        case ifc::symbolic::TypeBasis::Wchar_t: return "Wchar_t";
        case ifc::symbolic::TypeBasis::Int: return "Int";
        case ifc::symbolic::TypeBasis::Float: return "Float";
        case ifc::symbolic::TypeBasis::Double: return "Double";
        case ifc::symbolic::TypeBasis::Nullptr: return "Nullptr";
        case ifc::symbolic::TypeBasis::Ellipsis: return "Ellipsis";
        case ifc::symbolic::TypeBasis::SegmentType: return "SegmentType";
        case ifc::symbolic::TypeBasis::Class: return "Class";
        case ifc::symbolic::TypeBasis::Struct: return "Struct";
        case ifc::symbolic::TypeBasis::Union: return "Union";
        case ifc::symbolic::TypeBasis::Enum: return "Enum";
        case ifc::symbolic::TypeBasis::Typename: return "Typename";
        case ifc::symbolic::TypeBasis::Namespace: return "Namespace";
        case ifc::symbolic::TypeBasis::Interface: return "Interface";
        case ifc::symbolic::TypeBasis::Function: return "Function";
        case ifc::symbolic::TypeBasis::Empty: return "Empty";
        case ifc::symbolic::TypeBasis::VariableTemplate: return "VariableTemplate";
        case ifc::symbolic::TypeBasis::Concept: return "Concept";
        case ifc::symbolic::TypeBasis::Auto: return "Auto";
        case ifc::symbolic::TypeBasis::DecltypeAuto: return "DecltypeAuto";
        case ifc::symbolic::TypeBasis::Overload: return "Overload";
        case ifc::symbolic::TypeBasis::Count: return "Count";

        default: return "<unnamed>";
    }
}

template<class T>
void print( const std::string& prefix, const T t )
{
    std::cout << prefix << to_string( t ) << std::endl;
}

std::string join( const std::vector<std::string>& strings, const std::string& delimiter )
{
    return strings | std::views::join_with( delimiter ) | std::ranges::to<std::string>();
}

struct GetStringViewFunctor
{
    std::string_view operator()( const ifc::Reader& reader, const ifc::symbolic::Identity<ifc::NameIndex> nameIndexId ) const
    {
        return reader.get( ifc::TextOffset( nameIndexId.name.index() ) );
    }

    std::string_view operator()( const ifc::Reader& reader, const ifc::symbolic::Identity<ifc::TextOffset> textOffsetId ) const
    {
        return reader.get( textOffsetId.name );
    }
};

constexpr inline GetStringViewFunctor getStringView = GetStringViewFunctor{};

std::string getString( const ifc::Reader& reader, const ifc::symbolic::Identity<ifc::NameIndex> nameIndexId )
{
    assert( nameIndexId.name.sort() == ifc::NameSort::Identifier );
    return reader.get( ifc::TextOffset( nameIndexId.name.index() ) );
}

std::string getString( const ifc::Reader& reader, const ifc::symbolic::Identity<ifc::TextOffset> textOffsetId )
{
    return reader.get( textOffsetId.name );
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

    return "";
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

template<class T, class U>
using Ptm = T U::*;

template<index_like::MultiSorted TIndex>
struct Magic;

template<class TIndex, class UIndex>
struct EitherMagic
{
    const ifc::Reader& reader;
    const TIndex index1{};
    const UIndex index2{};
    const bool first{};

    template<class F>
    auto visit( F&& f ) const
    {
        if ( first )
        {
            return f( index1 );
        }
        else
        {
            return f( index2 );
        }
    }

    index_like::Index rawIndex() const noexcept
    {
        if ( first )
        {
            return index1;
        }
        else
        {
            return index2;
        }
    }
};

template<class TSort>
void sameSortOrThrow( const TSort a, const TSort b )
{
    assert( a == b );
    if ( a != b )
    {
        throw std::runtime_error( "invalid sort" );
    }
}

template<class T>
struct MagicSequence
{
    const ifc::Reader& reader;
    const gsl::span<const T> span{};

    const Magic<T> operator[]( size_t index ) const
    {
        return Magic( reader, span[index] );
    }
};

template<index_like::MultiSorted TIndex>
struct OptionalMagic
{
    const ifc::Reader& reader;
    const TIndex index{};

    operator bool() const noexcept
    {
        return not index_like::null( index );
    }

    template<index_like::Fiber U, index_like::MultiSorted UIndex>
    OptionalMagic<UIndex> tryGet( Ptm<UIndex, U> ptm ) const
    {
        if ( index.sort() == U::algebra_sort )
        {
            const auto& ref = reader.get<U>( index );
            return { reader, ref.*ptm };
        }

        return { reader, UIndex{} };
    }

    template<index_like::Fiber U, index_like::MultiSorted UIndex>
    OptionalMagic<UIndex> get( Ptm<UIndex, U> ptm ) const
    {
        if ( *this )
        {
            sameSortOrThrow( index.sort(), U::algebra_sort );
            const auto& ref = reader.get<U>( index );
            return { reader, ref.*ptm };
        }

        return { reader, UIndex{} };
    }

    template<index_like::Fiber U>
    std::optional<std::reference_wrapper<U>> get() const
    {
        if ( *this )
        {
            sameSortOrThrow( index.sort(), U::algebra_sort );
            return reader.get<U>( index );
        }

        return { reader, decltype( U::algebra_sort ){} };
    }

    template<std::invocable<decltype( reader ), decltype( index )> F>
    auto visit( F&& f ) -> std::optional<std::invoke_result_t<F, decltype( reader ), decltype( index )>> const
    {
        if ( *this )
        {
            return std::optional( f( reader, index ) );
        }

        return {};
    }
};

template<index_like::MultiSorted TIndex>
struct Magic
{
    const ifc::Reader& reader;
    const TIndex index{};

    template<index_like::Fiber U, index_like::MultiSorted UIndex>
    Magic<UIndex> get( Ptm<UIndex, U> ptm ) const
    {
        sameSortOrThrow( index.sort(), U::algebra_sort );
        const auto& ref = reader.get<U>( index );
        return { reader, ref.*ptm };
    }

    template<index_like::Fiber U>
    const U& get() const
    {
        sameSortOrThrow( index.sort(), U::algebra_sort );
        return reader.get<U>( index );
    }

    template<index_like::Fiber U, index_like::MultiSorted UIndex>
    OptionalMagic<UIndex> tryGet( Ptm<UIndex, U> ptm ) const
    {
        if ( index.sort() == U::algebra_sort )
        {
            const auto& ref = reader.get<U>( index );
            return { reader, ref.*ptm };
        }

        return { reader, UIndex{} };
    }

#if 0
    //template<index_like::MultiSorted E, HeapSort Tag>

    //template<typename<typename...> TS, typename T, typename... Args>
    template<typename T>
    struct extract_value_type;

    template<template <typename, typename ...> class C, typename T, typename ...Args>
    struct extract_value_type<C<T, Args...>>   //specialization
    {
        typedef T value_type;
    };

    /*template<template <int> typename T, int N>
    struct SequenceT*/

    template<template <int> typename T, int N>
    constexpr int extract( const T<N>& )
    {
        return N;
    }

    //template<class U, class E = typename extract_value_type<U>::value_type>
    //MagicSequence<E> sequence() const
    //{
    //    // reader.sequence( reader.get<U>( index ) )
    //    gsl::span<const ifc::TypeIndex> span;
    //    return MagicSequence<E>{ reader, span };
    //}
#endif

    template<class U>
    auto sequence() const
    {
        sameSortOrThrow( index.sort(), U::algebra_sort );
        return MagicSequence{ reader, reader.sequence( reader.get<U>( index ) ) };
    }

    template<index_like::Fiber U, index_like::Algebra UIndex>
        requires std::same_as<UIndex, ifc::TextOffset> or std::same_as<UIndex, ifc::NameIndex>
    std::string_view identity( Ptm<ifc::symbolic::Identity<UIndex>, U> ptm ) const
    {
        const auto& ref = reader.get<U>( index );
        return getStringView( reader, ref.*ptm );
    }

    //template<class U, index_like::Algebra UIndex, std::invocable<UIndex> F>
    //auto getVisit( Ptm<UIndex, U> ptm, F&& f ) const
    //{
    //    const auto& ref = reader.get<U>( index );
    //    return f( ref.*ptm );
    //}

    //template<class U, index_like::Algebra UIndex, std::invocable<decltype( reader ), UIndex> F>
    //auto getVisit( Ptm<UIndex, U> ptm, F&& f ) const
    //{
    //    const auto& ref = reader.get<U>( index );
    //    return f( reader, ref.*ptm );
    //}

    template<class F>
    auto visit( F&& f ) const
    {
        if constexpr ( std::invocable<F, decltype( reader ), decltype( index )> )
        {
            return f( reader, index );
        }
        else
        {
            return f( index );
        }
    }

    template<index_like::Fiber U1, index_like::Fiber U2, class T1, class T2>
    EitherMagic<T1, T2> either( Ptm<T1, U1> ptm1, Ptm<T2, U2> ptm2 ) const
    {
        if ( index.sort() == U1::algebra_sort )
        {
            const auto& ref = reader.get<U1>( index );
            return { reader, ref.*ptm1, {}, true };
        }
        else
        {
            assert( index.sort() == U2::algebra_sort );
            const auto& ref = reader.get<U2>( index );
            return { reader, {}, ref.*ptm2, false };
        }
    }

    //template<index_like::Fiber U1, class U1Index, index_like::Fiber U2>
    //Magic<U1> flat( Ptm<U1Index, U1> ptm1, Ptm<U1Index, U2> ptm2 ) const
    //{
    //    if ( index.sort() == U1::algebra_sort )
    //    {
    //        const auto& ref = reader.get<U1>( index );
    //        return { reader, ref.*ptm1 };
    //    }
    //    else
    //    {
    //        asert( index.sort() == U2::algebra_sort );
    //        const auto& ref = reader.get<U2>( index );
    //        return { reader, ref.*ptm2 };
    //    }
    //}
};

template<class... Ts>
struct overloaded : Ts...
{
    using Ts::operator()...;
};

std::string_view getSyntacticTemplateName( const ifc::Reader& reader, const ifc::ExprIndex primaryTemplate )
{
    return Magic( reader, primaryTemplate )
        .get( &ifc::symbolic::NamedDeclExpr::decl )
        .either<ifc::symbolic::TemplateDecl>( &ifc::symbolic::TemplateDecl::identity, &ifc::symbolic::AliasDecl::identity )
        .visit( overloaded{
            [&]( const ifc::symbolic::Identity<ifc::NameIndex>& identity ) { return getStringView( reader, identity ); },
            [&]( const ifc::symbolic::Identity<ifc::TextOffset>& identity ) { return getStringView( reader, identity ); }
        } );
}

std::string getFullTypeNameFromSyntacticTemplate( const ifc::Reader& reader, const ifc::TypeIndex syntacticIndex ) // incomplete/best-effort
{
    const auto& templateIdExpr = Magic( reader, syntacticIndex )
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

    throw std::runtime_error( "LiteralSort not implemented" );
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
            //assert( false );
            typeNameList.emplace_back( "(TODO: " + to_string( typeIndex.sort() ) + ")" );
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
            return std::string( to_string( reader.get<ifc::symbolic::FundamentalType>( typeIndex ).basis ) );

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

    return "(TODO: " + to_string( typeIndex.sort() ) + ")";
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

constexpr std::optional<std::string_view> enumBaseToCS( const ifc::symbolic::FundamentalType& type )
{
    constexpr std::optional<std::string_view> empty;

    switch ( type.basis )
    {
        case ifc::symbolic::TypeBasis::Bool:
        case ifc::symbolic::TypeBasis::Char: return type.sign == ifc::symbolic::TypeSign::Unsigned ? "byte" : "sbyte";
        case ifc::symbolic::TypeBasis::Int: return type.sign == ifc::symbolic::TypeSign::Unsigned ? "uint" : empty;
        default: throw std::runtime_error( "unexpected enum base type" );
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
        if ( const auto base = enumBaseToCS( reader.get<ifc::symbolic::FundamentalType>( baseIndex ) ) )
        {
            os << " : " << base.value();
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

static constexpr std::string_view StdName = "std";
static constexpr std::string_view GslName = "gsl";

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

    void printVisitor( std::ostream& os, const Scope&, const size_t level, const std::string& qualifiedName ) const
    {
        os << std::string( level * 2, ' ' ) << qualifiedName << std::endl;
    }

    using Visitor = std::function<void( const Scope&, size_t, const std::string& )>;

    void scopeVisitor( const Visitor& visitor, const Scope& current, const size_t level, const std::string& qualifiedName ) const
    {
        visitor( current, level, qualifiedName );
        for ( const Scope& nested : current.Children )
        {
            if ( nested.IsNamespace )
            {
                const auto nestedQualifiedName = std::string( nested.Name );
                scopeVisitor( visitor, nested, level + 1, qualifiedName.empty() ? nestedQualifiedName : ( qualifiedName + "::" + nestedQualifiedName ) );
            }
        }
    }

    void visit( const Visitor& visitor ) const
    {
        for ( const Scope& topLevel : mTopLevel )
        {
            scopeVisitor( visitor, topLevel, 0, "" );
        }
    }

    void print( std::ostream& os ) const
    {
        //visit( std::bind_front( &ScopeInfo::printVisitor, this, os ) );
        visit( [&]( const Scope& current, const size_t level, const std::string& qualifiedName ) {
            printVisitor( os, current, level, qualifiedName );
        } );
    }

private:
    std::unique_ptr<ScopeMap> mNamespaces;
    std::unique_ptr<ScopeMap> mTypeScopes;
    std::vector<ScopeRef> mTopLevel;
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
        //if ( scope.has_value() )
        //{
        //    for ( auto parent = scope.value().get().Parent; parent.has_value(); parent = parent.value().get().Parent )
        //    {
        //        ++mNestingCount;
        //    }
        //}
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

    //size_t nestingCount() const noexcept
    //{
    //    return mNestingCount;
    //}

protected:
    std::reference_wrapper<ifc::Reader> mReader;
    std::string_view mName;
    ifc::DeclIndex mIndex{};
    std::optional<ScopeRef> mScope;
    //size_t mNestingCount{};
};

using InfoBaseRef = std::reference_wrapper<const InfoBase>;

template<class T>
class InfoBaseT : public InfoBase
{
public:
    InfoBaseT( ifc::Reader& reader, const T& decl, std::optional<ScopeRef> scope )
        : InfoBase( reader, getStringView( reader, decl.identity ), reader.index_of<ifc::DeclIndex>( decl ), scope )
        , mDecl( decl )
    {
    }

    const T& decl() const noexcept
    {
        return mDecl;
    }

protected:
    std::reference_wrapper<const T> mDecl;
};

class EnumInfo : public InfoBaseT<ifc::symbolic::EnumerationDecl>
{
public:
    using InfoBaseT::InfoBaseT;

    void writeCS( std::ostream& os ) const
    {
        enumToCS( mReader, mName, decl().initializer, decl().base, os );
    }
};

template<class OutIndex, class LeftIndex, index_like::Fiber U>
Magic<OutIndex> operator|( const Magic<LeftIndex>& left, Ptm<OutIndex, U> ptm )
{
    return left.tryGet( ptm );
}

template<class OutIndex, class LeftIndex, index_like::Fiber U>
Magic<OutIndex> operator&( const Magic<LeftIndex>& left, Ptm<OutIndex, U> ptm )
{
    return left.get( ptm );
}

class StructInfo : public InfoBaseT<ifc::symbolic::ScopeDecl>
{
public:
    using InfoBaseT::InfoBaseT;

    std::optional<std::string_view> primitiveTypeNameCS( const std::string& typeName ) const
    {
        static const std::unordered_map<std::string, std::string_view> mapping = {
            { "bool", "bool" },
            { "Bool", "bool" },
            { "uint8_t", "byte" },
            { "uint16_t", "ushort" },
            { "uint32_t", "uint" },
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
            const auto tagArgTypeDecl = Magic( reader, expr )
                .get( &ifc::symbolic::TypeExpr::denotation )
                .get( &ifc::symbolic::DesignatedType::decl );

            const auto tagArgTypeName = tagArgTypeDecl.identity( &ifc::symbolic::EnumerationDecl::identity );

            return { tagArgTypeDecl.index, tagArgTypeName };
        }

        EnumeratorIndexAndName extractEnumeratorIndexAndName( const ifc::Reader& reader, const ifc::ExprIndex expr )
        {
            const auto& tagArgNamedDeclExpr = reader.get<ifc::symbolic::NamedDeclExpr>( expr );

            const auto tagArgTypeDecl = Magic( reader, tagArgNamedDeclExpr.type )
                .get( &ifc::symbolic::DesignatedType::decl );

            const auto tagArgTypeName = tagArgTypeDecl.identity( &ifc::symbolic::EnumerationDecl::identity );

            const auto tagArgEnumeratorName = Magic( reader, tagArgNamedDeclExpr.decl )
                .identity( &ifc::symbolic::EnumeratorDecl::identity );

            return { { tagArgTypeDecl.index, tagArgTypeName }, tagArgNamedDeclExpr.decl, tagArgEnumeratorName };
        }

        StructIndexAndName extractSequenceType( const ifc::Reader& reader, const ifc::ExprIndex expr )
        {
            const auto tagArgTypeDecl = Magic( reader, expr )
                .get( &ifc::symbolic::TypeExpr::denotation )
                .get( &ifc::symbolic::DesignatedType::decl );

            const auto tagArgTypeName = tagArgTypeDecl.identity( &ifc::symbolic::ScopeDecl::identity );

            return { tagArgTypeDecl.index, tagArgTypeName };
        }

        void collect( const ifc::Reader& reader, const ifc::symbolic::BaseType& baseType )
        {
            const auto designated = Magic( reader, baseType.type ).tryGet( &ifc::symbolic::DesignatedType::decl );
            if ( designated )
            {
                return; // TODO check base?
            }

            const auto& templateIdExpr = Magic( reader, baseType.type )
                .get( &ifc::symbolic::SyntacticType::expr ).get<ifc::symbolic::TemplateIdExpr>();

            const auto name = getSyntacticTemplateName( reader, templateIdExpr.primary_template );

            if ( name == "Over" )
            {
                Over.emplace( extractEnumerationIndexAndName( reader, templateIdExpr.arguments ) );
            }
            else if ( name == "Tag" )
            {
                Tag.emplace( extractEnumeratorIndexAndName( reader, templateIdExpr.arguments ) );
            }
            else if ( name == "Sequence" )
            {
                const auto tuple = Magic( reader, templateIdExpr.arguments ).sequence<ifc::symbolic::TupleExpr>();

                if ( tuple.span.size() == 2 )
                {
                    const auto enumeratorIndex = tuple[1].get( &ifc::symbolic::PackedTemplateArgumentsExpr::arguments ).index;
                    std::optional<EnumeratorIndexAndName> enumerator;
                    if ( enumeratorIndex.sort() != ifc::ExprSort::Empty )
                    {
                        enumerator = extractEnumeratorIndexAndName( reader, enumeratorIndex );
                    }

                    Sequence.emplace( std::make_tuple( extractSequenceType( reader, tuple.span[0] ), enumerator ) );

                    MembersToInline.emplace_back( std::make_tuple<std::string_view, std::string_view>( "Index", "start" ) );
                    MembersToInline.emplace_back( std::make_tuple<std::string_view, std::string_view>( "Cardinality", "cardinality" ) );
                }
                else
                {
                    assert( false );
                }
            }
            else if ( name == "Location" )
            {
                Tag.emplace( extractEnumeratorIndexAndName( reader, templateIdExpr.arguments ) );
                MembersToInline.emplace_back( "SourceLocation", "locus" );
            }
            else if ( name == "LocationAndType" )
            {
                Tag.emplace( extractEnumeratorIndexAndName( reader, templateIdExpr.arguments ) );
                MembersToInline.emplace_back( std::make_tuple<std::string_view, std::string_view>( "SourceLocation", "locus" ) );
                MembersToInline.emplace_back( std::make_tuple<std::string_view, std::string_view>( "TypeIndex", "type" ) );
            }
            else if ( name == "constant_traits" || name == "AssociatedTrait" || name == "TraitTag" || name == "AttributeAssociation" )
            {
                // TODO?
            }
            else
            {
                assert( false );
            }
        }

        void collect( const ifc::Reader& reader, const ifc::symbolic::TupleType& tupleType )
        {
            for ( const auto& base : reader.sequence( tupleType ) )
            {
                collect( reader, reader.get<ifc::symbolic::BaseType>( base ) );
            }
        }

        void collect( const ifc::Reader& reader, ifc::TypeIndex baseIndex )
        {
            if ( baseIndex.sort() == ifc::TypeSort::Base )
            {
                collect( reader, reader.get<ifc::symbolic::BaseType>( baseIndex ) );
            }
            else if ( baseIndex.sort() == ifc::TypeSort::Tuple )
            {
                collect( reader, reader.get<ifc::symbolic::TupleType>( baseIndex ) );
            }
            else
            {
                assert( false );
            }
        }
    };

    void writeCS( std::ostream& os,
        const std::unordered_map<ifc::DeclIndex, InfoBaseRef>& infoByIndex,
        const std::function<std::span<std::string_view>( const StructInfo& referer, const InfoBase& referee )> getRefereeQualifier,
        const std::function<void( std::ostream& )> writeNested ) const
    {
        auto& reader = mReader.get();

        std::set<std::tuple<std::string, size_t>> inlineArrays;
        SpecialBaseTypes baseTypes;

        if ( not index_like::null( decl().base ) )
        {
            baseTypes.collect( reader, decl().base );

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

        for ( const auto& member : baseTypes.MembersToInline )
        {
            os << "    public ";
            if ( isReadonlyStruct )
            {
                os << "readonly ";
            }
            os << std::get<0>( member ) << ' ' << std::get<1>( member ) << ';' << std::endl;;
        }

        if ( baseTypes.Over.has_value() )
        {
            os << "    public readonly uint IndexAndSort;" << std::endl;
        }

        if ( const auto* initScope = reader.try_get( decl().initializer ) )
        {
            for ( const auto& innerDeclaration : reader.sequence( *initScope ) )
            {
                if ( innerDeclaration.index.sort() == ifc::DeclSort::Field )
                {
                    os << "    public ";
                    if ( isReadonlyStruct )
                    {
                        os << "readonly ";
                    }

                    const auto& innerDecl = reader.get<ifc::symbolic::FieldDecl>( innerDeclaration.index );
                    const std::string typeName = getTypeName( mReader, innerDecl.type );

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
                            for ( const auto& refereeQualifier : getRefereeQualifier( *this, foundIt->second ) )
                            {
                                os << refereeQualifier << "::";
                            }
                            found = true;
                        }
                    }
                    else if ( innerDecl.type.sort() == ifc::TypeSort::Array )
                    {
                        const auto arrayType = reader.get<ifc::symbolic::ArrayType>( innerDecl.type );
                        const auto bound = Magic( reader, arrayType.bound )
                            .get( &ifc::symbolic::LiteralExpr::value )
                            .visit( [&]( const ifc::LitIndex index ) {
                            return index.sort() == ifc::LiteralSort::Immediate
                                ? ifc::to_underlying( index.index() )
                                : gsl::narrow_cast<uint32_t>( reader.get<int64_t>( index ) );
                        }
                        );

                        const auto arrayTypeName = getTypeName( reader, arrayType.element );
                        translatedTypeName = arrayTypeName + std::to_string( bound );

                        inlineArrays.emplace( arrayTypeName, bound );
                        found = true;
                    }
                    else if ( innerDecl.type.sort() == ifc::TypeSort::Syntactic )
                    {
                        const auto& templateIdExpr = Magic( reader, innerDecl.type )
                            .get( &ifc::symbolic::SyntacticType::expr ).get<ifc::symbolic::TemplateIdExpr>();

                        const auto name = getSyntacticTemplateName( reader, templateIdExpr.primary_template );
                        if ( name == "array" )
                        {
                            const auto tuple = Magic( reader, templateIdExpr.arguments ).sequence<ifc::symbolic::TupleExpr>();
                            if ( tuple.span.size() == 2 )
                            {
                                const auto bound = tuple[1]
                                    .get( &ifc::symbolic::LiteralExpr::value )
                                    .visit( [&]( const ifc::LitIndex index ) {
                                    return index.sort() == ifc::LiteralSort::Immediate
                                        ? ifc::to_underlying( index.index() )
                                        : gsl::narrow_cast<uint32_t>( reader.get<int64_t>( index ) );
                                }
                                );

                                const auto typeDecl = tuple[0]
                                    .get( &ifc::symbolic::TypeExpr::denotation )
                                    .get( &ifc::symbolic::DesignatedType::decl );

                                if ( typeDecl.index.sort() == ifc::DeclSort::Alias )
                                {
                                    const auto alias = typeDecl.identity( &ifc::symbolic::AliasDecl::identity );
                                    const auto arrayTypeName = std::string( primitiveTypeNameCS( std::string( alias ) ).value_or( alias ) );

                                    translatedTypeName = arrayTypeName + std::to_string( bound );

                                    inlineArrays.emplace( arrayTypeName, bound );
                                    found = true;
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
                            assert( false );
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
                else
                {
                    // ignore other (e.g. Constructor)
                }
            }
        }
        else
        {
            assert( false );
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

int main()
{
    //std::string name = R"(d:\.projects\.unsorted\2024\CppEnumString\CppEnumStringTest\x64\Debug\ExportedEnums.ixx.ifc)";
    std::string name = R"(d:\.projects\.unsorted\2024\WrapAllInModuleTest\WrapAllInModuleTest\x64\Debug\Everything.ixx.ifc)";

    auto ifc = ifchelper::IfcReader::loadFile( name );
    auto& reader = ifc.reader();

    ScopeInfo scopeInfo;
    scopeInfo.collect( reader, true );
    scopeInfo.print( std::cout );

    std::vector<EnumInfo> enums;

    struct ScopeContent
    {
        std::deque<EnumInfo> enums;
        std::deque<StructInfo> structs;
    };

    std::unordered_map<ifc::DeclIndex, ScopeContent> infoByScope;
    std::unordered_map<ifc::DeclIndex, std::vector<std::string_view>> namesByIndex;
    std::unordered_map<ifc::DeclIndex, InfoBaseRef> infoByIndex;

    const auto inIfcNamespace = []( const std::optional<ScopeRef>& scope ) {
        return scope.has_value() and scope.value().get().hasTopLevel( "ifc" );
    };

    const auto ignoreTypeByName = []( const InfoBase& info ) {
        static const std::set<std::string_view> excluded = {
            { "Pathname", "InputIfc", "Reader", "NodeKey", "Node", "Loader" },
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
        if ( decl.type.sort() == ifc::TypeSort::Fundamental )
        {
            const auto& typeOfType = reader.get<ifc::symbolic::FundamentalType>( decl.type );
            if ( typeOfType.basis == ifc::symbolic::TypeBasis::Class || typeOfType.basis == ifc::symbolic::TypeBasis::Struct )
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
    }

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

    std::ostringstream os;

    os << "namespace ifc" << std::endl << '{' << std::endl;
    os << "public enum Index : uint { }" << std::endl << std::endl;

    os << "public class OverAttribute<T> : Attribute { }" << std::endl << std::endl;
    os << "public class TagAttribute : Attribute { }" << std::endl << std::endl;
    os << "public class TagAttribute<T>(T sort) : TagAttribute { }" << std::endl << std::endl;
    os << "public readonly struct Sequence<T> { public readonly Index start; public readonly Cardinality cardinality; }" << std::endl << std::endl;
    os << "public readonly struct Identity<T> { public readonly T name; public readonly ifc.source.SourceLocation locus; }" << std::endl << std::endl;

    int currentLevel = 0;
    scopeInfo.visit( [&]( const Scope& current, const size_t level, const std::string& ) {
        if ( not current.hasTopLevel( "ifc" ) ) return;

        if ( currentLevel < level )
        {
            assert( currentLevel + 1 == level );

            os << "namespace " << current.Name << std::endl << '{' << std::endl;
            ++currentLevel;
        }

        if ( const auto foundIt = infoByScope.find( current.Index ); foundIt != infoByScope.end() )
        {
            for ( const auto& enumInfo : foundIt->second.enums | std::views::filter( std::not_fn( ignoreTypeByName ) ) )
            {
                if ( enumInfo.scope().value().get().IsNamespace )
                {
                    enumInfo.writeCS( os );
                }
            }

            for ( const auto& structInfo : foundIt->second.structs | std::views::filter( std::not_fn( ignoreTypeByName ) ) )
            {
                structInfo.writeCS( os, infoByIndex, getRefereeQualifier, [&]( std::ostream& os ) {
                    // write nested
                    if ( const auto nestedIt = infoByScope.find( structInfo.index() ); nestedIt != infoByScope.end() )
                    {
                        for ( const auto& nestedEnumInfo : nestedIt->second.enums )
                        {
                            nestedEnumInfo.writeCS( os );
                        }

                        for ( const auto& nestedStructInfo : nestedIt->second.structs )
                        {
                            nestedStructInfo.writeCS( os, infoByIndex, getRefereeQualifier, {} );
                        }
                    }
                } );
            }
        }

        if ( level < currentLevel )
        {
            --currentLevel;
            os << '}' << std::endl;
        }
    } );

    while ( currentLevel-- >= 0 )
    {
        os << '}' << std::endl;
    }

    const auto code = os.str();
    std::cout << code;

    std::ofstream ofs( R"(d:\.projects\.unsorted\2024\StructFromSpanTest\StructFromSpanTest\Test.cs)", std::ios::binary );
    if ( ofs )
    {
        ofs.write( code.data(), code.size() );
    }
    ofs.close();

    std::cout << "// Found " << typeCount << " types." << std::endl;
    // assert( typeCount == 375 );

    //for ( const auto& [scope, infos] : infoByScope )
    //{
    //    for ( const auto& enumInfo : infos.enums )
    //    {
    //        std::cout << "Enum: " << enumInfo.name() << " in scope " << getTypeName( reader, scope ) << std::endl;
    //    }

    //    for ( const auto& typeInfo : infos.structs )
    //    {
    //        std::cout << "Type: " << typeInfo.name() << " in scope " << getTypeName( reader, scope ) << std::endl;
    //    }
    //}
}
