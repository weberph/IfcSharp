using ifc;
using ifc.symbolic;
using ifc.symbolic.microsoft;
using ifc.symbolic.preprocessing;
using ifc.symbolic.syntax;
using ifc.symbolic.syntax.microsoft;

using Attribute = ifc.symbolic.syntax.Attribute;
using NoexceptSpecification = ifc.symbolic.syntax.NoexceptSpecification;
using Tuple = ifc.symbolic.syntax.Tuple;

namespace IfcSharpLibTest
{
    internal partial class TestVisitor
    {
        partial void Visit(in OperatorFunctionId operatorFunctionId);

        private void VisitOperatorFunctionId(NameIndex index)
        {
            ref readonly var operatorFunctionId = ref _reader.Get<OperatorFunctionId>(index);

            Visit(in operatorFunctionId);
        }

        partial void Visit(in ConversionFunctionId conversionFunctionId);

        private void VisitConversionFunctionId(NameIndex index)
        {
            ref readonly var conversionFunctionId = ref _reader.Get<ConversionFunctionId>(index);

            Visit(in conversionFunctionId);

            AddChild(conversionFunctionId.target);
        }

        partial void Visit(in LiteralOperatorId literalOperatorId);

        private void VisitLiteralOperatorId(NameIndex index)
        {
            ref readonly var literalOperatorId = ref _reader.Get<LiteralOperatorId>(index);

            Visit(in literalOperatorId);
        }

        partial void Visit(in TemplateName templateName);

        private void VisitTemplateName(NameIndex index)
        {
            ref readonly var templateName = ref _reader.Get<TemplateName>(index);

            Visit(in templateName);

            AddChild(templateName.name);
        }

        partial void Visit(in SpecializationName specializationName);

        private void VisitSpecializationName(NameIndex index)
        {
            ref readonly var specializationName = ref _reader.Get<SpecializationName>(index);

            Visit(in specializationName);

            AddChild(specializationName.arguments);
            AddChild(specializationName.primary_template);
        }

        partial void Visit(in SourceFileName sourceFileName);

        private void VisitSourceFileName(NameIndex index)
        {
            ref readonly var sourceFileName = ref _reader.Get<SourceFileName>(index);

            Visit(in sourceFileName);
        }

        partial void Visit(in GuideName guideName);

        private void VisitGuideName(NameIndex index)
        {
            ref readonly var guideName = ref _reader.Get<GuideName>(index);

            Visit(in guideName);

            AddChild(guideName.primary_template);
        }

        partial void Visit(in UnilevelChart unilevelChart);

        private void VisitUnilevelChart(ChartIndex index)
        {
            ref readonly var unilevelChart = ref _reader.Get<UnilevelChart>(index);

            Visit(in unilevelChart);

            AddChild(unilevelChart.requires_clause);
        }

        partial void Visit(in MultiChart multiChart);

        private void VisitMultiChart(ChartIndex index)
        {
            ref readonly var multiChart = ref _reader.Get<MultiChart>(index);

            Visit(in multiChart);
        }

        partial void Visit(in EnumeratorDecl enumeratorDecl);

        private void VisitEnumeratorDecl(DeclIndex index)
        {
            ref readonly var enumeratorDecl = ref _reader.Get<EnumeratorDecl>(index);

            Visit(in enumeratorDecl);

            AddChild(enumeratorDecl.initializer);
            AddChild(enumeratorDecl.type);
        }

        partial void Visit(in VariableDecl variableDecl);

        private void VisitVariableDecl(DeclIndex index)
        {
            ref readonly var variableDecl = ref _reader.Get<VariableDecl>(index);

            Visit(in variableDecl);

            AddChild(variableDecl.alignment);
            AddChild(variableDecl.initializer);
            AddChild(variableDecl.home_scope);
            AddChild(variableDecl.type);
        }

        partial void Visit(in ParameterDecl parameterDecl);

        private void VisitParameterDecl(DeclIndex index)
        {
            ref readonly var parameterDecl = ref _reader.Get<ParameterDecl>(index);

            Visit(in parameterDecl);

            AddChild(parameterDecl.type_constraint);
            AddChild(parameterDecl.type);
        }

        partial void Visit(in FieldDecl fieldDecl);

        private void VisitFieldDecl(DeclIndex index)
        {
            ref readonly var fieldDecl = ref _reader.Get<FieldDecl>(index);

            Visit(in fieldDecl);

            AddChild(fieldDecl.alignment);
            AddChild(fieldDecl.initializer);
            AddChild(fieldDecl.home_scope);
            AddChild(fieldDecl.type);
        }

        partial void Visit(in BitfieldDecl bitfieldDecl);

        private void VisitBitfieldDecl(DeclIndex index)
        {
            ref readonly var bitfieldDecl = ref _reader.Get<BitfieldDecl>(index);

            Visit(in bitfieldDecl);

            AddChild(bitfieldDecl.initializer);
            AddChild(bitfieldDecl.width);
            AddChild(bitfieldDecl.home_scope);
            AddChild(bitfieldDecl.type);
        }

        partial void Visit(in ScopeDecl scopeDecl);

        private void VisitScopeDecl(DeclIndex index)
        {
            ref readonly var scopeDecl = ref _reader.Get<ScopeDecl>(index);

            Visit(in scopeDecl);

            AddChild(scopeDecl.alignment);
            AddChild(scopeDecl.home_scope);
            AddChild(scopeDecl.@base);
            AddChild(scopeDecl.type);
        }

        partial void Visit(in EnumerationDecl enumerationDecl);

        private void VisitEnumerationDecl(DeclIndex index)
        {
            ref readonly var enumerationDecl = ref _reader.Get<EnumerationDecl>(index);

            Visit(in enumerationDecl);

            AddChild(enumerationDecl.alignment);
            AddChild(enumerationDecl.home_scope);
            AddChild(enumerationDecl.@base);
            AddChild(enumerationDecl.type);
        }

        partial void Visit(in AliasDecl aliasDecl);

        private void VisitAliasDecl(DeclIndex index)
        {
            ref readonly var aliasDecl = ref _reader.Get<AliasDecl>(index);

            Visit(in aliasDecl);

            AddChild(aliasDecl.aliasee);
            AddChild(aliasDecl.home_scope);
            AddChild(aliasDecl.type);
        }

        partial void Visit(in TemploidDecl temploidDecl);

        private void VisitTemploidDecl(DeclIndex index)
        {
            ref readonly var temploidDecl = ref _reader.Get<TemploidDecl>(index);

            Visit(in temploidDecl);

            AddChild(temploidDecl.chart);
        }

        partial void Visit(in TemplateDecl templateDecl);

        private void VisitTemplateDecl(DeclIndex index)
        {
            ref readonly var templateDecl = ref _reader.Get<TemplateDecl>(index);

            Visit(in templateDecl);

            AddChild(templateDecl.type);
        }

        partial void Visit(in PartialSpecializationDecl partialSpecializationDecl);

        private void VisitPartialSpecializationDecl(DeclIndex index)
        {
            ref readonly var partialSpecializationDecl = ref _reader.Get<PartialSpecializationDecl>(index);

            Visit(in partialSpecializationDecl);
        }

        partial void Visit(in SpecializationDecl specializationDecl);

        private void VisitSpecializationDecl(DeclIndex index)
        {
            ref readonly var specializationDecl = ref _reader.Get<SpecializationDecl>(index);

            Visit(in specializationDecl);

            AddChild(specializationDecl.decl);
        }

        partial void Visit(in DefaultArgumentDecl defaultArgumentDecl);

        private void VisitDefaultArgumentDecl(DeclIndex index)
        {
            ref readonly var defaultArgumentDecl = ref _reader.Get<DefaultArgumentDecl>(index);

            Visit(in defaultArgumentDecl);

            AddChild(defaultArgumentDecl.initializer);
            AddChild(defaultArgumentDecl.home_scope);
            AddChild(defaultArgumentDecl.type);
        }

        partial void Visit(in ConceptDecl conceptDecl);

        private void VisitConceptDecl(DeclIndex index)
        {
            ref readonly var conceptDecl = ref _reader.Get<ConceptDecl>(index);

            Visit(in conceptDecl);

            AddChild(conceptDecl.constraint);
            AddChild(conceptDecl.chart);
            AddChild(conceptDecl.type);
            AddChild(conceptDecl.home_scope);
        }

        partial void Visit(in FunctionDecl functionDecl);

        private void VisitFunctionDecl(DeclIndex index)
        {
            ref readonly var functionDecl = ref _reader.Get<FunctionDecl>(index);

            Visit(in functionDecl);

            AddChild(functionDecl.chart);
            AddChild(functionDecl.home_scope);
            AddChild(functionDecl.type);
        }

        partial void Visit(in NonStaticMemberFunctionDecl nonStaticMemberFunctionDecl);

        private void VisitNonStaticMemberFunctionDecl(DeclIndex index)
        {
            ref readonly var nonStaticMemberFunctionDecl = ref _reader.Get<NonStaticMemberFunctionDecl>(index);

            Visit(in nonStaticMemberFunctionDecl);

            AddChild(nonStaticMemberFunctionDecl.chart);
            AddChild(nonStaticMemberFunctionDecl.home_scope);
            AddChild(nonStaticMemberFunctionDecl.type);
        }

        partial void Visit(in ConstructorDecl constructorDecl);

        private void VisitConstructorDecl(DeclIndex index)
        {
            ref readonly var constructorDecl = ref _reader.Get<ConstructorDecl>(index);

            Visit(in constructorDecl);

            AddChild(constructorDecl.chart);
            AddChild(constructorDecl.home_scope);
            AddChild(constructorDecl.type);
        }

        partial void Visit(in InheritedConstructorDecl inheritedConstructorDecl);

        private void VisitInheritedConstructorDecl(DeclIndex index)
        {
            ref readonly var inheritedConstructorDecl = ref _reader.Get<InheritedConstructorDecl>(index);

            Visit(in inheritedConstructorDecl);

            AddChild(inheritedConstructorDecl.base_ctor);
            AddChild(inheritedConstructorDecl.chart);
            AddChild(inheritedConstructorDecl.home_scope);
            AddChild(inheritedConstructorDecl.type);
        }

        partial void Visit(in DestructorDecl destructorDecl);

        private void VisitDestructorDecl(DeclIndex index)
        {
            ref readonly var destructorDecl = ref _reader.Get<DestructorDecl>(index);

            Visit(in destructorDecl);

            AddChild(destructorDecl.home_scope);
        }

        partial void Visit(in ReferenceDecl referenceDecl);

        private void VisitReferenceDecl(DeclIndex index)
        {
            ref readonly var referenceDecl = ref _reader.Get<ReferenceDecl>(index);

            Visit(in referenceDecl);

            AddChild(referenceDecl.local_index);
        }

        partial void Visit(in UsingDecl usingDecl);

        private void VisitUsingDecl(DeclIndex index)
        {
            ref readonly var usingDecl = ref _reader.Get<UsingDecl>(index);

            Visit(in usingDecl);

            AddChild(usingDecl.parent);
            AddChild(usingDecl.resolution);
            AddChild(usingDecl.home_scope);
        }

        partial void Visit(in FriendDecl friendDecl);

        private void VisitFriendDecl(DeclIndex index)
        {
            ref readonly var friendDecl = ref _reader.Get<FriendDecl>(index);

            Visit(in friendDecl);

            AddChild(friendDecl.index);
        }

        partial void Visit(in ExpansionDecl expansionDecl);

        private void VisitExpansionDecl(DeclIndex index)
        {
            ref readonly var expansionDecl = ref _reader.Get<ExpansionDecl>(index);

            Visit(in expansionDecl);

            AddChild(expansionDecl.operand);
        }

        partial void Visit(in DeductionGuideDecl deductionGuideDecl);

