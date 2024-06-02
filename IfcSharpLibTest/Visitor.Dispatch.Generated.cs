using ifc;
using ifc.symbolic;
using IfcSharpLib;
using System.Runtime.CompilerServices;

namespace IfcSharpLibTest
{
    internal partial class TestVisitor
    {
        partial void Dispatch(ChildIndex childIndex)
        {
            switch (childIndex.Type)
            {
                case SortType.Name:
                    {
                        var index = childIndex.To<NameIndex>();
                        switch (index.Sort)
                        {
                            case NameSort.Operator:
                                VisitOperatorFunctionId(index);
                                break;
                            case NameSort.Conversion:
                                VisitConversionFunctionId(index);
                                break;
                            case NameSort.Literal:
                                VisitLiteralOperatorId(index);
                                break;
                            case NameSort.Template:
                                VisitTemplateName(index);
                                break;
                            case NameSort.Specialization:
                                VisitSpecializationName(index);
                                break;
                            case NameSort.SourceFile:
                                VisitSourceFileName(index);
                                break;
                            case NameSort.Guide:
                                VisitGuideName(index);
                                break;
                        }
                    }
                    break;
                case SortType.Chart:
                    {
                        var index = childIndex.To<ChartIndex>();
                        switch (index.Sort)
                        {
                            case ChartSort.Unilevel:
                                VisitUnilevelChart(index);
                                break;
                            case ChartSort.Multilevel:
                                VisitMultiChart(index);
                                break;
                        }
                    }
                    break;
                case SortType.Decl:
                    {
                        var index = childIndex.To<DeclIndex>();
                        switch (index.Sort)
                        {
                            case DeclSort.Enumerator:
                                VisitEnumeratorDecl(index);
                                break;
                            case DeclSort.Variable:
                                VisitVariableDecl(index);
                                break;
                            case DeclSort.Parameter:
                                VisitParameterDecl(index);
                                break;
                            case DeclSort.Field:
                                VisitFieldDecl(index);
                                break;
                            case DeclSort.Bitfield:
                                VisitBitfieldDecl(index);
                                break;
                            case DeclSort.Scope:
                                VisitScopeDecl(index);
                                break;
                            case DeclSort.Enumeration:
                                VisitEnumerationDecl(index);
                                break;
                            case DeclSort.Alias:
                                VisitAliasDecl(index);
                                break;
                            case DeclSort.Temploid:
                                VisitTemploidDecl(index);
                                break;
                            case DeclSort.Template:
                                VisitTemplateDecl(index);
                                break;
                            case DeclSort.PartialSpecialization:
                                VisitPartialSpecializationDecl(index);
                                break;
                            case DeclSort.Specialization:
                                VisitSpecializationDecl(index);
                                break;
                            case DeclSort.DefaultArgument:
                                VisitDefaultArgumentDecl(index);
                                break;
                            case DeclSort.Concept:
                                VisitConceptDecl(index);
                                break;
                            case DeclSort.Function:
                                VisitFunctionDecl(index);
                                break;
                            case DeclSort.Method:
                                VisitNonStaticMemberFunctionDecl(index);
                                break;
                            case DeclSort.Constructor:
                                VisitConstructorDecl(index);
                                break;
                            case DeclSort.InheritedConstructor:
                                VisitInheritedConstructorDecl(index);
                                break;
                            case DeclSort.Destructor:
                                VisitDestructorDecl(index);
                                break;
                            case DeclSort.Reference:
                                VisitReferenceDecl(index);
                                break;
                            case DeclSort.Using:
                                VisitUsingDecl(index);
                                break;
                            case DeclSort.Friend:
                                VisitFriendDecl(index);
                                break;
                            case DeclSort.Expansion:
                                VisitExpansionDecl(index);
                                break;
                            case DeclSort.DeductionGuide:
                                VisitDeductionGuideDecl(index);
                                break;
                            case DeclSort.Barren:
                                VisitBarrenDecl(index);
                                break;
                            case DeclSort.Tuple:
                                VisitTupleDecl(index);
                                break;
                            case DeclSort.SyntaxTree:
                                VisitSyntacticDecl(index);
                                break;
                            case DeclSort.Intrinsic:
                                VisitIntrinsicDecl(index);
                                break;
                            case DeclSort.Property:
                                VisitPropertyDecl(index);
                                break;
                            case DeclSort.OutputSegment:
                                VisitSegmentDecl(index);
                                break;
                        }
                    }
                    break;
                case SortType.Type:
                    {
                        var index = childIndex.To<TypeIndex>();
                        switch (index.Sort)
                        {
                            case TypeSort.Fundamental:
                                VisitFundamentalType(index);
                                break;
                            case TypeSort.Designated:
                                VisitDesignatedType(index);
                                break;
                            case TypeSort.Tor:
                                VisitTorType(index);
                                break;
                            case TypeSort.Syntactic:
                                VisitSyntacticType(index);
                                break;
                            case TypeSort.Expansion:
                                VisitExpansionType(index);
                                break;
                            case TypeSort.Pointer:
                                VisitPointerType(index);
                                break;
                            case TypeSort.PointerToMember:
                                VisitPointerToMemberType(index);
                                break;
                            case TypeSort.LvalueReference:
                                VisitLvalueReferenceType(index);
                                break;
                            case TypeSort.RvalueReference:
                                VisitRvalueReferenceType(index);
                                break;
                            case TypeSort.Function:
                                VisitFunctionType(index);
                                break;
                            case TypeSort.Method:
                                VisitMethodType(index);
                                break;
                            case TypeSort.Array:
                                VisitArrayType(index);
                                break;
                            case TypeSort.Typename:
                                VisitTypenameType(index);
                                break;
                            case TypeSort.Qualified:
                                VisitQualifiedType(index);
                                break;
                            case TypeSort.Base:
                                VisitBaseType(index);
                                break;
                            case TypeSort.Decltype:
                                VisitDecltypeType(index);
                                break;
                            case TypeSort.Placeholder:
                                VisitPlaceholderType(index);
                                break;
                            case TypeSort.Tuple:
                                VisitTupleType(index);
                                break;
                            case TypeSort.Forall:
                                VisitForallType(index);
                                break;
                            case TypeSort.Unaligned:
                                VisitUnalignedType(index);
                                break;
                            case TypeSort.SyntaxTree:
                                VisitSyntaxTreeType(index);
                                break;
                        }
                    }
                    break;
                case SortType.Syntax:
                    {
                        var index = childIndex.To<SyntaxIndex>();
                        switch (index.Sort)
                        {
                            case SyntaxSort.VendorExtension:
                                VisitVendorSyntax(index);
                                break;
                            case SyntaxSort.SimpleTypeSpecifier:
                                VisitSimpleTypeSpecifier(index);
                                break;
                            case SyntaxSort.DecltypeSpecifier:
                                VisitDecltypeSpecifier(index);
                                break;
                            case SyntaxSort.PlaceholderTypeSpecifier:
                                VisitPlaceholderTypeSpecifier(index);
                                break;
                            case SyntaxSort.TypeSpecifierSeq:
                                VisitTypeSpecifierSeq(index);
                                break;
                            case SyntaxSort.DeclSpecifierSeq:
                                VisitDeclSpecifierSeq(index);
                                break;
                            case SyntaxSort.VirtualSpecifierSeq:
                                VisitVirtualSpecifierSeq(index);
                                break;
                            case SyntaxSort.NoexceptSpecification:
                                VisitNoexceptSpecification(index);
                                break;
                            case SyntaxSort.ExplicitSpecifier:
                                VisitExplicitSpecifier(index);
                                break;
                            case SyntaxSort.EnumSpecifier:
                                VisitEnumSpecifier(index);
                                break;
                            case SyntaxSort.EnumeratorDefinition:
                                VisitEnumeratorDefinition(index);
                                break;
                            case SyntaxSort.ClassSpecifier:
                                VisitClassSpecifier(index);
                                break;
                            case SyntaxSort.MemberSpecification:
                                VisitMemberSpecification(index);
                                break;
                            case SyntaxSort.MemberDeclaration:
                                VisitMemberDeclaration(index);
                                break;
                            case SyntaxSort.MemberDeclarator:
                                VisitMemberDeclarator(index);
                                break;
                            case SyntaxSort.AccessSpecifier:
                                VisitAccessSpecifier(index);
                                break;
                            case SyntaxSort.BaseSpecifierList:
                                VisitBaseSpecifierList(index);
                                break;
                            case SyntaxSort.BaseSpecifier:
                                VisitBaseSpecifier(index);
                                break;
                            case SyntaxSort.TypeId:
                                VisitTypeId(index);
                                break;
                            case SyntaxSort.TrailingReturnType:
                                VisitTrailingReturnType(index);
                                break;
                            case SyntaxSort.Declarator:
                                VisitDeclarator(index);
                                break;
                            case SyntaxSort.PointerDeclarator:
                                VisitPointerDeclarator(index);
                                break;
                            case SyntaxSort.ArrayDeclarator:
                                VisitArrayDeclarator(index);
                                break;
                            case SyntaxSort.FunctionDeclarator:
                                VisitFunctionDeclarator(index);
                                break;
                            case SyntaxSort.ArrayOrFunctionDeclarator:
                                VisitArrayOrFunctionDeclarator(index);
                                break;
                            case SyntaxSort.ParameterDeclarator:
                                VisitParameterDeclarator(index);
                                break;
                            case SyntaxSort.InitDeclarator:
                                VisitInitDeclarator(index);
                                break;
                            case SyntaxSort.NewDeclarator:
                                VisitNewDeclarator(index);
                                break;
                            case SyntaxSort.SimpleDeclaration:
                                VisitSimpleDeclaration(index);
                                break;
                            case SyntaxSort.ExceptionDeclaration:
                                VisitExceptionDeclaration(index);
                                break;
                            case SyntaxSort.ConditionDeclaration:
                                VisitConditionDeclaration(index);
                                break;
                            case SyntaxSort.StaticAssertDeclaration:
                                VisitStaticAssertDeclaration(index);
                                break;
                            case SyntaxSort.AliasDeclaration:
                                VisitAliasDeclaration(index);
                                break;
                            case SyntaxSort.ConceptDefinition:
                                VisitConceptDefinition(index);
                                break;
                            case SyntaxSort.CompoundStatement:
                                VisitCompoundStatement(index);
                                break;
                            case SyntaxSort.ReturnStatement:
                                VisitReturnStatement(index);
                                break;
                            case SyntaxSort.IfStatement:
                                VisitIfStatement(index);
                                break;
                            case SyntaxSort.WhileStatement:
                                VisitWhileStatement(index);
                                break;
                            case SyntaxSort.DoWhileStatement:
                                VisitDoWhileStatement(index);
                                break;
                            case SyntaxSort.ForStatement:
                                VisitForStatement(index);
                                break;
                            case SyntaxSort.InitStatement:
                                VisitInitStatement(index);
                                break;
                            case SyntaxSort.RangeBasedForStatement:
                                VisitRangeBasedForStatement(index);
                                break;
                            case SyntaxSort.ForRangeDeclaration:
                                VisitForRangeDeclaration(index);
                                break;
                            case SyntaxSort.LabeledStatement:
                                VisitLabeledStatement(index);
                                break;
                            case SyntaxSort.BreakStatement:
                                VisitBreakStatement(index);
                                break;
                            case SyntaxSort.ContinueStatement:
                                VisitContinueStatement(index);
                                break;
                            case SyntaxSort.SwitchStatement:
                                VisitSwitchStatement(index);
                                break;
                            case SyntaxSort.GotoStatement:
                                VisitGotoStatement(index);
                                break;
                            case SyntaxSort.DeclarationStatement:
                                VisitDeclarationStatement(index);
                                break;
                            case SyntaxSort.ExpressionStatement:
                                VisitExpressionStatement(index);
                                break;
                            case SyntaxSort.TryBlock:
                                VisitTryBlock(index);
                                break;
                            case SyntaxSort.Handler:
                                VisitHandler(index);
                                break;
                            case SyntaxSort.HandlerSeq:
                                VisitHandlerSeq(index);
                                break;
                            case SyntaxSort.FunctionTryBlock:
                                VisitFunctionTryBlock(index);
                                break;
                            case SyntaxSort.TypeIdListElement:
                                VisitTypeIdListElement(index);
                                break;
                            case SyntaxSort.DynamicExceptionSpec:
                                VisitDynamicExceptionSpec(index);
                                break;
                            case SyntaxSort.StatementSeq:
                                VisitStatementSeq(index);
                                break;
                            case SyntaxSort.FunctionBody:
                                VisitFunctionBody(index);
                                break;
                            case SyntaxSort.Expression:
                                VisitExpression(index);
                                break;
                            case SyntaxSort.FunctionDefinition:
                                VisitFunctionDefinition(index);
                                break;
                            case SyntaxSort.MemberFunctionDeclaration:
                                VisitMemberFunctionDeclaration(index);
                                break;
                            case SyntaxSort.TemplateDeclaration:
                                VisitTemplateDeclaration(index);
                                break;
                            case SyntaxSort.RequiresClause:
                                VisitRequiresClause(index);
                                break;
                            case SyntaxSort.SimpleRequirement:
                                VisitSimpleRequirement(index);
                                break;
                            case SyntaxSort.TypeRequirement:
                                VisitTypeRequirement(index);
                                break;
                            case SyntaxSort.CompoundRequirement:
                                VisitCompoundRequirement(index);
                                break;
                            case SyntaxSort.NestedRequirement:
                                VisitNestedRequirement(index);
                                break;
                            case SyntaxSort.RequirementBody:
                                VisitRequirementBody(index);
                                break;
                            case SyntaxSort.TypeTemplateParameter:
                                VisitTypeTemplateParameter(index);
                                break;
                            case SyntaxSort.TemplateTemplateParameter:
                                VisitTemplateTemplateParameter(index);
                                break;
                            case SyntaxSort.TypeTemplateArgument:
                                VisitTypeTemplateArgument(index);
                                break;
                            case SyntaxSort.NonTypeTemplateArgument:
                                VisitNonTypeTemplateArgument(index);
                                break;
                            case SyntaxSort.TemplateParameterList:
                                VisitTemplateParameterList(index);
                                break;
                            case SyntaxSort.TemplateArgumentList:
                                VisitTemplateArgumentList(index);
                                break;
                            case SyntaxSort.TemplateId:
                                VisitTemplateId(index);
                                break;
                            case SyntaxSort.MemInitializer:
                                VisitMemInitializer(index);
                                break;
                            case SyntaxSort.CtorInitializer:
                                VisitCtorInitializer(index);
                                break;
                            case SyntaxSort.LambdaIntroducer:
                                VisitLambdaIntroducer(index);
                                break;
                            case SyntaxSort.LambdaDeclarator:
                                VisitLambdaDeclarator(index);
                                break;
                            case SyntaxSort.CaptureDefault:
                                VisitCaptureDefault(index);
                                break;
                            case SyntaxSort.SimpleCapture:
                                VisitSimpleCapture(index);
                                break;
                            case SyntaxSort.InitCapture:
                                VisitInitCapture(index);
                                break;
                            case SyntaxSort.ThisCapture:
                                VisitThisCapture(index);
                                break;
                            case SyntaxSort.AttributedStatement:
                                VisitAttributedStatement(index);
                                break;
                            case SyntaxSort.AttributedDeclaration:
                                VisitAttributedDeclaration(index);
                                break;
                            case SyntaxSort.AttributeSpecifierSeq:
                                VisitAttributeSpecifierSeq(index);
                                break;
                            case SyntaxSort.AttributeSpecifier:
                                VisitAttributeSpecifier(index);
                                break;
                            case SyntaxSort.AttributeUsingPrefix:
                                VisitAttributeUsingPrefix(index);
                                break;
                            case SyntaxSort.Attribute:
                                VisitAttribute(index);
                                break;
                            case SyntaxSort.AttributeArgumentClause:
                                VisitAttributeArgumentClause(index);
                                break;
                            case SyntaxSort.Alignas:
                                VisitAlignasSpecifier(index);
                                break;
                            case SyntaxSort.UsingDeclaration:
                                VisitUsingDeclaration(index);
                                break;
                            case SyntaxSort.UsingDeclarator:
                                VisitUsingDeclarator(index);
                                break;
                            case SyntaxSort.UsingDirective:
                                VisitUsingDirective(index);
                                break;
                            case SyntaxSort.ArrayIndex:
                                VisitArrayIndex(index);
                                break;
                            case SyntaxSort.SEHTry:
                                VisitSEHTry(index);
                                break;
                            case SyntaxSort.SEHExcept:
                                VisitSEHExcept(index);
                                break;
                            case SyntaxSort.SEHFinally:
                                VisitSEHFinally(index);
                                break;
                            case SyntaxSort.SEHLeave:
                                VisitSEHLeave(index);
                                break;
                            case SyntaxSort.TypeTraitIntrinsic:
                                VisitTypeTraitIntrinsic(index);
                                break;
                            case SyntaxSort.Tuple:
                                VisitTuple(index);
                                break;
                            case SyntaxSort.AsmStatement:
                                VisitAsmStatement(index);
                                break;
                            case SyntaxSort.NamespaceAliasDefinition:
                                VisitNamespaceAliasDefinition(index);
                                break;
                            case SyntaxSort.Super:
                                VisitSuper(index);
                                break;
                            case SyntaxSort.UnaryFoldExpression:
                                VisitUnaryFoldExpression(index);
                                break;
                            case SyntaxSort.BinaryFoldExpression:
                                VisitBinaryFoldExpression(index);
                                break;
                            case SyntaxSort.EmptyStatement:
                                VisitEmptyStatement(index);
                                break;
                            case SyntaxSort.StructuredBindingDeclaration:
                                VisitStructuredBindingDeclaration(index);
                                break;
                            case SyntaxSort.StructuredBindingIdentifier:
                                VisitStructuredBindingIdentifier(index);
                                break;
                            case SyntaxSort.UsingEnumDeclaration:
                                VisitUsingEnumDeclaration(index);
                                break;
                        }
                    }
                    break;
                case SortType.Stmt:
                    {
                        var index = childIndex.To<StmtIndex>();
                        switch (index.Sort)
                        {
                            case StmtSort.Try:
                                VisitTryStmt(index);
                                break;
                            case StmtSort.If:
                                VisitIfStmt(index);
                                break;
                            case StmtSort.For:
                                VisitForStmt(index);
                                break;
                            case StmtSort.Labeled:
                                VisitLabeledStmt(index);
                                break;
                            case StmtSort.While:
                                VisitWhileStmt(index);
                                break;
                            case StmtSort.Block:
                                VisitBlockStmt(index);
                                break;
                            case StmtSort.Break:
                                VisitBreakStmt(index);
                                break;
                            case StmtSort.Switch:
                                VisitSwitchStmt(index);
                                break;
                            case StmtSort.DoWhile:
                                VisitDoWhileStmt(index);
                                break;
                            case StmtSort.Goto:
                                VisitGotoStmt(index);
                                break;
                            case StmtSort.Continue:
                                VisitContinueStmt(index);
                                break;
                            case StmtSort.Expression:
                                VisitExpressionStmt(index);
                                break;
                            case StmtSort.Return:
                                VisitReturnStmt(index);
                                break;
                            case StmtSort.Decl:
                                VisitDeclStmt(index);
                                break;
                            case StmtSort.Expansion:
                                VisitExpansionStmt(index);
                                break;
                            case StmtSort.Handler:
                                VisitHandlerStmt(index);
                                break;
                            case StmtSort.Tuple:
                                VisitTupleStmt(index);
                                break;
                        }
                    }
                    break;
                case SortType.Expr:
                    {
                        var index = childIndex.To<ExprIndex>();
                        switch (index.Sort)
                        {
                            case ExprSort.Empty:
                                VisitEmptyExpr(index);
                                break;
                            case ExprSort.Literal:
                                VisitLiteralExpr(index);
                                break;
                            case ExprSort.Lambda:
                                VisitLambdaExpr(index);
                                break;
                            case ExprSort.Type:
                                VisitTypeExpr(index);
                                break;
                            case ExprSort.NamedDecl:
                                VisitNamedDeclExpr(index);
                                break;
                            case ExprSort.UnresolvedId:
                                VisitUnresolvedIdExpr(index);
                                break;
                            case ExprSort.TemplateId:
                                VisitTemplateIdExpr(index);
                                break;
                            case ExprSort.UnqualifiedId:
                                VisitUnqualifiedIdExpr(index);
                                break;
                            case ExprSort.SimpleIdentifier:
                                VisitSimpleIdentifierExpr(index);
                                break;
                            case ExprSort.Pointer:
                                VisitPointerExpr(index);
                                break;
                            case ExprSort.QualifiedName:
                                VisitQualifiedNameExpr(index);
                                break;
                            case ExprSort.Path:
                                VisitPathExpr(index);
                                break;
                            case ExprSort.Read:
                                VisitReadExpr(index);
                                break;
                            case ExprSort.Monad:
                                VisitMonadicExpr(index);
                                break;
                            case ExprSort.Dyad:
                                VisitDyadicExpr(index);
                                break;
                            case ExprSort.Triad:
                                VisitTriadicExpr(index);
                                break;
                            case ExprSort.String:
                                VisitStringExpr(index);
                                break;
                            case ExprSort.Temporary:
                                VisitTemporaryExpr(index);
                                break;
                            case ExprSort.Call:
                                VisitCallExpr(index);
                                break;
                            case ExprSort.MemberInitializer:
                                VisitMemberInitializerExpr(index);
                                break;
                            case ExprSort.MemberAccess:
                                VisitMemberAccessExpr(index);
                                break;
                            case ExprSort.InheritancePath:
                                VisitInheritancePathExpr(index);
                                break;
                            case ExprSort.InitializerList:
                                VisitInitializerListExpr(index);
                                break;
                            case ExprSort.Cast:
                                VisitCastExpr(index);
                                break;
                            case ExprSort.Condition:
                                VisitConditionExpr(index);
                                break;
                            case ExprSort.ExpressionList:
                                VisitExpressionListExpr(index);
                                break;
                            case ExprSort.SizeofType:
                                VisitSizeofTypeExpr(index);
                                break;
                            case ExprSort.Alignof:
                                VisitAlignofExpr(index);
                                break;
                            case ExprSort.Label:
                                VisitLabelExpr(index);
                                break;
                            case ExprSort.Typeid:
                                VisitTypeidExpr(index);
                                break;
                            case ExprSort.DestructorCall:
                                VisitDestructorCallExpr(index);
                                break;
                            case ExprSort.SyntaxTree:
                                VisitSyntaxTreeExpr(index);
                                break;
                            case ExprSort.FunctionString:
                                VisitFunctionStringExpr(index);
                                break;
                            case ExprSort.CompoundString:
                                VisitCompoundStringExpr(index);
                                break;
                            case ExprSort.StringSequence:
                                VisitStringSequenceExpr(index);
                                break;
                            case ExprSort.Initializer:
                                VisitInitializerExpr(index);
                                break;
                            case ExprSort.Requires:
                                VisitRequiresExpr(index);
                                break;
                            case ExprSort.UnaryFold:
                                VisitUnaryFoldExpr(index);
                                break;
                            case ExprSort.BinaryFold:
                                VisitBinaryFoldExpr(index);
                                break;
                            case ExprSort.HierarchyConversion:
                                VisitHierarchyConversionExpr(index);
                                break;
                            case ExprSort.ProductTypeValue:
                                VisitProductTypeValueExpr(index);
                                break;
                            case ExprSort.SumTypeValue:
                                VisitSumTypeValueExpr(index);
                                break;
                            case ExprSort.ArrayValue:
                                VisitArrayValueExpr(index);
                                break;
                            case ExprSort.DynamicDispatch:
                                VisitDynamicDispatchExpr(index);
                                break;
                            case ExprSort.VirtualFunctionConversion:
                                VisitVirtualFunctionConversionExpr(index);
                                break;
                            case ExprSort.Placeholder:
                                VisitPlaceholderExpr(index);
                                break;
                            case ExprSort.Expansion:
                                VisitExpansionExpr(index);
                                break;
                            case ExprSort.Tuple:
                                VisitTupleExpr(index);
                                break;
                            case ExprSort.Nullptr:
                                VisitNullptrExpr(index);
                                break;
                            case ExprSort.This:
                                VisitThisExpr(index);
                                break;
                            case ExprSort.TemplateReference:
                                VisitTemplateReferenceExpr(index);
                                break;
                            case ExprSort.Statement:
                                VisitStatementExpr(index);
                                break;
                            case ExprSort.TypeTraitIntrinsic:
                                VisitTypeTraitIntrinsicExpr(index);
                                break;
                            case ExprSort.DesignatedInitializer:
                                VisitDesignatedInitializerExpr(index);
                                break;
                            case ExprSort.PackedTemplateArguments:
                                VisitPackedTemplateArgumentsExpr(index);
                                break;
                            case ExprSort.Tokens:
                                VisitTokenExpr(index);
                                break;
                            case ExprSort.AssignInitializer:
                                VisitAssignInitializerExpr(index);
                                break;
                        }
                    }
                    break;
                case SortType.Macro:
                    {
                        var index = childIndex.To<MacroIndex>();
                        switch (index.Sort)
                        {
                            case MacroSort.ObjectLike:
                                VisitObjectLikeMacro(index);
                                break;
                            case MacroSort.FunctionLike:
                                VisitFunctionLikeMacro(index);
                                break;
                        }
                    }
                    break;
                case SortType.Pragma:
                    {
                        var index = childIndex.To<PragmaIndex>();
                        switch (index.Sort)
                        {
                            case PragmaSort.VendorExtension:
                                VisitPragmaComment(index);
                                break;
                        }
                    }
                    break;
                case SortType.Attr:
                    {
                        var index = childIndex.To<AttrIndex>();
                        switch (index.Sort)
                        {
                            case AttrSort.Basic:
                                VisitBasicAttr(index);
                                break;
                            case AttrSort.Scoped:
                                VisitScopedAttr(index);
                                break;
                            case AttrSort.Labeled:
                                VisitLabeledAttr(index);
                                break;
                            case AttrSort.Called:
                                VisitCalledAttr(index);
                                break;
                            case AttrSort.Expanded:
                                VisitExpandedAttr(index);
                                break;
                            case AttrSort.Factored:
                                VisitFactoredAttr(index);
                                break;
                            case AttrSort.Elaborated:
                                VisitElaboratedAttr(index);
                                break;
                            case AttrSort.Tuple:
                                VisitTupleAttr(index);
                                break;
                        }
                    }
                    break;
                case SortType.Dir:
                    {
                        var index = childIndex.To<DirIndex>();
                        switch (index.Sort)
                        {
                            case DirSort.Empty:
                                VisitEmptyDir(index);
                                break;
                            case DirSort.Attribute:
                                VisitAttributeDir(index);
                                break;
                            case DirSort.Pragma:
                                VisitPragmaDir(index);
                                break;
                            case DirSort.Using:
                                VisitUsingDir(index);
                                break;
                            case DirSort.DeclUse:
                                VisitUsingDeclarationDir(index);
                                break;
                            case DirSort.Expr:
                                VisitExprDir(index);
                                break;
                            case DirSort.StructuredBinding:
                                VisitStructuredBindingDir(index);
                                break;
                            case DirSort.SpecifiersSpread:
                                VisitSpecifiersSpreadDir(index);
                                break;
                            case DirSort.Tuple:
                                VisitTupleDir(index);
                                break;
                        }
                    }
                    break;
                case SortType.Form:
                    {
                        var index = childIndex.To<FormIndex>();
                        switch (index.Sort)
                        {
                            case FormSort.Identifier:
                                VisitIdentifierForm(index);
                                break;
                            case FormSort.Number:
                                VisitNumberForm(index);
                                break;
                            case FormSort.Character:
                                VisitCharacterForm(index);
                                break;
                            case FormSort.String:
                                VisitStringForm(index);
                                break;
                            case FormSort.Operator:
                                VisitOperatorForm(index);
                                break;
                            case FormSort.Keyword:
                                VisitKeywordForm(index);
                                break;
                            case FormSort.Whitespace:
                                VisitWhitespaceForm(index);
                                break;
                            case FormSort.Parameter:
                                VisitParameterForm(index);
                                break;
                            case FormSort.Stringize:
                                VisitStringizeForm(index);
                                break;
                            case FormSort.Catenate:
                                VisitCatenateForm(index);
                                break;
                            case FormSort.Pragma:
                                VisitPragmaForm(index);
                                break;
                            case FormSort.Header:
                                VisitHeaderForm(index);
                                break;
                            case FormSort.Parenthesized:
                                VisitParenthesizedForm(index);
                                break;
                            case FormSort.Tuple:
                                VisitTupleForm(index);
                                break;
                            case FormSort.Junk:
                                VisitJunkForm(index);
                                break;
                        }
                    }
                    break;
            }
        }
    }
}
