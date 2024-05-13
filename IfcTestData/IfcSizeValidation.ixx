// hash: f6dae4935db8e23cfec7bc0b9ad6c11c3e10d3203ec124697094a8a03f27961e

module;

#include <ifc/abstract-sgraph.hxx>

export module IfcSizeValidation;

export {
namespace ifc
{
// ifc - 
constexpr inline size_t FormatVersionSize = sizeof(FormatVersion);
// ifc - 
constexpr inline size_t SHA256HashSize = sizeof(SHA256Hash);
// ifc - 
constexpr inline size_t UnitIndexSize = sizeof(UnitIndex);
// ifc - 
constexpr inline size_t HeaderSize = sizeof(Header);
// ifc - 
constexpr inline size_t PartitionSummaryDataSize = sizeof(PartitionSummaryData);
// ifc - 
constexpr inline size_t IntegrityCheckFailedSize = sizeof(IntegrityCheckFailed);
// ifc - 
constexpr inline size_t UnsupportedFormatVersionSize = sizeof(UnsupportedFormatVersion);
// ifc - 
constexpr inline size_t PPOperatorSize = sizeof(PPOperator);
// ifc - 
constexpr inline size_t OperatorSize = sizeof(Operator);
// ifc - 
constexpr inline size_t FormIndexSize = sizeof(FormIndex);
// ifc - 
constexpr inline size_t StringIndexSize = sizeof(StringIndex);
// ifc - 
constexpr inline size_t NameIndexSize = sizeof(NameIndex);
// ifc - 
constexpr inline size_t ChartIndexSize = sizeof(ChartIndex);
// ifc - 
constexpr inline size_t DeclIndexSize = sizeof(DeclIndex);
// ifc - 
constexpr inline size_t TypeIndexSize = sizeof(TypeIndex);
// ifc - 
constexpr inline size_t SyntaxIndexSize = sizeof(SyntaxIndex);
// ifc - 
constexpr inline size_t LitIndexSize = sizeof(LitIndex);
// ifc - 
constexpr inline size_t StmtIndexSize = sizeof(StmtIndex);
// ifc - 
constexpr inline size_t ExprIndexSize = sizeof(ExprIndex);
// ifc - 
constexpr inline size_t MacroIndexSize = sizeof(MacroIndex);
// ifc - 
constexpr inline size_t PragmaIndexSize = sizeof(PragmaIndex);
// ifc - 
constexpr inline size_t AttrIndexSize = sizeof(AttrIndex);
// ifc - 
constexpr inline size_t DirIndexSize = sizeof(DirIndex);
// ifc - 
constexpr inline size_t TraitOrderingSize = sizeof(TraitOrdering);
// ifc - 
constexpr inline size_t TableOfContentsSize = sizeof(TableOfContents);
namespace source
{
}

namespace symbolic
{
// symbolic - symbolic
constexpr inline size_t DeclarationSize = sizeof(Declaration);
// symbolic - symbolic
constexpr inline size_t ConversionFunctionIdSize = sizeof(ConversionFunctionId);
// symbolic - symbolic
constexpr inline size_t OperatorFunctionIdSize = sizeof(OperatorFunctionId);
// symbolic - symbolic
constexpr inline size_t LiteralOperatorIdSize = sizeof(LiteralOperatorId);
// symbolic - symbolic
constexpr inline size_t TemplateNameSize = sizeof(TemplateName);
// symbolic - symbolic
constexpr inline size_t SpecializationNameSize = sizeof(SpecializationName);
// symbolic - symbolic
constexpr inline size_t SourceFileNameSize = sizeof(SourceFileName);
// symbolic - symbolic
constexpr inline size_t GuideNameSize = sizeof(GuideName);
// symbolic - symbolic
constexpr inline size_t ModuleReferenceSize = sizeof(ModuleReference);
// symbolic - symbolic
constexpr inline size_t SourceLocationSize = sizeof(SourceLocation);
// symbolic - symbolic
constexpr inline size_t WordSize = sizeof(Word);
// symbolic - symbolic
constexpr inline size_t WordSequenceSize = sizeof(WordSequence);
// symbolic - symbolic
constexpr inline size_t NoexceptSpecificationSize = sizeof(NoexceptSpecification);
// symbolic - symbolic
constexpr inline size_t FundamentalTypeSize = sizeof(FundamentalType);
// symbolic - symbolic
constexpr inline size_t DesignatedTypeSize = sizeof(DesignatedType);
// symbolic - symbolic
constexpr inline size_t TorTypeSize = sizeof(TorType);
// symbolic - symbolic
constexpr inline size_t SyntacticTypeSize = sizeof(SyntacticType);
// symbolic - symbolic
constexpr inline size_t ExpansionTypeSize = sizeof(ExpansionType);
// symbolic - symbolic
constexpr inline size_t PointerTypeSize = sizeof(PointerType);
// symbolic - symbolic
constexpr inline size_t LvalueReferenceTypeSize = sizeof(LvalueReferenceType);
// symbolic - symbolic
constexpr inline size_t RvalueReferenceTypeSize = sizeof(RvalueReferenceType);
// symbolic - symbolic
constexpr inline size_t UnalignedTypeSize = sizeof(UnalignedType);
// symbolic - symbolic
constexpr inline size_t DecltypeTypeSize = sizeof(DecltypeType);
// symbolic - symbolic
constexpr inline size_t PlaceholderTypeSize = sizeof(PlaceholderType);
// symbolic - symbolic
constexpr inline size_t PointerToMemberTypeSize = sizeof(PointerToMemberType);
// symbolic - symbolic
constexpr inline size_t TupleTypeSize = sizeof(TupleType);
// symbolic - symbolic
constexpr inline size_t ForallTypeSize = sizeof(ForallType);
// symbolic - symbolic
constexpr inline size_t FunctionTypeSize = sizeof(FunctionType);
// symbolic - symbolic
constexpr inline size_t MethodTypeSize = sizeof(MethodType);
// symbolic - symbolic
constexpr inline size_t ArrayTypeSize = sizeof(ArrayType);
// symbolic - symbolic
constexpr inline size_t QualifiedTypeSize = sizeof(QualifiedType);
// symbolic - symbolic
constexpr inline size_t TypenameTypeSize = sizeof(TypenameType);
// symbolic - symbolic
constexpr inline size_t BaseTypeSize = sizeof(BaseType);
// symbolic - symbolic
constexpr inline size_t SyntaxTreeTypeSize = sizeof(SyntaxTreeType);
// symbolic - symbolic
constexpr inline size_t FileAndLineSize = sizeof(FileAndLine);
// symbolic - symbolic
constexpr inline size_t ParameterizedEntitySize = sizeof(ParameterizedEntity);
// symbolic - symbolic
constexpr inline size_t SpecializationFormSize = sizeof(SpecializationForm);
// symbolic - symbolic
constexpr inline size_t MappingDefinitionSize = sizeof(MappingDefinition);
// symbolic - symbolic
constexpr inline size_t FunctionDeclSize = sizeof(FunctionDecl);
// symbolic - symbolic
constexpr inline size_t IntrinsicDeclSize = sizeof(IntrinsicDecl);
// symbolic - symbolic
constexpr inline size_t EnumeratorDeclSize = sizeof(EnumeratorDecl);
// symbolic - symbolic
constexpr inline size_t ParameterDeclSize = sizeof(ParameterDecl);
// symbolic - symbolic
constexpr inline size_t VariableDeclSize = sizeof(VariableDecl);
// symbolic - symbolic
constexpr inline size_t FieldDeclSize = sizeof(FieldDecl);
// symbolic - symbolic
constexpr inline size_t BitfieldDeclSize = sizeof(BitfieldDecl);
// symbolic - symbolic
constexpr inline size_t ScopeDeclSize = sizeof(ScopeDecl);
// symbolic - symbolic
constexpr inline size_t EnumerationDeclSize = sizeof(EnumerationDecl);
// symbolic - symbolic
constexpr inline size_t AliasDeclSize = sizeof(AliasDecl);
// symbolic - symbolic
constexpr inline size_t TemploidDeclSize = sizeof(TemploidDecl);
// symbolic - symbolic
constexpr inline size_t TemplateSize = sizeof(Template);
// symbolic - symbolic
constexpr inline size_t TemplateDeclSize = sizeof(TemplateDecl);
// symbolic - symbolic
constexpr inline size_t PartialSpecializationDeclSize = sizeof(PartialSpecializationDecl);
// symbolic - symbolic
constexpr inline size_t SpecializationDeclSize = sizeof(SpecializationDecl);
// symbolic - symbolic
constexpr inline size_t DefaultArgumentDeclSize = sizeof(DefaultArgumentDecl);
// symbolic - symbolic
constexpr inline size_t ConceptDeclSize = sizeof(ConceptDecl);
// symbolic - symbolic
constexpr inline size_t NonStaticMemberFunctionDeclSize = sizeof(NonStaticMemberFunctionDecl);
// symbolic - symbolic
constexpr inline size_t ConstructorDeclSize = sizeof(ConstructorDecl);
// symbolic - symbolic
constexpr inline size_t InheritedConstructorDeclSize = sizeof(InheritedConstructorDecl);
// symbolic - symbolic
constexpr inline size_t DestructorDeclSize = sizeof(DestructorDecl);
// symbolic - symbolic
constexpr inline size_t DeductionGuideDeclSize = sizeof(DeductionGuideDecl);
// symbolic - symbolic
constexpr inline size_t BarrenDeclSize = sizeof(BarrenDecl);
// symbolic - symbolic
constexpr inline size_t ReferenceDeclSize = sizeof(ReferenceDecl);
// symbolic - symbolic
constexpr inline size_t PropertyDeclSize = sizeof(PropertyDecl);
// symbolic - symbolic
constexpr inline size_t SegmentDeclSize = sizeof(SegmentDecl);
// symbolic - symbolic
constexpr inline size_t UsingDeclSize = sizeof(UsingDecl);
// symbolic - symbolic
constexpr inline size_t FriendDeclSize = sizeof(FriendDecl);
// symbolic - symbolic
constexpr inline size_t ExpansionDeclSize = sizeof(ExpansionDecl);
// symbolic - symbolic
constexpr inline size_t SyntacticDeclSize = sizeof(SyntacticDecl);
// symbolic - symbolic
constexpr inline size_t TupleDeclSize = sizeof(TupleDecl);
// symbolic - symbolic
constexpr inline size_t ScopeSize = sizeof(Scope);
// symbolic - symbolic
constexpr inline size_t UnilevelChartSize = sizeof(UnilevelChart);
// symbolic - symbolic
constexpr inline size_t MultiChartSize = sizeof(MultiChart);
// symbolic - symbolic
constexpr inline size_t BlockStmtSize = sizeof(BlockStmt);
// symbolic - symbolic
constexpr inline size_t TryStmtSize = sizeof(TryStmt);
// symbolic - symbolic
constexpr inline size_t ExpressionStmtSize = sizeof(ExpressionStmt);
// symbolic - symbolic
constexpr inline size_t IfStmtSize = sizeof(IfStmt);
// symbolic - symbolic
constexpr inline size_t WhileStmtSize = sizeof(WhileStmt);
// symbolic - symbolic
constexpr inline size_t DoWhileStmtSize = sizeof(DoWhileStmt);
// symbolic - symbolic
constexpr inline size_t ForStmtSize = sizeof(ForStmt);
// symbolic - symbolic
constexpr inline size_t BreakStmtSize = sizeof(BreakStmt);
// symbolic - symbolic
constexpr inline size_t ContinueStmtSize = sizeof(ContinueStmt);
// symbolic - symbolic
constexpr inline size_t GotoStmtSize = sizeof(GotoStmt);
// symbolic - symbolic
constexpr inline size_t SwitchStmtSize = sizeof(SwitchStmt);
// symbolic - symbolic
constexpr inline size_t LabeledStmtSize = sizeof(LabeledStmt);
// symbolic - symbolic
constexpr inline size_t DeclStmtSize = sizeof(DeclStmt);
// symbolic - symbolic
constexpr inline size_t ReturnStmtSize = sizeof(ReturnStmt);
// symbolic - symbolic
constexpr inline size_t HandlerStmtSize = sizeof(HandlerStmt);
// symbolic - symbolic
constexpr inline size_t ExpansionStmtSize = sizeof(ExpansionStmt);
// symbolic - symbolic
constexpr inline size_t TupleStmtSize = sizeof(TupleStmt);
// symbolic - symbolic
constexpr inline size_t StringLiteralSize = sizeof(StringLiteral);
// symbolic - symbolic
constexpr inline size_t TypeExprSize = sizeof(TypeExpr);
// symbolic - symbolic
constexpr inline size_t StringExprSize = sizeof(StringExpr);
// symbolic - symbolic
constexpr inline size_t FunctionStringExprSize = sizeof(FunctionStringExpr);
// symbolic - symbolic
constexpr inline size_t CompoundStringExprSize = sizeof(CompoundStringExpr);
// symbolic - symbolic
constexpr inline size_t StringSequenceExprSize = sizeof(StringSequenceExpr);
// symbolic - symbolic
constexpr inline size_t UnresolvedIdExprSize = sizeof(UnresolvedIdExpr);
// symbolic - symbolic
constexpr inline size_t TemplateIdExprSize = sizeof(TemplateIdExpr);
// symbolic - symbolic
constexpr inline size_t TemplateReferenceExprSize = sizeof(TemplateReferenceExpr);
// symbolic - symbolic
constexpr inline size_t NamedDeclExprSize = sizeof(NamedDeclExpr);
// symbolic - symbolic
constexpr inline size_t LiteralExprSize = sizeof(LiteralExpr);
// symbolic - symbolic
constexpr inline size_t EmptyExprSize = sizeof(EmptyExpr);
// symbolic - symbolic
constexpr inline size_t PathExprSize = sizeof(PathExpr);
// symbolic - symbolic
constexpr inline size_t ReadExprSize = sizeof(ReadExpr);
// symbolic - symbolic
constexpr inline size_t MonadicExprSize = sizeof(MonadicExpr);
// symbolic - symbolic
constexpr inline size_t DyadicExprSize = sizeof(DyadicExpr);
// symbolic - symbolic
constexpr inline size_t TriadicExprSize = sizeof(TriadicExpr);
// symbolic - symbolic
constexpr inline size_t HierarchyConversionExprSize = sizeof(HierarchyConversionExpr);
// symbolic - symbolic
constexpr inline size_t DestructorCallExprSize = sizeof(DestructorCallExpr);
// symbolic - symbolic
constexpr inline size_t TupleExprSize = sizeof(TupleExpr);
// symbolic - symbolic
constexpr inline size_t PlaceholderExprSize = sizeof(PlaceholderExpr);
// symbolic - symbolic
constexpr inline size_t ExpansionExprSize = sizeof(ExpansionExpr);
// symbolic - symbolic
constexpr inline size_t TokenExprSize = sizeof(TokenExpr);
// symbolic - symbolic
constexpr inline size_t CallExprSize = sizeof(CallExpr);
// symbolic - symbolic
constexpr inline size_t TemporaryExprSize = sizeof(TemporaryExpr);
// symbolic - symbolic
constexpr inline size_t DynamicDispatchExprSize = sizeof(DynamicDispatchExpr);
// symbolic - symbolic
constexpr inline size_t VirtualFunctionConversionExprSize = sizeof(VirtualFunctionConversionExpr);
// symbolic - symbolic
constexpr inline size_t RequiresExprSize = sizeof(RequiresExpr);
// symbolic - symbolic
constexpr inline size_t UnaryFoldExprSize = sizeof(UnaryFoldExpr);
// symbolic - symbolic
constexpr inline size_t BinaryFoldExprSize = sizeof(BinaryFoldExpr);
// symbolic - symbolic
constexpr inline size_t StatementExprSize = sizeof(StatementExpr);
// symbolic - symbolic
constexpr inline size_t TypeTraitIntrinsicExprSize = sizeof(TypeTraitIntrinsicExpr);
// symbolic - symbolic
constexpr inline size_t MemberInitializerExprSize = sizeof(MemberInitializerExpr);
// symbolic - symbolic
constexpr inline size_t MemberAccessExprSize = sizeof(MemberAccessExpr);
// symbolic - symbolic
constexpr inline size_t InheritancePathExprSize = sizeof(InheritancePathExpr);
// symbolic - symbolic
constexpr inline size_t InitializerListExprSize = sizeof(InitializerListExpr);
// symbolic - symbolic
constexpr inline size_t InitializerExprSize = sizeof(InitializerExpr);
// symbolic - symbolic
constexpr inline size_t CastExprSize = sizeof(CastExpr);
// symbolic - symbolic
constexpr inline size_t ConditionExprSize = sizeof(ConditionExpr);
// symbolic - symbolic
constexpr inline size_t SimpleIdentifierExprSize = sizeof(SimpleIdentifierExpr);
// symbolic - symbolic
constexpr inline size_t PointerExprSize = sizeof(PointerExpr);
// symbolic - symbolic
constexpr inline size_t UnqualifiedIdExprSize = sizeof(UnqualifiedIdExpr);
// symbolic - symbolic
constexpr inline size_t QualifiedNameExprSize = sizeof(QualifiedNameExpr);
// symbolic - symbolic
constexpr inline size_t DesignatedInitializerExprSize = sizeof(DesignatedInitializerExpr);
// symbolic - symbolic
constexpr inline size_t ExpressionListExprSize = sizeof(ExpressionListExpr);
// symbolic - symbolic
constexpr inline size_t AssignInitializerExprSize = sizeof(AssignInitializerExpr);
// symbolic - symbolic
constexpr inline size_t SizeofTypeExprSize = sizeof(SizeofTypeExpr);
// symbolic - symbolic
constexpr inline size_t AlignofExprSize = sizeof(AlignofExpr);
// symbolic - symbolic
constexpr inline size_t LabelExprSize = sizeof(LabelExpr);
// symbolic - symbolic
constexpr inline size_t NullptrExprSize = sizeof(NullptrExpr);
// symbolic - symbolic
constexpr inline size_t ThisExprSize = sizeof(ThisExpr);
// symbolic - symbolic
constexpr inline size_t PackedTemplateArgumentsExprSize = sizeof(PackedTemplateArgumentsExpr);
// symbolic - symbolic
constexpr inline size_t LambdaExprSize = sizeof(LambdaExpr);
// symbolic - symbolic
constexpr inline size_t TypeidExprSize = sizeof(TypeidExpr);
// symbolic - symbolic
constexpr inline size_t SyntaxTreeExprSize = sizeof(SyntaxTreeExpr);
// symbolic - symbolic
constexpr inline size_t ProductTypeValueExprSize = sizeof(ProductTypeValueExpr);
// symbolic - symbolic
constexpr inline size_t SumTypeValueExprSize = sizeof(SumTypeValueExpr);
// symbolic - symbolic
constexpr inline size_t ArrayValueExprSize = sizeof(ArrayValueExpr);
// symbolic - symbolic
constexpr inline size_t ObjectLikeMacroSize = sizeof(ObjectLikeMacro);
// symbolic - symbolic
constexpr inline size_t FunctionLikeMacroSize = sizeof(FunctionLikeMacro);
// symbolic - symbolic
constexpr inline size_t PragmaWarningRegionSize = sizeof(PragmaWarningRegion);
// symbolic - symbolic
constexpr inline size_t IntegerLiteralSize = sizeof(IntegerLiteral);
// symbolic - symbolic
constexpr inline size_t LiteralRealSize = sizeof(LiteralReal);
// symbolic - symbolic
constexpr inline size_t FloatingPointLiteralSize = sizeof(FloatingPointLiteral);
// symbolic - symbolic
constexpr inline size_t PragmaPushStateSize = sizeof(PragmaPushState);
// symbolic - symbolic
constexpr inline size_t BasicAttrSize = sizeof(BasicAttr);
// symbolic - symbolic
constexpr inline size_t ScopedAttrSize = sizeof(ScopedAttr);
// symbolic - symbolic
constexpr inline size_t LabeledAttrSize = sizeof(LabeledAttr);
// symbolic - symbolic
constexpr inline size_t CalledAttrSize = sizeof(CalledAttr);
// symbolic - symbolic
constexpr inline size_t ExpandedAttrSize = sizeof(ExpandedAttr);
// symbolic - symbolic
constexpr inline size_t FactoredAttrSize = sizeof(FactoredAttr);
// symbolic - symbolic
constexpr inline size_t ElaboratedAttrSize = sizeof(ElaboratedAttr);
// symbolic - symbolic
constexpr inline size_t TupleAttrSize = sizeof(TupleAttr);
// symbolic - symbolic
constexpr inline size_t EmptyDirSize = sizeof(EmptyDir);
// symbolic - symbolic
constexpr inline size_t AttributeDirSize = sizeof(AttributeDir);
// symbolic - symbolic
constexpr inline size_t PragmaDirSize = sizeof(PragmaDir);
// symbolic - symbolic
constexpr inline size_t UsingDirSize = sizeof(UsingDir);
// symbolic - symbolic
constexpr inline size_t UsingDeclarationDirSize = sizeof(UsingDeclarationDir);
// symbolic - symbolic
constexpr inline size_t ExprDirSize = sizeof(ExprDir);
// symbolic - symbolic
constexpr inline size_t StructuredBindingDirSize = sizeof(StructuredBindingDir);
// symbolic - symbolic
constexpr inline size_t SpecifiersSpreadDirSize = sizeof(SpecifiersSpreadDir);
// symbolic - symbolic
constexpr inline size_t TupleDirSize = sizeof(TupleDir);
namespace syntax
{
// syntax - symbolic::syntax
constexpr inline size_t DecltypeSpecifierSize = sizeof(DecltypeSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t PlaceholderTypeSpecifierSize = sizeof(PlaceholderTypeSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t SimpleTypeSpecifierSize = sizeof(SimpleTypeSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t TypeSpecifierSeqSize = sizeof(TypeSpecifierSeq);
// syntax - symbolic::syntax
constexpr inline size_t KeywordSize = sizeof(Keyword);
// syntax - symbolic::syntax
constexpr inline size_t DeclSpecifierSeqSize = sizeof(DeclSpecifierSeq);
// syntax - symbolic::syntax
constexpr inline size_t EnumSpecifierSize = sizeof(EnumSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t EnumeratorDefinitionSize = sizeof(EnumeratorDefinition);
// syntax - symbolic::syntax
constexpr inline size_t ClassSpecifierSize = sizeof(ClassSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t BaseSpecifierListSize = sizeof(BaseSpecifierList);
// syntax - symbolic::syntax
constexpr inline size_t BaseSpecifierSize = sizeof(BaseSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t MemberSpecificationSize = sizeof(MemberSpecification);
// syntax - symbolic::syntax
constexpr inline size_t AccessSpecifierSize = sizeof(AccessSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t MemberDeclarationSize = sizeof(MemberDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t MemberDeclaratorSize = sizeof(MemberDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t TypeIdSize = sizeof(TypeId);
// syntax - symbolic::syntax
constexpr inline size_t TrailingReturnTypeSize = sizeof(TrailingReturnType);
// syntax - symbolic::syntax
constexpr inline size_t PointerDeclaratorSize = sizeof(PointerDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t ArrayDeclaratorSize = sizeof(ArrayDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t FunctionDeclaratorSize = sizeof(FunctionDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t ArrayOrFunctionDeclaratorSize = sizeof(ArrayOrFunctionDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t ParameterDeclaratorSize = sizeof(ParameterDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t VirtualSpecifierSeqSize = sizeof(VirtualSpecifierSeq);
// syntax - symbolic::syntax
constexpr inline size_t NoexceptSpecificationSize = sizeof(NoexceptSpecification);
// syntax - symbolic::syntax
constexpr inline size_t ExplicitSpecifierSize = sizeof(ExplicitSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t DeclaratorSize = sizeof(Declarator);
// syntax - symbolic::syntax
constexpr inline size_t InitDeclaratorSize = sizeof(InitDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t NewDeclaratorSize = sizeof(NewDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t SimpleDeclarationSize = sizeof(SimpleDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t ExceptionDeclarationSize = sizeof(ExceptionDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t ConditionDeclarationSize = sizeof(ConditionDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t StaticAssertDeclarationSize = sizeof(StaticAssertDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t AliasDeclarationSize = sizeof(AliasDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t ConceptDefinitionSize = sizeof(ConceptDefinition);
// syntax - symbolic::syntax
constexpr inline size_t StructuredBindingDeclarationSize = sizeof(StructuredBindingDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t StructuredBindingIdentifierSize = sizeof(StructuredBindingIdentifier);
// syntax - symbolic::syntax
constexpr inline size_t AsmStatementSize = sizeof(AsmStatement);
// syntax - symbolic::syntax
constexpr inline size_t ReturnStatementSize = sizeof(ReturnStatement);
// syntax - symbolic::syntax
constexpr inline size_t CompoundStatementSize = sizeof(CompoundStatement);
// syntax - symbolic::syntax
constexpr inline size_t IfStatementSize = sizeof(IfStatement);
// syntax - symbolic::syntax
constexpr inline size_t WhileStatementSize = sizeof(WhileStatement);
// syntax - symbolic::syntax
constexpr inline size_t DoWhileStatementSize = sizeof(DoWhileStatement);
// syntax - symbolic::syntax
constexpr inline size_t ForStatementSize = sizeof(ForStatement);
// syntax - symbolic::syntax
constexpr inline size_t InitStatementSize = sizeof(InitStatement);
// syntax - symbolic::syntax
constexpr inline size_t RangeBasedForStatementSize = sizeof(RangeBasedForStatement);
// syntax - symbolic::syntax
constexpr inline size_t ForRangeDeclarationSize = sizeof(ForRangeDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t LabeledStatementSize = sizeof(LabeledStatement);
// syntax - symbolic::syntax
constexpr inline size_t BreakStatementSize = sizeof(BreakStatement);
// syntax - symbolic::syntax
constexpr inline size_t ContinueStatementSize = sizeof(ContinueStatement);
// syntax - symbolic::syntax
constexpr inline size_t SwitchStatementSize = sizeof(SwitchStatement);
// syntax - symbolic::syntax
constexpr inline size_t GotoStatementSize = sizeof(GotoStatement);
// syntax - symbolic::syntax
constexpr inline size_t DeclarationStatementSize = sizeof(DeclarationStatement);
// syntax - symbolic::syntax
constexpr inline size_t ExpressionStatementSize = sizeof(ExpressionStatement);
// syntax - symbolic::syntax
constexpr inline size_t TryBlockSize = sizeof(TryBlock);
// syntax - symbolic::syntax
constexpr inline size_t HandlerSize = sizeof(Handler);
// syntax - symbolic::syntax
constexpr inline size_t HandlerSeqSize = sizeof(HandlerSeq);
// syntax - symbolic::syntax
constexpr inline size_t FunctionTryBlockSize = sizeof(FunctionTryBlock);
// syntax - symbolic::syntax
constexpr inline size_t TypeIdListElementSize = sizeof(TypeIdListElement);
// syntax - symbolic::syntax
constexpr inline size_t DynamicExceptionSpecSize = sizeof(DynamicExceptionSpec);
// syntax - symbolic::syntax
constexpr inline size_t StatementSeqSize = sizeof(StatementSeq);
// syntax - symbolic::syntax
constexpr inline size_t MemberFunctionDeclarationSize = sizeof(MemberFunctionDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t FunctionDefinitionSize = sizeof(FunctionDefinition);
// syntax - symbolic::syntax
constexpr inline size_t FunctionBodySize = sizeof(FunctionBody);
// syntax - symbolic::syntax
constexpr inline size_t ExpressionSize = sizeof(Expression);
// syntax - symbolic::syntax
constexpr inline size_t TemplateParameterListSize = sizeof(TemplateParameterList);
// syntax - symbolic::syntax
constexpr inline size_t TemplateDeclarationSize = sizeof(TemplateDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t RequiresClauseSize = sizeof(RequiresClause);
// syntax - symbolic::syntax
constexpr inline size_t SimpleRequirementSize = sizeof(SimpleRequirement);
// syntax - symbolic::syntax
constexpr inline size_t TypeRequirementSize = sizeof(TypeRequirement);
// syntax - symbolic::syntax
constexpr inline size_t CompoundRequirementSize = sizeof(CompoundRequirement);
// syntax - symbolic::syntax
constexpr inline size_t NestedRequirementSize = sizeof(NestedRequirement);
// syntax - symbolic::syntax
constexpr inline size_t RequirementBodySize = sizeof(RequirementBody);
// syntax - symbolic::syntax
constexpr inline size_t TypeTemplateParameterSize = sizeof(TypeTemplateParameter);
// syntax - symbolic::syntax
constexpr inline size_t TemplateTemplateParameterSize = sizeof(TemplateTemplateParameter);
// syntax - symbolic::syntax
constexpr inline size_t TypeTemplateArgumentSize = sizeof(TypeTemplateArgument);
// syntax - symbolic::syntax
constexpr inline size_t NonTypeTemplateArgumentSize = sizeof(NonTypeTemplateArgument);
// syntax - symbolic::syntax
constexpr inline size_t TemplateArgumentListSize = sizeof(TemplateArgumentList);
// syntax - symbolic::syntax
constexpr inline size_t TemplateIdSize = sizeof(TemplateId);
// syntax - symbolic::syntax
constexpr inline size_t MemInitializerSize = sizeof(MemInitializer);
// syntax - symbolic::syntax
constexpr inline size_t CtorInitializerSize = sizeof(CtorInitializer);
// syntax - symbolic::syntax
constexpr inline size_t CaptureDefaultSize = sizeof(CaptureDefault);
// syntax - symbolic::syntax
constexpr inline size_t SimpleCaptureSize = sizeof(SimpleCapture);
// syntax - symbolic::syntax
constexpr inline size_t InitCaptureSize = sizeof(InitCapture);
// syntax - symbolic::syntax
constexpr inline size_t ThisCaptureSize = sizeof(ThisCapture);
// syntax - symbolic::syntax
constexpr inline size_t LambdaIntroducerSize = sizeof(LambdaIntroducer);
// syntax - symbolic::syntax
constexpr inline size_t LambdaDeclaratorSize = sizeof(LambdaDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t UsingDeclarationSize = sizeof(UsingDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t UsingEnumDeclarationSize = sizeof(UsingEnumDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t UsingDeclaratorSize = sizeof(UsingDeclarator);
// syntax - symbolic::syntax
constexpr inline size_t UsingDirectiveSize = sizeof(UsingDirective);
// syntax - symbolic::syntax
constexpr inline size_t NamespaceAliasDefinitionSize = sizeof(NamespaceAliasDefinition);
// syntax - symbolic::syntax
constexpr inline size_t ArrayIndexSize = sizeof(ArrayIndex);
// syntax - symbolic::syntax
constexpr inline size_t TypeTraitIntrinsicSize = sizeof(TypeTraitIntrinsic);
// syntax - symbolic::syntax
constexpr inline size_t SEHTrySize = sizeof(SEHTry);
// syntax - symbolic::syntax
constexpr inline size_t SEHExceptSize = sizeof(SEHExcept);
// syntax - symbolic::syntax
constexpr inline size_t SEHFinallySize = sizeof(SEHFinally);
// syntax - symbolic::syntax
constexpr inline size_t SEHLeaveSize = sizeof(SEHLeave);
// syntax - symbolic::syntax
constexpr inline size_t SuperSize = sizeof(Super);
// syntax - symbolic::syntax
constexpr inline size_t UnaryFoldExpressionSize = sizeof(UnaryFoldExpression);
// syntax - symbolic::syntax
constexpr inline size_t BinaryFoldExpressionSize = sizeof(BinaryFoldExpression);
// syntax - symbolic::syntax
constexpr inline size_t EmptyStatementSize = sizeof(EmptyStatement);
// syntax - symbolic::syntax
constexpr inline size_t AttributedStatementSize = sizeof(AttributedStatement);
// syntax - symbolic::syntax
constexpr inline size_t AttributedDeclarationSize = sizeof(AttributedDeclaration);
// syntax - symbolic::syntax
constexpr inline size_t AttributeSpecifierSeqSize = sizeof(AttributeSpecifierSeq);
// syntax - symbolic::syntax
constexpr inline size_t AttributeSpecifierSize = sizeof(AttributeSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t AttributeUsingPrefixSize = sizeof(AttributeUsingPrefix);
// syntax - symbolic::syntax
constexpr inline size_t AttributeSize = sizeof(Attribute);
// syntax - symbolic::syntax
constexpr inline size_t AttributeArgumentClauseSize = sizeof(AttributeArgumentClause);
// syntax - symbolic::syntax
constexpr inline size_t AlignasSpecifierSize = sizeof(AlignasSpecifier);
// syntax - symbolic::syntax
constexpr inline size_t TupleSize = sizeof(Tuple);
namespace microsoft
{
// microsoft - symbolic::syntax::microsoft
constexpr inline size_t TypeOrExprOperandSize = sizeof(TypeOrExprOperand);
// microsoft - symbolic::syntax::microsoft
constexpr inline size_t DeclspecSize = sizeof(Declspec);
// microsoft - symbolic::syntax::microsoft
constexpr inline size_t BuiltinAddressOfSize = sizeof(BuiltinAddressOf);
// microsoft - symbolic::syntax::microsoft
constexpr inline size_t UUIDOfSize = sizeof(UUIDOf);
// microsoft - symbolic::syntax::microsoft
constexpr inline size_t IntrinsicSize = sizeof(Intrinsic);
// microsoft - symbolic::syntax::microsoft
constexpr inline size_t IfExistsSize = sizeof(IfExists);
// microsoft - symbolic::syntax::microsoft
constexpr inline size_t VendorSyntaxSize = sizeof(VendorSyntax);
}

}

namespace microsoft
{
// microsoft - symbolic::microsoft
constexpr inline size_t PragmaCommentSize = sizeof(PragmaComment);
}

namespace preprocessing
{
// preprocessing - symbolic::preprocessing
constexpr inline size_t IdentifierFormSize = sizeof(IdentifierForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t NumberFormSize = sizeof(NumberForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t CharacterFormSize = sizeof(CharacterForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t StringFormSize = sizeof(StringForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t OperatorFormSize = sizeof(OperatorForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t KeywordFormSize = sizeof(KeywordForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t WhitespaceFormSize = sizeof(WhitespaceForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t ParameterFormSize = sizeof(ParameterForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t StringizeFormSize = sizeof(StringizeForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t CatenateFormSize = sizeof(CatenateForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t PragmaFormSize = sizeof(PragmaForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t HeaderFormSize = sizeof(HeaderForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t ParenthesizedFormSize = sizeof(ParenthesizedForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t JunkFormSize = sizeof(JunkForm);
// preprocessing - symbolic::preprocessing
constexpr inline size_t TupleFormSize = sizeof(TupleForm);
}

namespace trait
{
// trait - symbolic::trait
constexpr inline size_t MappingExprSize = sizeof(MappingExpr);
// trait - symbolic::trait
constexpr inline size_t AliasTemplateSize = sizeof(AliasTemplate);
// trait - symbolic::trait
constexpr inline size_t FriendsSize = sizeof(Friends);
// trait - symbolic::trait
constexpr inline size_t SpecializationsSize = sizeof(Specializations);
// trait - symbolic::trait
constexpr inline size_t RequiresSize = sizeof(Requires);
// trait - symbolic::trait
constexpr inline size_t AttributesSize = sizeof(Attributes);
// trait - symbolic::trait
constexpr inline size_t DeprecatedSize = sizeof(Deprecated);
// trait - symbolic::trait
constexpr inline size_t DeductionGuidesSize = sizeof(DeductionGuides);
// trait - symbolic::trait
constexpr inline size_t LocusSpanSize = sizeof(LocusSpan);
// trait - symbolic::trait
constexpr inline size_t MsvcLabelPropertiesSize = sizeof(MsvcLabelProperties);
// trait - symbolic::trait
constexpr inline size_t MsvcFileBoundaryPropertiesSize = sizeof(MsvcFileBoundaryProperties);
// trait - symbolic::trait
constexpr inline size_t MsvcFileHashDataSize = sizeof(MsvcFileHashData);
// trait - symbolic::trait
constexpr inline size_t MsvcUuidSize = sizeof(MsvcUuid);
// trait - symbolic::trait
constexpr inline size_t MsvcSegmentSize = sizeof(MsvcSegment);
// trait - symbolic::trait
constexpr inline size_t MsvcSpecializationEncodingSize = sizeof(MsvcSpecializationEncoding);
// trait - symbolic::trait
constexpr inline size_t MsvcSalAnnotationSize = sizeof(MsvcSalAnnotation);
// trait - symbolic::trait
constexpr inline size_t MsvcFunctionParametersSize = sizeof(MsvcFunctionParameters);
// trait - symbolic::trait
constexpr inline size_t MsvcInitializerLocusSize = sizeof(MsvcInitializerLocus);
// trait - symbolic::trait
constexpr inline size_t MsvcCodegenExpressionSize = sizeof(MsvcCodegenExpression);
// trait - symbolic::trait
constexpr inline size_t DeclAttributesSize = sizeof(DeclAttributes);
// trait - symbolic::trait
constexpr inline size_t StmtAttributesSize = sizeof(StmtAttributes);
// trait - symbolic::trait
constexpr inline size_t MsvcVendorSize = sizeof(MsvcVendor);
// trait - symbolic::trait
constexpr inline size_t MsvcCodegenMappingExprSize = sizeof(MsvcCodegenMappingExpr);
// trait - symbolic::trait
constexpr inline size_t MsvcDynamicInitVariableSize = sizeof(MsvcDynamicInitVariable);
// trait - symbolic::trait
constexpr inline size_t MsvcCodegenLabelPropertiesSize = sizeof(MsvcCodegenLabelProperties);
// trait - symbolic::trait
constexpr inline size_t MsvcCodegenSwitchTypeSize = sizeof(MsvcCodegenSwitchType);
// trait - symbolic::trait
constexpr inline size_t MsvcCodegenDoWhileStmtSize = sizeof(MsvcCodegenDoWhileStmt);
// trait - symbolic::trait
constexpr inline size_t MsvcLexicalScopeIndicesSize = sizeof(MsvcLexicalScopeIndices);
// trait - symbolic::trait
constexpr inline size_t MsvcFileBoundarySize = sizeof(MsvcFileBoundary);
// trait - symbolic::trait
constexpr inline size_t MsvcHeaderUnitSourceFileSize = sizeof(MsvcHeaderUnitSourceFile);
// trait - symbolic::trait
constexpr inline size_t MsvcFileHashSize = sizeof(MsvcFileHash);
}

}

namespace error_condition
{
}

namespace tool
{
}

namespace util
{
}

}

}