        private void VisitDeductionGuideDecl(DeclIndex index)
        {
            ref readonly var deductionGuideDecl = ref _reader.Get<DeductionGuideDecl>(index);

            Visit(in deductionGuideDecl);

            AddChild(deductionGuideDecl.target);
            AddChild(deductionGuideDecl.source);
            AddChild(deductionGuideDecl.home_scope);
        }

        partial void Visit(in BarrenDecl barrenDecl);

        private void VisitBarrenDecl(DeclIndex index)
        {
            ref readonly var barrenDecl = ref _reader.Get<BarrenDecl>(index);

            Visit(in barrenDecl);

            AddChild(barrenDecl.directive);
        }

        partial void Visit(in TupleDecl tupleDecl);

        private void VisitTupleDecl(DeclIndex index)
        {
            ref readonly var tupleDecl = ref _reader.Get<TupleDecl>(index);

            Visit(in tupleDecl);
        }

        partial void Visit(in SyntacticDecl syntacticDecl);

        private void VisitSyntacticDecl(DeclIndex index)
        {
            ref readonly var syntacticDecl = ref _reader.Get<SyntacticDecl>(index);

            Visit(in syntacticDecl);

            AddChild(syntacticDecl.index);
        }

        partial void Visit(in IntrinsicDecl intrinsicDecl);

        private void VisitIntrinsicDecl(DeclIndex index)
        {
            ref readonly var intrinsicDecl = ref _reader.Get<IntrinsicDecl>(index);

            Visit(in intrinsicDecl);

            AddChild(intrinsicDecl.home_scope);
            AddChild(intrinsicDecl.type);
        }

        partial void Visit(in PropertyDecl propertyDecl);

        private void VisitPropertyDecl(DeclIndex index)
        {
            ref readonly var propertyDecl = ref _reader.Get<PropertyDecl>(index);

            Visit(in propertyDecl);

            AddChild(propertyDecl.data_member);
        }

        partial void Visit(in SegmentDecl segmentDecl);

        private void VisitSegmentDecl(DeclIndex index)
        {
            ref readonly var segmentDecl = ref _reader.Get<SegmentDecl>(index);

            Visit(in segmentDecl);
        }

        partial void Visit(in FundamentalType fundamentalType);

        private void VisitFundamentalType(TypeIndex index)
        {
            ref readonly var fundamentalType = ref _reader.Get<FundamentalType>(index);

            Visit(in fundamentalType);
        }

        partial void Visit(in DesignatedType designatedType);

        private void VisitDesignatedType(TypeIndex index)
        {
            ref readonly var designatedType = ref _reader.Get<DesignatedType>(index);

            Visit(in designatedType);

            AddChild(designatedType.decl);
        }

        partial void Visit(in TorType torType);

        private void VisitTorType(TypeIndex index)
        {
            ref readonly var torType = ref _reader.Get<TorType>(index);

            Visit(in torType);

            AddChild(torType.source);
        }

        partial void Visit(in SyntacticType syntacticType);

        private void VisitSyntacticType(TypeIndex index)
        {
            ref readonly var syntacticType = ref _reader.Get<SyntacticType>(index);

            Visit(in syntacticType);

            AddChild(syntacticType.expr);
        }

        partial void Visit(in ExpansionType expansionType);

        private void VisitExpansionType(TypeIndex index)
        {
            ref readonly var expansionType = ref _reader.Get<ExpansionType>(index);

            Visit(in expansionType);

            AddChild(expansionType.pack);
        }

        partial void Visit(in PointerType pointerType);

        private void VisitPointerType(TypeIndex index)
        {
            ref readonly var pointerType = ref _reader.Get<PointerType>(index);

            Visit(in pointerType);

            AddChild(pointerType.pointee);
        }

        partial void Visit(in PointerToMemberType pointerToMemberType);

        private void VisitPointerToMemberType(TypeIndex index)
        {
            ref readonly var pointerToMemberType = ref _reader.Get<PointerToMemberType>(index);

            Visit(in pointerToMemberType);

            AddChild(pointerToMemberType.type);
            AddChild(pointerToMemberType.scope);
        }

        partial void Visit(in LvalueReferenceType lvalueReferenceType);

        private void VisitLvalueReferenceType(TypeIndex index)
        {
            ref readonly var lvalueReferenceType = ref _reader.Get<LvalueReferenceType>(index);

            Visit(in lvalueReferenceType);

            AddChild(lvalueReferenceType.referee);
        }

        partial void Visit(in RvalueReferenceType rvalueReferenceType);

        private void VisitRvalueReferenceType(TypeIndex index)
        {
            ref readonly var rvalueReferenceType = ref _reader.Get<RvalueReferenceType>(index);

            Visit(in rvalueReferenceType);

            AddChild(rvalueReferenceType.referee);
        }

        partial void Visit(in FunctionType functionType);

        private void VisitFunctionType(TypeIndex index)
        {
            ref readonly var functionType = ref _reader.Get<FunctionType>(index);

            Visit(in functionType);

            AddChild(functionType.source);
            AddChild(functionType.target);
        }

        partial void Visit(in MethodType methodType);

        private void VisitMethodType(TypeIndex index)
        {
            ref readonly var methodType = ref _reader.Get<MethodType>(index);

            Visit(in methodType);

            AddChild(methodType.class_type);
            AddChild(methodType.source);
            AddChild(methodType.target);
        }

        partial void Visit(in ArrayType arrayType);

        private void VisitArrayType(TypeIndex index)
        {
            ref readonly var arrayType = ref _reader.Get<ArrayType>(index);

            Visit(in arrayType);

            AddChild(arrayType.bound);
            AddChild(arrayType.element);
        }

        partial void Visit(in TypenameType typenameType);

        private void VisitTypenameType(TypeIndex index)
        {
            ref readonly var typenameType = ref _reader.Get<TypenameType>(index);

            Visit(in typenameType);

            AddChild(typenameType.path);
        }

        partial void Visit(in QualifiedType qualifiedType);

        private void VisitQualifiedType(TypeIndex index)
        {
            ref readonly var qualifiedType = ref _reader.Get<QualifiedType>(index);

            Visit(in qualifiedType);

            AddChild(qualifiedType.unqualified_type);
        }

        partial void Visit(in BaseType baseType);

        private void VisitBaseType(TypeIndex index)
        {
            ref readonly var baseType = ref _reader.Get<BaseType>(index);

            Visit(in baseType);

            AddChild(baseType.type);
        }

        partial void Visit(in DecltypeType decltypeType);

        private void VisitDecltypeType(TypeIndex index)
        {
            ref readonly var decltypeType = ref _reader.Get<DecltypeType>(index);

            Visit(in decltypeType);

            AddChild(decltypeType.expression);
        }

        partial void Visit(in PlaceholderType placeholderType);

        private void VisitPlaceholderType(TypeIndex index)
        {
            ref readonly var placeholderType = ref _reader.Get<PlaceholderType>(index);

            Visit(in placeholderType);

            AddChild(placeholderType.elaboration);
            AddChild(placeholderType.constraint);
        }

        partial void Visit(in TupleType tupleType);

        private void VisitTupleType(TypeIndex index)
        {
            ref readonly var tupleType = ref _reader.Get<TupleType>(index);

            Visit(in tupleType);
        }

        partial void Visit(in ForallType forallType);

        private void VisitForallType(TypeIndex index)
        {
            ref readonly var forallType = ref _reader.Get<ForallType>(index);

            Visit(in forallType);

            AddChild(forallType.subject);
            AddChild(forallType.chart);
        }

        partial void Visit(in UnalignedType unalignedType);

        private void VisitUnalignedType(TypeIndex index)
        {
            ref readonly var unalignedType = ref _reader.Get<UnalignedType>(index);

            Visit(in unalignedType);

            AddChild(unalignedType.operand);
        }

        partial void Visit(in SyntaxTreeType syntaxTreeType);

        private void VisitSyntaxTreeType(TypeIndex index)
        {
            ref readonly var syntaxTreeType = ref _reader.Get<SyntaxTreeType>(index);

            Visit(in syntaxTreeType);

            AddChild(syntaxTreeType.syntax);
        }

        partial void Visit(in VendorSyntax vendorSyntax);

        private void VisitVendorSyntax(SyntaxIndex index)
        {
            ref readonly var vendorSyntax = ref _reader.Get<VendorSyntax>(index);

            Visit(in vendorSyntax);
        }

        partial void Visit(in SimpleTypeSpecifier simpleTypeSpecifier);

        private void VisitSimpleTypeSpecifier(SyntaxIndex index)
        {
            ref readonly var simpleTypeSpecifier = ref _reader.Get<SimpleTypeSpecifier>(index);

            Visit(in simpleTypeSpecifier);

            AddChild(simpleTypeSpecifier.expr);
            AddChild(simpleTypeSpecifier.type);
        }

        partial void Visit(in DecltypeSpecifier decltypeSpecifier);

        private void VisitDecltypeSpecifier(SyntaxIndex index)
        {
            ref readonly var decltypeSpecifier = ref _reader.Get<DecltypeSpecifier>(index);

            Visit(in decltypeSpecifier);

            AddChild(decltypeSpecifier.expression);
        }

        partial void Visit(in PlaceholderTypeSpecifier placeholderTypeSpecifier);

        private void VisitPlaceholderTypeSpecifier(SyntaxIndex index)
        {
            ref readonly var placeholderTypeSpecifier = ref _reader.Get<PlaceholderTypeSpecifier>(index);

            Visit(in placeholderTypeSpecifier);
        }

        partial void Visit(in TypeSpecifierSeq typeSpecifierSeq);

        private void VisitTypeSpecifierSeq(SyntaxIndex index)
        {
            ref readonly var typeSpecifierSeq = ref _reader.Get<TypeSpecifierSeq>(index);

            Visit(in typeSpecifierSeq);

            AddChild(typeSpecifierSeq.type);
            AddChild(typeSpecifierSeq.type_script);
        }

        partial void Visit(in DeclSpecifierSeq declSpecifierSeq);

        private void VisitDeclSpecifierSeq(SyntaxIndex index)
        {
            ref readonly var declSpecifierSeq = ref _reader.Get<DeclSpecifierSeq>(index);

            Visit(in declSpecifierSeq);

            AddChild(declSpecifierSeq.explicit_specifier);
            AddChild(declSpecifierSeq.type_script);
            AddChild(declSpecifierSeq.type);
        }

        partial void Visit(in VirtualSpecifierSeq virtualSpecifierSeq);

        private void VisitVirtualSpecifierSeq(SyntaxIndex index)
        {
            ref readonly var virtualSpecifierSeq = ref _reader.Get<VirtualSpecifierSeq>(index);

            Visit(in virtualSpecifierSeq);
        }

        partial void Visit(in NoexceptSpecification noexceptSpecification);

        private void VisitNoexceptSpecification(SyntaxIndex index)
        {
            ref readonly var noexceptSpecification = ref _reader.Get<NoexceptSpecification>(index);

            Visit(in noexceptSpecification);

            AddChild(noexceptSpecification.expression);
        }

        partial void Visit(in ExplicitSpecifier explicitSpecifier);

        private void VisitExplicitSpecifier(SyntaxIndex index)
        {
            ref readonly var explicitSpecifier = ref _reader.Get<ExplicitSpecifier>(index);

            Visit(in explicitSpecifier);

            AddChild(explicitSpecifier.expression);
        }

        partial void Visit(in EnumSpecifier enumSpecifier);

        private void VisitEnumSpecifier(SyntaxIndex index)
        {
            ref readonly var enumSpecifier = ref _reader.Get<EnumSpecifier>(index);

            Visit(in enumSpecifier);

            AddChild(enumSpecifier.enum_base);
            AddChild(enumSpecifier.enumerators);
            AddChild(enumSpecifier.name);
        }

