using ifc;
using System.Collections.Frozen;

namespace IfcSharpLib
{
    internal static class TocMapping
    {
        private delegate void Assign(ref TableOfContents toc, PartitionSummaryData summary);
        private delegate void AssignIndexed(ref TableOfContents toc, string partitionName, PartitionSummaryData summary);

        public static void SetSummaryByName(ref TableOfContents toc, string name, PartitionSummaryData summary)
        {
            if (DirectAssign.TryGetValue(name, out var assigner))
            {
                assigner(ref toc, summary);
            }

            foreach (var (prefix, dispatch) in PartitionDispatchTable)
            {
                if (name.StartsWith(prefix))
                {
                    dispatch(ref toc, name, summary);
                }
            }
        }

        static TocMapping()
        {
            DeclsortTableReverse = Reverse(DeclsortTable);
            TypesortTableReverse = Reverse(TypesortTable);
            StmtsortTableReverse = Reverse(StmtsortTable);
            ExprsortTableReverse = Reverse(ExprsortTable);
            ChartsortTableReverse = Reverse(ChartsortTable);
            NamesortTableReverse = Reverse(NamesortTable);
            SyntaxsortTableReverse = Reverse(SyntaxSortTable);
            MacrosortTableReverse = Reverse(MacroSortTable);
            HeapsortTableReverse = Reverse(HeapsortTable);
            FormsortTableReverse = Reverse(FormsortTable);
            TraitsortTableReverse = Reverse(TraitsortTable);
            MsvcTraitsortTableReverse = Reverse(MsvcTraitsortTable);
            PragmasortTableReverse = Reverse(PragmasortTable);
            AttrsortTableReverse = Reverse(AttrsortTable);
            DirsortTableReverse = Reverse(DirsortTable);

            PartitionDispatchTable = new Dictionary<string, AssignIndexed> // note: special handling for "names" (-1)
            {
                { "decl.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.decls[(int)DeclsortTableReverse.GetValueOrDefault(n)] = d },
                { "type.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.types[(int)TypesortTableReverse.GetValueOrDefault(n)] = d },
                { "name.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.names[(int)NamesortTableReverse.GetValueOrDefault(n) - 1] = d },
                { "expr.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.exprs[(int)ExprsortTableReverse.GetValueOrDefault(n)] = d },
                { "stmt.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.stmts[(int)StmtsortTableReverse.GetValueOrDefault(n)] = d },
                { "syntax.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.elements[(int)SyntaxsortTableReverse.GetValueOrDefault(n)] = d },
                { "macro.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.macros[(int)MacrosortTableReverse.GetValueOrDefault(n)] = d },
                { "heap.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.heaps[(int)HeapsortTableReverse.GetValueOrDefault(n)] = d },
                { "pragma-directive.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.pragma_directives[(int)PragmasortTableReverse.GetValueOrDefault(n)] = d },
                { "pp.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.forms[(int)FormsortTableReverse.GetValueOrDefault(n)] = d },
                { "trait.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.traits[(int)TraitsortTableReverse.GetValueOrDefault(n)] = d },
                { "attr.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.attrs[(int)AttrsortTableReverse.GetValueOrDefault(n)] = d },
                { "dir.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.dirs[(int)DirsortTableReverse.GetValueOrDefault(n)] = d },
                { ".msvc.", (ref TableOfContents toc, string n, PartitionSummaryData d) => toc.msvc_traits[(int)MsvcTraitsortTableReverse.GetValueOrDefault(n)] = d },
            }.ToFrozenDictionary();
        }

        private static readonly FrozenDictionary<string, Assign> DirectAssign = new Dictionary<string, Assign>
        {
            { "command_line", (ref TableOfContents toc, PartitionSummaryData d) => toc.command_line = d },
            { "exported_modules", (ref TableOfContents toc, PartitionSummaryData d) => toc.exported_modules = d },
            { "imported_modules", (ref TableOfContents toc, PartitionSummaryData d) => toc.imported_modules = d },
            { "u64s", (ref TableOfContents toc, PartitionSummaryData d) => toc.u64s = d },
            { "fps", (ref TableOfContents toc, PartitionSummaryData d) => toc.fps = d },
            { "string_literals", (ref TableOfContents toc, PartitionSummaryData d) => toc.string_literals = d },
            { "states", (ref TableOfContents toc, PartitionSummaryData d) => toc.states = d },
            { "lines", (ref TableOfContents toc, PartitionSummaryData d) => toc.lines = d },
            { "words", (ref TableOfContents toc, PartitionSummaryData d) => toc.words = d },
            { "sentences", (ref TableOfContents toc, PartitionSummaryData d) => toc.sentences = d },
            { "scopes", (ref TableOfContents toc, PartitionSummaryData d) => toc.scopes = d },
            { "entities", (ref TableOfContents toc, PartitionSummaryData d) => toc.entities = d },
            { "spec_forms", (ref TableOfContents toc, PartitionSummaryData d) => toc.spec_forms = d },
            //{ "names", (ref TableOfContents toc, PartitionSummaryData d) => toc.names = d },
            //{ "decls", (ref TableOfContents toc, PartitionSummaryData d) => toc.decls = d },
            //{ "types", (ref TableOfContents toc, PartitionSummaryData d) => toc.types = d },
            //{ "stmts", (ref TableOfContents toc, PartitionSummaryData d) => toc.stmts = d },
            //{ "exprs", (ref TableOfContents toc, PartitionSummaryData d) => toc.exprs = d },
            //{ "elements", (ref TableOfContents toc, PartitionSummaryData d) => toc.elements = d },
            //{ "forms", (ref TableOfContents toc, PartitionSummaryData d) => toc.forms = d },
            //{ "traits", (ref TableOfContents toc, PartitionSummaryData d) => toc.traits = d },
            //{ "msvc_traits", (ref TableOfContents toc, PartitionSummaryData d) => toc.msvc_traits = d },
            { "charts", (ref TableOfContents toc, PartitionSummaryData d) => toc.charts = d },
            { "multi_charts", (ref TableOfContents toc, PartitionSummaryData d) => toc.multi_charts = d },
            //{ "heaps", (ref TableOfContents toc, PartitionSummaryData d) => toc.heaps = d },
            { "suppressed_warnings", (ref TableOfContents toc, PartitionSummaryData d) => toc.suppressed_warnings = d },
            //{ "macros", (ref TableOfContents toc, PartitionSummaryData d) => toc.macros = d },
            //{ "pragma_directives", (ref TableOfContents toc, PartitionSummaryData d) => toc.pragma_directives = d },
            //{ "attrs", (ref TableOfContents toc, PartitionSummaryData d) => toc.attrs = d },
            //{ "dirs", (ref TableOfContents toc, PartitionSummaryData d) => toc.dirs = d },
            { "implementation_pragmas", (ref TableOfContents toc, PartitionSummaryData d) => toc.implementation_pragmas = d },
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<string, AssignIndexed> PartitionDispatchTable;

        private static readonly FrozenDictionary<string, DeclSort> DeclsortTableReverse;
        private static readonly FrozenDictionary<string, TypeSort> TypesortTableReverse;
        private static readonly FrozenDictionary<string, StmtSort> StmtsortTableReverse;
        private static readonly FrozenDictionary<string, ExprSort> ExprsortTableReverse;
        private static readonly FrozenDictionary<string, ChartSort> ChartsortTableReverse;
        private static readonly FrozenDictionary<string, NameSort> NamesortTableReverse;
        private static readonly FrozenDictionary<string, SyntaxSort> SyntaxsortTableReverse;
        private static readonly FrozenDictionary<string, MacroSort> MacrosortTableReverse;
        private static readonly FrozenDictionary<string, HeapSort> HeapsortTableReverse;
        private static readonly FrozenDictionary<string, FormSort> FormsortTableReverse;
        private static readonly FrozenDictionary<string, TraitSort> TraitsortTableReverse;
        private static readonly FrozenDictionary<string, MsvcTraitSort> MsvcTraitsortTableReverse;
        private static readonly FrozenDictionary<string, PragmaSort> PragmasortTableReverse;
        private static readonly FrozenDictionary<string, AttrSort> AttrsortTableReverse;
        private static readonly FrozenDictionary<string, DirSort> DirsortTableReverse;

        private static FrozenDictionary<string, T> Reverse<T>(FrozenDictionary<T, string> dict) where T : Enum
        {
            var reversed = new Dictionary<string, T>();
            foreach (var (key, value) in dict)
            {
                reversed.Add(value, key);
            }
            return reversed.ToFrozenDictionary();
        }

        private static readonly FrozenDictionary<DeclSort, string> DeclsortTable = new Dictionary<DeclSort, string>
        {
            { DeclSort.VendorExtension, "decl.vendor-extension"},
            { DeclSort.Enumerator, "decl.enumerator"},
            { DeclSort.Variable, "decl.variable"},
            { DeclSort.Parameter, "decl.parameter"},
            { DeclSort.Field, "decl.field"},
            { DeclSort.Bitfield, "decl.bitfield"},
            { DeclSort.Scope, "decl.scope"},
            { DeclSort.Enumeration, "decl.enum"},
            { DeclSort.Alias, "decl.alias"},
            { DeclSort.Temploid, "decl.temploid"},
            { DeclSort.Template, "decl.template"},
            { DeclSort.PartialSpecialization, "decl.partial-specialization"},
            { DeclSort.Specialization, "decl.specialization"},
            { DeclSort.DefaultArgument, "decl.default-arg"},
            { DeclSort.Concept, "decl.concept"},
            { DeclSort.Function, "decl.function"},
            { DeclSort.Method, "decl.method"},
            { DeclSort.Constructor, "decl.constructor"},
            { DeclSort.InheritedConstructor, "decl.inherited-constructor"},
            { DeclSort.Destructor, "decl.destructor"},
            { DeclSort.Reference, "decl.reference"},
            { DeclSort.Using, "decl.using-declaration"},
            { DeclSort.UnusedSort0, "decl.unused0"},
            { DeclSort.Friend, "decl.friend"},
            { DeclSort.Expansion, "decl.expansion"},
            { DeclSort.DeductionGuide, "decl.deduction-guide"},
            { DeclSort.Barren, "decl.barren"},
            { DeclSort.Tuple, "decl.tuple"},
            { DeclSort.SyntaxTree, "decl.syntax-tree"},
            { DeclSort.Intrinsic, "decl.intrinsic"},
            { DeclSort.Property, "decl.property"},
            { DeclSort.OutputSegment, "decl.segment"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<TypeSort, string> TypesortTable = new Dictionary<TypeSort, string>
        {
            { TypeSort.VendorExtension, "type.vendor-extension"},
            { TypeSort.Fundamental, "type.fundamental"},
            { TypeSort.Designated, "type.designated"},
            { TypeSort.Tor, "type.tor"},
            { TypeSort.Syntactic, "type.syntactic"},
            { TypeSort.Expansion, "type.expansion"},
            { TypeSort.Pointer, "type.pointer"},
            { TypeSort.PointerToMember, "type.pointer-to-member"},
            { TypeSort.LvalueReference, "type.lvalue-reference"},
            { TypeSort.RvalueReference, "type.rvalue-reference"},
            { TypeSort.Function, "type.function"},
            { TypeSort.Method, "type.nonstatic-member-function"},
            { TypeSort.Array, "type.array"},
            { TypeSort.Typename, "type.typename"},
            { TypeSort.Qualified, "type.qualified"},
            { TypeSort.Base, "type.base"},
            { TypeSort.Decltype, "type.decltype"},
            { TypeSort.Placeholder, "type.placeholder"},
            { TypeSort.Tuple, "type.tuple"},
            { TypeSort.Forall, "type.forall"},
            { TypeSort.Unaligned, "type.unaligned"},
            { TypeSort.SyntaxTree, "type.syntax-tree"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<StmtSort, string> StmtsortTable = new Dictionary<StmtSort, string>

        {
            { StmtSort.VendorExtension, "stmt.vendor-extension"},
            { StmtSort.Try, "stmt.try"},
            { StmtSort.If, "stmt.if"},
            { StmtSort.For, "stmt.for"},
            { StmtSort.Labeled, "stmt.labeled"},
            { StmtSort.While, "stmt.while"},
            { StmtSort.Block, "stmt.block"},
            { StmtSort.Break, "stmt.break"},
            { StmtSort.Switch, "stmt.switch"},
            { StmtSort.DoWhile, "stmt.do-while"},
            { StmtSort.Goto, "stmt.goto"},
            { StmtSort.Continue, "stmt.continue"},
            { StmtSort.Expression, "stmt.expression"},
            { StmtSort.Return, "stmt.return"},
            { StmtSort.Decl, "stmt.decl"},
            { StmtSort.Expansion, "stmt.expansion"},
            { StmtSort.SyntaxTree, "stmt.syntax-tree"},
            { StmtSort.Handler, "stmt.handler"},
            { StmtSort.Tuple, "stmt.tuple"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<ExprSort, string> ExprsortTable = new Dictionary<ExprSort, string>
        {
            { ExprSort.VendorExtension, "expr.vendor-extension"},
            { ExprSort.Empty, "expr.empty"},
            { ExprSort.Literal, "expr.literal"},
            { ExprSort.Lambda, "expr.lambda"},
            { ExprSort.Type, "expr.type"},
            { ExprSort.NamedDecl, "expr.decl"},
            { ExprSort.UnresolvedId, "expr.unresolved"},
            { ExprSort.TemplateId, "expr.template-id"},
            { ExprSort.UnqualifiedId, "expr.unqualified-id"},
            { ExprSort.SimpleIdentifier, "expr.simple-identifier"},
            { ExprSort.Pointer, "expr.pointer"},
            { ExprSort.QualifiedName, "expr.qualified-name"},
            { ExprSort.Path, "expr.path"},
            { ExprSort.Read, "expr.read"},
            { ExprSort.Monad, "expr.monad"},
            { ExprSort.Dyad, "expr.dyad"},
            { ExprSort.Triad, "expr.triad"},
            { ExprSort.String, "expr.strings"},
            { ExprSort.Temporary, "expr.temporary"},
            { ExprSort.Call, "expr.call"},
            { ExprSort.MemberInitializer, "expr.member-initializer"},
            { ExprSort.MemberAccess, "expr.member-access"},
            { ExprSort.InheritancePath, "expr.inheritance-path"},
            { ExprSort.InitializerList, "expr.initializer-list"},
            { ExprSort.Cast, "expr.cast"},
            { ExprSort.Condition, "expr.condition"},
            { ExprSort.ExpressionList, "expr.expression-list"},
            { ExprSort.SizeofType, "expr.sizeof-type"},
            { ExprSort.Alignof, "expr.alignof"},
            { ExprSort.Label, "expr.label"},
            { ExprSort.UnusedSort0, "expr.unused0"},
            { ExprSort.Typeid, "expr.typeid"},
            { ExprSort.DestructorCall, "expr.destructor-call"},
            { ExprSort.SyntaxTree, "expr.syntax-tree"},
            { ExprSort.FunctionString, "expr.function-string"},
            { ExprSort.CompoundString, "expr.compound-string"},
            { ExprSort.StringSequence, "expr.string-sequence"},
            { ExprSort.Initializer, "expr.initializer"},
            { ExprSort.Requires, "expr.requires"},
            { ExprSort.UnaryFold, "expr.unary-fold"},
            { ExprSort.BinaryFold, "expr.binary-fold"},
            { ExprSort.HierarchyConversion, "expr.hierarchy-conversion"},
            { ExprSort.ProductTypeValue, "expr.product-type-value"},
            { ExprSort.SumTypeValue, "expr.sum-type-value"},
            { ExprSort.UnusedSort1, "expr.unused1"},
            { ExprSort.ArrayValue, "expr.array-value"},
            { ExprSort.DynamicDispatch, "expr.dynamic-dispatch"},
            { ExprSort.VirtualFunctionConversion, "expr.virtual-function-conversion"},
            { ExprSort.Placeholder, "expr.placeholder"},
            { ExprSort.Expansion, "expr.expansion"},
            { ExprSort.Generic, "expr.generic"},
            { ExprSort.Tuple, "expr.tuple"},
            { ExprSort.Nullptr, "expr.nullptr"},
            { ExprSort.This, "expr.this"},
            { ExprSort.TemplateReference, "expr.template-reference"},
            { ExprSort.Statement, "expr.stmt"},
            { ExprSort.TypeTraitIntrinsic, "expr.type-trait"},
            { ExprSort.DesignatedInitializer, "expr.designated-init"},
            { ExprSort.PackedTemplateArguments, "expr.packed-template-arguments"},
            { ExprSort.Tokens, "expr.tokens"},
            { ExprSort.AssignInitializer, "expr.assign-initializer"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<ChartSort, string> ChartsortTable = new Dictionary<ChartSort, string>
        {
            { ChartSort.None, "chart.none"},
            { ChartSort.Unilevel, "chart.unilevel"},
            { ChartSort.Multilevel, "chart.multilevel"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<NameSort, string> NamesortTable = new Dictionary<NameSort, string>
        {
            { NameSort.Identifier, "name.identifier"},  { NameSort.Operator, "name.operator"},
            { NameSort.Conversion, "name.conversion"},  { NameSort.Literal, "name.literal"},
            { NameSort.Template, "name.template"},      { NameSort.Specialization, "name.specialization"},
            { NameSort.SourceFile, "name.source-file"}, { NameSort.Guide, "name.guide"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<SyntaxSort, string> SyntaxSortTable = new Dictionary<SyntaxSort, string>
        {
            { SyntaxSort.VendorExtension, "syntax.vendor-extension"},
            { SyntaxSort.SimpleTypeSpecifier, "syntax.simple-type-specifier"},
            { SyntaxSort.DecltypeSpecifier, "syntax.decltype-specifier"},
            { SyntaxSort.PlaceholderTypeSpecifier, "syntax.placeholder-type-specifier"},
            { SyntaxSort.TypeSpecifierSeq, "syntax.type-specifier-seq"},
            { SyntaxSort.DeclSpecifierSeq, "syntax.decl-specifier-seq"},
            { SyntaxSort.VirtualSpecifierSeq, "syntax.virtual-specifier-seq"},
            { SyntaxSort.NoexceptSpecification, "syntax.noexcept-specification"},
            { SyntaxSort.ExplicitSpecifier, "syntax.explicit-specifier"},
            { SyntaxSort.EnumSpecifier, "syntax.enum-specifier"},
            { SyntaxSort.EnumeratorDefinition, "syntax.enumerator-definition"},
            { SyntaxSort.ClassSpecifier, "syntax.class-specifier"},
            { SyntaxSort.MemberSpecification, "syntax.member-specification"},
            { SyntaxSort.MemberDeclaration, "syntax.member-declaration"},
            { SyntaxSort.MemberDeclarator, "syntax.member-declarator"},
            { SyntaxSort.AccessSpecifier, "syntax.access-specifier"},
            { SyntaxSort.BaseSpecifierList, "syntax.base-specifier-list"},
            { SyntaxSort.BaseSpecifier, "syntax.base-specifier"},
            { SyntaxSort.TypeId, "syntax.type-id"},
            { SyntaxSort.TrailingReturnType, "syntax.trailing-return-type"},
            { SyntaxSort.Declarator, "syntax.declarator"},
            { SyntaxSort.PointerDeclarator, "syntax.pointer-declarator"},
            { SyntaxSort.ArrayDeclarator, "syntax.array-declarator"},
            { SyntaxSort.FunctionDeclarator, "syntax.function-declarator"},
            { SyntaxSort.ArrayOrFunctionDeclarator, "syntax.array-or-function-declarator"},
            { SyntaxSort.ParameterDeclarator, "syntax.parameter-declarator"},
            { SyntaxSort.InitDeclarator, "syntax.init-declarator"},
            { SyntaxSort.NewDeclarator, "syntax.new-declarator"},
            { SyntaxSort.SimpleDeclaration, "syntax.simple-declaration"},
            { SyntaxSort.ExceptionDeclaration, "syntax.exception-declaration"},
            { SyntaxSort.ConditionDeclaration, "syntax.condition-declaration"},
            { SyntaxSort.StaticAssertDeclaration, "syntax.static_assert-declaration"},
            { SyntaxSort.AliasDeclaration, "syntax.alias-declaration"},
            { SyntaxSort.ConceptDefinition, "syntax.concept-definition"},
            { SyntaxSort.CompoundStatement, "syntax.compound-statement"},
            { SyntaxSort.ReturnStatement, "syntax.return-statement"},
            { SyntaxSort.IfStatement, "syntax.if-statement"},
            { SyntaxSort.WhileStatement, "syntax.while-statement"},
            { SyntaxSort.DoWhileStatement, "syntax.do-while-statement"},
            { SyntaxSort.ForStatement, "syntax.for-statement"},
            { SyntaxSort.InitStatement, "syntax.init-statement"},
            { SyntaxSort.RangeBasedForStatement, "syntax.range-based-for-statement"},
            { SyntaxSort.ForRangeDeclaration, "syntax.for-range-declaration"},
            { SyntaxSort.LabeledStatement, "syntax.labeled-statement"},
            { SyntaxSort.BreakStatement, "syntax.break-statement"},
            { SyntaxSort.ContinueStatement, "syntax.continue-statement"},
            { SyntaxSort.SwitchStatement, "syntax.switch-statement"},
            { SyntaxSort.GotoStatement, "syntax.goto-statement"},
            { SyntaxSort.DeclarationStatement, "syntax.declaration-statement"},
            { SyntaxSort.ExpressionStatement, "syntax.expression-statement"},
            { SyntaxSort.TryBlock, "syntax.try-block"},
            { SyntaxSort.Handler, "syntax.handler"},
            { SyntaxSort.HandlerSeq, "syntax.handler-seq"},
            { SyntaxSort.FunctionTryBlock, "syntax.function-try-block"},
            { SyntaxSort.TypeIdListElement, "syntax.type-list-element"},
            { SyntaxSort.DynamicExceptionSpec, "syntax.dynamic-exception-specification"},
            { SyntaxSort.StatementSeq, "syntax.statement-seq"},
            { SyntaxSort.FunctionBody, "syntax.function-body"},
            { SyntaxSort.Expression, "syntax.expression"},
            { SyntaxSort.FunctionDefinition, "syntax.function-definition"},
            { SyntaxSort.MemberFunctionDeclaration, "syntax.member-function-declaration"},
            { SyntaxSort.TemplateDeclaration, "syntax.template-declaration"},
            { SyntaxSort.RequiresClause, "syntax.requires-clause"},
            { SyntaxSort.SimpleRequirement, "syntax.simple-requirement"},
            { SyntaxSort.TypeRequirement, "syntax.type-requirement"},
            { SyntaxSort.CompoundRequirement, "syntax.compound-requirement"},
            { SyntaxSort.NestedRequirement, "syntax.nested-requirement"},
            { SyntaxSort.RequirementBody, "syntax.requirement-body"},
            { SyntaxSort.TypeTemplateParameter, "syntax.type-template-parameter"},
            { SyntaxSort.TemplateTemplateParameter, "syntax.template-template-parameter"},
            { SyntaxSort.TypeTemplateArgument, "syntax.type-template-argument"},
            { SyntaxSort.NonTypeTemplateArgument, "syntax.non-type-template-argument"},
            { SyntaxSort.TemplateParameterList, "syntax.template-parameter-list"},
            { SyntaxSort.TemplateArgumentList, "syntax.template-argument-list"},
            { SyntaxSort.TemplateId, "syntax.template-id"},
            { SyntaxSort.MemInitializer, "syntax.mem-initializer"},
            { SyntaxSort.CtorInitializer, "syntax.ctor-initializer"},
            { SyntaxSort.LambdaIntroducer, "syntax.lambda-introducer"},
            { SyntaxSort.LambdaDeclarator, "syntax.lambda-declarator"},
            { SyntaxSort.CaptureDefault, "syntax.capture-default"},
            { SyntaxSort.SimpleCapture, "syntax.simple-capture"},
            { SyntaxSort.InitCapture, "syntax.init-capture"},
            { SyntaxSort.ThisCapture, "syntax.this-capture"},
            { SyntaxSort.AttributedStatement, "syntax.attributed-statement"},
            { SyntaxSort.AttributedDeclaration, "syntax.attributed-declaration"},
            { SyntaxSort.AttributeSpecifierSeq, "syntax.attribute-specifier-seq"},
            { SyntaxSort.AttributeSpecifier, "syntax.attribute-specifier"},
            { SyntaxSort.AttributeUsingPrefix, "syntax.attribute-using-prefix"},
            { SyntaxSort.Attribute, "syntax.attribute"},
            { SyntaxSort.AttributeArgumentClause, "syntax.attribute-argument-clause"},
            { SyntaxSort.Alignas, "syntax.alignas"},
            { SyntaxSort.UsingDeclaration, "syntax.using-declaration"},
            { SyntaxSort.UsingDeclarator, "syntax.using-declarator"},
            { SyntaxSort.UsingDirective, "syntax.using-directive"},
            { SyntaxSort.ArrayIndex, "syntax.array-index"},
            { SyntaxSort.SEHTry, "syntax.structured-exception-try"},
            { SyntaxSort.SEHExcept, "syntax.structured-exception-except"},
            { SyntaxSort.SEHFinally, "syntax.structured-exception-finally"},
            { SyntaxSort.SEHLeave, "syntax.structured-exception-leave"},
            { SyntaxSort.TypeTraitIntrinsic, "syntax.type-trait-intrinsic"},
            { SyntaxSort.Tuple, "syntax.tuple"},
            { SyntaxSort.AsmStatement, "syntax.asm-statement"},
            { SyntaxSort.NamespaceAliasDefinition, "syntax.namespace-alias-definition"},
            { SyntaxSort.Super, "syntax.super"},
            { SyntaxSort.UnaryFoldExpression, "syntax.unary-fold-expression"},
            { SyntaxSort.BinaryFoldExpression, "syntax.binary-fold-expression"},
            { SyntaxSort.EmptyStatement, "syntax.empty-statement"},
            { SyntaxSort.StructuredBindingDeclaration, "syntax.structured-binding-declaration"},
            { SyntaxSort.StructuredBindingIdentifier, "syntax.structured-binding-identifier"},
            { SyntaxSort.UsingEnumDeclaration, "syntax.using-enum-declaration"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<MacroSort, string> MacroSortTable = new Dictionary<MacroSort, string>
        {
            { MacroSort.ObjectLike, "macro.object-like"},
            { MacroSort.FunctionLike, "macro.function-like"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<HeapSort, string> HeapsortTable = new Dictionary<HeapSort, string>

        {
            { HeapSort.Decl, "heap.decl"},   { HeapSort.Type, "heap.type"},  { HeapSort.Stmt, "heap.stmt"},
            { HeapSort.Expr, "heap.expr"},   { HeapSort.Syntax, "heap.syn"}, { HeapSort.Word, "heap.word"},
            { HeapSort.Chart, "heap.chart"}, { HeapSort.Spec, "heap.spec"},  { HeapSort.Form, "heap.pp"},
            { HeapSort.Attr, "heap.attr"},   { HeapSort.Dir, "heap.dir"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<FormSort, string> FormsortTable = new Dictionary<FormSort, string>
        {
            { FormSort.Identifier, "pp.ident"},    { FormSort.Number, "pp.num"},
            { FormSort.Character, "pp.char"},      { FormSort.String, "pp.string"},
            { FormSort.Operator, "pp.op"},         { FormSort.Keyword, "pp.key"},
            { FormSort.Whitespace, "pp.space"},    { FormSort.Parameter, "pp.param"},
            { FormSort.Stringize, "pp.to-string"}, { FormSort.Catenate, "pp.catenate"},
            { FormSort.Pragma, "pp.pragma"},       { FormSort.Header, "pp.header"},
            { FormSort.Parenthesized, "pp.paren"}, { FormSort.Tuple, "pp.tuple"},
            { FormSort.Junk, "pp.junk"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<TraitSort, string> TraitsortTable = new Dictionary<TraitSort, string>
        {
            { TraitSort.MappingExpr, "trait.mapping-expr"}, { TraitSort.AliasTemplate, "trait.alias-template"},
            { TraitSort.Friends, "trait.friend"},           { TraitSort.Specializations, "trait.specialization"},
            { TraitSort.Requires, "trait.requires"},        { TraitSort.Attributes, "trait.attribute"},
            { TraitSort.Deprecated, "trait.deprecated"},    { TraitSort.DeductionGuides, "trait.deduction-guides"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<MsvcTraitSort, string> MsvcTraitsortTable = new Dictionary<MsvcTraitSort, string>
        {
            { MsvcTraitSort.Uuid, ".msvc.trait.uuid"},
            { MsvcTraitSort.Segment, ".msvc.trait.code-segment"},
            { MsvcTraitSort.SpecializationEncoding, ".msvc.trait.specialization-encodings"},
            { MsvcTraitSort.SalAnnotation, ".msvc.trait.code-analysis.sal"},
            { MsvcTraitSort.FunctionParameters, ".msvc.trait.named-function-parameters"},
            { MsvcTraitSort.InitializerLocus, ".msvc.trait.entity-initializer-locus"},
            { MsvcTraitSort.TemplateTemplateParameters, ".msvc.trait.template-template-parameter-classes"},
            { MsvcTraitSort.CodegenExpression, ".msvc.trait.codegen-expression-trees"},
            { MsvcTraitSort.Vendor, ".msvc.trait.vendor-traits"},
            { MsvcTraitSort.DeclAttributes, ".msvc.trait.decl-attrs"}, // FIXME: This should go away once we have a bit in the graph for C++ attributes.
            { MsvcTraitSort.StmtAttributes, ".msvc.trait.stmt-attrs"}, // FIXME: this should go away once we have a bit in the graph for C++ attributes.
            { MsvcTraitSort.CodegenMappingExpr, ".msvc.trait.codegen-mapping-expr"},
            { MsvcTraitSort.DynamicInitVariable, ".msvc.trait.dynamic-init-variable"},
            { MsvcTraitSort.CodegenLabelProperties, ".msvc.trait.codegen-label-properties"},
            { MsvcTraitSort.CodegenSwitchType, ".msvc.trait.codegen-switch-type"},
            { MsvcTraitSort.CodegenDoWhileStmt, ".msvc.trait.codegen-dowhile-stmt"},
            { MsvcTraitSort.LexicalScopeIndex, ".msvc.trait.lexical-scope-index"},
            { MsvcTraitSort.FileBoundary, ".msvc.trait.file-boundary"},
            { MsvcTraitSort.HeaderUnitSourceFile, ".msvc.trait.header-unit-source-file"},
            { MsvcTraitSort.FileHash, ".msvc.trait.file-hash"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<PragmaSort, string> PragmasortTable = new Dictionary<PragmaSort, string>
        {
            { PragmaSort.VendorExtension, "pragma-directive.vendor-extension"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<AttrSort, string> AttrsortTable = new Dictionary<AttrSort, string>
        {
            { AttrSort.Nothing, "attr.nothing"},   { AttrSort.Basic, "attr.basic"},
            { AttrSort.Scoped, "attr.scoped"},     { AttrSort.Labeled, "attr.labeled"},
            { AttrSort.Called, "attr.called"},     { AttrSort.Expanded, "attr.expanded"},
            { AttrSort.Factored, "attr.factored"}, { AttrSort.Elaborated, "attr.elaborated"},
            { AttrSort.Tuple, "attr.tuple"},
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<DirSort, string> DirsortTable = new Dictionary<DirSort, string>
        {
            { DirSort.VendorExtension, "dir.vendor-extension"},
            { DirSort.Empty, "dir.empty"},
            { DirSort.Attribute, "dir.attribute"},
            { DirSort.Pragma, "dir.pragma"},
            { DirSort.Using, "dir.using"},
            { DirSort.DeclUse, "dir.decl-use"},
            { DirSort.Expr, "dir.expr"},
            { DirSort.StructuredBinding, "dir.struct-binding"},
            { DirSort.SpecifiersSpread, "dir.specifiers-spread"},
            { DirSort.Unused0, "dir.unused0"},
            { DirSort.Unused1, "dir.unused1"},
            { DirSort.Unused2, "dir.unused2"},
            { DirSort.Unused3, "dir.unused3"},
            { DirSort.Unused4, "dir.unused4"},
            { DirSort.Unused5, "dir.unused5"},
            { DirSort.Unused6, "dir.unused6"},
            { DirSort.Unused7, "dir.unused7"},
            { DirSort.Unused8, "dir.unused8"},
            { DirSort.Unused9, "dir.unused9"},
            { DirSort.Unused10, "dir.unused10"},
            { DirSort.Unused11, "dir.unused11"},
            { DirSort.Unused12, "dir.unused12"},
            { DirSort.Unused13, "dir.unused13"},
            { DirSort.Unused14, "dir.unused14"},
            { DirSort.Unused15, "dir.unused15"},
            { DirSort.Unused16, "dir.unused16"},
            { DirSort.Unused17, "dir.unused17"},
            { DirSort.Unused18, "dir.unused18"},
            { DirSort.Unused19, "dir.unused19"},
            { DirSort.Unused20, "dir.unused20"},
            { DirSort.Unused21, "dir.unused21"},
            { DirSort.Tuple, "dir.tuple"},
        }.ToFrozenDictionary();
    }
}
