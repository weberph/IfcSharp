#include <ifc/abstract-sgraph.hxx>

#include <string_view>

namespace ifchelper
{
    std::string_view to_string( const ifc::TypeSort val ) noexcept
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

    std::string_view to_string( const ifc::DeclSort val ) noexcept
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

    std::string_view to_string( const ifc::ExprSort val ) noexcept
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

    std::string_view to_string( const ifc::symbolic::TypeBasis val ) noexcept
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
}