        partial void Visit(in EnumeratorDefinition enumeratorDefinition);

        private void VisitEnumeratorDefinition(SyntaxIndex index)
        {
            ref readonly var enumeratorDefinition = ref _reader.Get<EnumeratorDefinition>(index);

            Visit(in enumeratorDefinition);

            AddChild(enumeratorDefinition.expression);
        }

        partial void Visit(in ClassSpecifier classSpecifier);

        private void VisitClassSpecifier(SyntaxIndex index)
        {
            ref readonly var classSpecifier = ref _reader.Get<ClassSpecifier>(index);

            Visit(in classSpecifier);

            AddChild(classSpecifier.members);
            AddChild(classSpecifier.base_classes);
            AddChild(classSpecifier.name);
        }

        partial void Visit(in MemberSpecification memberSpecification);

        private void VisitMemberSpecification(SyntaxIndex index)
        {
            ref readonly var memberSpecification = ref _reader.Get<MemberSpecification>(index);

            Visit(in memberSpecification);

            AddChild(memberSpecification.declarations);
        }

        partial void Visit(in MemberDeclaration memberDeclaration);

        private void VisitMemberDeclaration(SyntaxIndex index)
        {
            ref readonly var memberDeclaration = ref _reader.Get<MemberDeclaration>(index);

            Visit(in memberDeclaration);

            AddChild(memberDeclaration.declarators);
            AddChild(memberDeclaration.decl_specifier_seq);
        }

        partial void Visit(in MemberDeclarator memberDeclarator);

        private void VisitMemberDeclarator(SyntaxIndex index)
        {
            ref readonly var memberDeclarator = ref _reader.Get<MemberDeclarator>(index);

            Visit(in memberDeclarator);

            AddChild(memberDeclarator.initializer);
            AddChild(memberDeclarator.expression);
            AddChild(memberDeclarator.requires_clause);
            AddChild(memberDeclarator.declarator);
        }

        partial void Visit(in AccessSpecifier accessSpecifier);

        private void VisitAccessSpecifier(SyntaxIndex index)
        {
            ref readonly var accessSpecifier = ref _reader.Get<AccessSpecifier>(index);

            Visit(in accessSpecifier);
        }

        partial void Visit(in BaseSpecifierList baseSpecifierList);

        private void VisitBaseSpecifierList(SyntaxIndex index)
        {
            ref readonly var baseSpecifierList = ref _reader.Get<BaseSpecifierList>(index);

            Visit(in baseSpecifierList);

            AddChild(baseSpecifierList.base_specifiers);
        }

        partial void Visit(in BaseSpecifier baseSpecifier);

        private void VisitBaseSpecifier(SyntaxIndex index)
        {
            ref readonly var baseSpecifier = ref _reader.Get<BaseSpecifier>(index);

            Visit(in baseSpecifier);

            AddChild(baseSpecifier.name);
        }

        partial void Visit(in TypeId typeId);

        private void VisitTypeId(SyntaxIndex index)
        {
            ref readonly var typeId = ref _reader.Get<TypeId>(index);

            Visit(in typeId);

            AddChild(typeId.declarator);
            AddChild(typeId.type);
        }

        partial void Visit(in TrailingReturnType trailingReturnType);

        private void VisitTrailingReturnType(SyntaxIndex index)
        {
            ref readonly var trailingReturnType = ref _reader.Get<TrailingReturnType>(index);

            Visit(in trailingReturnType);

            AddChild(trailingReturnType.type);
        }

        partial void Visit(in Declarator declarator);

        private void VisitDeclarator(SyntaxIndex index)
        {
            ref readonly var declarator = ref _reader.Get<Declarator>(index);

            Visit(in declarator);

            AddChild(declarator.name);
            AddChild(declarator.virtual_specifiers);
            AddChild(declarator.trailing_return_type);
            AddChild(declarator.array_or_function_declarator);
            AddChild(declarator.parenthesized_declarator);
            AddChild(declarator.pointer);
        }

        partial void Visit(in PointerDeclarator pointerDeclarator);

        private void VisitPointerDeclarator(SyntaxIndex index)
        {
            ref readonly var pointerDeclarator = ref _reader.Get<PointerDeclarator>(index);

            Visit(in pointerDeclarator);

            AddChild(pointerDeclarator.child);
            AddChild(pointerDeclarator.owner);
        }

        partial void Visit(in ArrayDeclarator arrayDeclarator);

        private void VisitArrayDeclarator(SyntaxIndex index)
        {
            ref readonly var arrayDeclarator = ref _reader.Get<ArrayDeclarator>(index);

            Visit(in arrayDeclarator);

            AddChild(arrayDeclarator.bounds);
        }

        partial void Visit(in FunctionDeclarator functionDeclarator);

        private void VisitFunctionDeclarator(SyntaxIndex index)
        {
            ref readonly var functionDeclarator = ref _reader.Get<FunctionDeclarator>(index);

            Visit(in functionDeclarator);

            AddChild(functionDeclarator.exception_specification);
            AddChild(functionDeclarator.parameters);
        }

        partial void Visit(in ArrayOrFunctionDeclarator arrayOrFunctionDeclarator);

        private void VisitArrayOrFunctionDeclarator(SyntaxIndex index)
        {
            ref readonly var arrayOrFunctionDeclarator = ref _reader.Get<ArrayOrFunctionDeclarator>(index);

            Visit(in arrayOrFunctionDeclarator);

            AddChild(arrayOrFunctionDeclarator.next);
            AddChild(arrayOrFunctionDeclarator.declarator);
        }

        partial void Visit(in ParameterDeclarator parameterDeclarator);

        private void VisitParameterDeclarator(SyntaxIndex index)
        {
            ref readonly var parameterDeclarator = ref _reader.Get<ParameterDeclarator>(index);

            Visit(in parameterDeclarator);

            AddChild(parameterDeclarator.default_argument);
            AddChild(parameterDeclarator.declarator);
            AddChild(parameterDeclarator.decl_specifier_seq);
        }

        partial void Visit(in InitDeclarator initDeclarator);

        private void VisitInitDeclarator(SyntaxIndex index)
        {
            ref readonly var initDeclarator = ref _reader.Get<InitDeclarator>(index);

            Visit(in initDeclarator);

            AddChild(initDeclarator.initializer);
            AddChild(initDeclarator.requires_clause);
            AddChild(initDeclarator.declarator);
        }

        partial void Visit(in NewDeclarator newDeclarator);

        private void VisitNewDeclarator(SyntaxIndex index)
        {
            ref readonly var newDeclarator = ref _reader.Get<NewDeclarator>(index);

            Visit(in newDeclarator);

            AddChild(newDeclarator.declarator);
        }

        partial void Visit(in SimpleDeclaration simpleDeclaration);

        private void VisitSimpleDeclaration(SyntaxIndex index)
        {
            ref readonly var simpleDeclaration = ref _reader.Get<SimpleDeclaration>(index);

            Visit(in simpleDeclaration);

            AddChild(simpleDeclaration.declarators);
            AddChild(simpleDeclaration.decl_specifier_seq);
        }

        partial void Visit(in ExceptionDeclaration exceptionDeclaration);

        private void VisitExceptionDeclaration(SyntaxIndex index)
        {
            ref readonly var exceptionDeclaration = ref _reader.Get<ExceptionDeclaration>(index);

            Visit(in exceptionDeclaration);

            AddChild(exceptionDeclaration.declarator);
            AddChild(exceptionDeclaration.type_specifier_seq);
        }

        partial void Visit(in ConditionDeclaration conditionDeclaration);

        private void VisitConditionDeclaration(SyntaxIndex index)
        {
            ref readonly var conditionDeclaration = ref _reader.Get<ConditionDeclaration>(index);

            Visit(in conditionDeclaration);

            AddChild(conditionDeclaration.init_statement);
            AddChild(conditionDeclaration.decl_specifier);
        }

        partial void Visit(in StaticAssertDeclaration staticAssertDeclaration);

        private void VisitStaticAssertDeclaration(SyntaxIndex index)
        {
            ref readonly var staticAssertDeclaration = ref _reader.Get<StaticAssertDeclaration>(index);

            Visit(in staticAssertDeclaration);

            AddChild(staticAssertDeclaration.message);
            AddChild(staticAssertDeclaration.expression);
        }

        partial void Visit(in AliasDeclaration aliasDeclaration);

        private void VisitAliasDeclaration(SyntaxIndex index)
        {
            ref readonly var aliasDeclaration = ref _reader.Get<AliasDeclaration>(index);

            Visit(in aliasDeclaration);

            AddChild(aliasDeclaration.defining_type_id);
        }

        partial void Visit(in ConceptDefinition conceptDefinition);

        private void VisitConceptDefinition(SyntaxIndex index)
        {
            ref readonly var conceptDefinition = ref _reader.Get<ConceptDefinition>(index);

            Visit(in conceptDefinition);

            AddChild(conceptDefinition.expression);
            AddChild(conceptDefinition.parameters);
        }

        partial void Visit(in CompoundStatement compoundStatement);

        private void VisitCompoundStatement(SyntaxIndex index)
        {
            ref readonly var compoundStatement = ref _reader.Get<CompoundStatement>(index);

            Visit(in compoundStatement);

            AddChild(compoundStatement.statements);
        }

        partial void Visit(in ReturnStatement returnStatement);

        private void VisitReturnStatement(SyntaxIndex index)
        {
            ref readonly var returnStatement = ref _reader.Get<ReturnStatement>(index);

            Visit(in returnStatement);

            AddChild(returnStatement.expr);
        }

        partial void Visit(in IfStatement ifStatement);

        private void VisitIfStatement(SyntaxIndex index)
        {
            ref readonly var ifStatement = ref _reader.Get<IfStatement>(index);

            Visit(in ifStatement);

            AddChild(ifStatement.if_false);
            AddChild(ifStatement.if_true);
            AddChild(ifStatement.condition);
            AddChild(ifStatement.init_statement);
        }

        partial void Visit(in WhileStatement whileStatement);

        private void VisitWhileStatement(SyntaxIndex index)
        {
            ref readonly var whileStatement = ref _reader.Get<WhileStatement>(index);

            Visit(in whileStatement);

            AddChild(whileStatement.statement);
            AddChild(whileStatement.condition);
        }

        partial void Visit(in DoWhileStatement doWhileStatement);

        private void VisitDoWhileStatement(SyntaxIndex index)
        {
            ref readonly var doWhileStatement = ref _reader.Get<DoWhileStatement>(index);

            Visit(in doWhileStatement);

            AddChild(doWhileStatement.statement);
            AddChild(doWhileStatement.condition);
        }

        partial void Visit(in ForStatement forStatement);

        private void VisitForStatement(SyntaxIndex index)
        {
            ref readonly var forStatement = ref _reader.Get<ForStatement>(index);

            Visit(in forStatement);

            AddChild(forStatement.statement);
            AddChild(forStatement.expression);
            AddChild(forStatement.condition);
            AddChild(forStatement.init_statement);
        }

        partial void Visit(in InitStatement initStatement);

        private void VisitInitStatement(SyntaxIndex index)
        {
            ref readonly var initStatement = ref _reader.Get<InitStatement>(index);

            Visit(in initStatement);

            AddChild(initStatement.expression_or_declaration);
        }

        partial void Visit(in RangeBasedForStatement rangeBasedForStatement);

        private void VisitRangeBasedForStatement(SyntaxIndex index)
        {
            ref readonly var rangeBasedForStatement = ref _reader.Get<RangeBasedForStatement>(index);

            Visit(in rangeBasedForStatement);

            AddChild(rangeBasedForStatement.statement);
            AddChild(rangeBasedForStatement.initializer);
            AddChild(rangeBasedForStatement.declaration);
            AddChild(rangeBasedForStatement.init_statement);
        }

