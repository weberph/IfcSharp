// hash: b3d59d821a761a9be80ffadcbda6e55aa2ab066948d94164d9bbb0bfeb97ce6a

module;

#include <ifc/abstract-sgraph.hxx>

export module IfcSizeValidation;

export {
	namespace ifc
	{
		constexpr inline size_t FormatVersionSize = sizeof(FormatVersion);
		constexpr inline size_t SHA256HashSize = sizeof(SHA256Hash);
		constexpr inline size_t UnitIndexSize = sizeof(UnitIndex);
		constexpr inline size_t HeaderSize = sizeof(Header);
		constexpr inline size_t PartitionSummaryDataSize = sizeof(PartitionSummaryData);
		constexpr inline size_t IntegrityCheckFailedSize = sizeof(IntegrityCheckFailed);
		constexpr inline size_t UnsupportedFormatVersionSize = sizeof(UnsupportedFormatVersion);
		constexpr inline size_t PPOperatorSize = sizeof(PPOperator);
		constexpr inline size_t OperatorSize = sizeof(Operator);
		constexpr inline size_t FormIndexSize = sizeof(FormIndex);
		constexpr inline size_t StringIndexSize = sizeof(StringIndex);
		constexpr inline size_t NameIndexSize = sizeof(NameIndex);
		constexpr inline size_t ChartIndexSize = sizeof(ChartIndex);
		constexpr inline size_t DeclIndexSize = sizeof(DeclIndex);
		constexpr inline size_t TypeIndexSize = sizeof(TypeIndex);
		constexpr inline size_t SyntaxIndexSize = sizeof(SyntaxIndex);
		constexpr inline size_t LitIndexSize = sizeof(LitIndex);
		constexpr inline size_t StmtIndexSize = sizeof(StmtIndex);
		constexpr inline size_t ExprIndexSize = sizeof(ExprIndex);
		constexpr inline size_t MacroIndexSize = sizeof(MacroIndex);
		constexpr inline size_t PragmaIndexSize = sizeof(PragmaIndex);
		constexpr inline size_t AttrIndexSize = sizeof(AttrIndex);
		constexpr inline size_t DirIndexSize = sizeof(DirIndex);
		constexpr inline size_t TraitOrderingSize = sizeof(TraitOrdering);
		constexpr inline size_t TableOfContentsSize = sizeof(TableOfContents);
		namespace source
		{
		}

		namespace symbolic
		{
			constexpr inline size_t DeclarationSize = sizeof(Declaration);
			constexpr inline size_t ConversionFunctionIdSize = sizeof(ConversionFunctionId);
			constexpr inline size_t OperatorFunctionIdSize = sizeof(OperatorFunctionId);
			constexpr inline size_t LiteralOperatorIdSize = sizeof(LiteralOperatorId);
			constexpr inline size_t TemplateNameSize = sizeof(TemplateName);
			constexpr inline size_t SpecializationNameSize = sizeof(SpecializationName);
			constexpr inline size_t SourceFileNameSize = sizeof(SourceFileName);
			constexpr inline size_t GuideNameSize = sizeof(GuideName);
			constexpr inline size_t ModuleReferenceSize = sizeof(ModuleReference);
			constexpr inline size_t SourceLocationSize = sizeof(SourceLocation);
			constexpr inline size_t WordSize = sizeof(Word);
			constexpr inline size_t WordSequenceSize = sizeof(WordSequence);
			constexpr inline size_t NoexceptSpecificationSize = sizeof(NoexceptSpecification);
			constexpr inline size_t FundamentalTypeSize = sizeof(FundamentalType);
			constexpr inline size_t DesignatedTypeSize = sizeof(DesignatedType);
			constexpr inline size_t TorTypeSize = sizeof(TorType);
			constexpr inline size_t SyntacticTypeSize = sizeof(SyntacticType);
			constexpr inline size_t ExpansionTypeSize = sizeof(ExpansionType);
			constexpr inline size_t PointerTypeSize = sizeof(PointerType);
			constexpr inline size_t LvalueReferenceTypeSize = sizeof(LvalueReferenceType);
			constexpr inline size_t RvalueReferenceTypeSize = sizeof(RvalueReferenceType);
			constexpr inline size_t UnalignedTypeSize = sizeof(UnalignedType);
			constexpr inline size_t DecltypeTypeSize = sizeof(DecltypeType);
			constexpr inline size_t PlaceholderTypeSize = sizeof(PlaceholderType);
			constexpr inline size_t PointerToMemberTypeSize = sizeof(PointerToMemberType);
			constexpr inline size_t TupleTypeSize = sizeof(TupleType);
			constexpr inline size_t ForallTypeSize = sizeof(ForallType);
			constexpr inline size_t FunctionTypeSize = sizeof(FunctionType);
			constexpr inline size_t MethodTypeSize = sizeof(MethodType);
			constexpr inline size_t ArrayTypeSize = sizeof(ArrayType);
			constexpr inline size_t QualifiedTypeSize = sizeof(QualifiedType);
			constexpr inline size_t TypenameTypeSize = sizeof(TypenameType);
			constexpr inline size_t BaseTypeSize = sizeof(BaseType);
			constexpr inline size_t SyntaxTreeTypeSize = sizeof(SyntaxTreeType);
			constexpr inline size_t FileAndLineSize = sizeof(FileAndLine);
			constexpr inline size_t ParameterizedEntitySize = sizeof(ParameterizedEntity);
			constexpr inline size_t SpecializationFormSize = sizeof(SpecializationForm);
			constexpr inline size_t MappingDefinitionSize = sizeof(MappingDefinition);
			constexpr inline size_t FunctionDeclSize = sizeof(FunctionDecl);
			constexpr inline size_t IntrinsicDeclSize = sizeof(IntrinsicDecl);
			constexpr inline size_t EnumeratorDeclSize = sizeof(EnumeratorDecl);
			constexpr inline size_t ParameterDeclSize = sizeof(ParameterDecl);
			constexpr inline size_t VariableDeclSize = sizeof(VariableDecl);
			constexpr inline size_t FieldDeclSize = sizeof(FieldDecl);
			constexpr inline size_t BitfieldDeclSize = sizeof(BitfieldDecl);
			constexpr inline size_t ScopeDeclSize = sizeof(ScopeDecl);
			constexpr inline size_t EnumerationDeclSize = sizeof(EnumerationDecl);
			constexpr inline size_t AliasDeclSize = sizeof(AliasDecl);
			constexpr inline size_t TemploidDeclSize = sizeof(TemploidDecl);
			constexpr inline size_t TemplateSize = sizeof(Template);
			constexpr inline size_t TemplateDeclSize = sizeof(TemplateDecl);
			constexpr inline size_t PartialSpecializationDeclSize = sizeof(PartialSpecializationDecl);
			constexpr inline size_t SpecializationDeclSize = sizeof(SpecializationDecl);
			constexpr inline size_t DefaultArgumentDeclSize = sizeof(DefaultArgumentDecl);
			constexpr inline size_t ConceptDeclSize = sizeof(ConceptDecl);
			constexpr inline size_t NonStaticMemberFunctionDeclSize = sizeof(NonStaticMemberFunctionDecl);
			constexpr inline size_t ConstructorDeclSize = sizeof(ConstructorDecl);
			constexpr inline size_t InheritedConstructorDeclSize = sizeof(InheritedConstructorDecl);
			constexpr inline size_t DestructorDeclSize = sizeof(DestructorDecl);
			constexpr inline size_t DeductionGuideDeclSize = sizeof(DeductionGuideDecl);
			constexpr inline size_t BarrenDeclSize = sizeof(BarrenDecl);
			constexpr inline size_t ReferenceDeclSize = sizeof(ReferenceDecl);
			constexpr inline size_t PropertyDeclSize = sizeof(PropertyDecl);
			constexpr inline size_t SegmentDeclSize = sizeof(SegmentDecl);
			constexpr inline size_t UsingDeclSize = sizeof(UsingDecl);
			constexpr inline size_t FriendDeclSize = sizeof(FriendDecl);
			constexpr inline size_t ExpansionDeclSize = sizeof(ExpansionDecl);
			constexpr inline size_t SyntacticDeclSize = sizeof(SyntacticDecl);
			constexpr inline size_t TupleDeclSize = sizeof(TupleDecl);
			constexpr inline size_t ScopeSize = sizeof(Scope);
			constexpr inline size_t UnilevelChartSize = sizeof(UnilevelChart);
			constexpr inline size_t MultiChartSize = sizeof(MultiChart);
			constexpr inline size_t BlockStmtSize = sizeof(BlockStmt);
			constexpr inline size_t TryStmtSize = sizeof(TryStmt);
			constexpr inline size_t ExpressionStmtSize = sizeof(ExpressionStmt);
			constexpr inline size_t IfStmtSize = sizeof(IfStmt);
			constexpr inline size_t WhileStmtSize = sizeof(WhileStmt);
			constexpr inline size_t DoWhileStmtSize = sizeof(DoWhileStmt);
			constexpr inline size_t ForStmtSize = sizeof(ForStmt);
			constexpr inline size_t BreakStmtSize = sizeof(BreakStmt);
			constexpr inline size_t ContinueStmtSize = sizeof(ContinueStmt);
			constexpr inline size_t GotoStmtSize = sizeof(GotoStmt);
			constexpr inline size_t SwitchStmtSize = sizeof(SwitchStmt);
			constexpr inline size_t LabeledStmtSize = sizeof(LabeledStmt);
			constexpr inline size_t DeclStmtSize = sizeof(DeclStmt);
			constexpr inline size_t ReturnStmtSize = sizeof(ReturnStmt);
			constexpr inline size_t HandlerStmtSize = sizeof(HandlerStmt);
			constexpr inline size_t ExpansionStmtSize = sizeof(ExpansionStmt);
			constexpr inline size_t TupleStmtSize = sizeof(TupleStmt);
			constexpr inline size_t StringLiteralSize = sizeof(StringLiteral);
			constexpr inline size_t TypeExprSize = sizeof(TypeExpr);
			constexpr inline size_t StringExprSize = sizeof(StringExpr);
			constexpr inline size_t FunctionStringExprSize = sizeof(FunctionStringExpr);
			constexpr inline size_t CompoundStringExprSize = sizeof(CompoundStringExpr);
			constexpr inline size_t StringSequenceExprSize = sizeof(StringSequenceExpr);
			constexpr inline size_t UnresolvedIdExprSize = sizeof(UnresolvedIdExpr);
			constexpr inline size_t TemplateIdExprSize = sizeof(TemplateIdExpr);
			constexpr inline size_t TemplateReferenceExprSize = sizeof(TemplateReferenceExpr);
			constexpr inline size_t NamedDeclExprSize = sizeof(NamedDeclExpr);
			constexpr inline size_t LiteralExprSize = sizeof(LiteralExpr);
			constexpr inline size_t EmptyExprSize = sizeof(EmptyExpr);
			constexpr inline size_t PathExprSize = sizeof(PathExpr);
			constexpr inline size_t ReadExprSize = sizeof(ReadExpr);
			constexpr inline size_t MonadicExprSize = sizeof(MonadicExpr);
			constexpr inline size_t DyadicExprSize = sizeof(DyadicExpr);
			constexpr inline size_t TriadicExprSize = sizeof(TriadicExpr);
			constexpr inline size_t HierarchyConversionExprSize = sizeof(HierarchyConversionExpr);
			constexpr inline size_t DestructorCallExprSize = sizeof(DestructorCallExpr);
			constexpr inline size_t TupleExprSize = sizeof(TupleExpr);
			constexpr inline size_t PlaceholderExprSize = sizeof(PlaceholderExpr);
			constexpr inline size_t ExpansionExprSize = sizeof(ExpansionExpr);
			constexpr inline size_t TokenExprSize = sizeof(TokenExpr);
			constexpr inline size_t CallExprSize = sizeof(CallExpr);
			constexpr inline size_t TemporaryExprSize = sizeof(TemporaryExpr);
			constexpr inline size_t DynamicDispatchExprSize = sizeof(DynamicDispatchExpr);
			constexpr inline size_t VirtualFunctionConversionExprSize = sizeof(VirtualFunctionConversionExpr);
			constexpr inline size_t RequiresExprSize = sizeof(RequiresExpr);
			constexpr inline size_t UnaryFoldExprSize = sizeof(UnaryFoldExpr);
			constexpr inline size_t BinaryFoldExprSize = sizeof(BinaryFoldExpr);
			constexpr inline size_t StatementExprSize = sizeof(StatementExpr);
			constexpr inline size_t TypeTraitIntrinsicExprSize = sizeof(TypeTraitIntrinsicExpr);
			constexpr inline size_t MemberInitializerExprSize = sizeof(MemberInitializerExpr);
			constexpr inline size_t MemberAccessExprSize = sizeof(MemberAccessExpr);
			constexpr inline size_t InheritancePathExprSize = sizeof(InheritancePathExpr);
			constexpr inline size_t InitializerListExprSize = sizeof(InitializerListExpr);
			constexpr inline size_t InitializerExprSize = sizeof(InitializerExpr);
			constexpr inline size_t CastExprSize = sizeof(CastExpr);
			constexpr inline size_t ConditionExprSize = sizeof(ConditionExpr);
			constexpr inline size_t SimpleIdentifierExprSize = sizeof(SimpleIdentifierExpr);
			constexpr inline size_t PointerExprSize = sizeof(PointerExpr);
			constexpr inline size_t UnqualifiedIdExprSize = sizeof(UnqualifiedIdExpr);
			constexpr inline size_t QualifiedNameExprSize = sizeof(QualifiedNameExpr);
			constexpr inline size_t DesignatedInitializerExprSize = sizeof(DesignatedInitializerExpr);
			constexpr inline size_t ExpressionListExprSize = sizeof(ExpressionListExpr);
			constexpr inline size_t AssignInitializerExprSize = sizeof(AssignInitializerExpr);
			constexpr inline size_t SizeofTypeExprSize = sizeof(SizeofTypeExpr);
			constexpr inline size_t AlignofExprSize = sizeof(AlignofExpr);
			constexpr inline size_t LabelExprSize = sizeof(LabelExpr);
			constexpr inline size_t NullptrExprSize = sizeof(NullptrExpr);
			constexpr inline size_t ThisExprSize = sizeof(ThisExpr);
			constexpr inline size_t PackedTemplateArgumentsExprSize = sizeof(PackedTemplateArgumentsExpr);
			constexpr inline size_t LambdaExprSize = sizeof(LambdaExpr);
			constexpr inline size_t TypeidExprSize = sizeof(TypeidExpr);
			constexpr inline size_t SyntaxTreeExprSize = sizeof(SyntaxTreeExpr);
			constexpr inline size_t ProductTypeValueExprSize = sizeof(ProductTypeValueExpr);
			constexpr inline size_t SumTypeValueExprSize = sizeof(SumTypeValueExpr);
			constexpr inline size_t ArrayValueExprSize = sizeof(ArrayValueExpr);
			constexpr inline size_t ObjectLikeMacroSize = sizeof(ObjectLikeMacro);
			constexpr inline size_t FunctionLikeMacroSize = sizeof(FunctionLikeMacro);
			constexpr inline size_t PragmaWarningRegionSize = sizeof(PragmaWarningRegion);
			constexpr inline size_t IntegerLiteralSize = sizeof(IntegerLiteral);
			constexpr inline size_t LiteralRealSize = sizeof(LiteralReal);
			constexpr inline size_t FloatingPointLiteralSize = sizeof(FloatingPointLiteral);
			constexpr inline size_t PragmaPushStateSize = sizeof(PragmaPushState);
			constexpr inline size_t BasicAttrSize = sizeof(BasicAttr);
			constexpr inline size_t ScopedAttrSize = sizeof(ScopedAttr);
			constexpr inline size_t LabeledAttrSize = sizeof(LabeledAttr);
			constexpr inline size_t CalledAttrSize = sizeof(CalledAttr);
			constexpr inline size_t ExpandedAttrSize = sizeof(ExpandedAttr);
			constexpr inline size_t FactoredAttrSize = sizeof(FactoredAttr);
			constexpr inline size_t ElaboratedAttrSize = sizeof(ElaboratedAttr);
			constexpr inline size_t TupleAttrSize = sizeof(TupleAttr);
			constexpr inline size_t EmptyDirSize = sizeof(EmptyDir);
			constexpr inline size_t AttributeDirSize = sizeof(AttributeDir);
			constexpr inline size_t PragmaDirSize = sizeof(PragmaDir);
			constexpr inline size_t UsingDirSize = sizeof(UsingDir);
			constexpr inline size_t UsingDeclarationDirSize = sizeof(UsingDeclarationDir);
			constexpr inline size_t ExprDirSize = sizeof(ExprDir);
			constexpr inline size_t StructuredBindingDirSize = sizeof(StructuredBindingDir);
			constexpr inline size_t SpecifiersSpreadDirSize = sizeof(SpecifiersSpreadDir);
			constexpr inline size_t TupleDirSize = sizeof(TupleDir);
			namespace syntax
			{
				constexpr inline size_t DecltypeSpecifierSize = sizeof(DecltypeSpecifier);
				constexpr inline size_t PlaceholderTypeSpecifierSize = sizeof(PlaceholderTypeSpecifier);
				constexpr inline size_t SimpleTypeSpecifierSize = sizeof(SimpleTypeSpecifier);
				constexpr inline size_t TypeSpecifierSeqSize = sizeof(TypeSpecifierSeq);
				constexpr inline size_t KeywordSize = sizeof(Keyword);
				constexpr inline size_t DeclSpecifierSeqSize = sizeof(DeclSpecifierSeq);
				constexpr inline size_t EnumSpecifierSize = sizeof(EnumSpecifier);
				constexpr inline size_t EnumeratorDefinitionSize = sizeof(EnumeratorDefinition);
				constexpr inline size_t ClassSpecifierSize = sizeof(ClassSpecifier);
				constexpr inline size_t BaseSpecifierListSize = sizeof(BaseSpecifierList);
				constexpr inline size_t BaseSpecifierSize = sizeof(BaseSpecifier);
				constexpr inline size_t MemberSpecificationSize = sizeof(MemberSpecification);
				constexpr inline size_t AccessSpecifierSize = sizeof(AccessSpecifier);
				constexpr inline size_t MemberDeclarationSize = sizeof(MemberDeclaration);
				constexpr inline size_t MemberDeclaratorSize = sizeof(MemberDeclarator);
				constexpr inline size_t TypeIdSize = sizeof(TypeId);
				constexpr inline size_t TrailingReturnTypeSize = sizeof(TrailingReturnType);
				constexpr inline size_t PointerDeclaratorSize = sizeof(PointerDeclarator);
				constexpr inline size_t ArrayDeclaratorSize = sizeof(ArrayDeclarator);
				constexpr inline size_t FunctionDeclaratorSize = sizeof(FunctionDeclarator);
				constexpr inline size_t ArrayOrFunctionDeclaratorSize = sizeof(ArrayOrFunctionDeclarator);
				constexpr inline size_t ParameterDeclaratorSize = sizeof(ParameterDeclarator);
				constexpr inline size_t VirtualSpecifierSeqSize = sizeof(VirtualSpecifierSeq);
				constexpr inline size_t NoexceptSpecificationSize = sizeof(NoexceptSpecification);
				constexpr inline size_t ExplicitSpecifierSize = sizeof(ExplicitSpecifier);
				constexpr inline size_t DeclaratorSize = sizeof(Declarator);
				constexpr inline size_t InitDeclaratorSize = sizeof(InitDeclarator);
				constexpr inline size_t NewDeclaratorSize = sizeof(NewDeclarator);
				constexpr inline size_t SimpleDeclarationSize = sizeof(SimpleDeclaration);
				constexpr inline size_t ExceptionDeclarationSize = sizeof(ExceptionDeclaration);
				constexpr inline size_t ConditionDeclarationSize = sizeof(ConditionDeclaration);
				constexpr inline size_t StaticAssertDeclarationSize = sizeof(StaticAssertDeclaration);
				constexpr inline size_t AliasDeclarationSize = sizeof(AliasDeclaration);
				constexpr inline size_t ConceptDefinitionSize = sizeof(ConceptDefinition);
				constexpr inline size_t StructuredBindingDeclarationSize = sizeof(StructuredBindingDeclaration);
				constexpr inline size_t StructuredBindingIdentifierSize = sizeof(StructuredBindingIdentifier);
				constexpr inline size_t AsmStatementSize = sizeof(AsmStatement);
				constexpr inline size_t ReturnStatementSize = sizeof(ReturnStatement);
				constexpr inline size_t CompoundStatementSize = sizeof(CompoundStatement);
				constexpr inline size_t IfStatementSize = sizeof(IfStatement);
				constexpr inline size_t WhileStatementSize = sizeof(WhileStatement);
				constexpr inline size_t DoWhileStatementSize = sizeof(DoWhileStatement);
				constexpr inline size_t ForStatementSize = sizeof(ForStatement);
				constexpr inline size_t InitStatementSize = sizeof(InitStatement);
				constexpr inline size_t RangeBasedForStatementSize = sizeof(RangeBasedForStatement);
				constexpr inline size_t ForRangeDeclarationSize = sizeof(ForRangeDeclaration);
				constexpr inline size_t LabeledStatementSize = sizeof(LabeledStatement);
				constexpr inline size_t BreakStatementSize = sizeof(BreakStatement);
				constexpr inline size_t ContinueStatementSize = sizeof(ContinueStatement);
				constexpr inline size_t SwitchStatementSize = sizeof(SwitchStatement);
				constexpr inline size_t GotoStatementSize = sizeof(GotoStatement);
				constexpr inline size_t DeclarationStatementSize = sizeof(DeclarationStatement);
				constexpr inline size_t ExpressionStatementSize = sizeof(ExpressionStatement);
				constexpr inline size_t TryBlockSize = sizeof(TryBlock);
				constexpr inline size_t HandlerSize = sizeof(Handler);
				constexpr inline size_t HandlerSeqSize = sizeof(HandlerSeq);
				constexpr inline size_t FunctionTryBlockSize = sizeof(FunctionTryBlock);
				constexpr inline size_t TypeIdListElementSize = sizeof(TypeIdListElement);
				constexpr inline size_t DynamicExceptionSpecSize = sizeof(DynamicExceptionSpec);
				constexpr inline size_t StatementSeqSize = sizeof(StatementSeq);
				constexpr inline size_t MemberFunctionDeclarationSize = sizeof(MemberFunctionDeclaration);
				constexpr inline size_t FunctionDefinitionSize = sizeof(FunctionDefinition);
				constexpr inline size_t FunctionBodySize = sizeof(FunctionBody);
				constexpr inline size_t ExpressionSize = sizeof(Expression);
				constexpr inline size_t TemplateParameterListSize = sizeof(TemplateParameterList);
				constexpr inline size_t TemplateDeclarationSize = sizeof(TemplateDeclaration);
				constexpr inline size_t RequiresClauseSize = sizeof(RequiresClause);
				constexpr inline size_t SimpleRequirementSize = sizeof(SimpleRequirement);
				constexpr inline size_t TypeRequirementSize = sizeof(TypeRequirement);
				constexpr inline size_t CompoundRequirementSize = sizeof(CompoundRequirement);
				constexpr inline size_t NestedRequirementSize = sizeof(NestedRequirement);
				constexpr inline size_t RequirementBodySize = sizeof(RequirementBody);
				constexpr inline size_t TypeTemplateParameterSize = sizeof(TypeTemplateParameter);
				constexpr inline size_t TemplateTemplateParameterSize = sizeof(TemplateTemplateParameter);
				constexpr inline size_t TypeTemplateArgumentSize = sizeof(TypeTemplateArgument);
				constexpr inline size_t NonTypeTemplateArgumentSize = sizeof(NonTypeTemplateArgument);
				constexpr inline size_t TemplateArgumentListSize = sizeof(TemplateArgumentList);
				constexpr inline size_t TemplateIdSize = sizeof(TemplateId);
				constexpr inline size_t MemInitializerSize = sizeof(MemInitializer);
				constexpr inline size_t CtorInitializerSize = sizeof(CtorInitializer);
				constexpr inline size_t CaptureDefaultSize = sizeof(CaptureDefault);
				constexpr inline size_t SimpleCaptureSize = sizeof(SimpleCapture);
				constexpr inline size_t InitCaptureSize = sizeof(InitCapture);
				constexpr inline size_t ThisCaptureSize = sizeof(ThisCapture);
				constexpr inline size_t LambdaIntroducerSize = sizeof(LambdaIntroducer);
				constexpr inline size_t LambdaDeclaratorSize = sizeof(LambdaDeclarator);
				constexpr inline size_t UsingDeclarationSize = sizeof(UsingDeclaration);
				constexpr inline size_t UsingEnumDeclarationSize = sizeof(UsingEnumDeclaration);
				constexpr inline size_t UsingDeclaratorSize = sizeof(UsingDeclarator);
				constexpr inline size_t UsingDirectiveSize = sizeof(UsingDirective);
				constexpr inline size_t NamespaceAliasDefinitionSize = sizeof(NamespaceAliasDefinition);
				constexpr inline size_t ArrayIndexSize = sizeof(ArrayIndex);
				constexpr inline size_t TypeTraitIntrinsicSize = sizeof(TypeTraitIntrinsic);
				constexpr inline size_t SEHTrySize = sizeof(SEHTry);
				constexpr inline size_t SEHExceptSize = sizeof(SEHExcept);
				constexpr inline size_t SEHFinallySize = sizeof(SEHFinally);
				constexpr inline size_t SEHLeaveSize = sizeof(SEHLeave);
				constexpr inline size_t SuperSize = sizeof(Super);
				constexpr inline size_t UnaryFoldExpressionSize = sizeof(UnaryFoldExpression);
				constexpr inline size_t BinaryFoldExpressionSize = sizeof(BinaryFoldExpression);
				constexpr inline size_t EmptyStatementSize = sizeof(EmptyStatement);
				constexpr inline size_t AttributedStatementSize = sizeof(AttributedStatement);
				constexpr inline size_t AttributedDeclarationSize = sizeof(AttributedDeclaration);
				constexpr inline size_t AttributeSpecifierSeqSize = sizeof(AttributeSpecifierSeq);
				constexpr inline size_t AttributeSpecifierSize = sizeof(AttributeSpecifier);
				constexpr inline size_t AttributeUsingPrefixSize = sizeof(AttributeUsingPrefix);
				constexpr inline size_t AttributeSize = sizeof(Attribute);
				constexpr inline size_t AttributeArgumentClauseSize = sizeof(AttributeArgumentClause);
				constexpr inline size_t AlignasSpecifierSize = sizeof(AlignasSpecifier);
				constexpr inline size_t TupleSize = sizeof(Tuple);
				namespace microsoft
				{
					constexpr inline size_t TypeOrExprOperandSize = sizeof(TypeOrExprOperand);
					constexpr inline size_t DeclspecSize = sizeof(Declspec);
					constexpr inline size_t BuiltinAddressOfSize = sizeof(BuiltinAddressOf);
					constexpr inline size_t UUIDOfSize = sizeof(UUIDOf);
					constexpr inline size_t IntrinsicSize = sizeof(Intrinsic);
					constexpr inline size_t IfExistsSize = sizeof(IfExists);
					constexpr inline size_t VendorSyntaxSize = sizeof(VendorSyntax);
				}

			}

			namespace microsoft
			{
				constexpr inline size_t PragmaCommentSize = sizeof(PragmaComment);
			}

			namespace preprocessing
			{
				constexpr inline size_t IdentifierFormSize = sizeof(IdentifierForm);
				constexpr inline size_t NumberFormSize = sizeof(NumberForm);
				constexpr inline size_t CharacterFormSize = sizeof(CharacterForm);
				constexpr inline size_t StringFormSize = sizeof(StringForm);
				constexpr inline size_t OperatorFormSize = sizeof(OperatorForm);
				constexpr inline size_t KeywordFormSize = sizeof(KeywordForm);
				constexpr inline size_t WhitespaceFormSize = sizeof(WhitespaceForm);
				constexpr inline size_t ParameterFormSize = sizeof(ParameterForm);
				constexpr inline size_t StringizeFormSize = sizeof(StringizeForm);
				constexpr inline size_t CatenateFormSize = sizeof(CatenateForm);
				constexpr inline size_t PragmaFormSize = sizeof(PragmaForm);
				constexpr inline size_t HeaderFormSize = sizeof(HeaderForm);
				constexpr inline size_t ParenthesizedFormSize = sizeof(ParenthesizedForm);
				constexpr inline size_t JunkFormSize = sizeof(JunkForm);
				constexpr inline size_t TupleFormSize = sizeof(TupleForm);
			}

			namespace trait
			{
				constexpr inline size_t MappingExprSize = sizeof(MappingExpr);
				constexpr inline size_t AliasTemplateSize = sizeof(AliasTemplate);
				constexpr inline size_t FriendsSize = sizeof(Friends);
				constexpr inline size_t SpecializationsSize = sizeof(Specializations);
				constexpr inline size_t RequiresSize = sizeof(Requires);
				constexpr inline size_t AttributesSize = sizeof(Attributes);
				constexpr inline size_t DeprecatedSize = sizeof(Deprecated);
				constexpr inline size_t DeductionGuidesSize = sizeof(DeductionGuides);
				constexpr inline size_t LocusSpanSize = sizeof(LocusSpan);
				constexpr inline size_t MsvcLabelPropertiesSize = sizeof(MsvcLabelProperties);
				constexpr inline size_t MsvcFileBoundaryPropertiesSize = sizeof(MsvcFileBoundaryProperties);
				constexpr inline size_t MsvcFileHashDataSize = sizeof(MsvcFileHashData);
				constexpr inline size_t MsvcUuidSize = sizeof(MsvcUuid);
				constexpr inline size_t MsvcSegmentSize = sizeof(MsvcSegment);
				constexpr inline size_t MsvcSpecializationEncodingSize = sizeof(MsvcSpecializationEncoding);
				constexpr inline size_t MsvcSalAnnotationSize = sizeof(MsvcSalAnnotation);
				constexpr inline size_t MsvcFunctionParametersSize = sizeof(MsvcFunctionParameters);
				constexpr inline size_t MsvcInitializerLocusSize = sizeof(MsvcInitializerLocus);
				constexpr inline size_t MsvcCodegenExpressionSize = sizeof(MsvcCodegenExpression);
				constexpr inline size_t DeclAttributesSize = sizeof(DeclAttributes);
				constexpr inline size_t StmtAttributesSize = sizeof(StmtAttributes);
				constexpr inline size_t MsvcVendorSize = sizeof(MsvcVendor);
				constexpr inline size_t MsvcCodegenMappingExprSize = sizeof(MsvcCodegenMappingExpr);
				constexpr inline size_t MsvcDynamicInitVariableSize = sizeof(MsvcDynamicInitVariable);
				constexpr inline size_t MsvcCodegenLabelPropertiesSize = sizeof(MsvcCodegenLabelProperties);
				constexpr inline size_t MsvcCodegenSwitchTypeSize = sizeof(MsvcCodegenSwitchType);
				constexpr inline size_t MsvcCodegenDoWhileStmtSize = sizeof(MsvcCodegenDoWhileStmt);
				constexpr inline size_t MsvcLexicalScopeIndicesSize = sizeof(MsvcLexicalScopeIndices);
				constexpr inline size_t MsvcFileBoundarySize = sizeof(MsvcFileBoundary);
				constexpr inline size_t MsvcHeaderUnitSourceFileSize = sizeof(MsvcHeaderUnitSourceFile);
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