        partial void Visit(in ForRangeDeclaration forRangeDeclaration);

        private void VisitForRangeDeclaration(SyntaxIndex index)
        {
            ref readonly var forRangeDeclaration = ref _reader.Get<ForRangeDeclaration>(index);

            Visit(in forRangeDeclaration);

            AddChild(forRangeDeclaration.declarator);
            AddChild(forRangeDeclaration.decl_specifier_seq);
        }

        partial void Visit(in LabeledStatement labeledStatement);

        private void VisitLabeledStatement(SyntaxIndex index)
        {
            ref readonly var labeledStatement = ref _reader.Get<LabeledStatement>(index);

            Visit(in labeledStatement);

            AddChild(labeledStatement.statement);
            AddChild(labeledStatement.expression);
        }

        partial void Visit(in BreakStatement breakStatement);

        private void VisitBreakStatement(SyntaxIndex index)
        {
            ref readonly var breakStatement = ref _reader.Get<BreakStatement>(index);

            Visit(in breakStatement);
        }

        partial void Visit(in ContinueStatement continueStatement);

        private void VisitContinueStatement(SyntaxIndex index)
        {
            ref readonly var continueStatement = ref _reader.Get<ContinueStatement>(index);

            Visit(in continueStatement);
        }

        partial void Visit(in SwitchStatement switchStatement);

        private void VisitSwitchStatement(SyntaxIndex index)
        {
            ref readonly var switchStatement = ref _reader.Get<SwitchStatement>(index);

            Visit(in switchStatement);

            AddChild(switchStatement.statement);
            AddChild(switchStatement.condition);
            AddChild(switchStatement.init_statement);
        }

        partial void Visit(in GotoStatement gotoStatement);

        private void VisitGotoStatement(SyntaxIndex index)
        {
            ref readonly var gotoStatement = ref _reader.Get<GotoStatement>(index);

            Visit(in gotoStatement);
        }

        partial void Visit(in DeclarationStatement declarationStatement);

        private void VisitDeclarationStatement(SyntaxIndex index)
        {
            ref readonly var declarationStatement = ref _reader.Get<DeclarationStatement>(index);

            Visit(in declarationStatement);

            AddChild(declarationStatement.declaration);
        }

        partial void Visit(in ExpressionStatement expressionStatement);

        private void VisitExpressionStatement(SyntaxIndex index)
        {
            ref readonly var expressionStatement = ref _reader.Get<ExpressionStatement>(index);

            Visit(in expressionStatement);

            AddChild(expressionStatement.expression);
        }

        partial void Visit(in TryBlock tryBlock);

        private void VisitTryBlock(SyntaxIndex index)
        {
            ref readonly var tryBlock = ref _reader.Get<TryBlock>(index);

            Visit(in tryBlock);

            AddChild(tryBlock.handler_seq);
            AddChild(tryBlock.statement);
        }

        partial void Visit(in Handler handler);

        private void VisitHandler(SyntaxIndex index)
        {
            ref readonly var handler = ref _reader.Get<Handler>(index);

            Visit(in handler);

            AddChild(handler.statement);
            AddChild(handler.exception_declaration);
        }

        partial void Visit(in HandlerSeq handlerSeq);

        private void VisitHandlerSeq(SyntaxIndex index)
        {
            ref readonly var handlerSeq = ref _reader.Get<HandlerSeq>(index);

            Visit(in handlerSeq);

            AddChild(handlerSeq.handlers);
        }

        partial void Visit(in FunctionTryBlock functionTryBlock);

        private void VisitFunctionTryBlock(SyntaxIndex index)
        {
            ref readonly var functionTryBlock = ref _reader.Get<FunctionTryBlock>(index);

            Visit(in functionTryBlock);

            AddChild(functionTryBlock.initializers);
            AddChild(functionTryBlock.handler_seq);
            AddChild(functionTryBlock.statement);
        }

        partial void Visit(in TypeIdListElement typeIdListElement);

        private void VisitTypeIdListElement(SyntaxIndex index)
        {
            ref readonly var typeIdListElement = ref _reader.Get<TypeIdListElement>(index);

            Visit(in typeIdListElement);

            AddChild(typeIdListElement.type_id);
        }

        partial void Visit(in DynamicExceptionSpec dynamicExceptionSpec);

        private void VisitDynamicExceptionSpec(SyntaxIndex index)
        {
            ref readonly var dynamicExceptionSpec = ref _reader.Get<DynamicExceptionSpec>(index);

            Visit(in dynamicExceptionSpec);

            AddChild(dynamicExceptionSpec.type_list);
        }

        partial void Visit(in StatementSeq statementSeq);

        private void VisitStatementSeq(SyntaxIndex index)
        {
            ref readonly var statementSeq = ref _reader.Get<StatementSeq>(index);

            Visit(in statementSeq);

            AddChild(statementSeq.statements);
        }

        partial void Visit(in FunctionBody functionBody);

        private void VisitFunctionBody(SyntaxIndex index)
        {
            ref readonly var functionBody = ref _reader.Get<FunctionBody>(index);

            Visit(in functionBody);

            AddChild(functionBody.initializers);
            AddChild(functionBody.function_try_block);
            AddChild(functionBody.statements);
        }

        partial void Visit(in Expression expression);

        private void VisitExpression(SyntaxIndex index)
        {
            ref readonly var expression = ref _reader.Get<Expression>(index);

            Visit(in expression);

            AddChild(expression.expression);
        }

        partial void Visit(in FunctionDefinition functionDefinition);

        private void VisitFunctionDefinition(SyntaxIndex index)
        {
            ref readonly var functionDefinition = ref _reader.Get<FunctionDefinition>(index);

            Visit(in functionDefinition);

            AddChild(functionDefinition.body);
            AddChild(functionDefinition.requires_clause);
            AddChild(functionDefinition.declarator);
            AddChild(functionDefinition.decl_specifier_seq);
        }

        partial void Visit(in MemberFunctionDeclaration memberFunctionDeclaration);

        private void VisitMemberFunctionDeclaration(SyntaxIndex index)
        {
            ref readonly var memberFunctionDeclaration = ref _reader.Get<MemberFunctionDeclaration>(index);

            Visit(in memberFunctionDeclaration);

            AddChild(memberFunctionDeclaration.definition);
        }

        partial void Visit(in TemplateDeclaration templateDeclaration);

        private void VisitTemplateDeclaration(SyntaxIndex index)
        {
            ref readonly var templateDeclaration = ref _reader.Get<TemplateDeclaration>(index);

            Visit(in templateDeclaration);

            AddChild(templateDeclaration.declaration);
            AddChild(templateDeclaration.parameters);
        }

        partial void Visit(in RequiresClause requiresClause);

        private void VisitRequiresClause(SyntaxIndex index)
        {
            ref readonly var requiresClause = ref _reader.Get<RequiresClause>(index);

            Visit(in requiresClause);

            AddChild(requiresClause.expression);
        }

        partial void Visit(in SimpleRequirement simpleRequirement);

        private void VisitSimpleRequirement(SyntaxIndex index)
        {
            ref readonly var simpleRequirement = ref _reader.Get<SimpleRequirement>(index);

            Visit(in simpleRequirement);

            AddChild(simpleRequirement.expression);
        }

        partial void Visit(in TypeRequirement typeRequirement);

        private void VisitTypeRequirement(SyntaxIndex index)
        {
            ref readonly var typeRequirement = ref _reader.Get<TypeRequirement>(index);

            Visit(in typeRequirement);

            AddChild(typeRequirement.type);
        }

        partial void Visit(in CompoundRequirement compoundRequirement);

        private void VisitCompoundRequirement(SyntaxIndex index)
        {
            ref readonly var compoundRequirement = ref _reader.Get<CompoundRequirement>(index);

            Visit(in compoundRequirement);

            AddChild(compoundRequirement.type_constraint);
            AddChild(compoundRequirement.expression);
        }

        partial void Visit(in NestedRequirement nestedRequirement);

        private void VisitNestedRequirement(SyntaxIndex index)
        {
            ref readonly var nestedRequirement = ref _reader.Get<NestedRequirement>(index);

            Visit(in nestedRequirement);

            AddChild(nestedRequirement.expression);
        }

        partial void Visit(in RequirementBody requirementBody);

        private void VisitRequirementBody(SyntaxIndex index)
        {
            ref readonly var requirementBody = ref _reader.Get<RequirementBody>(index);

            Visit(in requirementBody);

            AddChild(requirementBody.requirements);
        }

        partial void Visit(in TypeTemplateParameter typeTemplateParameter);

        private void VisitTypeTemplateParameter(SyntaxIndex index)
        {
            ref readonly var typeTemplateParameter = ref _reader.Get<TypeTemplateParameter>(index);

            Visit(in typeTemplateParameter);

            AddChild(typeTemplateParameter.default_argument);
            AddChild(typeTemplateParameter.type_constraint);
        }

        partial void Visit(in TemplateTemplateParameter templateTemplateParameter);

        private void VisitTemplateTemplateParameter(SyntaxIndex index)
        {
            ref readonly var templateTemplateParameter = ref _reader.Get<TemplateTemplateParameter>(index);

            Visit(in templateTemplateParameter);

            AddChild(templateTemplateParameter.parameters);
            AddChild(templateTemplateParameter.default_argument);
        }

        partial void Visit(in TypeTemplateArgument typeTemplateArgument);

        private void VisitTypeTemplateArgument(SyntaxIndex index)
        {
            ref readonly var typeTemplateArgument = ref _reader.Get<TypeTemplateArgument>(index);

            Visit(in typeTemplateArgument);

            AddChild(typeTemplateArgument.argument);
        }

        partial void Visit(in NonTypeTemplateArgument nonTypeTemplateArgument);

        private void VisitNonTypeTemplateArgument(SyntaxIndex index)
        {
            ref readonly var nonTypeTemplateArgument = ref _reader.Get<NonTypeTemplateArgument>(index);

            Visit(in nonTypeTemplateArgument);

            AddChild(nonTypeTemplateArgument.argument);
        }

        partial void Visit(in TemplateParameterList templateParameterList);

        private void VisitTemplateParameterList(SyntaxIndex index)
        {
            ref readonly var templateParameterList = ref _reader.Get<TemplateParameterList>(index);

            Visit(in templateParameterList);

            AddChild(templateParameterList.requires_clause);
            AddChild(templateParameterList.parameters);
        }

        partial void Visit(in TemplateArgumentList templateArgumentList);

        private void VisitTemplateArgumentList(SyntaxIndex index)
        {
            ref readonly var templateArgumentList = ref _reader.Get<TemplateArgumentList>(index);

            Visit(in templateArgumentList);

            AddChild(templateArgumentList.arguments);
        }

        partial void Visit(in TemplateId templateId);

        private void VisitTemplateId(SyntaxIndex index)
        {
            ref readonly var templateId = ref _reader.Get<TemplateId>(index);

            Visit(in templateId);

            AddChild(templateId.arguments);
            AddChild(templateId.symbol);
            AddChild(templateId.name);
        }

        partial void Visit(in MemInitializer memInitializer);

        private void VisitMemInitializer(SyntaxIndex index)
        {
            ref readonly var memInitializer = ref _reader.Get<MemInitializer>(index);

            Visit(in memInitializer);

            AddChild(memInitializer.initializer);
            AddChild(memInitializer.name);
        }

        partial void Visit(in CtorInitializer ctorInitializer);

        private void VisitCtorInitializer(SyntaxIndex index)
        {
            ref readonly var ctorInitializer = ref _reader.Get<CtorInitializer>(index);

            Visit(in ctorInitializer);

            AddChild(ctorInitializer.initializers);
        }

        partial void Visit(in LambdaIntroducer lambdaIntroducer);

        private void VisitLambdaIntroducer(SyntaxIndex index)
        {
            ref readonly var lambdaIntroducer = ref _reader.Get<LambdaIntroducer>(index);

            Visit(in lambdaIntroducer);

            AddChild(lambdaIntroducer.captures);
        }

        partial void Visit(in LambdaDeclarator lambdaDeclarator);

        private void VisitLambdaDeclarator(SyntaxIndex index)
        {
            ref readonly var lambdaDeclarator = ref _reader.Get<LambdaDeclarator>(index);

            Visit(in lambdaDeclarator);

            AddChild(lambdaDeclarator.trailing_return_type);
            AddChild(lambdaDeclarator.exception_specification);
            AddChild(lambdaDeclarator.parameters);
        }

        partial void Visit(in CaptureDefault captureDefault);

        private void VisitCaptureDefault(SyntaxIndex index)
        {
            ref readonly var captureDefault = ref _reader.Get<CaptureDefault>(index);

            Visit(in captureDefault);
        }

        partial void Visit(in SimpleCapture simpleCapture);

        private void VisitSimpleCapture(SyntaxIndex index)
        {
            ref readonly var simpleCapture = ref _reader.Get<SimpleCapture>(index);

            Visit(in simpleCapture);

            AddChild(simpleCapture.name);
        }

        partial void Visit(in InitCapture initCapture);

        private void VisitInitCapture(SyntaxIndex index)
        {
            ref readonly var initCapture = ref _reader.Get<InitCapture>(index);

            Visit(in initCapture);

            AddChild(initCapture.initializer);
            AddChild(initCapture.name);
        }

        partial void Visit(in ThisCapture thisCapture);

        private void VisitThisCapture(SyntaxIndex index)
        {
            ref readonly var thisCapture = ref _reader.Get<ThisCapture>(index);

            Visit(in thisCapture);
        }

        partial void Visit(in AttributedStatement attributedStatement);

        private void VisitAttributedStatement(SyntaxIndex index)
        {
            ref readonly var attributedStatement = ref _reader.Get<AttributedStatement>(index);

            Visit(in attributedStatement);

            AddChild(attributedStatement.attributes);
            AddChild(attributedStatement.statement);
        }

        partial void Visit(in AttributedDeclaration attributedDeclaration);

        private void VisitAttributedDeclaration(SyntaxIndex index)
        {
            ref readonly var attributedDeclaration = ref _reader.Get<AttributedDeclaration>(index);

            Visit(in attributedDeclaration);

            AddChild(attributedDeclaration.attributes);
            AddChild(attributedDeclaration.declaration);
        }

        partial void Visit(in AttributeSpecifierSeq attributeSpecifierSeq);

        private void VisitAttributeSpecifierSeq(SyntaxIndex index)
        {
            ref readonly var attributeSpecifierSeq = ref _reader.Get<AttributeSpecifierSeq>(index);

            Visit(in attributeSpecifierSeq);

            AddChild(attributeSpecifierSeq.attributes);
        }

        partial void Visit(in AttributeSpecifier attributeSpecifier);

        private void VisitAttributeSpecifier(SyntaxIndex index)
        {
            ref readonly var attributeSpecifier = ref _reader.Get<AttributeSpecifier>(index);

            Visit(in attributeSpecifier);

            AddChild(attributeSpecifier.attributes);
            AddChild(attributeSpecifier.using_prefix);
        }

        partial void Visit(in AttributeUsingPrefix attributeUsingPrefix);

        private void VisitAttributeUsingPrefix(SyntaxIndex index)
        {
            ref readonly var attributeUsingPrefix = ref _reader.Get<AttributeUsingPrefix>(index);

            Visit(in attributeUsingPrefix);

            AddChild(attributeUsingPrefix.attribute_namespace);
        }

        partial void Visit(in Attribute attribute);

        private void VisitAttribute(SyntaxIndex index)
        {
            ref readonly var attribute = ref _reader.Get<Attribute>(index);

            Visit(in attribute);

            AddChild(attribute.argument_clause);
            AddChild(attribute.attribute_namespace);
            AddChild(attribute.identifier);
        }

        partial void Visit(in AttributeArgumentClause attributeArgumentClause);

        private void VisitAttributeArgumentClause(SyntaxIndex index)
        {
            ref readonly var attributeArgumentClause = ref _reader.Get<AttributeArgumentClause>(index);

            Visit(in attributeArgumentClause);
        }

        partial void Visit(in AlignasSpecifier alignasSpecifier);

        private void VisitAlignasSpecifier(SyntaxIndex index)
        {
            ref readonly var alignasSpecifier = ref _reader.Get<AlignasSpecifier>(index);

            Visit(in alignasSpecifier);

            AddChild(alignasSpecifier.expression);
        }

        partial void Visit(in UsingDeclaration usingDeclaration);

        private void VisitUsingDeclaration(SyntaxIndex index)
        {
            ref readonly var usingDeclaration = ref _reader.Get<UsingDeclaration>(index);

            Visit(in usingDeclaration);

            AddChild(usingDeclaration.declarators);
        }

        partial void Visit(in UsingDeclarator usingDeclarator);

        private void VisitUsingDeclarator(SyntaxIndex index)
        {
            ref readonly var usingDeclarator = ref _reader.Get<UsingDeclarator>(index);

            Visit(in usingDeclarator);

            AddChild(usingDeclarator.qualified_name);
        }

        partial void Visit(in UsingDirective usingDirective);

        private void VisitUsingDirective(SyntaxIndex index)
        {
            ref readonly var usingDirective = ref _reader.Get<UsingDirective>(index);

            Visit(in usingDirective);

            AddChild(usingDirective.qualified_name);
        }

        partial void Visit(in ArrayIndex arrayIndex);

        private void VisitArrayIndex(SyntaxIndex index)
        {
            ref readonly var arrayIndex = ref _reader.Get<ArrayIndex>(index);

            Visit(in arrayIndex);

            AddChild(arrayIndex.index);
            AddChild(arrayIndex.array);
        }

        partial void Visit(in SEHTry sEHTry);

        private void VisitSEHTry(SyntaxIndex index)
        {
            ref readonly var sEHTry = ref _reader.Get<SEHTry>(index);

            Visit(in sEHTry);

            AddChild(sEHTry.handler);
            AddChild(sEHTry.statement);
        }

        partial void Visit(in SEHExcept sEHExcept);

        private void VisitSEHExcept(SyntaxIndex index)
        {
            ref readonly var sEHExcept = ref _reader.Get<SEHExcept>(index);

            Visit(in sEHExcept);

            AddChild(sEHExcept.statement);
            AddChild(sEHExcept.expression);
        }

        partial void Visit(in SEHFinally sEHFinally);

        private void VisitSEHFinally(SyntaxIndex index)
        {
            ref readonly var sEHFinally = ref _reader.Get<SEHFinally>(index);

            Visit(in sEHFinally);

            AddChild(sEHFinally.statement);
        }

        partial void Visit(in SEHLeave sEHLeave);

        private void VisitSEHLeave(SyntaxIndex index)
        {
            ref readonly var sEHLeave = ref _reader.Get<SEHLeave>(index);

            Visit(in sEHLeave);
        }

        partial void Visit(in TypeTraitIntrinsic typeTraitIntrinsic);

        private void VisitTypeTraitIntrinsic(SyntaxIndex index)
        {
            ref readonly var typeTraitIntrinsic = ref _reader.Get<TypeTraitIntrinsic>(index);

            Visit(in typeTraitIntrinsic);

            AddChild(typeTraitIntrinsic.arguments);
        }

        partial void Visit(in Tuple tuple);

        private void VisitTuple(SyntaxIndex index)
        {
            ref readonly var tuple = ref _reader.Get<Tuple>(index);

            Visit(in tuple);
        }

        partial void Visit(in AsmStatement asmStatement);

        private void VisitAsmStatement(SyntaxIndex index)
        {
            ref readonly var asmStatement = ref _reader.Get<AsmStatement>(index);

            Visit(in asmStatement);
        }

        partial void Visit(in NamespaceAliasDefinition namespaceAliasDefinition);

        private void VisitNamespaceAliasDefinition(SyntaxIndex index)
        {
            ref readonly var namespaceAliasDefinition = ref _reader.Get<NamespaceAliasDefinition>(index);

            Visit(in namespaceAliasDefinition);

            AddChild(namespaceAliasDefinition.namespace_name);
            AddChild(namespaceAliasDefinition.identifier);
        }

        partial void Visit(in Super super);

        private void VisitSuper(SyntaxIndex index)
        {
            ref readonly var super = ref _reader.Get<Super>(index);

            Visit(in super);
        }

        partial void Visit(in UnaryFoldExpression unaryFoldExpression);

        private void VisitUnaryFoldExpression(SyntaxIndex index)
        {
            ref readonly var unaryFoldExpression = ref _reader.Get<UnaryFoldExpression>(index);

            Visit(in unaryFoldExpression);

            AddChild(unaryFoldExpression.expression);
        }

        partial void Visit(in BinaryFoldExpression binaryFoldExpression);

        private void VisitBinaryFoldExpression(SyntaxIndex index)
        {
            ref readonly var binaryFoldExpression = ref _reader.Get<BinaryFoldExpression>(index);

            Visit(in binaryFoldExpression);

            AddChild(binaryFoldExpression.right_expression);
            AddChild(binaryFoldExpression.left_expression);
        }

        partial void Visit(in EmptyStatement emptyStatement);

        private void VisitEmptyStatement(SyntaxIndex index)
        {
            ref readonly var emptyStatement = ref _reader.Get<EmptyStatement>(index);

            Visit(in emptyStatement);
        }

        partial void Visit(in StructuredBindingDeclaration structuredBindingDeclaration);

        private void VisitStructuredBindingDeclaration(SyntaxIndex index)
        {
            ref readonly var structuredBindingDeclaration = ref _reader.Get<StructuredBindingDeclaration>(index);

            Visit(in structuredBindingDeclaration);

            AddChild(structuredBindingDeclaration.initializer);
            AddChild(structuredBindingDeclaration.identifier_list);
            AddChild(structuredBindingDeclaration.decl_specifier_seq);
        }

        partial void Visit(in StructuredBindingIdentifier structuredBindingIdentifier);

        private void VisitStructuredBindingIdentifier(SyntaxIndex index)
        {
            ref readonly var structuredBindingIdentifier = ref _reader.Get<StructuredBindingIdentifier>(index);

            Visit(in structuredBindingIdentifier);

            AddChild(structuredBindingIdentifier.identifier);
        }

        partial void Visit(in UsingEnumDeclaration usingEnumDeclaration);

        private void VisitUsingEnumDeclaration(SyntaxIndex index)
        {
            ref readonly var usingEnumDeclaration = ref _reader.Get<UsingEnumDeclaration>(index);

            Visit(in usingEnumDeclaration);

            AddChild(usingEnumDeclaration.name);
        }

        partial void Visit(in TryStmt tryStmt);

        private void VisitTryStmt(StmtIndex index)
        {
            ref readonly var tryStmt = ref _reader.Get<TryStmt>(index);

            Visit(in tryStmt);

            AddChild(tryStmt.handlers);
        }

        partial void Visit(in IfStmt ifStmt);

        private void VisitIfStmt(StmtIndex index)
        {
            ref readonly var ifStmt = ref _reader.Get<IfStmt>(index);

            Visit(in ifStmt);

            AddChild(ifStmt.alternative);
            AddChild(ifStmt.consequence);
            AddChild(ifStmt.condition);
            AddChild(ifStmt.init);
        }

        partial void Visit(in ForStmt forStmt);

        private void VisitForStmt(StmtIndex index)
        {
            ref readonly var forStmt = ref _reader.Get<ForStmt>(index);

            Visit(in forStmt);

            AddChild(forStmt.body);
            AddChild(forStmt.increment);
            AddChild(forStmt.condition);
            AddChild(forStmt.init);
        }

        partial void Visit(in LabeledStmt labeledStmt);

        private void VisitLabeledStmt(StmtIndex index)
        {
            ref readonly var labeledStmt = ref _reader.Get<LabeledStmt>(index);

            Visit(in labeledStmt);

            AddChild(labeledStmt.statement);
            AddChild(labeledStmt.label);
            AddChild(labeledStmt.type);
        }

        partial void Visit(in WhileStmt whileStmt);

        private void VisitWhileStmt(StmtIndex index)
        {
            ref readonly var whileStmt = ref _reader.Get<WhileStmt>(index);

            Visit(in whileStmt);

            AddChild(whileStmt.body);
            AddChild(whileStmt.condition);
        }

        partial void Visit(in BlockStmt blockStmt);

        private void VisitBlockStmt(StmtIndex index)
        {
            ref readonly var blockStmt = ref _reader.Get<BlockStmt>(index);

            Visit(in blockStmt);
        }

        partial void Visit(in BreakStmt breakStmt);

        private void VisitBreakStmt(StmtIndex index)
        {
            ref readonly var breakStmt = ref _reader.Get<BreakStmt>(index);

            Visit(in breakStmt);
        }

        partial void Visit(in SwitchStmt switchStmt);

        private void VisitSwitchStmt(StmtIndex index)
        {
            ref readonly var switchStmt = ref _reader.Get<SwitchStmt>(index);

            Visit(in switchStmt);

            AddChild(switchStmt.body);
            AddChild(switchStmt.control);
            AddChild(switchStmt.init);
        }

        partial void Visit(in DoWhileStmt doWhileStmt);

        private void VisitDoWhileStmt(StmtIndex index)
        {
            ref readonly var doWhileStmt = ref _reader.Get<DoWhileStmt>(index);

            Visit(in doWhileStmt);

            AddChild(doWhileStmt.body);
            AddChild(doWhileStmt.condition);
        }

        partial void Visit(in GotoStmt gotoStmt);

        private void VisitGotoStmt(StmtIndex index)
        {
            ref readonly var gotoStmt = ref _reader.Get<GotoStmt>(index);

            Visit(in gotoStmt);

            AddChild(gotoStmt.target);
        }

        partial void Visit(in ContinueStmt continueStmt);

        private void VisitContinueStmt(StmtIndex index)
        {
            ref readonly var continueStmt = ref _reader.Get<ContinueStmt>(index);

            Visit(in continueStmt);
        }

        partial void Visit(in ExpressionStmt expressionStmt);

        private void VisitExpressionStmt(StmtIndex index)
        {
            ref readonly var expressionStmt = ref _reader.Get<ExpressionStmt>(index);

            Visit(in expressionStmt);

            AddChild(expressionStmt.expr);
        }

        partial void Visit(in ReturnStmt returnStmt);

        private void VisitReturnStmt(StmtIndex index)
        {
            ref readonly var returnStmt = ref _reader.Get<ReturnStmt>(index);

            Visit(in returnStmt);

            AddChild(returnStmt.function_type);
            AddChild(returnStmt.expr);
            AddChild(returnStmt.type);
        }

        partial void Visit(in DeclStmt declStmt);

        private void VisitDeclStmt(StmtIndex index)
        {
            ref readonly var declStmt = ref _reader.Get<DeclStmt>(index);

            Visit(in declStmt);

            AddChild(declStmt.decl);
        }

        partial void Visit(in ExpansionStmt expansionStmt);

        private void VisitExpansionStmt(StmtIndex index)
        {
            ref readonly var expansionStmt = ref _reader.Get<ExpansionStmt>(index);

            Visit(in expansionStmt);

            AddChild(expansionStmt.operand);
        }

        partial void Visit(in HandlerStmt handlerStmt);

        private void VisitHandlerStmt(StmtIndex index)
        {
            ref readonly var handlerStmt = ref _reader.Get<HandlerStmt>(index);

            Visit(in handlerStmt);

            AddChild(handlerStmt.body);
            AddChild(handlerStmt.exception);
        }

        partial void Visit(in TupleStmt tupleStmt);

        private void VisitTupleStmt(StmtIndex index)
        {
            ref readonly var tupleStmt = ref _reader.Get<TupleStmt>(index);

            Visit(in tupleStmt);

            AddChild(tupleStmt.type);
        }

        partial void Visit(in EmptyExpr emptyExpr);

        private void VisitEmptyExpr(ExprIndex index)
        {
            ref readonly var emptyExpr = ref _reader.Get<EmptyExpr>(index);

            Visit(in emptyExpr);

            AddChild(emptyExpr.type);
        }

        partial void Visit(in LiteralExpr literalExpr);

        private void VisitLiteralExpr(ExprIndex index)
        {
            ref readonly var literalExpr = ref _reader.Get<LiteralExpr>(index);

            Visit(in literalExpr);

            AddChild(literalExpr.value);
            AddChild(literalExpr.type);
        }

        partial void Visit(in LambdaExpr lambdaExpr);

        private void VisitLambdaExpr(ExprIndex index)
        {
            ref readonly var lambdaExpr = ref _reader.Get<LambdaExpr>(index);

            Visit(in lambdaExpr);

            AddChild(lambdaExpr.body);
            AddChild(lambdaExpr.requires_clause);
            AddChild(lambdaExpr.declarator);
            AddChild(lambdaExpr.template_parameters);
            AddChild(lambdaExpr.introducer);
        }

        partial void Visit(in TypeExpr typeExpr);

        private void VisitTypeExpr(ExprIndex index)
        {
            ref readonly var typeExpr = ref _reader.Get<TypeExpr>(index);

            Visit(in typeExpr);

            AddChild(typeExpr.denotation);
            AddChild(typeExpr.type);
        }

        partial void Visit(in NamedDeclExpr namedDeclExpr);

        private void VisitNamedDeclExpr(ExprIndex index)
        {
            ref readonly var namedDeclExpr = ref _reader.Get<NamedDeclExpr>(index);

            Visit(in namedDeclExpr);

            AddChild(namedDeclExpr.decl);
            AddChild(namedDeclExpr.type);
        }

        partial void Visit(in UnresolvedIdExpr unresolvedIdExpr);

        private void VisitUnresolvedIdExpr(ExprIndex index)
        {
            ref readonly var unresolvedIdExpr = ref _reader.Get<UnresolvedIdExpr>(index);

            Visit(in unresolvedIdExpr);

            AddChild(unresolvedIdExpr.name);
            AddChild(unresolvedIdExpr.type);
        }

        partial void Visit(in TemplateIdExpr templateIdExpr);

        private void VisitTemplateIdExpr(ExprIndex index)
        {
            ref readonly var templateIdExpr = ref _reader.Get<TemplateIdExpr>(index);

            Visit(in templateIdExpr);

            AddChild(templateIdExpr.arguments);
            AddChild(templateIdExpr.primary_template);
            AddChild(templateIdExpr.type);
        }

        partial void Visit(in UnqualifiedIdExpr unqualifiedIdExpr);

        private void VisitUnqualifiedIdExpr(ExprIndex index)
        {
            ref readonly var unqualifiedIdExpr = ref _reader.Get<UnqualifiedIdExpr>(index);

            Visit(in unqualifiedIdExpr);

            AddChild(unqualifiedIdExpr.symbol);
            AddChild(unqualifiedIdExpr.name);
            AddChild(unqualifiedIdExpr.type);
        }

        partial void Visit(in SimpleIdentifierExpr simpleIdentifierExpr);

        private void VisitSimpleIdentifierExpr(ExprIndex index)
        {
            ref readonly var simpleIdentifierExpr = ref _reader.Get<SimpleIdentifierExpr>(index);

            Visit(in simpleIdentifierExpr);

            AddChild(simpleIdentifierExpr.name);
            AddChild(simpleIdentifierExpr.type);
        }

        partial void Visit(in PointerExpr pointerExpr);

        private void VisitPointerExpr(ExprIndex index)
        {
            ref readonly var pointerExpr = ref _reader.Get<PointerExpr>(index);

            Visit(in pointerExpr);
        }

        partial void Visit(in QualifiedNameExpr qualifiedNameExpr);

        private void VisitQualifiedNameExpr(ExprIndex index)
        {
            ref readonly var qualifiedNameExpr = ref _reader.Get<QualifiedNameExpr>(index);

            Visit(in qualifiedNameExpr);

            AddChild(qualifiedNameExpr.elements);
            AddChild(qualifiedNameExpr.type);
        }

        partial void Visit(in PathExpr pathExpr);

        private void VisitPathExpr(ExprIndex index)
        {
            ref readonly var pathExpr = ref _reader.Get<PathExpr>(index);

            Visit(in pathExpr);

            AddChild(pathExpr.member);
            AddChild(pathExpr.scope);
            AddChild(pathExpr.type);
        }

        partial void Visit(in ReadExpr readExpr);

        private void VisitReadExpr(ExprIndex index)
        {
            ref readonly var readExpr = ref _reader.Get<ReadExpr>(index);

            Visit(in readExpr);

            AddChild(readExpr.child);
            AddChild(readExpr.type);
        }

        partial void Visit(in MonadicExpr monadicExpr);

        private void VisitMonadicExpr(ExprIndex index)
        {
            ref readonly var monadicExpr = ref _reader.Get<MonadicExpr>(index);

            Visit(in monadicExpr);

            AddChild(monadicExpr.impl);
            AddChild(monadicExpr.type);
        }

        partial void Visit(in DyadicExpr dyadicExpr);

        private void VisitDyadicExpr(ExprIndex index)
        {
            ref readonly var dyadicExpr = ref _reader.Get<DyadicExpr>(index);

            Visit(in dyadicExpr);

            AddChild(dyadicExpr.impl);
            AddChild(dyadicExpr.type);
        }

        partial void Visit(in TriadicExpr triadicExpr);

        private void VisitTriadicExpr(ExprIndex index)
        {
            ref readonly var triadicExpr = ref _reader.Get<TriadicExpr>(index);

            Visit(in triadicExpr);

            AddChild(triadicExpr.impl);
            AddChild(triadicExpr.type);
        }

        partial void Visit(in StringExpr stringExpr);

        private void VisitStringExpr(ExprIndex index)
        {
            ref readonly var stringExpr = ref _reader.Get<StringExpr>(index);

            Visit(in stringExpr);

            AddChild(stringExpr.@string);
            AddChild(stringExpr.type);
        }

        partial void Visit(in TemporaryExpr temporaryExpr);

        private void VisitTemporaryExpr(ExprIndex index)
        {
            ref readonly var temporaryExpr = ref _reader.Get<TemporaryExpr>(index);

            Visit(in temporaryExpr);

            AddChild(temporaryExpr.type);
        }

        partial void Visit(in CallExpr callExpr);

        private void VisitCallExpr(ExprIndex index)
        {
            ref readonly var callExpr = ref _reader.Get<CallExpr>(index);

            Visit(in callExpr);

            AddChild(callExpr.arguments);
            AddChild(callExpr.function);
            AddChild(callExpr.type);
        }

        partial void Visit(in MemberInitializerExpr memberInitializerExpr);

        private void VisitMemberInitializerExpr(ExprIndex index)
        {
            ref readonly var memberInitializerExpr = ref _reader.Get<MemberInitializerExpr>(index);

            Visit(in memberInitializerExpr);

            AddChild(memberInitializerExpr.expression);
            AddChild(memberInitializerExpr.@base);
            AddChild(memberInitializerExpr.member);
            AddChild(memberInitializerExpr.type);
        }

        partial void Visit(in MemberAccessExpr memberAccessExpr);

        private void VisitMemberAccessExpr(ExprIndex index)
        {
            ref readonly var memberAccessExpr = ref _reader.Get<MemberAccessExpr>(index);

            Visit(in memberAccessExpr);

            AddChild(memberAccessExpr.parent);
            AddChild(memberAccessExpr.offset);
            AddChild(memberAccessExpr.type);
        }

        partial void Visit(in InheritancePathExpr inheritancePathExpr);

        private void VisitInheritancePathExpr(ExprIndex index)
        {
            ref readonly var inheritancePathExpr = ref _reader.Get<InheritancePathExpr>(index);

            Visit(in inheritancePathExpr);

            AddChild(inheritancePathExpr.path);
            AddChild(inheritancePathExpr.type);
        }

        partial void Visit(in InitializerListExpr initializerListExpr);

        private void VisitInitializerListExpr(ExprIndex index)
        {
            ref readonly var initializerListExpr = ref _reader.Get<InitializerListExpr>(index);

            Visit(in initializerListExpr);

            AddChild(initializerListExpr.elements);
            AddChild(initializerListExpr.type);
        }

        partial void Visit(in CastExpr castExpr);

        private void VisitCastExpr(ExprIndex index)
        {
            ref readonly var castExpr = ref _reader.Get<CastExpr>(index);

            Visit(in castExpr);

            AddChild(castExpr.target);
            AddChild(castExpr.source);
            AddChild(castExpr.type);
        }

        partial void Visit(in ConditionExpr conditionExpr);

        private void VisitConditionExpr(ExprIndex index)
        {
            ref readonly var conditionExpr = ref _reader.Get<ConditionExpr>(index);

            Visit(in conditionExpr);

            AddChild(conditionExpr.expression);
            AddChild(conditionExpr.type);
        }

        partial void Visit(in ExpressionListExpr expressionListExpr);

        private void VisitExpressionListExpr(ExprIndex index)
        {
            ref readonly var expressionListExpr = ref _reader.Get<ExpressionListExpr>(index);

            Visit(in expressionListExpr);

            AddChild(expressionListExpr.expressions);
        }

        partial void Visit(in SizeofTypeExpr sizeofTypeExpr);

        private void VisitSizeofTypeExpr(ExprIndex index)
        {
            ref readonly var sizeofTypeExpr = ref _reader.Get<SizeofTypeExpr>(index);

            Visit(in sizeofTypeExpr);

            AddChild(sizeofTypeExpr.operand);
            AddChild(sizeofTypeExpr.type);
        }

        partial void Visit(in AlignofExpr alignofExpr);

        private void VisitAlignofExpr(ExprIndex index)
        {
            ref readonly var alignofExpr = ref _reader.Get<AlignofExpr>(index);

            Visit(in alignofExpr);

            AddChild(alignofExpr.type_id);
            AddChild(alignofExpr.type);
        }

        partial void Visit(in LabelExpr labelExpr);

        private void VisitLabelExpr(ExprIndex index)
        {
            ref readonly var labelExpr = ref _reader.Get<LabelExpr>(index);

            Visit(in labelExpr);

            AddChild(labelExpr.designator);
            AddChild(labelExpr.type);
        }

        partial void Visit(in TypeidExpr typeidExpr);

        private void VisitTypeidExpr(ExprIndex index)
        {
            ref readonly var typeidExpr = ref _reader.Get<TypeidExpr>(index);

            Visit(in typeidExpr);

            AddChild(typeidExpr.operand);
            AddChild(typeidExpr.type);
        }

        partial void Visit(in DestructorCallExpr destructorCallExpr);

        private void VisitDestructorCallExpr(ExprIndex index)
        {
            ref readonly var destructorCallExpr = ref _reader.Get<DestructorCallExpr>(index);

            Visit(in destructorCallExpr);

            AddChild(destructorCallExpr.decltype_specifier);
            AddChild(destructorCallExpr.name);
            AddChild(destructorCallExpr.type);
        }

        partial void Visit(in SyntaxTreeExpr syntaxTreeExpr);

        private void VisitSyntaxTreeExpr(ExprIndex index)
        {
            ref readonly var syntaxTreeExpr = ref _reader.Get<SyntaxTreeExpr>(index);

            Visit(in syntaxTreeExpr);

            AddChild(syntaxTreeExpr.syntax);
        }

        partial void Visit(in FunctionStringExpr functionStringExpr);

        private void VisitFunctionStringExpr(ExprIndex index)
        {
            ref readonly var functionStringExpr = ref _reader.Get<FunctionStringExpr>(index);

            Visit(in functionStringExpr);

            AddChild(functionStringExpr.type);
        }

        partial void Visit(in CompoundStringExpr compoundStringExpr);

        private void VisitCompoundStringExpr(ExprIndex index)
        {
            ref readonly var compoundStringExpr = ref _reader.Get<CompoundStringExpr>(index);

            Visit(in compoundStringExpr);

            AddChild(compoundStringExpr.@string);
            AddChild(compoundStringExpr.type);
        }

        partial void Visit(in StringSequenceExpr stringSequenceExpr);

        private void VisitStringSequenceExpr(ExprIndex index)
        {
            ref readonly var stringSequenceExpr = ref _reader.Get<StringSequenceExpr>(index);

            Visit(in stringSequenceExpr);

            AddChild(stringSequenceExpr.strings);
            AddChild(stringSequenceExpr.type);
        }

        partial void Visit(in InitializerExpr initializerExpr);

        private void VisitInitializerExpr(ExprIndex index)
        {
            ref readonly var initializerExpr = ref _reader.Get<InitializerExpr>(index);

            Visit(in initializerExpr);

            AddChild(initializerExpr.initializer);
            AddChild(initializerExpr.type);
        }

        partial void Visit(in RequiresExpr requiresExpr);

        private void VisitRequiresExpr(ExprIndex index)
        {
            ref readonly var requiresExpr = ref _reader.Get<RequiresExpr>(index);

            Visit(in requiresExpr);

            AddChild(requiresExpr.body);
            AddChild(requiresExpr.parameters);
            AddChild(requiresExpr.type);
        }

        partial void Visit(in UnaryFoldExpr unaryFoldExpr);

        private void VisitUnaryFoldExpr(ExprIndex index)
        {
            ref readonly var unaryFoldExpr = ref _reader.Get<UnaryFoldExpr>(index);

            Visit(in unaryFoldExpr);

            AddChild(unaryFoldExpr.expr);
            AddChild(unaryFoldExpr.type);
        }

        partial void Visit(in BinaryFoldExpr binaryFoldExpr);

        private void VisitBinaryFoldExpr(ExprIndex index)
        {
            ref readonly var binaryFoldExpr = ref _reader.Get<BinaryFoldExpr>(index);

            Visit(in binaryFoldExpr);

            AddChild(binaryFoldExpr.right);
            AddChild(binaryFoldExpr.left);
            AddChild(binaryFoldExpr.type);
        }

        partial void Visit(in HierarchyConversionExpr hierarchyConversionExpr);

        private void VisitHierarchyConversionExpr(ExprIndex index)
        {
            ref readonly var hierarchyConversionExpr = ref _reader.Get<HierarchyConversionExpr>(index);

            Visit(in hierarchyConversionExpr);

            AddChild(hierarchyConversionExpr.override_inheritance_path);
            AddChild(hierarchyConversionExpr.inheritance_path);
            AddChild(hierarchyConversionExpr.target);
            AddChild(hierarchyConversionExpr.source);
            AddChild(hierarchyConversionExpr.type);
        }

        partial void Visit(in ProductTypeValueExpr productTypeValueExpr);

        private void VisitProductTypeValueExpr(ExprIndex index)
        {
            ref readonly var productTypeValueExpr = ref _reader.Get<ProductTypeValueExpr>(index);

            Visit(in productTypeValueExpr);

            AddChild(productTypeValueExpr.base_class_values);
            AddChild(productTypeValueExpr.members);
            AddChild(productTypeValueExpr.structure);
            AddChild(productTypeValueExpr.type);
        }

        partial void Visit(in SumTypeValueExpr sumTypeValueExpr);

        private void VisitSumTypeValueExpr(ExprIndex index)
        {
            ref readonly var sumTypeValueExpr = ref _reader.Get<SumTypeValueExpr>(index);

            Visit(in sumTypeValueExpr);

            AddChild(sumTypeValueExpr.value);
            AddChild(sumTypeValueExpr.variant);
            AddChild(sumTypeValueExpr.type);
        }

        partial void Visit(in ArrayValueExpr arrayValueExpr);

        private void VisitArrayValueExpr(ExprIndex index)
        {
            ref readonly var arrayValueExpr = ref _reader.Get<ArrayValueExpr>(index);

            Visit(in arrayValueExpr);

            AddChild(arrayValueExpr.element_type);
            AddChild(arrayValueExpr.elements);
            AddChild(arrayValueExpr.type);
        }

        partial void Visit(in DynamicDispatchExpr dynamicDispatchExpr);

        private void VisitDynamicDispatchExpr(ExprIndex index)
        {
            ref readonly var dynamicDispatchExpr = ref _reader.Get<DynamicDispatchExpr>(index);

            Visit(in dynamicDispatchExpr);

            AddChild(dynamicDispatchExpr.postfix_expr);
            AddChild(dynamicDispatchExpr.type);
        }

        partial void Visit(in VirtualFunctionConversionExpr virtualFunctionConversionExpr);

        private void VisitVirtualFunctionConversionExpr(ExprIndex index)
        {
            ref readonly var virtualFunctionConversionExpr = ref _reader.Get<VirtualFunctionConversionExpr>(index);

            Visit(in virtualFunctionConversionExpr);

            AddChild(virtualFunctionConversionExpr.function);
            AddChild(virtualFunctionConversionExpr.type);
        }

        partial void Visit(in PlaceholderExpr placeholderExpr);

        private void VisitPlaceholderExpr(ExprIndex index)
        {
            ref readonly var placeholderExpr = ref _reader.Get<PlaceholderExpr>(index);

            Visit(in placeholderExpr);

            AddChild(placeholderExpr.type);
        }

        partial void Visit(in ExpansionExpr expansionExpr);

        private void VisitExpansionExpr(ExprIndex index)
        {
            ref readonly var expansionExpr = ref _reader.Get<ExpansionExpr>(index);

            Visit(in expansionExpr);

            AddChild(expansionExpr.operand);
            AddChild(expansionExpr.type);
        }

        partial void Visit(in TupleExpr tupleExpr);

        private void VisitTupleExpr(ExprIndex index)
        {
            ref readonly var tupleExpr = ref _reader.Get<TupleExpr>(index);

            Visit(in tupleExpr);

            AddChild(tupleExpr.type);
        }

        partial void Visit(in NullptrExpr nullptrExpr);

        private void VisitNullptrExpr(ExprIndex index)
        {
            ref readonly var nullptrExpr = ref _reader.Get<NullptrExpr>(index);

            Visit(in nullptrExpr);

            AddChild(nullptrExpr.type);
        }

        partial void Visit(in ThisExpr thisExpr);

        private void VisitThisExpr(ExprIndex index)
        {
            ref readonly var thisExpr = ref _reader.Get<ThisExpr>(index);

            Visit(in thisExpr);

            AddChild(thisExpr.type);
        }

        partial void Visit(in TemplateReferenceExpr templateReferenceExpr);

        private void VisitTemplateReferenceExpr(ExprIndex index)
        {
            ref readonly var templateReferenceExpr = ref _reader.Get<TemplateReferenceExpr>(index);

            Visit(in templateReferenceExpr);

            AddChild(templateReferenceExpr.template_arguments);
            AddChild(templateReferenceExpr.parent);
            AddChild(templateReferenceExpr.member_name);
            AddChild(templateReferenceExpr.member);
            AddChild(templateReferenceExpr.type);
        }

        partial void Visit(in StatementExpr statementExpr);

        private void VisitStatementExpr(ExprIndex index)
        {
            ref readonly var statementExpr = ref _reader.Get<StatementExpr>(index);

            Visit(in statementExpr);

            AddChild(statementExpr.stmt);
            AddChild(statementExpr.type);
        }

        partial void Visit(in TypeTraitIntrinsicExpr typeTraitIntrinsicExpr);

        private void VisitTypeTraitIntrinsicExpr(ExprIndex index)
        {
            ref readonly var typeTraitIntrinsicExpr = ref _reader.Get<TypeTraitIntrinsicExpr>(index);

            Visit(in typeTraitIntrinsicExpr);

            AddChild(typeTraitIntrinsicExpr.arguments);
            AddChild(typeTraitIntrinsicExpr.type);
        }

        partial void Visit(in DesignatedInitializerExpr designatedInitializerExpr);

        private void VisitDesignatedInitializerExpr(ExprIndex index)
        {
            ref readonly var designatedInitializerExpr = ref _reader.Get<DesignatedInitializerExpr>(index);

            Visit(in designatedInitializerExpr);

            AddChild(designatedInitializerExpr.initializer);
            AddChild(designatedInitializerExpr.type);
        }

        partial void Visit(in PackedTemplateArgumentsExpr packedTemplateArgumentsExpr);

        private void VisitPackedTemplateArgumentsExpr(ExprIndex index)
        {
            ref readonly var packedTemplateArgumentsExpr = ref _reader.Get<PackedTemplateArgumentsExpr>(index);

            Visit(in packedTemplateArgumentsExpr);

            AddChild(packedTemplateArgumentsExpr.arguments);
            AddChild(packedTemplateArgumentsExpr.type);
        }

        partial void Visit(in TokenExpr tokenExpr);

        private void VisitTokenExpr(ExprIndex index)
        {
            ref readonly var tokenExpr = ref _reader.Get<TokenExpr>(index);

            Visit(in tokenExpr);

            AddChild(tokenExpr.type);
        }

        partial void Visit(in AssignInitializerExpr assignInitializerExpr);

        private void VisitAssignInitializerExpr(ExprIndex index)
        {
            ref readonly var assignInitializerExpr = ref _reader.Get<AssignInitializerExpr>(index);

            Visit(in assignInitializerExpr);

            AddChild(assignInitializerExpr.initializer);
        }

        partial void Visit(in ObjectLikeMacro objectLikeMacro);

        private void VisitObjectLikeMacro(MacroIndex index)
        {
            ref readonly var objectLikeMacro = ref _reader.Get<ObjectLikeMacro>(index);

            Visit(in objectLikeMacro);

            AddChild(objectLikeMacro.replacement_list);
        }

        partial void Visit(in FunctionLikeMacro functionLikeMacro);

        private void VisitFunctionLikeMacro(MacroIndex index)
        {
            ref readonly var functionLikeMacro = ref _reader.Get<FunctionLikeMacro>(index);

            Visit(in functionLikeMacro);

            AddChild(functionLikeMacro.replacement_list);
            AddChild(functionLikeMacro.parameters);
        }

        partial void Visit(in PragmaComment pragmaComment);

        private void VisitPragmaComment(PragmaIndex index)
        {
            ref readonly var pragmaComment = ref _reader.Get<PragmaComment>(index);

            Visit(in pragmaComment);
        }

        partial void Visit(in BasicAttr basicAttr);

        private void VisitBasicAttr(AttrIndex index)
        {
            ref readonly var basicAttr = ref _reader.Get<BasicAttr>(index);

            Visit(in basicAttr);
        }

        partial void Visit(in ScopedAttr scopedAttr);

        private void VisitScopedAttr(AttrIndex index)
        {
            ref readonly var scopedAttr = ref _reader.Get<ScopedAttr>(index);

            Visit(in scopedAttr);
        }

        partial void Visit(in LabeledAttr labeledAttr);

        private void VisitLabeledAttr(AttrIndex index)
        {
            ref readonly var labeledAttr = ref _reader.Get<LabeledAttr>(index);

            Visit(in labeledAttr);

            AddChild(labeledAttr.attribute);
        }

        partial void Visit(in CalledAttr calledAttr);

        private void VisitCalledAttr(AttrIndex index)
        {
            ref readonly var calledAttr = ref _reader.Get<CalledAttr>(index);

            Visit(in calledAttr);

            AddChild(calledAttr.arguments);
            AddChild(calledAttr.function);
        }

        partial void Visit(in ExpandedAttr expandedAttr);

        private void VisitExpandedAttr(AttrIndex index)
        {
            ref readonly var expandedAttr = ref _reader.Get<ExpandedAttr>(index);

            Visit(in expandedAttr);

            AddChild(expandedAttr.operand);
        }

        partial void Visit(in FactoredAttr factoredAttr);

        private void VisitFactoredAttr(AttrIndex index)
        {
            ref readonly var factoredAttr = ref _reader.Get<FactoredAttr>(index);

            Visit(in factoredAttr);

            AddChild(factoredAttr.terms);
        }

        partial void Visit(in ElaboratedAttr elaboratedAttr);

        private void VisitElaboratedAttr(AttrIndex index)
        {
            ref readonly var elaboratedAttr = ref _reader.Get<ElaboratedAttr>(index);

            Visit(in elaboratedAttr);

            AddChild(elaboratedAttr.expr);
        }

        partial void Visit(in TupleAttr tupleAttr);

        private void VisitTupleAttr(AttrIndex index)
        {
            ref readonly var tupleAttr = ref _reader.Get<TupleAttr>(index);

            Visit(in tupleAttr);
        }

        partial void Visit(in EmptyDir emptyDir);

        private void VisitEmptyDir(DirIndex index)
        {
            ref readonly var emptyDir = ref _reader.Get<EmptyDir>(index);

            Visit(in emptyDir);
        }

        partial void Visit(in AttributeDir attributeDir);

        private void VisitAttributeDir(DirIndex index)
        {
            ref readonly var attributeDir = ref _reader.Get<AttributeDir>(index);

            Visit(in attributeDir);

            AddChild(attributeDir.attr);
        }

        partial void Visit(in PragmaDir pragmaDir);

        private void VisitPragmaDir(DirIndex index)
        {
            ref readonly var pragmaDir = ref _reader.Get<PragmaDir>(index);

            Visit(in pragmaDir);
        }

        partial void Visit(in UsingDir usingDir);

        private void VisitUsingDir(DirIndex index)
        {
            ref readonly var usingDir = ref _reader.Get<UsingDir>(index);

            Visit(in usingDir);

            AddChild(usingDir.resolution);
            AddChild(usingDir.nominated);
        }

        partial void Visit(in UsingDeclarationDir usingDeclarationDir);

        private void VisitUsingDeclarationDir(DirIndex index)
        {
            ref readonly var usingDeclarationDir = ref _reader.Get<UsingDeclarationDir>(index);

            Visit(in usingDeclarationDir);

            AddChild(usingDeclarationDir.result);
            AddChild(usingDeclarationDir.path);
        }

        partial void Visit(in ExprDir exprDir);

        private void VisitExprDir(DirIndex index)
        {
            ref readonly var exprDir = ref _reader.Get<ExprDir>(index);

            Visit(in exprDir);

            AddChild(exprDir.expr);
        }

        partial void Visit(in StructuredBindingDir structuredBindingDir);

        private void VisitStructuredBindingDir(DirIndex index)
        {
            ref readonly var structuredBindingDir = ref _reader.Get<StructuredBindingDir>(index);

            Visit(in structuredBindingDir);
        }

        partial void Visit(in SpecifiersSpreadDir specifiersSpreadDir);

        private void VisitSpecifiersSpreadDir(DirIndex index)
        {
            ref readonly var specifiersSpreadDir = ref _reader.Get<SpecifiersSpreadDir>(index);

            Visit(in specifiersSpreadDir);
        }

        partial void Visit(in TupleDir tupleDir);

        private void VisitTupleDir(DirIndex index)
        {
            ref readonly var tupleDir = ref _reader.Get<TupleDir>(index);

            Visit(in tupleDir);
        }

        partial void Visit(in IdentifierForm identifierForm);

        private void VisitIdentifierForm(FormIndex index)
        {
            ref readonly var identifierForm = ref _reader.Get<IdentifierForm>(index);

            Visit(in identifierForm);
        }

        partial void Visit(in NumberForm numberForm);

        private void VisitNumberForm(FormIndex index)
        {
            ref readonly var numberForm = ref _reader.Get<NumberForm>(index);

            Visit(in numberForm);
        }

        partial void Visit(in CharacterForm characterForm);

        private void VisitCharacterForm(FormIndex index)
        {
            ref readonly var characterForm = ref _reader.Get<CharacterForm>(index);

            Visit(in characterForm);
        }

        partial void Visit(in StringForm stringForm);

        private void VisitStringForm(FormIndex index)
        {
            ref readonly var stringForm = ref _reader.Get<StringForm>(index);

            Visit(in stringForm);
        }

        partial void Visit(in OperatorForm operatorForm);

        private void VisitOperatorForm(FormIndex index)
        {
            ref readonly var operatorForm = ref _reader.Get<OperatorForm>(index);

            Visit(in operatorForm);
        }

        partial void Visit(in KeywordForm keywordForm);

        private void VisitKeywordForm(FormIndex index)
        {
            ref readonly var keywordForm = ref _reader.Get<KeywordForm>(index);

            Visit(in keywordForm);
        }

        partial void Visit(in WhitespaceForm whitespaceForm);

        private void VisitWhitespaceForm(FormIndex index)
        {
            ref readonly var whitespaceForm = ref _reader.Get<WhitespaceForm>(index);

            Visit(in whitespaceForm);
        }

        partial void Visit(in ParameterForm parameterForm);

        private void VisitParameterForm(FormIndex index)
        {
            ref readonly var parameterForm = ref _reader.Get<ParameterForm>(index);

            Visit(in parameterForm);
        }

        partial void Visit(in StringizeForm stringizeForm);

        private void VisitStringizeForm(FormIndex index)
        {
            ref readonly var stringizeForm = ref _reader.Get<StringizeForm>(index);

            Visit(in stringizeForm);

            AddChild(stringizeForm.operand);
        }

        partial void Visit(in CatenateForm catenateForm);

        private void VisitCatenateForm(FormIndex index)
        {
            ref readonly var catenateForm = ref _reader.Get<CatenateForm>(index);

            Visit(in catenateForm);

            AddChild(catenateForm.second);
            AddChild(catenateForm.first);
        }

        partial void Visit(in PragmaForm pragmaForm);

        private void VisitPragmaForm(FormIndex index)
        {
            ref readonly var pragmaForm = ref _reader.Get<PragmaForm>(index);

            Visit(in pragmaForm);

            AddChild(pragmaForm.operand);
        }

        partial void Visit(in HeaderForm headerForm);

        private void VisitHeaderForm(FormIndex index)
        {
            ref readonly var headerForm = ref _reader.Get<HeaderForm>(index);

            Visit(in headerForm);
        }

        partial void Visit(in ParenthesizedForm parenthesizedForm);

        private void VisitParenthesizedForm(FormIndex index)
        {
            ref readonly var parenthesizedForm = ref _reader.Get<ParenthesizedForm>(index);

            Visit(in parenthesizedForm);

            AddChild(parenthesizedForm.operand);
        }

        partial void Visit(in TupleForm tupleForm);

        private void VisitTupleForm(FormIndex index)
        {
            ref readonly var tupleForm = ref _reader.Get<TupleForm>(index);

            Visit(in tupleForm);
        }

        partial void Visit(in JunkForm junkForm);

        private void VisitJunkForm(FormIndex index)
        {
            ref readonly var junkForm = ref _reader.Get<JunkForm>(index);

            Visit(in junkForm);
        }

    }
}
