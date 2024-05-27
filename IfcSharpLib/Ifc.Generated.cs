// hash: a6d7bb6f644cebf49132e5e9ab4563c780d4858b88df97f14765c9cd4e39d201

using System.Runtime.InteropServices;

#pragma warning disable CS0649 // Field '...' is never assigned to, and will always have its default value 0

namespace ifc
{
    public readonly struct Sequence<T> { public readonly Index start; public readonly Cardinality cardinality; }

    public readonly struct Identity<T> { public readonly T name; public readonly symbolic.SourceLocation locus; }

}

namespace ifc
{
    public enum ColumnNumber
    {
        Invalid = -1
    }

    public enum LineNumber
    {
        Max = 16777215
    }

    public enum Version : byte
    {
    }

    public enum EntitySize : uint
    {
    }

    public enum ByteOffset : uint
    {
    }

    public enum Cardinality : uint
    {
    }

    public enum Abi : byte
    {
    }

    public enum Architecture : byte
    {
        Unknown,
        X86,
        X64,
        ARM32,
        ARM64,
        HybridX86ARM64,
        ARM64EC
    }

    public enum CPlusPlus : uint
    {
    }

    public enum TextOffset : uint
    {
    }

    public enum ScopeIndex : uint
    {
    }

    public enum UnitSort : byte
    {
        Source,
        Primary,
        Partition,
        Header,
        ExportedTU,
        Count
    }

    public enum IfcOptions
    {
        None,
        IntegrityCheck,
        AllowAnyPrimaryInterface,
        SkipVersionCheck = 4
    }

    public enum WordSort : byte
    {
        Unknown,
        Directive,
        Punctuator,
        Literal,
        Operator,
        Keyword,
        Identifier,
        Count
    }

    public enum OperatorSort : byte
    {
        Niladic,
        Monadic,
        Dyadic,
        Triadic,
        Storage = 14,
        Variadic = 15
    }

    public enum NiladicOperator : ushort
    {
        Unknown,
        Phantom,
        Constant,
        Nil,
        Msvc = 1024,
        MsvcConstantObject = 1025,
        MsvcLambda = 1026,
        Last = 1027
    }

    public enum MonadicOperator : ushort
    {
        Unknown,
        Plus,
        Negate,
        Deref,
        Address,
        Complement,
        Not,
        PreIncrement,
        PreDecrement,
        PostIncrement,
        PostDecrement,
        Truncate,
        Ceil,
        Floor,
        Paren,
        Brace,
        Alignas,
        Alignof,
        Sizeof,
        Cardinality,
        Typeid,
        Noexcept,
        Requires,
        CoReturn,
        Await,
        Yield,
        Throw,
        New,
        Delete,
        DeleteArray,
        Expand,
        Read,
        Materialize,
        PseudoDtorCall,
        LookupGlobally,
        Artificial,
        MetaDescriptor,
        Msvc = 1024,
        MsvcAssume = 1025,
        MsvcAlignof = 1026,
        MsvcUuidof = 1027,
        MsvcIsClass = 1028,
        MsvcIsUnion = 1029,
        MsvcIsEnum = 1030,
        MsvcIsPolymorphic = 1031,
        MsvcIsEmpty = 1032,
        MsvcIsTriviallyCopyConstructible = 1033,
        MsvcIsTriviallyCopyAssignable = 1034,
        MsvcIsTriviallyDestructible = 1035,
        MsvcHasVirtualDestructor = 1036,
        MsvcIsNothrowCopyConstructible = 1037,
        MsvcIsNothrowCopyAssignable = 1038,
        MsvcIsPod = 1039,
        MsvcIsAbstract = 1040,
        MsvcIsTrivial = 1041,
        MsvcIsTriviallyCopyable = 1042,
        MsvcIsStandardLayout = 1043,
        MsvcIsLiteralType = 1044,
        MsvcIsTriviallyMoveConstructible = 1045,
        MsvcHasTrivialMoveAssign = 1046,
        MsvcIsTriviallyMoveAssignable = 1047,
        MsvcIsNothrowMoveAssignable = 1048,
        MsvcUnderlyingType = 1049,
        MsvcIsDestructible = 1050,
        MsvcIsNothrowDestructible = 1051,
        MsvcHasUniqueObjectRepresentations = 1052,
        MsvcIsAggregate = 1053,
        MsvcBuiltinAddressOf = 1054,
        MsvcIsRefClass = 1055,
        MsvcIsValueClass = 1056,
        MsvcIsSimpleValueClass = 1057,
        MsvcIsInterfaceClass = 1058,
        MsvcIsDelegate = 1059,
        MsvcIsFinal = 1060,
        MsvcIsSealed = 1061,
        MsvcHasFinalizer = 1062,
        MsvcHasCopy = 1063,
        MsvcHasAssign = 1064,
        MsvcHasUserDestructor = 1065,
        MsvcConfusion = 4064,
        MsvcConfusedExpand = 4065,
        MsvcConfusedDependentSizeof = 4066,
        MsvcConfusedPopState = 4067,
        MsvcConfusedDtorAction = 4068,
        MsvcConfusedVtorDisplacement = 4069,
        MsvcConfusedDependentExpression = 4070,
        MsvcConfusedSubstitution = 4071,
        MsvcConfusedAggregateReturn = 4072,
        MsvcConfusedVftblPointerInit = 4073,
        Last = 4074
    }

    public enum DyadicOperator : ushort
    {
        Unknown,
        Plus,
        Minus,
        Mult,
        Slash,
        Modulo,
        Remainder,
        Bitand,
        Bitor,
        Bitxor,
        Lshift,
        Rshift,
        Equal,
        NotEqual,
        Less,
        LessEqual,
        Greater,
        GreaterEqual,
        Compare,
        LogicAnd,
        LogicOr,
        Assign,
        PlusAssign,
        MinusAssign,
        MultAssign,
        SlashAssign,
        ModuloAssign,
        BitandAssign,
        BitorAssign,
        BitxorAssign,
        LshiftAssign,
        RshiftAssign,
        Comma,
        Dot,
        Arrow,
        DotStar,
        ArrowStar,
        Curry,
        Apply,
        Index,
        DefaultAt,
        New,
        NewArray,
        Destruct,
        DestructAt,
        Cleanup,
        Qualification,
        Promote,
        Demote,
        Coerce,
        Rewrite,
        Bless,
        Cast,
        ExplicitConversion,
        ReinterpretCast,
        StaticCast,
        ConstCast,
        DynamicCast,
        Narrow,
        Widen,
        Pretend,
        Closure,
        ZeroInitialize,
        ClearStorage,
        Select,
        Msvc = 1024,
        MsvcTryCast = 1025,
        MsvcCurry = 1026,
        MsvcVirtualCurry = 1027,
        MsvcAlign = 1028,
        MsvcBitSpan = 1029,
        MsvcBitfieldAccess = 1030,
        MsvcObscureBitfieldAccess = 1031,
        MsvcInitialize = 1032,
        MsvcBuiltinOffsetOf = 1033,
        MsvcIsBaseOf = 1034,
        MsvcIsConvertibleTo = 1035,
        MsvcIsTriviallyAssignable = 1036,
        MsvcIsNothrowAssignable = 1037,
        MsvcIsAssignable = 1038,
        MsvcIsAssignableNocheck = 1039,
        MsvcBuiltinBitCast = 1040,
        MsvcBuiltinIsLayoutCompatible = 1041,
        MsvcBuiltinIsPointerInterconvertibleBaseOf = 1042,
        MsvcBuiltinIsPointerInterconvertibleWithClass = 1043,
        MsvcBuiltinIsCorrespondingMember = 1044,
        MsvcIntrinsic = 1045,
        MsvcSaturatedArithmetic = 1046,
        MsvcBuiltinAllocationAnnotation = 1047,
        Last = 1048
    }

    public enum TriadicOperator : ushort
    {
        Unknown,
        Choice,
        ConstructAt,
        Initialize,
        Msvc = 1024,
        MsvcConfusion = 4064,
        MsvcConfusedPushState = 4065,
        MsvcConfusedChoice = 4066,
        Last = 4067
    }

    public enum StorageOperator : ushort
    {
        Unknown,
        AllocateSingle,
        AllocateArray,
        DeallocateSingle,
        DeallocateArray,
        Msvc = 1024,
        Last = 1025
    }

    public enum VariadicOperator : ushort
    {
        Unknown,
        Collection,
        Sequence,
        Msvc = 1024,
        MsvcHasTrivialConstructor = 1025,
        MsvcIsConstructible = 1026,
        MsvcIsNothrowConstructible = 1027,
        MsvcIsTriviallyConstructible = 1028,
        Last = 1029
    }

    public enum FormSort : byte
    {
        Identifier,
        Number,
        Character,
        String,
        Operator,
        Keyword,
        Whitespace,
        Parameter,
        Stringize,
        Catenate,
        Pragma,
        Header,
        Parenthesized,
        Tuple,
        Junk,
        Count
    }

    public enum LineIndex : uint
    {
    }

    public enum WordIndex : uint
    {
    }

    public enum SentenceIndex : uint
    {
    }

    public enum SpecFormIndex : uint
    {
    }

    public enum StringSort : byte
    {
        Ordinary,
        UTF8,
        UTF16,
        UTF32,
        Wide,
        Count
    }

    public enum Ownership : byte
    {
        Unknown,
        Imported,
        Exported,
        Merged
    }

    public enum ReachableProperties : byte
    {
        Nothing,
        Initializer,
        DefaultArguments,
        Attributes = 4,
        All = 7
    }

    public enum Access : byte
    {
        None,
        Private,
        Protected,
        Public,
        Count
    }

    public enum BasicSpecifiers : byte
    {
        Cxx,
        C,
        Internal,
        Vague = 4,
        External = 8,
        Deprecated = 16,
        InitializedInClass = 32,
        NonExported = 64,
        IsMemberOfGlobalModule = 128
    }

    public enum CallingConvention : byte
    {
        Cdecl,
        Fast,
        Std,
        This,
        Clr,
        Vector,
        Eabi,
        Count
    }

    public enum FunctionTypeTraits : byte
    {
        None,
        Const,
        Volatile,
        Lvalue = 4,
        Rvalue = 8
    }

    public enum ExceptionSpecification : byte
    {
        None,
        NonNoexcept,
        Noexcept,
        Conditional,
        Empty,
        ExplicitList,
        Count
    }

    public enum NoexceptSort : byte
    {
        None,
        False,
        True,
        Expression,
        InferredSpecialMember,
        Unenforced,
        Count
    }

    public enum ScopeTraits : byte
    {
        None,
        Unnamed,
        Inline,
        InitializerExported = 4,
        ClosureType = 8,
        Final = 16,
        Vendor = 128
    }

    public enum ObjectTraits : byte
    {
        None,
        Constexpr,
        Mutable,
        ThreadLocal = 4,
        Inline = 8,
        InitializerExported = 16,
        NoUniqueAddress = 32,
        Vendor = 128
    }

    public enum PackSize : ushort
    {
    }

    public enum FunctionTraits : ushort
    {
        None,
        Inline,
        Constexpr,
        Explicit = 4,
        Virtual = 8,
        NoReturn = 16,
        PureVirtual = 32,
        HiddenFriend = 64,
        Defaulted = 128,
        Deleted = 256,
        Constrained = 512,
        Immediate = 1024,
        Final = 2048,
        Override = 4096,
        Vendor = 32768
    }

    public enum GuideTraits : byte
    {
        None,
        Explicit
    }

    public enum VendorTraits : uint
    {
        None,
        ForceInline,
        Naked,
        NoAlias = 4,
        NoInline = 8,
        Restrict = 16,
        SafeBuffers = 32,
        DllExport = 64,
        DllImport = 128,
        CodeSegment = 256,
        NoVtable = 512,
        IntrinsicType = 1024,
        EmptyBases = 2048,
        Process = 4096,
        Allocate = 8192,
        SelectAny = 16384,
        Comdat = 32768,
        Uuid = 65536,
        NoCtorDisplacement = 131072,
        DefaultCtorDisplacement = 262144,
        FullCtorDisplacement = 524288,
        NoSanitizeAddress = 1048576,
        NoUniqueAddress = 2097152,
        NoInitAll = 4194304,
        DynamicInitialization = 8388608,
        LexicalScopeIndex = 16777216,
        ResumableFunction = 33554432,
        PersistentTemporary = 67108864,
        IneligibleForNRVO = 134217728
    }

    public enum SuppressedWarningSequenceIndex : uint
    {
    }

    public enum SuppressedWarning : ushort
    {
    }

    public enum SegmentTraits : uint
    {
    }

    public enum SegmentType : byte
    {
    }

    public enum NameSort : byte
    {
        Identifier,
        Operator,
        Conversion,
        Literal,
        Template,
        Specialization,
        SourceFile,
        Guide,
        Count
    }

    public enum ChartSort : byte
    {
        None,
        Unilevel,
        Multilevel,
        Count
    }

    public enum DeclSort : byte
    {
        VendorExtension,
        Enumerator,
        Variable,
        Parameter,
        Field,
        Bitfield,
        Scope,
        Enumeration,
        Alias,
        Temploid,
        Template,
        PartialSpecialization,
        Specialization,
        DefaultArgument,
        Concept,
        Function,
        Method,
        Constructor,
        InheritedConstructor,
        Destructor,
        Reference,
        Using,
        UnusedSort0,
        Friend,
        Expansion,
        DeductionGuide,
        Barren,
        Tuple,
        SyntaxTree,
        Intrinsic,
        Property,
        OutputSegment,
        Count
    }

    public enum TypeSort : byte
    {
        VendorExtension,
        Fundamental,
        Designated,
        Tor,
        Syntactic,
        Expansion,
        Pointer,
        PointerToMember,
        LvalueReference,
        RvalueReference,
        Function,
        Method,
        Array,
        Typename,
        Qualified,
        Base,
        Decltype,
        Placeholder,
        Tuple,
        Forall,
        Unaligned,
        SyntaxTree,
        Count
    }

    public enum SyntaxSort : byte
    {
        VendorExtension,
        SimpleTypeSpecifier,
        DecltypeSpecifier,
        PlaceholderTypeSpecifier,
        TypeSpecifierSeq,
        DeclSpecifierSeq,
        VirtualSpecifierSeq,
        NoexceptSpecification,
        ExplicitSpecifier,
        EnumSpecifier,
        EnumeratorDefinition,
        ClassSpecifier,
        MemberSpecification,
        MemberDeclaration,
        MemberDeclarator,
        AccessSpecifier,
        BaseSpecifierList,
        BaseSpecifier,
        TypeId,
        TrailingReturnType,
        Declarator,
        PointerDeclarator,
        ArrayDeclarator,
        FunctionDeclarator,
        ArrayOrFunctionDeclarator,
        ParameterDeclarator,
        InitDeclarator,
        NewDeclarator,
        SimpleDeclaration,
        ExceptionDeclaration,
        ConditionDeclaration,
        StaticAssertDeclaration,
        AliasDeclaration,
        ConceptDefinition,
        CompoundStatement,
        ReturnStatement,
        IfStatement,
        WhileStatement,
        DoWhileStatement,
        ForStatement,
        InitStatement,
        RangeBasedForStatement,
        ForRangeDeclaration,
        LabeledStatement,
        BreakStatement,
        ContinueStatement,
        SwitchStatement,
        GotoStatement,
        DeclarationStatement,
        ExpressionStatement,
        TryBlock,
        Handler,
        HandlerSeq,
        FunctionTryBlock,
        TypeIdListElement,
        DynamicExceptionSpec,
        StatementSeq,
        FunctionBody,
        Expression,
        FunctionDefinition,
        MemberFunctionDeclaration,
        TemplateDeclaration,
        RequiresClause,
        SimpleRequirement,
        TypeRequirement,
        CompoundRequirement,
        NestedRequirement,
        RequirementBody,
        TypeTemplateParameter,
        TemplateTemplateParameter,
        TypeTemplateArgument,
        NonTypeTemplateArgument,
        TemplateParameterList,
        TemplateArgumentList,
        TemplateId,
        MemInitializer,
        CtorInitializer,
        LambdaIntroducer,
        LambdaDeclarator,
        CaptureDefault,
        SimpleCapture,
        InitCapture,
        ThisCapture,
        AttributedStatement,
        AttributedDeclaration,
        AttributeSpecifierSeq,
        AttributeSpecifier,
        AttributeUsingPrefix,
        Attribute,
        AttributeArgumentClause,
        Alignas,
        UsingDeclaration,
        UsingDeclarator,
        UsingDirective,
        ArrayIndex,
        SEHTry,
        SEHExcept,
        SEHFinally,
        SEHLeave,
        TypeTraitIntrinsic,
        Tuple,
        AsmStatement,
        NamespaceAliasDefinition,
        Super,
        UnaryFoldExpression,
        BinaryFoldExpression,
        EmptyStatement,
        StructuredBindingDeclaration,
        StructuredBindingIdentifier,
        UsingEnumDeclaration,
        Count
    }

    public enum ParameterSort : byte
    {
        Object,
        Type,
        NonType,
        Template,
        Count
    }

    public enum LiteralSort : byte
    {
        Immediate,
        Integer,
        FloatingPoint,
        Count
    }

    public enum StmtSort : byte
    {
        VendorExtension,
        Try,
        If,
        For,
        Labeled,
        While,
        Block,
        Break,
        Switch,
        DoWhile,
        Goto,
        Continue,
        Expression,
        Return,
        Decl,
        Expansion,
        SyntaxTree,
        Handler,
        Tuple,
        Count
    }

    public enum ExprSort : byte
    {
        VendorExtension,
        Empty,
        Literal,
        Lambda,
        Type,
        NamedDecl,
        UnresolvedId,
        TemplateId,
        UnqualifiedId,
        SimpleIdentifier,
        Pointer,
        QualifiedName,
        Path,
        Read,
        Monad,
        Dyad,
        Triad,
        String,
        Temporary,
        Call,
        MemberInitializer,
        MemberAccess,
        InheritancePath,
        InitializerList,
        Cast,
        Condition,
        ExpressionList,
        SizeofType,
        Alignof,
        Label,
        UnusedSort0,
        Typeid,
        DestructorCall,
        SyntaxTree,
        FunctionString,
        CompoundString,
        StringSequence,
        Initializer,
        Requires,
        UnaryFold,
        BinaryFold,
        HierarchyConversion,
        ProductTypeValue,
        SumTypeValue,
        UnusedSort1,
        ArrayValue,
        DynamicDispatch,
        VirtualFunctionConversion,
        Placeholder,
        Expansion,
        Generic,
        Tuple,
        Nullptr,
        This,
        TemplateReference,
        Statement,
        TypeTraitIntrinsic,
        DesignatedInitializer,
        PackedTemplateArguments,
        Tokens,
        AssignInitializer,
        Count
    }

    public enum InheritanceSort : byte
    {
        None,
        Single,
        Multiple,
        Count
    }

    public enum Qualifier : byte
    {
        None,
        Const,
        Volatile,
        Restrict = 4
    }

    public enum WordCategory : ushort
    {
    }

    public enum MacroSort : byte
    {
        ObjectLike,
        FunctionLike,
        Count
    }

    public enum PragmaSort : byte
    {
        VendorExtension,
        Count
    }

    public enum AttrSort : byte
    {
        Nothing,
        Basic,
        Scoped,
        Labeled,
        Called,
        Expanded,
        Factored,
        Elaborated,
        Tuple,
        Count
    }

    public enum DirSort : byte
    {
        VendorExtension,
        Empty,
        Attribute,
        Pragma,
        Using,
        DeclUse,
        Expr,
        StructuredBinding,
        SpecifiersSpread,
        Unused0,
        Unused1,
        Unused2,
        Unused3,
        Unused4,
        Unused5,
        Unused6,
        Unused7,
        Unused8,
        Unused9,
        Unused10,
        Unused11,
        Unused12,
        Unused13,
        Unused14,
        Unused15,
        Unused16,
        Unused17,
        Unused18,
        Unused19,
        Unused20,
        Unused21,
        Tuple,
        Count
    }

    public enum HeapSort : byte
    {
        Decl,
        Type,
        Stmt,
        Expr,
        Syntax,
        Word,
        Chart,
        Spec,
        Form,
        Attr,
        Dir,
        Count
    }

    public enum TraitSort : byte
    {
        MappingExpr,
        AliasTemplate,
        Friends,
        Specializations,
        Requires,
        Attributes,
        Deprecated,
        DeductionGuides,
        Count
    }

    public enum MsvcTraitSort : byte
    {
        Uuid,
        Segment,
        SpecializationEncoding,
        SalAnnotation,
        FunctionParameters,
        InitializerLocus,
        TemplateTemplateParameters,
        CodegenExpression,
        Vendor,
        DeclAttributes,
        StmtAttributes,
        CodegenMappingExpr,
        DynamicInitVariable,
        CodegenLabelProperties,
        CodegenSwitchType,
        CodegenDoWhileStmt,
        LexicalScopeIndex,
        FileBoundary,
        HeaderUnitSourceFile,
        FileHash,
        Count
    }

    public readonly struct FormatVersion
    {
        public readonly Version major;
        public readonly Version minor;
    }

    public readonly struct SHA256Hash
    {
        public readonly uint_Array8 value;
    }

    [System.Runtime.CompilerServices.InlineArray(8)]
    public struct uint_Array8
    {
        private uint _element;
    }
    [Over<UnitSort>]
    public readonly struct UnitIndex : IOver<UnitSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 3);
        public UnitSort Sort => (UnitSort)(IndexAndSort & 0b111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Unit;
    }

    public readonly struct Header
    {
        public readonly SHA256Hash content_hash;
        public readonly FormatVersion version;
        public readonly Abi abi;
        public readonly Architecture arch;
        public readonly CPlusPlus cplusplus;
        public readonly ByteOffset string_table_bytes;
        public readonly Cardinality string_table_size;
        public readonly UnitIndex unit;
        public readonly TextOffset src_path;
        public readonly ScopeIndex global_scope;
        public readonly ByteOffset toc;
        public readonly Cardinality partition_count;
        [MarshalAs(UnmanagedType.U1)]
        public readonly bool internal_partition;
    }

    public readonly struct PartitionSummaryData
    {
        public readonly TextOffset name;
        public readonly ByteOffset offset;
        public readonly Cardinality cardinality;
        public readonly EntitySize entry_size;
    }

    public readonly struct IntegrityCheckFailed
    {
        public readonly SHA256Hash expected;
        public readonly SHA256Hash actual;
    }

    public readonly struct UnsupportedFormatVersion
    {
        public readonly FormatVersion version;
    }

    public readonly struct PPOperator
    {
        public enum Index : ushort
        {
        }

        private readonly ushort tag_bitfield;
        // ushort value (bitfield continuation)
        public ushort tag => (ushort)((tag_bitfield >> 13) & 0b111);
        public ushort value => (ushort)((tag_bitfield >> 0) & 0b1111111111111);
    }

    public readonly struct Operator
    {
        public enum Index : ushort
        {
        }

        private readonly ushort tag_bitfield;
        // ushort value (bitfield continuation)
        public ushort tag => (ushort)((tag_bitfield >> 12) & 0b1111);
        public ushort value => (ushort)((tag_bitfield >> 0) & 0b111111111111);
    }

    [Over<FormSort>]
    public readonly struct FormIndex : IOver<FormSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 4);
        public FormSort Sort => (FormSort)(IndexAndSort & 0b1111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Form;
    }

    [Over<StringSort>]
    public readonly struct StringIndex : IOver<StringSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 3);
        public StringSort Sort => (StringSort)(IndexAndSort & 0b111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.String;
    }

    [Over<NameSort>]
    public readonly struct NameIndex : IOver<NameSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 3);
        public NameSort Sort => (NameSort)(IndexAndSort & 0b111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Name;
    }

    [Over<ChartSort>]
    public readonly struct ChartIndex : IOver<ChartSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 2);
        public ChartSort Sort => (ChartSort)(IndexAndSort & 0b11);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Chart;
    }

    [Over<DeclSort>]
    public readonly struct DeclIndex : IOver<DeclSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 5);
        public DeclSort Sort => (DeclSort)(IndexAndSort & 0b11111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Decl;
    }

    [Over<TypeSort>]
    public readonly struct TypeIndex : IOver<TypeSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 5);
        public TypeSort Sort => (TypeSort)(IndexAndSort & 0b11111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Type;
    }

    [Over<SyntaxSort>]
    public readonly struct SyntaxIndex : IOver<SyntaxSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 7);
        public SyntaxSort Sort => (SyntaxSort)(IndexAndSort & 0b1111111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Syntax;
    }

    [Over<LiteralSort>]
    public readonly struct LitIndex : IOver<LiteralSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 2);
        public LiteralSort Sort => (LiteralSort)(IndexAndSort & 0b11);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Literal;
    }

    [Over<StmtSort>]
    public readonly struct StmtIndex : IOver<StmtSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 5);
        public StmtSort Sort => (StmtSort)(IndexAndSort & 0b11111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Stmt;
    }

    [Over<ExprSort>]
    public readonly struct ExprIndex : IOver<ExprSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 6);
        public ExprSort Sort => (ExprSort)(IndexAndSort & 0b111111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Expr;
    }

    [Over<MacroSort>]
    public readonly struct MacroIndex : IOver<MacroSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 1);
        public MacroSort Sort => (MacroSort)(IndexAndSort & 0b1);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Macro;
    }

    [Over<PragmaSort>]
    public readonly struct PragmaIndex : IOver<PragmaSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 1);
        public PragmaSort Sort => (PragmaSort)(IndexAndSort & 0b1);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Pragma;
    }

    [Over<AttrSort>]
    public readonly struct AttrIndex : IOver<AttrSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 4);
        public AttrSort Sort => (AttrSort)(IndexAndSort & 0b1111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Attr;
    }

    [Over<DirSort>]
    public readonly struct DirIndex : IOver<DirSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 5);
        public DirSort Sort => (DirSort)(IndexAndSort & 0b11111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Dir;
    }

    public readonly struct TraitOrdering
    {
    }

    public struct TableOfContents
    {
        public PartitionSummaryData command_line;
        public PartitionSummaryData exported_modules;
        public PartitionSummaryData imported_modules;
        public PartitionSummaryData u64s;
        public PartitionSummaryData fps;
        public PartitionSummaryData string_literals;
        public PartitionSummaryData states;
        public PartitionSummaryData lines;
        public PartitionSummaryData words;
        public PartitionSummaryData sentences;
        public PartitionSummaryData scopes;
        public PartitionSummaryData entities;
        public PartitionSummaryData spec_forms;
        public PartitionSummaryData_Array7 names;
        public PartitionSummaryData_Array32 decls;
        public PartitionSummaryData_Array22 types;
        public PartitionSummaryData_Array19 stmts;
        public PartitionSummaryData_Array61 exprs;
        public PartitionSummaryData_Array110 elements;
        public PartitionSummaryData_Array15 forms;
        public PartitionSummaryData_Array8 traits;
        public PartitionSummaryData_Array20 msvc_traits;
        public PartitionSummaryData charts;
        public PartitionSummaryData multi_charts;
        public PartitionSummaryData_Array11 heaps;
        public PartitionSummaryData suppressed_warnings;
        public PartitionSummaryData_Array2 macros;
        public PartitionSummaryData_Array1 pragma_directives;
        public PartitionSummaryData_Array9 attrs;
        public PartitionSummaryData_Array32 dirs;
        public PartitionSummaryData implementation_pragmas;
    }

    [System.Runtime.CompilerServices.InlineArray(1)]
    public struct PartitionSummaryData_Array1
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(11)]
    public struct PartitionSummaryData_Array11
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(110)]
    public struct PartitionSummaryData_Array110
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(15)]
    public struct PartitionSummaryData_Array15
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(19)]
    public struct PartitionSummaryData_Array19
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(2)]
    public struct PartitionSummaryData_Array2
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(20)]
    public struct PartitionSummaryData_Array20
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(22)]
    public struct PartitionSummaryData_Array22
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(32)]
    public struct PartitionSummaryData_Array32
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(61)]
    public struct PartitionSummaryData_Array61
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(7)]
    public struct PartitionSummaryData_Array7
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(8)]
    public struct PartitionSummaryData_Array8
    {
        private PartitionSummaryData _element;
    }
    [System.Runtime.CompilerServices.InlineArray(9)]
    public struct PartitionSummaryData_Array9
    {
        private PartitionSummaryData _element;
    }
    namespace source
    {
        public enum Punctuator : ushort
        {
            Unknown,
            LeftParenthesis,
            RightParenthesis,
            LeftBracket,
            RightBracket,
            LeftBrace,
            RightBrace,
            Colon,
            Question,
            Semicolon,
            ColonColon,
            Pound,
            Msvc = 8191,
            MsvcZeroWidthSpace = 8192,
            MsvcEndOfPhrase = 8193,
            MsvcFullStop = 8194,
            MsvcNestedTemplateStart = 8195,
            MsvcDefaultArgumentStart = 8196,
            MsvcAlignasEdictStart = 8197,
            MsvcDefaultInitStart = 8198
        }

        public enum Operator : ushort
        {
            Unknown,
            Equal,
            Comma,
            Exclaim,
            Plus,
            Dash,
            Star,
            Slash,
            Percent,
            LeftChevron,
            RightChevron,
            Tilde,
            Caret,
            Bar,
            Ampersand,
            PlusPlus,
            DashDash,
            Less,
            LessEqual,
            Greater,
            GreaterEqual,
            EqualEqual,
            ExclaimEqual,
            Diamond,
            PlusEqual,
            DashEqual,
            StarEqual,
            SlashEqual,
            PercentEqual,
            AmpersandEqual,
            BarEqual,
            CaretEqual,
            LeftChevronEqual,
            RightChevronEqual,
            AmpersandAmpersand,
            BarBar,
            Ellipsis,
            Dot,
            Arrow,
            DotStar,
            ArrowStar,
            Msvc = 8191
        }

        public enum Directive : ushort
        {
            Unknown,
            Msvc = 8191,
            MsvcPragmaPush = 8192,
            MsvcPragmaPop = 8193,
            MsvcDirectiveStart = 8194,
            MsvcDirectiveEnd = 8195,
            MsvcPragmaAllocText = 8196,
            MsvcPragmaAutoInline = 8197,
            MsvcPragmaBssSeg = 8198,
            MsvcPragmaCheckStack = 8199,
            MsvcPragmaCodeSeg = 8200,
            MsvcPragmaComment = 8201,
            MsvcPragmaComponent = 8202,
            MsvcPragmaConform = 8203,
            MsvcPragmaConstSeg = 8204,
            MsvcPragmaDataSeg = 8205,
            MsvcPragmaDeprecated = 8206,
            MsvcPragmaDetectMismatch = 8207,
            MsvcPragmaEndregion = 8208,
            MsvcPragmaExecutionCharacterSet = 8209,
            MsvcPragmaFenvAccess = 8210,
            MsvcPragmaFileHash = 8211,
            MsvcPragmaFloatControl = 8212,
            MsvcPragmaFpContract = 8213,
            MsvcPragmaFunction = 8214,
            MsvcPragmaBGI = 8215,
            MsvcPragmaIdent = 8216,
            MsvcPragmaImplementationKey = 8217,
            MsvcPragmaIncludeAlias = 8218,
            MsvcPragmaInitSeg = 8219,
            MsvcPragmaInlineDepth = 8220,
            MsvcPragmaInlineRecursion = 8221,
            MsvcPragmaIntrinsic = 8222,
            MsvcPragmaLoop = 8223,
            MsvcPragmaMakePublic = 8224,
            MsvcPragmaManaged = 8225,
            MsvcPragmaMessage = 8226,
            MsvcPragmaOMP = 8227,
            MsvcPragmaOptimize = 8228,
            MsvcPragmaPack = 8229,
            MsvcPragmaPointerToMembers = 8230,
            MsvcPragmaPopMacro = 8231,
            MsvcPragmaPrefast = 8232,
            MsvcPragmaPushMacro = 8233,
            MsvcPragmaRegion = 8234,
            MsvcPragmaRuntimeChecks = 8235,
            MsvcPragmaSameSeg = 8236,
            MsvcPragmaSection = 8237,
            MsvcPragmaSegment = 8238,
            MsvcPragmaSetlocale = 8239,
            MsvcPragmaStartMapRegion = 8240,
            MsvcPragmaStopMapRegion = 8241,
            MsvcPragmaStrictGSCheck = 8242,
            MsvcPragmaSystemHeader = 8243,
            MsvcPragmaUnmanaged = 8244,
            MsvcPragmaVtordisp = 8245,
            MsvcPragmaWarning = 8246,
            MsvcPragmaP0include = 8247,
            MsvcPragmaP0line = 8248
        }

        public enum Literal : ushort
        {
            Unknown,
            Scalar,
            String,
            DefinedString,
            Msvc = 8191,
            MsvcFunctionNameMacro = 8192,
            MsvcStringPrefixMacro = 8193,
            MsvcBinding = 8194,
            MsvcResolvedType = 8195,
            MsvcDefinedConstant = 8196,
            MsvcCastTargetType = 8197,
            MsvcTemplateId = 8198
        }

        public enum Keyword : ushort
        {
            Unknown,
            Alignas,
            Alignof,
            Asm,
            Auto,
            Bool,
            Break,
            Case,
            Catch,
            Char,
            Char8T,
            Char16T,
            Char32T,
            Class,
            Concept,
            Const,
            Consteval,
            Constexpr,
            Constinit,
            ConstCast,
            Continue,
            CoAwait,
            CoReturn,
            CoYield,
            Decltype,
            Default,
            Delete,
            Do,
            Double,
            DynamicCast,
            Else,
            Enum,
            Explicit,
            Export,
            Extern,
            False,
            Float,
            For,
            Friend,
            Generic,
            Goto,
            If,
            Inline,
            Int,
            Long,
            Mutable,
            Namespace,
            New,
            Noexcept,
            Nullptr,
            Operator,
            Pragma,
            Private,
            Protected,
            Public,
            Register,
            ReinterpretCast,
            Requires,
            Restrict,
            Return,
            Short,
            Signed,
            Sizeof,
            Static,
            StaticAssert,
            StaticCast,
            Struct,
            Switch,
            Template,
            This,
            ThreadLocal,
            Throw,
            True,
            Try,
            Typedef,
            Typeid,
            Typename,
            Union,
            Unsigned,
            Using,
            Virtual,
            Void,
            Volatile,
            WcharT,
            While,
            Msvc = 8191,
            MsvcAsm = 8192,
            MsvcAssume = 8193,
            MsvcAlignof = 8194,
            MsvcBased = 8195,
            MsvcCdecl = 8196,
            MsvcClrcall = 8197,
            MsvcDeclspec = 8198,
            MsvcEabi = 8199,
            MsvcEvent = 8200,
            MsvcSehExcept = 8201,
            MsvcFastcall = 8202,
            MsvcSehFinally = 8203,
            MsvcForceinline = 8204,
            MsvcHook = 8205,
            MsvcIdentifier = 8206,
            MsvcIfExists = 8207,
            MsvcIfNotExists = 8208,
            MsvcInt8 = 8209,
            MsvcInt16 = 8210,
            MsvcInt32 = 8211,
            MsvcInt64 = 8212,
            MsvcInt128 = 8213,
            MsvcInterface = 8214,
            MsvcLeave = 8215,
            MsvcMultipleInheritance = 8216,
            MsvcNullptr = 8217,
            MsvcNovtordisp = 8218,
            MsvcPragma = 8219,
            MsvcPtr32 = 8220,
            MsvcPtr64 = 8221,
            MsvcRestrict = 8222,
            MsvcSingleInheritance = 8223,
            MsvcSptr = 8224,
            MsvcStdcall = 8225,
            MsvcSuper = 8226,
            MsvcThiscall = 8227,
            MsvcSehTry = 8228,
            MsvcUptr = 8229,
            MsvcUuidof = 8230,
            MsvcUnaligned = 8231,
            MsvcUnhook = 8232,
            MsvcVectorcall = 8233,
            MsvcVirtualInheritance = 8234,
            MsvcW64 = 8235,
            MsvcIsClass = 8236,
            MsvcIsUnion = 8237,
            MsvcIsEnum = 8238,
            MsvcIsPolymorphic = 8239,
            MsvcIsEmpty = 8240,
            MsvcHasTrivialConstructor = 8241,
            MsvcIsTriviallyConstructible = 8242,
            MsvcIsTriviallyCopyConstructible = 8243,
            MsvcIsTriviallyCopyAssignable = 8244,
            MsvcIsTriviallyDestructible = 8245,
            MsvcHasVirtualDestructor = 8246,
            MsvcIsNothrowConstructible = 8247,
            MsvcIsNothrowCopyConstructible = 8248,
            MsvcIsNothrowCopyAssignable = 8249,
            MsvcIsPod = 8250,
            MsvcIsAbstract = 8251,
            MsvcIsBaseOf = 8252,
            MsvcIsConvertibleTo = 8253,
            MsvcIsTrivial = 8254,
            MsvcIsTriviallyCopyable = 8255,
            MsvcIsStandardLayout = 8256,
            MsvcIsLiteralType = 8257,
            MsvcIsTriviallyMoveConstructible = 8258,
            MsvcHasTrivialMoveAssign = 8259,
            MsvcIsTriviallyMoveAssignable = 8260,
            MsvcIsNothrowMoveAssignable = 8261,
            MsvcIsConstructible = 8262,
            MsvcUnderlyingType = 8263,
            MsvcIsTriviallyAssignable = 8264,
            MsvcIsNothrowAssignable = 8265,
            MsvcIsDestructible = 8266,
            MsvcIsNothrowDestructible = 8267,
            MsvcIsAssignable = 8268,
            MsvcIsAssignableNocheck = 8269,
            MsvcHasUniqueObjectRepresentations = 8270,
            MsvcIsAggregate = 8271,
            MsvcBuiltinAddressOf = 8272,
            MsvcBuiltinOffsetOf = 8273,
            MsvcBuiltinBitCast = 8274,
            MsvcBuiltinIsLayoutCompatible = 8275,
            MsvcBuiltinIsPointerInterconvertibleBaseOf = 8276,
            MsvcBuiltinIsPointerInterconvertibleWithClass = 8277,
            MsvcBuiltinIsCorrespondingMember = 8278,
            MsvcIsRefClass = 8279,
            MsvcIsValueClass = 8280,
            MsvcIsSimpleValueClass = 8281,
            MsvcIsInterfaceClass = 8282,
            MsvcIsDelegate = 8283,
            MsvcIsFinal = 8284,
            MsvcIsSealed = 8285,
            MsvcHasFinalizer = 8286,
            MsvcHasCopy = 8287,
            MsvcHasAssign = 8288,
            MsvcHasUserDestructor = 8289,
            MsvcPackCardinality = 8290,
            MsvcConfusedSizeof = 8291,
            MsvcConfusedAlignas = 8292
        }

        public enum Identifier : ushort
        {
            Plain,
            Msvc = 8191,
            MsvcBuiltinHugeVal = 8192,
            MsvcBuiltinHugeValf = 8193,
            MsvcBuiltinNan = 8194,
            MsvcBuiltinNanf = 8195,
            MsvcBuiltinNans = 8196,
            MsvcBuiltinNansf = 8197
        }

    }

    namespace symbolic
    {
        public enum TypeBasis : byte
        {
            Void,
            Bool,
            Char,
            Wchar_t,
            Int,
            Float,
            Double,
            Nullptr,
            Ellipsis,
            SegmentType,
            Class,
            Struct,
            Union,
            Enum,
            Typename,
            Namespace,
            Interface,
            Function,
            Empty,
            VariableTemplate,
            Concept,
            Auto,
            DecltypeAuto,
            Overload,
            Count
        }

        public enum TypePrecision : byte
        {
            Default,
            Short,
            Long,
            Bit8,
            Bit16,
            Bit32,
            Bit64,
            Bit128,
            Count
        }

        public enum TypeSign : byte
        {
            Plain,
            Signed,
            Unsigned,
            Count
        }

        public enum ExpansionMode : byte
        {
            Full,
            Partial
        }

        public enum BaseClassTraits : byte
        {
            None,
            Shared,
            Expanded
        }

        public enum DefaultIndex : uint
        {
            UnderlyingSort = 5
        }

        public enum SpecializationSort : byte
        {
            Implicit,
            Explicit,
            Instantiation
        }

        public enum Associativity : byte
        {
            Unspecified,
            Left,
            Right
        }

        public enum ActiveMemberIndex : uint
        {
        }

        public enum Phases : uint
        {
            Unknown,
            Reading,
            Lexing,
            Preprocessing = 4,
            Parsing = 8,
            Importing = 16,
            NameResolution = 32,
            Typing = 64,
            Evaluation = 128,
            Instantiation = 256,
            Analysis = 512,
            CodeGeneration = 1024,
            Linking = 2048,
            Loading = 4096,
            Execution = 8192
        }

        public readonly struct Declaration
        {
            public readonly DeclIndex index;
        }

        [Tag<NameSort>(NameSort.Conversion)]
        public readonly struct ConversionFunctionId : IHasSort<ConversionFunctionId, NameSort>
        {
            public static NameSort Sort => NameSort.Conversion;
            public static SortType Type => SortType.Name;

            public readonly TypeIndex target;
            public readonly TextOffset name;
        }

        [Tag<NameSort>(NameSort.Operator)]
        public readonly struct OperatorFunctionId : IHasSort<OperatorFunctionId, NameSort>
        {
            public static NameSort Sort => NameSort.Operator;
            public static SortType Type => SortType.Name;

            public readonly TextOffset name;
            public readonly Operator symbol;
        }

        [Tag<NameSort>(NameSort.Literal)]
        public readonly struct LiteralOperatorId : IHasSort<LiteralOperatorId, NameSort>
        {
            public static NameSort Sort => NameSort.Literal;
            public static SortType Type => SortType.Name;

            public readonly TextOffset name_index;
        }

        [Tag<NameSort>(NameSort.Template)]
        public readonly struct TemplateName : IHasSort<TemplateName, NameSort>
        {
            public static NameSort Sort => NameSort.Template;
            public static SortType Type => SortType.Name;

            public readonly NameIndex name;
        }

        [Tag<NameSort>(NameSort.Specialization)]
        public readonly struct SpecializationName : IHasSort<SpecializationName, NameSort>
        {
            public static NameSort Sort => NameSort.Specialization;
            public static SortType Type => SortType.Name;

            public readonly NameIndex primary_template;
            public readonly ExprIndex arguments;
        }

        [Tag<NameSort>(NameSort.SourceFile)]
        public readonly struct SourceFileName : IHasSort<SourceFileName, NameSort>
        {
            public static NameSort Sort => NameSort.SourceFile;
            public static SortType Type => SortType.Name;

            public readonly TextOffset name;
            public readonly TextOffset include_guard;
        }

        [Tag<NameSort>(NameSort.Guide)]
        public readonly struct GuideName : IHasSort<GuideName, NameSort>
        {
            public static NameSort Sort => NameSort.Guide;
            public static SortType Type => SortType.Name;

            public readonly DeclIndex primary_template;
        }

        public readonly struct ModuleReference
        {
            public readonly TextOffset owner;
            public readonly TextOffset partition;
        }

        public readonly struct SourceLocation
        {
            public readonly LineIndex line;
            public readonly ColumnNumber column;
        }

        public readonly struct Word
        {
            [StructLayout(LayoutKind.Explicit)]
            public readonly struct UnnamedUnion1
            {
                [FieldOffset(0)]
                public readonly TextOffset text;
                [FieldOffset(0)]
                public readonly ExprIndex expr;
                [FieldOffset(0)]
                public readonly TypeIndex type;
                [FieldOffset(0)]
                public readonly Index state;
                [FieldOffset(0)]
                public readonly StringIndex @string;
            }

            [StructLayout(LayoutKind.Explicit)]
            public readonly struct UnnamedUnion2
            {
                [FieldOffset(0)]
                public readonly WordCategory category;
                [FieldOffset(0)]
                public readonly source.Directive src_directive;
                [FieldOffset(0)]
                public readonly source.Punctuator src_punctuator;
                [FieldOffset(0)]
                public readonly source.Literal src_literal;
                [FieldOffset(0)]
                public readonly source.Operator src_operator;
                [FieldOffset(0)]
                public readonly source.Keyword src_keyword;
                [FieldOffset(0)]
                public readonly source.Identifier src_identifier;
            }

            public readonly SourceLocation locus;
            private readonly UnnamedUnion1 unnamedUnion1;
            public TextOffset text => unnamedUnion1.text;
            public ExprIndex expr => unnamedUnion1.expr;
            public TypeIndex type => unnamedUnion1.type;
            public Index state => unnamedUnion1.state;
            public StringIndex @string => unnamedUnion1.@string;
            private readonly UnnamedUnion2 unnamedUnion2;
            public WordCategory category => unnamedUnion2.category;
            public source.Directive src_directive => unnamedUnion2.src_directive;
            public source.Punctuator src_punctuator => unnamedUnion2.src_punctuator;
            public source.Literal src_literal => unnamedUnion2.src_literal;
            public source.Operator src_operator => unnamedUnion2.src_operator;
            public source.Keyword src_keyword => unnamedUnion2.src_keyword;
            public source.Identifier src_identifier => unnamedUnion2.src_identifier;
            public readonly WordSort algebra_sort;
        }

        public readonly struct WordSequence
        {
            public readonly Index start;
            public readonly Cardinality cardinality;
            public readonly SourceLocation locus;
        }

        public readonly struct NoexceptSpecification
        {
            public readonly SentenceIndex words;
            public readonly NoexceptSort sort;
        }

        [Tag<TypeSort>(TypeSort.Fundamental)]
        public readonly struct FundamentalType : IHasSort<FundamentalType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Fundamental;
            public static SortType Type => SortType.Type;

            public readonly TypeBasis basis;
            public readonly TypePrecision precision;
            public readonly TypeSign sign;
            public readonly byte unused;
        }

        [Tag<TypeSort>(TypeSort.Designated)]
        public readonly struct DesignatedType : IHasSort<DesignatedType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Designated;
            public static SortType Type => SortType.Type;

            public readonly DeclIndex decl;
        }

        [Tag<TypeSort>(TypeSort.Tor)]
        public readonly struct TorType : IHasSort<TorType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Tor;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex source;
            public readonly NoexceptSpecification eh_spec;
            public readonly CallingConvention convention;
        }

        [Tag<TypeSort>(TypeSort.Syntactic)]
        public readonly struct SyntacticType : IHasSort<SyntacticType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Syntactic;
            public static SortType Type => SortType.Type;

            public readonly ExprIndex expr;
        }

        [Tag<TypeSort>(TypeSort.Expansion)]
        public readonly struct ExpansionType : IHasSort<ExpansionType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Expansion;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex pack;
            public readonly ExpansionMode mode;
        }

        [Tag<TypeSort>(TypeSort.Pointer)]
        public readonly struct PointerType : IHasSort<PointerType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Pointer;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex pointee;
        }

        [Tag<TypeSort>(TypeSort.LvalueReference)]
        public readonly struct LvalueReferenceType : IHasSort<LvalueReferenceType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.LvalueReference;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex referee;
        }

        [Tag<TypeSort>(TypeSort.RvalueReference)]
        public readonly struct RvalueReferenceType : IHasSort<RvalueReferenceType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.RvalueReference;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex referee;
        }

        [Tag<TypeSort>(TypeSort.Unaligned)]
        public readonly struct UnalignedType : IHasSort<UnalignedType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Unaligned;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex operand;
        }

        [Tag<TypeSort>(TypeSort.Decltype)]
        public readonly struct DecltypeType : IHasSort<DecltypeType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Decltype;
            public static SortType Type => SortType.Type;

            public readonly SyntaxIndex expression;
        }

        [Tag<TypeSort>(TypeSort.Placeholder)]
        public readonly struct PlaceholderType : IHasSort<PlaceholderType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Placeholder;
            public static SortType Type => SortType.Type;

            public readonly ExprIndex constraint;
            public readonly TypeBasis basis;
            public readonly TypeIndex elaboration;
        }

        [Tag<TypeSort>(TypeSort.PointerToMember)]
        public readonly struct PointerToMemberType : IHasSort<PointerToMemberType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.PointerToMember;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex scope;
            public readonly TypeIndex type;
        }

        [Tag<TypeSort>(TypeSort.Tuple)]
        public readonly struct TupleType : IHasSort<TupleType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Tuple;
            public static SortType Type => SortType.Type;

            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<TypeSort>(TypeSort.Forall)]
        public readonly struct ForallType : IHasSort<ForallType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Forall;
            public static SortType Type => SortType.Type;

            public readonly ChartIndex chart;
            public readonly TypeIndex subject;
        }

        [Tag<TypeSort>(TypeSort.Function)]
        public readonly struct FunctionType : IHasSort<FunctionType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Function;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex target;
            public readonly TypeIndex source;
            public readonly NoexceptSpecification eh_spec;
            public readonly CallingConvention convention;
            public readonly FunctionTypeTraits traits;
        }

        [Tag<TypeSort>(TypeSort.Method)]
        public readonly struct MethodType : IHasSort<MethodType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Method;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex target;
            public readonly TypeIndex source;
            public readonly TypeIndex class_type;
            public readonly NoexceptSpecification eh_spec;
            public readonly CallingConvention convention;
            public readonly FunctionTypeTraits traits;
        }

        [Tag<TypeSort>(TypeSort.Array)]
        public readonly struct ArrayType : IHasSort<ArrayType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Array;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex element;
            public readonly ExprIndex bound;
        }

        [Tag<TypeSort>(TypeSort.Qualified)]
        public readonly struct QualifiedType : IHasSort<QualifiedType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Qualified;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex unqualified_type;
            public readonly Qualifier qualifiers;
        }

        [Tag<TypeSort>(TypeSort.Typename)]
        public readonly struct TypenameType : IHasSort<TypenameType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Typename;
            public static SortType Type => SortType.Type;

            public readonly ExprIndex path;
        }

        [Tag<TypeSort>(TypeSort.Base)]
        public readonly struct BaseType : IHasSort<BaseType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.Base;
            public static SortType Type => SortType.Type;

            public readonly TypeIndex type;
            public readonly Access access;
            public readonly BaseClassTraits traits;
        }

        [Tag<TypeSort>(TypeSort.SyntaxTree)]
        public readonly struct SyntaxTreeType : IHasSort<SyntaxTreeType, TypeSort>
        {
            public static TypeSort Sort => TypeSort.SyntaxTree;
            public static SortType Type => SortType.Type;

            public readonly SyntaxIndex syntax;
        }

        public readonly struct FileAndLine
        {
            public readonly NameIndex file;
            public readonly LineNumber line;
        }

        public readonly struct ParameterizedEntity
        {
            public readonly DeclIndex decl;
            public readonly SentenceIndex head;
            public readonly SentenceIndex body;
            public readonly SentenceIndex attributes;
        }

        public readonly struct SpecializationForm
        {
            public readonly DeclIndex template_decl;
            public readonly ExprIndex arguments;
        }

        public readonly struct MappingDefinition
        {
            public readonly ChartIndex parameters;
            public readonly ExprIndex initializers;
            public readonly StmtIndex body;
        }

        [Tag<DeclSort>(DeclSort.Function)]
        public readonly struct FunctionDecl : IHasSort<FunctionDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Function;
            public static SortType Type => SortType.Decl;

            public readonly Identity<NameIndex> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly ChartIndex chart;
            public readonly FunctionTraits traits;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Intrinsic)]
        public readonly struct IntrinsicDecl : IHasSort<IntrinsicDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Intrinsic;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly FunctionTraits traits;
        }

        [Tag<DeclSort>(DeclSort.Enumerator)]
        public readonly struct EnumeratorDecl : IHasSort<EnumeratorDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Enumerator;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly ExprIndex initializer;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
        }

        [Tag<DeclSort>(DeclSort.Parameter)]
        public readonly struct ParameterDecl : IHasSort<ParameterDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Parameter;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly ExprIndex type_constraint;
            public readonly DefaultIndex initializer;
            public readonly uint level;
            public readonly uint position;
            public readonly ParameterSort sort;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Variable)]
        public readonly struct VariableDecl : IHasSort<VariableDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Variable;
            public static SortType Type => SortType.Decl;

            public readonly Identity<NameIndex> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly ExprIndex initializer;
            public readonly ExprIndex alignment;
            public readonly ObjectTraits obj_spec;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Field)]
        public readonly struct FieldDecl : IHasSort<FieldDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Field;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly ExprIndex initializer;
            public readonly ExprIndex alignment;
            public readonly ObjectTraits obj_spec;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Bitfield)]
        public readonly struct BitfieldDecl : IHasSort<BitfieldDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Bitfield;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly ExprIndex width;
            public readonly ExprIndex initializer;
            public readonly ObjectTraits obj_spec;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Scope)]
        public readonly struct ScopeDecl : IHasSort<ScopeDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Scope;
            public static SortType Type => SortType.Decl;

            public readonly Identity<NameIndex> identity;
            public readonly TypeIndex type;
            public readonly TypeIndex @base;
            public readonly ScopeIndex initializer;
            public readonly DeclIndex home_scope;
            public readonly ExprIndex alignment;
            public readonly PackSize pack_size;
            public readonly BasicSpecifiers basic_spec;
            public readonly ScopeTraits scope_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Enumeration)]
        public readonly struct EnumerationDecl : IHasSort<EnumerationDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Enumeration;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly TypeIndex @base;
            public readonly Sequence<EnumeratorDecl> initializer;
            public readonly DeclIndex home_scope;
            public readonly ExprIndex alignment;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Alias)]
        public readonly struct AliasDecl : IHasSort<AliasDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Alias;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly TypeIndex aliasee;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
        }

        [Tag<DeclSort>(DeclSort.Temploid)]
        public readonly struct TemploidDecl : IHasSort<TemploidDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Temploid;
            public static SortType Type => SortType.Decl;

            public readonly ParameterizedEntity ParameterizedEntity;
            public readonly ChartIndex chart;
            public readonly ReachableProperties properties;
        }

        public readonly struct Template
        {
            public readonly Identity<NameIndex> identity;
            public readonly DeclIndex home_scope;
            public readonly ChartIndex chart;
            public readonly ParameterizedEntity entity;
        }

        [Tag<DeclSort>(DeclSort.Template)]
        public readonly struct TemplateDecl : IHasSort<TemplateDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Template;
            public static SortType Type => SortType.Decl;

            public readonly Template Template;
            public readonly TypeIndex type;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.PartialSpecialization)]
        public readonly struct PartialSpecializationDecl : IHasSort<PartialSpecializationDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.PartialSpecialization;
            public static SortType Type => SortType.Decl;

            public readonly Template Template;
            public readonly SpecFormIndex specialization_form;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Specialization)]
        public readonly struct SpecializationDecl : IHasSort<SpecializationDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Specialization;
            public static SortType Type => SortType.Decl;

            public readonly SpecFormIndex specialization_form;
            public readonly DeclIndex decl;
            public readonly SpecializationSort sort;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.DefaultArgument)]
        public readonly struct DefaultArgumentDecl : IHasSort<DefaultArgumentDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.DefaultArgument;
            public static SortType Type => SortType.Decl;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly ExprIndex initializer;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Concept)]
        public readonly struct ConceptDecl : IHasSort<ConceptDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Concept;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly DeclIndex home_scope;
            public readonly TypeIndex type;
            public readonly ChartIndex chart;
            public readonly ExprIndex constraint;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly SentenceIndex head;
            public readonly SentenceIndex body;
        }

        [Tag<DeclSort>(DeclSort.Method)]
        public readonly struct NonStaticMemberFunctionDecl : IHasSort<NonStaticMemberFunctionDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Method;
            public static SortType Type => SortType.Decl;

            public readonly Identity<NameIndex> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly ChartIndex chart;
            public readonly FunctionTraits traits;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Constructor)]
        public readonly struct ConstructorDecl : IHasSort<ConstructorDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Constructor;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly ChartIndex chart;
            public readonly FunctionTraits traits;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.InheritedConstructor)]
        public readonly struct InheritedConstructorDecl : IHasSort<InheritedConstructorDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.InheritedConstructor;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly ChartIndex chart;
            public readonly FunctionTraits traits;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly DeclIndex base_ctor;
        }

        [Tag<DeclSort>(DeclSort.Destructor)]
        public readonly struct DestructorDecl : IHasSort<DestructorDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Destructor;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly DeclIndex home_scope;
            public readonly NoexceptSpecification eh_spec;
            public readonly FunctionTraits traits;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly CallingConvention convention;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.DeductionGuide)]
        public readonly struct DeductionGuideDecl : IHasSort<DeductionGuideDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.DeductionGuide;
            public static SortType Type => SortType.Decl;

            public readonly Identity<NameIndex> identity;
            public readonly DeclIndex home_scope;
            public readonly ChartIndex source;
            public readonly ExprIndex target;
            public readonly GuideTraits traits;
            public readonly BasicSpecifiers basic_spec;
        }

        [Tag<DeclSort>(DeclSort.Barren)]
        public readonly struct BarrenDecl : IHasSort<BarrenDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Barren;
            public static SortType Type => SortType.Decl;

            public readonly DirIndex directive;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
        }

        [Tag<DeclSort>(DeclSort.Reference)]
        public readonly struct ReferenceDecl : IHasSort<ReferenceDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Reference;
            public static SortType Type => SortType.Decl;

            public readonly ModuleReference translation_unit;
            public readonly DeclIndex local_index;
        }

        [Tag<DeclSort>(DeclSort.Property)]
        public readonly struct PropertyDecl : IHasSort<PropertyDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Property;
            public static SortType Type => SortType.Decl;

            public readonly DeclIndex data_member;
            public readonly TextOffset get_method_name;
            public readonly TextOffset set_method_name;
        }

        [Tag<DeclSort>(DeclSort.OutputSegment)]
        public readonly struct SegmentDecl : IHasSort<SegmentDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.OutputSegment;
            public static SortType Type => SortType.Decl;

            public readonly TextOffset name;
            public readonly TextOffset class_id;
            public readonly SegmentTraits seg_spec;
            public readonly SegmentType type;
        }

        [Tag<DeclSort>(DeclSort.Using)]
        public readonly struct UsingDecl : IHasSort<UsingDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Using;
            public static SortType Type => SortType.Decl;

            public readonly Identity<TextOffset> identity;
            public readonly DeclIndex home_scope;
            public readonly DeclIndex resolution;
            public readonly ExprIndex parent;
            public readonly TextOffset name;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            [MarshalAs(UnmanagedType.U1)]
            public readonly bool is_hidden;
        }

        [Tag<DeclSort>(DeclSort.Friend)]
        public readonly struct FriendDecl : IHasSort<FriendDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Friend;
            public static SortType Type => SortType.Decl;

            public readonly ExprIndex index;
        }

        [Tag<DeclSort>(DeclSort.Expansion)]
        public readonly struct ExpansionDecl : IHasSort<ExpansionDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Expansion;
            public static SortType Type => SortType.Decl;

            public readonly SourceLocation locus;
            public readonly DeclIndex operand;
        }

        [Tag<DeclSort>(DeclSort.SyntaxTree)]
        public readonly struct SyntacticDecl : IHasSort<SyntacticDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.SyntaxTree;
            public static SortType Type => SortType.Decl;

            public readonly SyntaxIndex index;
        }

        [Tag<DeclSort>(DeclSort.Tuple)]
        public readonly struct TupleDecl : IHasSort<TupleDecl, DeclSort>
        {
            public static DeclSort Sort => DeclSort.Tuple;
            public static SortType Type => SortType.Decl;

            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        public readonly struct Scope
        {
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<ChartSort>(ChartSort.Unilevel)]
        public readonly struct UnilevelChart : IHasSort<UnilevelChart, ChartSort>
        {
            public static ChartSort Sort => ChartSort.Unilevel;
            public static SortType Type => SortType.Chart;

            public readonly Index start;
            public readonly Cardinality cardinality;
            public readonly ExprIndex requires_clause;
        }

        [Tag<ChartSort>(ChartSort.Multilevel)]
        public readonly struct MultiChart : IHasSort<MultiChart, ChartSort>
        {
            public static ChartSort Sort => ChartSort.Multilevel;
            public static SortType Type => SortType.Chart;

            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<StmtSort>(StmtSort.Block)]
        public readonly struct BlockStmt : IHasSort<BlockStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Block;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<StmtSort>(StmtSort.Try)]
        public readonly struct TryStmt : IHasSort<TryStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Try;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly Index start;
            public readonly Cardinality cardinality;
            public readonly StmtIndex handlers;
        }

        [Tag<StmtSort>(StmtSort.Expression)]
        public readonly struct ExpressionStmt : IHasSort<ExpressionStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Expression;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly ExprIndex expr;
        }

        [Tag<StmtSort>(StmtSort.If)]
        public readonly struct IfStmt : IHasSort<IfStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.If;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly StmtIndex init;
            public readonly StmtIndex condition;
            public readonly StmtIndex consequence;
            public readonly StmtIndex alternative;
        }

        [Tag<StmtSort>(StmtSort.While)]
        public readonly struct WhileStmt : IHasSort<WhileStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.While;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly StmtIndex condition;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.DoWhile)]
        public readonly struct DoWhileStmt : IHasSort<DoWhileStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.DoWhile;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly ExprIndex condition;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.For)]
        public readonly struct ForStmt : IHasSort<ForStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.For;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly StmtIndex init;
            public readonly StmtIndex condition;
            public readonly StmtIndex increment;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.Break)]
        public readonly struct BreakStmt : IHasSort<BreakStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Break;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
        }

        [Tag<StmtSort>(StmtSort.Continue)]
        public readonly struct ContinueStmt : IHasSort<ContinueStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Continue;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
        }

        [Tag<StmtSort>(StmtSort.Goto)]
        public readonly struct GotoStmt : IHasSort<GotoStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Goto;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly ExprIndex target;
        }

        [Tag<StmtSort>(StmtSort.Switch)]
        public readonly struct SwitchStmt : IHasSort<SwitchStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Switch;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly StmtIndex init;
            public readonly ExprIndex control;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.Labeled)]
        public readonly struct LabeledStmt : IHasSort<LabeledStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Labeled;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex label;
            public readonly StmtIndex statement;
        }

        [Tag<StmtSort>(StmtSort.Decl)]
        public readonly struct DeclStmt : IHasSort<DeclStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Decl;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly DeclIndex decl;
        }

        [Tag<StmtSort>(StmtSort.Return)]
        public readonly struct ReturnStmt : IHasSort<ReturnStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Return;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex expr;
            public readonly TypeIndex function_type;
        }

        [Tag<StmtSort>(StmtSort.Handler)]
        public readonly struct HandlerStmt : IHasSort<HandlerStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Handler;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly DeclIndex exception;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.Expansion)]
        public readonly struct ExpansionStmt : IHasSort<ExpansionStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Expansion;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly StmtIndex operand;
        }

        [Tag<StmtSort>(StmtSort.Tuple)]
        public readonly struct TupleStmt : IHasSort<TupleStmt, StmtSort>
        {
            public static StmtSort Sort => StmtSort.Tuple;
            public static SortType Type => SortType.Stmt;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        public readonly struct StringLiteral
        {
            public readonly TextOffset start;
            public readonly Cardinality size;
            public readonly TextOffset suffix;
        }

        [Tag<ExprSort>(ExprSort.Type)]
        public readonly struct TypeExpr : IHasSort<TypeExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Type;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex denotation;
        }

        [Tag<ExprSort>(ExprSort.String)]
        public readonly struct StringExpr : IHasSort<StringExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.String;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly StringIndex @string;
        }

        [Tag<ExprSort>(ExprSort.FunctionString)]
        public readonly struct FunctionStringExpr : IHasSort<FunctionStringExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.FunctionString;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TextOffset macro;
        }

        [Tag<ExprSort>(ExprSort.CompoundString)]
        public readonly struct CompoundStringExpr : IHasSort<CompoundStringExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.CompoundString;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TextOffset prefix;
            public readonly ExprIndex @string;
        }

        [Tag<ExprSort>(ExprSort.StringSequence)]
        public readonly struct StringSequenceExpr : IHasSort<StringSequenceExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.StringSequence;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex strings;
        }

        [Tag<ExprSort>(ExprSort.UnresolvedId)]
        public readonly struct UnresolvedIdExpr : IHasSort<UnresolvedIdExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.UnresolvedId;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly NameIndex name;
        }

        [Tag<ExprSort>(ExprSort.TemplateId)]
        public readonly struct TemplateIdExpr : IHasSort<TemplateIdExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.TemplateId;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex primary_template;
            public readonly ExprIndex arguments;
        }

        [Tag<ExprSort>(ExprSort.TemplateReference)]
        public readonly struct TemplateReferenceExpr : IHasSort<TemplateReferenceExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.TemplateReference;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex member;
            public readonly NameIndex member_name;
            public readonly TypeIndex parent;
            public readonly ExprIndex template_arguments;
        }

        [Tag<ExprSort>(ExprSort.NamedDecl)]
        public readonly struct NamedDeclExpr : IHasSort<NamedDeclExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.NamedDecl;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex decl;
        }

        [Tag<ExprSort>(ExprSort.Literal)]
        public readonly struct LiteralExpr : IHasSort<LiteralExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Literal;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly LitIndex value;
        }

        [Tag<ExprSort>(ExprSort.Empty)]
        public readonly struct EmptyExpr : IHasSort<EmptyExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Empty;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
        }

        [Tag<ExprSort>(ExprSort.Path)]
        public readonly struct PathExpr : IHasSort<PathExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Path;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex scope;
            public readonly ExprIndex member;
        }

        [Tag<ExprSort>(ExprSort.Read)]
        public readonly struct ReadExpr : IHasSort<ReadExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Read;
            public static SortType Type => SortType.Expr;

            public enum Kind : byte
            {
                Unknown,
                Indirection,
                RemoveReference,
                LvalueToRvalue,
                IntegralConversion,
                Count
            }

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex child;
            public readonly Kind kind;
        }

        [Tag<ExprSort>(ExprSort.Monad)]
        public readonly struct MonadicExpr : IHasSort<MonadicExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Monad;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex impl;
            public readonly ExprIndex_Array1 arg;
            public readonly MonadicOperator assort;
        }

        [System.Runtime.CompilerServices.InlineArray(1)]
        public struct ExprIndex_Array1
        {
            private ExprIndex _element;
        }
        [Tag<ExprSort>(ExprSort.Dyad)]
        public readonly struct DyadicExpr : IHasSort<DyadicExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Dyad;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex impl;
            public readonly ExprIndex_Array2 arg;
            public readonly DyadicOperator assort;
        }

        [System.Runtime.CompilerServices.InlineArray(2)]
        public struct ExprIndex_Array2
        {
            private ExprIndex _element;
        }
        [Tag<ExprSort>(ExprSort.Triad)]
        public readonly struct TriadicExpr : IHasSort<TriadicExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Triad;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex impl;
            public readonly ExprIndex_Array3 arg;
            public readonly TriadicOperator assort;
        }

        [System.Runtime.CompilerServices.InlineArray(3)]
        public struct ExprIndex_Array3
        {
            private ExprIndex _element;
        }
        [Tag<ExprSort>(ExprSort.HierarchyConversion)]
        public readonly struct HierarchyConversionExpr : IHasSort<HierarchyConversionExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.HierarchyConversion;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex source;
            public readonly TypeIndex target;
            public readonly ExprIndex inheritance_path;
            public readonly ExprIndex override_inheritance_path;
            public readonly DyadicOperator assort;
        }

        [Tag<ExprSort>(ExprSort.DestructorCall)]
        public readonly struct DestructorCallExpr : IHasSort<DestructorCallExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.DestructorCall;
            public static SortType Type => SortType.Expr;

            public enum Kind : byte
            {
                Unknown,
                Destructor,
                Finalizer
            }

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex name;
            public readonly SyntaxIndex decltype_specifier;
            public readonly Kind kind;
        }

        [Tag<ExprSort>(ExprSort.Tuple)]
        public readonly struct TupleExpr : IHasSort<TupleExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Tuple;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<ExprSort>(ExprSort.Placeholder)]
        public readonly struct PlaceholderExpr : IHasSort<PlaceholderExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Placeholder;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
        }

        [Tag<ExprSort>(ExprSort.Expansion)]
        public readonly struct ExpansionExpr : IHasSort<ExpansionExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Expansion;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex operand;
        }

        [Tag<ExprSort>(ExprSort.Tokens)]
        public readonly struct TokenExpr : IHasSort<TokenExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Tokens;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly SentenceIndex tokens;
        }

        [Tag<ExprSort>(ExprSort.Call)]
        public readonly struct CallExpr : IHasSort<CallExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Call;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex function;
            public readonly ExprIndex arguments;
        }

        [Tag<ExprSort>(ExprSort.Temporary)]
        public readonly struct TemporaryExpr : IHasSort<TemporaryExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Temporary;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly uint index;
        }

        [Tag<ExprSort>(ExprSort.DynamicDispatch)]
        public readonly struct DynamicDispatchExpr : IHasSort<DynamicDispatchExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.DynamicDispatch;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex postfix_expr;
        }

        [Tag<ExprSort>(ExprSort.VirtualFunctionConversion)]
        public readonly struct VirtualFunctionConversionExpr : IHasSort<VirtualFunctionConversionExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.VirtualFunctionConversion;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex function;
        }

        [Tag<ExprSort>(ExprSort.Requires)]
        public readonly struct RequiresExpr : IHasSort<RequiresExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Requires;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly SyntaxIndex parameters;
            public readonly SyntaxIndex body;
        }

        [Tag<ExprSort>(ExprSort.UnaryFold)]
        public readonly struct UnaryFoldExpr : IHasSort<UnaryFoldExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.UnaryFold;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex expr;
            public readonly DyadicOperator op;
            public readonly Associativity assoc;
        }

        [Tag<ExprSort>(ExprSort.BinaryFold)]
        public readonly struct BinaryFoldExpr : IHasSort<BinaryFoldExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.BinaryFold;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex left;
            public readonly ExprIndex right;
            public readonly DyadicOperator op;
            public readonly Associativity assoc;
        }

        [Tag<ExprSort>(ExprSort.Statement)]
        public readonly struct StatementExpr : IHasSort<StatementExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Statement;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly StmtIndex stmt;
        }

        [Tag<ExprSort>(ExprSort.TypeTraitIntrinsic)]
        public readonly struct TypeTraitIntrinsicExpr : IHasSort<TypeTraitIntrinsicExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.TypeTraitIntrinsic;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex arguments;
            public readonly Operator intrinsic;
        }

        [Tag<ExprSort>(ExprSort.MemberInitializer)]
        public readonly struct MemberInitializerExpr : IHasSort<MemberInitializerExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.MemberInitializer;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex member;
            public readonly TypeIndex @base;
            public readonly ExprIndex expression;
        }

        [Tag<ExprSort>(ExprSort.MemberAccess)]
        public readonly struct MemberAccessExpr : IHasSort<MemberAccessExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.MemberAccess;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex offset;
            public readonly TypeIndex parent;
            public readonly TextOffset name;
        }

        [Tag<ExprSort>(ExprSort.InheritancePath)]
        public readonly struct InheritancePathExpr : IHasSort<InheritancePathExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.InheritancePath;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex path;
        }

        [Tag<ExprSort>(ExprSort.InitializerList)]
        public readonly struct InitializerListExpr : IHasSort<InitializerListExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.InitializerList;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex elements;
        }

        [Tag<ExprSort>(ExprSort.Initializer)]
        public readonly struct InitializerExpr : IHasSort<InitializerExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Initializer;
            public static SortType Type => SortType.Expr;

            public enum Kind : byte
            {
                Unknown,
                DirectInitialization,
                CopyInitialization
            }

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex initializer;
            public readonly Kind kind;
        }

        [Tag<ExprSort>(ExprSort.Cast)]
        public readonly struct CastExpr : IHasSort<CastExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Cast;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex source;
            public readonly TypeIndex target;
            public readonly DyadicOperator assort;
        }

        [Tag<ExprSort>(ExprSort.Condition)]
        public readonly struct ConditionExpr : IHasSort<ConditionExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Condition;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex expression;
        }

        [Tag<ExprSort>(ExprSort.SimpleIdentifier)]
        public readonly struct SimpleIdentifierExpr : IHasSort<SimpleIdentifierExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.SimpleIdentifier;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly NameIndex name;
        }

        [Tag<ExprSort>(ExprSort.Pointer)]
        public readonly struct PointerExpr : IHasSort<PointerExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Pointer;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
        }

        [Tag<ExprSort>(ExprSort.UnqualifiedId)]
        public readonly struct UnqualifiedIdExpr : IHasSort<UnqualifiedIdExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.UnqualifiedId;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly NameIndex name;
            public readonly ExprIndex symbol;
            public readonly SourceLocation template_keyword;
        }

        [Tag<ExprSort>(ExprSort.QualifiedName)]
        public readonly struct QualifiedNameExpr : IHasSort<QualifiedNameExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.QualifiedName;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex elements;
            public readonly SourceLocation typename_keyword;
        }

        [Tag<ExprSort>(ExprSort.DesignatedInitializer)]
        public readonly struct DesignatedInitializerExpr : IHasSort<DesignatedInitializerExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.DesignatedInitializer;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TextOffset member;
            public readonly ExprIndex initializer;
        }

        [Tag<ExprSort>(ExprSort.ExpressionList)]
        public readonly struct ExpressionListExpr : IHasSort<ExpressionListExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.ExpressionList;
            public static SortType Type => SortType.Expr;

            public enum Delimiter : byte
            {
                Unknown,
                Brace,
                Parenthesis
            }

            public readonly SourceLocation left_delimiter;
            public readonly SourceLocation right_delimiter;
            public readonly ExprIndex expressions;
            public readonly Delimiter delimiter;
        }

        [Tag<ExprSort>(ExprSort.AssignInitializer)]
        public readonly struct AssignInitializerExpr : IHasSort<AssignInitializerExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.AssignInitializer;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation assign;
            public readonly ExprIndex initializer;
        }

        [Tag<ExprSort>(ExprSort.SizeofType)]
        public readonly struct SizeofTypeExpr : IHasSort<SizeofTypeExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.SizeofType;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex operand;
        }

        [Tag<ExprSort>(ExprSort.Alignof)]
        public readonly struct AlignofExpr : IHasSort<AlignofExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Alignof;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex type_id;
        }

        [Tag<ExprSort>(ExprSort.Label)]
        public readonly struct LabelExpr : IHasSort<LabelExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Label;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex designator;
        }

        [Tag<ExprSort>(ExprSort.Nullptr)]
        public readonly struct NullptrExpr : IHasSort<NullptrExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Nullptr;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
        }

        [Tag<ExprSort>(ExprSort.This)]
        public readonly struct ThisExpr : IHasSort<ThisExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.This;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
        }

        [Tag<ExprSort>(ExprSort.PackedTemplateArguments)]
        public readonly struct PackedTemplateArgumentsExpr : IHasSort<PackedTemplateArgumentsExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.PackedTemplateArguments;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex arguments;
        }

        [Tag<ExprSort>(ExprSort.Lambda)]
        public readonly struct LambdaExpr : IHasSort<LambdaExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Lambda;
            public static SortType Type => SortType.Expr;

            public readonly SyntaxIndex introducer;
            public readonly SyntaxIndex template_parameters;
            public readonly SyntaxIndex declarator;
            public readonly SyntaxIndex requires_clause;
            public readonly SyntaxIndex body;
        }

        [Tag<ExprSort>(ExprSort.Typeid)]
        public readonly struct TypeidExpr : IHasSort<TypeidExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.Typeid;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex operand;
        }

        [Tag<ExprSort>(ExprSort.SyntaxTree)]
        public readonly struct SyntaxTreeExpr : IHasSort<SyntaxTreeExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.SyntaxTree;
            public static SortType Type => SortType.Expr;

            public readonly SyntaxIndex syntax;
        }

        [Tag<ExprSort>(ExprSort.ProductTypeValue)]
        public readonly struct ProductTypeValueExpr : IHasSort<ProductTypeValueExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.ProductTypeValue;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex structure;
            public readonly ExprIndex members;
            public readonly ExprIndex base_class_values;
        }

        [Tag<ExprSort>(ExprSort.SumTypeValue)]
        public readonly struct SumTypeValueExpr : IHasSort<SumTypeValueExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.SumTypeValue;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex variant;
            public readonly ActiveMemberIndex active_member;
            public readonly ExprIndex value;
        }

        [Tag<ExprSort>(ExprSort.ArrayValue)]
        public readonly struct ArrayValueExpr : IHasSort<ArrayValueExpr, ExprSort>
        {
            public static ExprSort Sort => ExprSort.ArrayValue;
            public static SortType Type => SortType.Expr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex elements;
            public readonly TypeIndex element_type;
        }

        [Tag<MacroSort>(MacroSort.ObjectLike)]
        public readonly struct ObjectLikeMacro : IHasSort<ObjectLikeMacro, MacroSort>
        {
            public static MacroSort Sort => MacroSort.ObjectLike;
            public static SortType Type => SortType.Macro;

            public readonly SourceLocation locus;
            public readonly TextOffset name;
            public readonly FormIndex replacement_list;
        }

        [Tag<MacroSort>(MacroSort.FunctionLike)]
        public readonly struct FunctionLikeMacro : IHasSort<FunctionLikeMacro, MacroSort>
        {
            public static MacroSort Sort => MacroSort.FunctionLike;
            public static SortType Type => SortType.Macro;

            public readonly SourceLocation locus;
            public readonly TextOffset name;
            public readonly FormIndex parameters;
            public readonly FormIndex replacement_list;
            private readonly uint arity_bitfield;
            // uint variadic (bitfield continuation)
            public uint arity => ((arity_bitfield >> 1) & 0b1111111111111111111111111111111);
            public uint variadic => ((arity_bitfield >> 0) & 0b1);
        }

        public readonly struct PragmaWarningRegion
        {
            public readonly SourceLocation start_locus;
            public readonly SourceLocation end_locus;
            public readonly SuppressedWarning suppressed_warning;
        }

        public readonly struct IntegerLiteral
        {
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public readonly struct LiteralReal
        {
            public readonly double value;
            public readonly ushort size;
        }

        public readonly struct FloatingPointLiteral
        {
        }

        public readonly struct PragmaPushState
        {
            public readonly DeclIndex text_segment;
            public readonly DeclIndex const_segment;
            public readonly DeclIndex data_segment;
            public readonly DeclIndex bss_segment;
            private readonly uint pack_size_bitfield;
            // uint fp_control (bitfield continuation)
            // uint exec_charset (bitfield continuation)
            // uint vtor_disp (bitfield continuation)
            private readonly uint std_for_scope_bitfield;
            // uint unused (bitfield continuation)
            // uint strict_gs_check (bitfield continuation)
            public uint pack_size => ((pack_size_bitfield >> 24) & 0b11111111);
            public uint fp_control => ((pack_size_bitfield >> 16) & 0b11111111);
            public uint exec_charset => ((pack_size_bitfield >> 8) & 0b11111111);
            public uint vtor_disp => ((pack_size_bitfield >> 0) & 0b11111111);
            public uint std_for_scope => ((std_for_scope_bitfield >> 31) & 0b1);
            public uint unused => ((std_for_scope_bitfield >> 30) & 0b1);
            public uint strict_gs_check => ((std_for_scope_bitfield >> 29) & 0b1);
        }

        [Tag<AttrSort>(AttrSort.Basic)]
        public readonly struct BasicAttr : IHasSort<BasicAttr, AttrSort>
        {
            public static AttrSort Sort => AttrSort.Basic;
            public static SortType Type => SortType.Attr;

            public readonly Word word;
        }

        [Tag<AttrSort>(AttrSort.Scoped)]
        public readonly struct ScopedAttr : IHasSort<ScopedAttr, AttrSort>
        {
            public static AttrSort Sort => AttrSort.Scoped;
            public static SortType Type => SortType.Attr;

            public readonly Word scope;
            public readonly Word member;
        }

        [Tag<AttrSort>(AttrSort.Labeled)]
        public readonly struct LabeledAttr : IHasSort<LabeledAttr, AttrSort>
        {
            public static AttrSort Sort => AttrSort.Labeled;
            public static SortType Type => SortType.Attr;

            public readonly Word label;
            public readonly AttrIndex attribute;
        }

        [Tag<AttrSort>(AttrSort.Called)]
        public readonly struct CalledAttr : IHasSort<CalledAttr, AttrSort>
        {
            public static AttrSort Sort => AttrSort.Called;
            public static SortType Type => SortType.Attr;

            public readonly AttrIndex function;
            public readonly AttrIndex arguments;
        }

        [Tag<AttrSort>(AttrSort.Expanded)]
        public readonly struct ExpandedAttr : IHasSort<ExpandedAttr, AttrSort>
        {
            public static AttrSort Sort => AttrSort.Expanded;
            public static SortType Type => SortType.Attr;

            public readonly AttrIndex operand;
        }

        [Tag<AttrSort>(AttrSort.Factored)]
        public readonly struct FactoredAttr : IHasSort<FactoredAttr, AttrSort>
        {
            public static AttrSort Sort => AttrSort.Factored;
            public static SortType Type => SortType.Attr;

            public readonly Word factor;
            public readonly AttrIndex terms;
        }

        [Tag<AttrSort>(AttrSort.Elaborated)]
        public readonly struct ElaboratedAttr : IHasSort<ElaboratedAttr, AttrSort>
        {
            public static AttrSort Sort => AttrSort.Elaborated;
            public static SortType Type => SortType.Attr;

            public readonly ExprIndex expr;
        }

        [Tag<AttrSort>(AttrSort.Tuple)]
        public readonly struct TupleAttr : IHasSort<TupleAttr, AttrSort>
        {
            public static AttrSort Sort => AttrSort.Tuple;
            public static SortType Type => SortType.Attr;

            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<DirSort>(DirSort.Empty)]
        public readonly struct EmptyDir : IHasSort<EmptyDir, DirSort>
        {
            public static DirSort Sort => DirSort.Empty;
            public static SortType Type => SortType.Dir;

            public readonly SourceLocation locus;
        }

        [Tag<DirSort>(DirSort.Attribute)]
        public readonly struct AttributeDir : IHasSort<AttributeDir, DirSort>
        {
            public static DirSort Sort => DirSort.Attribute;
            public static SortType Type => SortType.Dir;

            public readonly SourceLocation locus;
            public readonly AttrIndex attr;
        }

        [Tag<DirSort>(DirSort.Pragma)]
        public readonly struct PragmaDir : IHasSort<PragmaDir, DirSort>
        {
            public static DirSort Sort => DirSort.Pragma;
            public static SortType Type => SortType.Dir;

            public readonly SourceLocation locus;
            public readonly SentenceIndex words;
        }

        [Tag<DirSort>(DirSort.Using)]
        public readonly struct UsingDir : IHasSort<UsingDir, DirSort>
        {
            public static DirSort Sort => DirSort.Using;
            public static SortType Type => SortType.Dir;

            public readonly SourceLocation locus;
            public readonly ExprIndex nominated;
            public readonly DeclIndex resolution;
        }

        [Tag<DirSort>(DirSort.DeclUse)]
        public readonly struct UsingDeclarationDir : IHasSort<UsingDeclarationDir, DirSort>
        {
            public static DirSort Sort => DirSort.DeclUse;
            public static SortType Type => SortType.Dir;

            public readonly SourceLocation locus;
            public readonly ExprIndex path;
            public readonly DeclIndex result;
        }

        [Tag<DirSort>(DirSort.Expr)]
        public readonly struct ExprDir : IHasSort<ExprDir, DirSort>
        {
            public static DirSort Sort => DirSort.Expr;
            public static SortType Type => SortType.Dir;

            public readonly SourceLocation locus;
            public readonly ExprIndex expr;
            public readonly Phases phases;
        }

        [Tag<DirSort>(DirSort.StructuredBinding)]
        public readonly struct StructuredBindingDir : IHasSort<StructuredBindingDir, DirSort>
        {
            public static DirSort Sort => DirSort.StructuredBinding;
            public static SortType Type => SortType.Dir;

            public readonly SourceLocation locus;
            public readonly Sequence<DeclIndex> bindings;
            public readonly Sequence<TextOffset> names;
        }

        [Tag<DirSort>(DirSort.SpecifiersSpread)]
        public readonly struct SpecifiersSpreadDir : IHasSort<SpecifiersSpreadDir, DirSort>
        {
            public static DirSort Sort => DirSort.SpecifiersSpread;
            public static SortType Type => SortType.Dir;

            public readonly SourceLocation locus;
        }

        [Tag<DirSort>(DirSort.Tuple)]
        public readonly struct TupleDir : IHasSort<TupleDir, DirSort>
        {
            public static DirSort Sort => DirSort.Tuple;
            public static SortType Type => SortType.Dir;

            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        namespace syntax
        {
            public enum StorageClass : uint
            {
                None,
                Auto,
                Constexpr,
                Explicit = 4,
                Extern = 8,
                Force_inline = 16,
                Friend = 32,
                Inline = 64,
                Mutable = 128,
                New_slot = 256,
                Register = 512,
                Static = 1024,
                Thread_local = 2048,
                Tile_static = 4096,
                Typedef = 8192,
                Virtual = 16384,
                Consteval = 32768,
                Constinit = 65536
            }

            public enum FoldKind : uint
            {
                Unknown,
                LeftFold,
                RightFold
            }

            [Tag<SyntaxSort>(SyntaxSort.DecltypeSpecifier)]
            public readonly struct DecltypeSpecifier : IHasSort<DecltypeSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.DecltypeSpecifier;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
                public readonly SourceLocation decltype_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.PlaceholderTypeSpecifier)]
            public readonly struct PlaceholderTypeSpecifier : IHasSort<PlaceholderTypeSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.PlaceholderTypeSpecifier;
                public static SortType Type => SortType.Syntax;

                public readonly PlaceholderType type;
                public readonly SourceLocation keyword;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.SimpleTypeSpecifier)]
            public readonly struct SimpleTypeSpecifier : IHasSort<SimpleTypeSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.SimpleTypeSpecifier;
                public static SortType Type => SortType.Syntax;

                public readonly TypeIndex type;
                public readonly ExprIndex expr;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeSpecifierSeq)]
            public readonly struct TypeSpecifierSeq : IHasSort<TypeSpecifierSeq, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TypeSpecifierSeq;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex type_script;
                public readonly TypeIndex type;
                public readonly SourceLocation locus;
                public readonly Qualifier qualifiers;
                [MarshalAs(UnmanagedType.U1)]
                public readonly bool is_unhashed;
            }

            public readonly struct Keyword
            {
                public enum Kind : byte
                {
                    None,
                    Class,
                    Struct,
                    Union,
                    Public,
                    Protected,
                    Private,
                    Default,
                    Delete,
                    Mutable,
                    Constexpr,
                    Consteval,
                    Typename,
                    Constinit
                }

                public readonly SourceLocation locus;
                public readonly Kind kind;
            }

            [Tag<SyntaxSort>(SyntaxSort.DeclSpecifierSeq)]
            public readonly struct DeclSpecifierSeq : IHasSort<DeclSpecifierSeq, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.DeclSpecifierSeq;
                public static SortType Type => SortType.Syntax;

                public readonly TypeIndex type;
                public readonly SyntaxIndex type_script;
                public readonly SourceLocation locus;
                public readonly StorageClass storage_class;
                public readonly SentenceIndex declspec;
                public readonly SyntaxIndex explicit_specifier;
                public readonly Qualifier qualifiers;
            }

            [Tag<SyntaxSort>(SyntaxSort.EnumSpecifier)]
            public readonly struct EnumSpecifier : IHasSort<EnumSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.EnumSpecifier;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex name;
                public readonly Keyword class_or_struct;
                public readonly SyntaxIndex enumerators;
                public readonly SyntaxIndex enum_base;
                public readonly SourceLocation locus;
                public readonly SourceLocation colon;
                public readonly SourceLocation left_brace;
                public readonly SourceLocation right_brace;
            }

            [Tag<SyntaxSort>(SyntaxSort.EnumeratorDefinition)]
            public readonly struct EnumeratorDefinition : IHasSort<EnumeratorDefinition, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.EnumeratorDefinition;
                public static SortType Type => SortType.Syntax;

                public readonly TextOffset name;
                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
                public readonly SourceLocation assign;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.ClassSpecifier)]
            public readonly struct ClassSpecifier : IHasSort<ClassSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ClassSpecifier;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex name;
                public readonly Keyword class_key;
                public readonly SyntaxIndex base_classes;
                public readonly SyntaxIndex members;
                public readonly SourceLocation left_brace;
                public readonly SourceLocation right_brace;
            }

            [Tag<SyntaxSort>(SyntaxSort.BaseSpecifierList)]
            public readonly struct BaseSpecifierList : IHasSort<BaseSpecifierList, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.BaseSpecifierList;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex base_specifiers;
                public readonly SourceLocation colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.BaseSpecifier)]
            public readonly struct BaseSpecifier : IHasSort<BaseSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.BaseSpecifier;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex name;
                public readonly Keyword access_keyword;
                public readonly SourceLocation virtual_keyword;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemberSpecification)]
            public readonly struct MemberSpecification : IHasSort<MemberSpecification, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.MemberSpecification;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex declarations;
            }

            [Tag<SyntaxSort>(SyntaxSort.AccessSpecifier)]
            public readonly struct AccessSpecifier : IHasSort<AccessSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.AccessSpecifier;
                public static SortType Type => SortType.Syntax;

                public readonly Keyword keyword;
                public readonly SourceLocation colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemberDeclaration)]
            public readonly struct MemberDeclaration : IHasSort<MemberDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.MemberDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarators;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemberDeclarator)]
            public readonly struct MemberDeclarator : IHasSort<MemberDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.MemberDeclarator;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex declarator;
                public readonly SyntaxIndex requires_clause;
                public readonly ExprIndex expression;
                public readonly ExprIndex initializer;
                public readonly SourceLocation locus;
                public readonly SourceLocation colon;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeId)]
            public readonly struct TypeId : IHasSort<TypeId, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TypeId;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex type;
                public readonly SyntaxIndex declarator;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.TrailingReturnType)]
            public readonly struct TrailingReturnType : IHasSort<TrailingReturnType, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TrailingReturnType;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex type;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.PointerDeclarator)]
            public readonly struct PointerDeclarator : IHasSort<PointerDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.PointerDeclarator;
                public static SortType Type => SortType.Syntax;

                public enum Kind : byte
                {
                    None,
                    Pointer,
                    LvalueReference,
                    RvalueReference,
                    PointerToMember
                }

                public readonly ExprIndex owner;
                public readonly SyntaxIndex child;
                public readonly SourceLocation locus;
                public readonly Kind kind;
                public readonly Qualifier qualifiers;
                public readonly CallingConvention convention;
                [MarshalAs(UnmanagedType.U1)]
                public readonly bool is_function;
            }

            [Tag<SyntaxSort>(SyntaxSort.ArrayDeclarator)]
            public readonly struct ArrayDeclarator : IHasSort<ArrayDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ArrayDeclarator;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex bounds;
                public readonly SourceLocation left_bracket;
                public readonly SourceLocation right_bracket;
            }

            [Tag<SyntaxSort>(SyntaxSort.FunctionDeclarator)]
            public readonly struct FunctionDeclarator : IHasSort<FunctionDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.FunctionDeclarator;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex parameters;
                public readonly SyntaxIndex exception_specification;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation ref_qualifier;
                public readonly FunctionTypeTraits traits;
            }

            [Tag<SyntaxSort>(SyntaxSort.ArrayOrFunctionDeclarator)]
            public readonly struct ArrayOrFunctionDeclarator : IHasSort<ArrayOrFunctionDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ArrayOrFunctionDeclarator;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex declarator;
                public readonly SyntaxIndex next;
            }

            [Tag<SyntaxSort>(SyntaxSort.ParameterDeclarator)]
            public readonly struct ParameterDeclarator : IHasSort<ParameterDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ParameterDeclarator;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarator;
                public readonly ExprIndex default_argument;
                public readonly SourceLocation locus;
                public readonly ParameterSort sort;
            }

            [Tag<SyntaxSort>(SyntaxSort.VirtualSpecifierSeq)]
            public readonly struct VirtualSpecifierSeq : IHasSort<VirtualSpecifierSeq, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.VirtualSpecifierSeq;
                public static SortType Type => SortType.Syntax;

                public readonly SourceLocation locus;
                public readonly SourceLocation final_keyword;
                public readonly SourceLocation override_keyword;
                [MarshalAs(UnmanagedType.U1)]
                public readonly bool is_pure;
            }

            [Tag<SyntaxSort>(SyntaxSort.NoexceptSpecification)]
            public readonly struct NoexceptSpecification : IHasSort<NoexceptSpecification, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.NoexceptSpecification;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.ExplicitSpecifier)]
            public readonly struct ExplicitSpecifier : IHasSort<ExplicitSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ExplicitSpecifier;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.Declarator)]
            public readonly struct Declarator : IHasSort<Declarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.Declarator;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex pointer;
                public readonly SyntaxIndex parenthesized_declarator;
                public readonly SyntaxIndex array_or_function_declarator;
                public readonly SyntaxIndex trailing_return_type;
                public readonly SyntaxIndex virtual_specifiers;
                public readonly ExprIndex name;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation locus;
                public readonly Qualifier qualifiers;
                public readonly CallingConvention convention;
                [MarshalAs(UnmanagedType.U1)]
                public readonly bool is_function;
            }

            [Tag<SyntaxSort>(SyntaxSort.InitDeclarator)]
            public readonly struct InitDeclarator : IHasSort<InitDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.InitDeclarator;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex declarator;
                public readonly SyntaxIndex requires_clause;
                public readonly ExprIndex initializer;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.NewDeclarator)]
            public readonly struct NewDeclarator : IHasSort<NewDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.NewDeclarator;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex declarator;
            }

            [Tag<SyntaxSort>(SyntaxSort.SimpleDeclaration)]
            public readonly struct SimpleDeclaration : IHasSort<SimpleDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.SimpleDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarators;
                public readonly SourceLocation locus;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ExceptionDeclaration)]
            public readonly struct ExceptionDeclaration : IHasSort<ExceptionDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ExceptionDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex type_specifier_seq;
                public readonly SyntaxIndex declarator;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
            }

            [Tag<SyntaxSort>(SyntaxSort.ConditionDeclaration)]
            public readonly struct ConditionDeclaration : IHasSort<ConditionDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ConditionDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex decl_specifier;
                public readonly SyntaxIndex init_statement;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.StaticAssertDeclaration)]
            public readonly struct StaticAssertDeclaration : IHasSort<StaticAssertDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.StaticAssertDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
                public readonly ExprIndex message;
                public readonly SourceLocation locus;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
                public readonly SourceLocation semi_colon;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.AliasDeclaration)]
            public readonly struct AliasDeclaration : IHasSort<AliasDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.AliasDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly TextOffset identifier;
                public readonly SyntaxIndex defining_type_id;
                public readonly SourceLocation locus;
                public readonly SourceLocation assign;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ConceptDefinition)]
            public readonly struct ConceptDefinition : IHasSort<ConceptDefinition, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ConceptDefinition;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex parameters;
                public readonly SourceLocation locus;
                public readonly TextOffset identifier;
                public readonly ExprIndex expression;
                public readonly SourceLocation concept_keyword;
                public readonly SourceLocation assign;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.StructuredBindingDeclaration)]
            public readonly struct StructuredBindingDeclaration : IHasSort<StructuredBindingDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.StructuredBindingDeclaration;
                public static SortType Type => SortType.Syntax;

                public enum RefQualifierKind : byte
                {
                    None,
                    Rvalue,
                    Lvalue
                }

                public readonly SourceLocation locus;
                public readonly SourceLocation ref_qualifier;
                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex identifier_list;
                public readonly ExprIndex initializer;
                public readonly RefQualifierKind ref_qualifier_kind;
            }

            [Tag<SyntaxSort>(SyntaxSort.StructuredBindingIdentifier)]
            public readonly struct StructuredBindingIdentifier : IHasSort<StructuredBindingIdentifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.StructuredBindingIdentifier;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex identifier;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.AsmStatement)]
            public readonly struct AsmStatement : IHasSort<AsmStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.AsmStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex tokens;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.ReturnStatement)]
            public readonly struct ReturnStatement : IHasSort<ReturnStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ReturnStatement;
                public static SortType Type => SortType.Syntax;

                public enum ReturnKind : byte
                {
                    Return,
                    Co_return
                }

                public readonly SentenceIndex pragma_tokens;
                public readonly ExprIndex expr;
                public readonly ReturnKind return_kind;
                public readonly SourceLocation return_locus;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.CompoundStatement)]
            public readonly struct CompoundStatement : IHasSort<CompoundStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.CompoundStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex statements;
                public readonly SourceLocation left_curly;
                public readonly SourceLocation right_curly;
            }

            [Tag<SyntaxSort>(SyntaxSort.IfStatement)]
            public readonly struct IfStatement : IHasSort<IfStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.IfStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex init_statement;
                public readonly ExprIndex condition;
                public readonly SyntaxIndex if_true;
                public readonly SyntaxIndex if_false;
                public readonly SourceLocation if_keyword;
                public readonly SourceLocation constexpr_locus;
                public readonly SourceLocation else_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.WhileStatement)]
            public readonly struct WhileStatement : IHasSort<WhileStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.WhileStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly ExprIndex condition;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation while_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.DoWhileStatement)]
            public readonly struct DoWhileStatement : IHasSort<DoWhileStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.DoWhileStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly ExprIndex condition;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation do_keyword;
                public readonly SourceLocation while_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ForStatement)]
            public readonly struct ForStatement : IHasSort<ForStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ForStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex init_statement;
                public readonly ExprIndex condition;
                public readonly ExprIndex expression;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation for_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.InitStatement)]
            public readonly struct InitStatement : IHasSort<InitStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.InitStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex expression_or_declaration;
            }

            [Tag<SyntaxSort>(SyntaxSort.RangeBasedForStatement)]
            public readonly struct RangeBasedForStatement : IHasSort<RangeBasedForStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.RangeBasedForStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex init_statement;
                public readonly SyntaxIndex declaration;
                public readonly ExprIndex initializer;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation for_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
                public readonly SourceLocation colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ForRangeDeclaration)]
            public readonly struct ForRangeDeclaration : IHasSort<ForRangeDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ForRangeDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarator;
            }

            [Tag<SyntaxSort>(SyntaxSort.LabeledStatement)]
            public readonly struct LabeledStatement : IHasSort<LabeledStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.LabeledStatement;
                public static SortType Type => SortType.Syntax;

                public enum Kind : byte
                {
                    None,
                    Case,
                    Default,
                    Label
                }

                public readonly SentenceIndex pragma_tokens;
                public readonly ExprIndex expression;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation locus;
                public readonly SourceLocation colon;
                public readonly Kind kind;
            }

            [Tag<SyntaxSort>(SyntaxSort.BreakStatement)]
            public readonly struct BreakStatement : IHasSort<BreakStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.BreakStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SourceLocation break_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ContinueStatement)]
            public readonly struct ContinueStatement : IHasSort<ContinueStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ContinueStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SourceLocation continue_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.SwitchStatement)]
            public readonly struct SwitchStatement : IHasSort<SwitchStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.SwitchStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex init_statement;
                public readonly ExprIndex condition;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation switch_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.GotoStatement)]
            public readonly struct GotoStatement : IHasSort<GotoStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.GotoStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly TextOffset name;
                public readonly SourceLocation locus;
                public readonly SourceLocation label;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.DeclarationStatement)]
            public readonly struct DeclarationStatement : IHasSort<DeclarationStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.DeclarationStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex declaration;
            }

            [Tag<SyntaxSort>(SyntaxSort.ExpressionStatement)]
            public readonly struct ExpressionStatement : IHasSort<ExpressionStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ExpressionStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly ExprIndex expression;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.TryBlock)]
            public readonly struct TryBlock : IHasSort<TryBlock, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TryBlock;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex statement;
                public readonly SyntaxIndex handler_seq;
                public readonly SourceLocation try_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.Handler)]
            public readonly struct Handler : IHasSort<Handler, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.Handler;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex exception_declaration;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation catch_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.HandlerSeq)]
            public readonly struct HandlerSeq : IHasSort<HandlerSeq, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.HandlerSeq;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex handlers;
            }

            [Tag<SyntaxSort>(SyntaxSort.FunctionTryBlock)]
            public readonly struct FunctionTryBlock : IHasSort<FunctionTryBlock, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.FunctionTryBlock;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex statement;
                public readonly SyntaxIndex handler_seq;
                public readonly SyntaxIndex initializers;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeIdListElement)]
            public readonly struct TypeIdListElement : IHasSort<TypeIdListElement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TypeIdListElement;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex type_id;
                public readonly SourceLocation ellipsis;
            }

            [Tag<SyntaxSort>(SyntaxSort.DynamicExceptionSpec)]
            public readonly struct DynamicExceptionSpec : IHasSort<DynamicExceptionSpec, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.DynamicExceptionSpec;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex type_list;
                public readonly SourceLocation throw_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.StatementSeq)]
            public readonly struct StatementSeq : IHasSort<StatementSeq, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.StatementSeq;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex statements;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemberFunctionDeclaration)]
            public readonly struct MemberFunctionDeclaration : IHasSort<MemberFunctionDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.MemberFunctionDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex definition;
            }

            [Tag<SyntaxSort>(SyntaxSort.FunctionDefinition)]
            public readonly struct FunctionDefinition : IHasSort<FunctionDefinition, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.FunctionDefinition;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarator;
                public readonly SyntaxIndex requires_clause;
                public readonly SyntaxIndex body;
            }

            [Tag<SyntaxSort>(SyntaxSort.FunctionBody)]
            public readonly struct FunctionBody : IHasSort<FunctionBody, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.FunctionBody;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex statements;
                public readonly SyntaxIndex function_try_block;
                public readonly SyntaxIndex initializers;
                public readonly Keyword default_or_delete;
                public readonly SourceLocation assign;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.Expression)]
            public readonly struct Expression : IHasSort<Expression, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.Expression;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateParameterList)]
            public readonly struct TemplateParameterList : IHasSort<TemplateParameterList, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TemplateParameterList;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex parameters;
                public readonly SyntaxIndex requires_clause;
                public readonly SourceLocation left_angle;
                public readonly SourceLocation right_angle;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateDeclaration)]
            public readonly struct TemplateDeclaration : IHasSort<TemplateDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TemplateDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex parameters;
                public readonly SyntaxIndex declaration;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.RequiresClause)]
            public readonly struct RequiresClause : IHasSort<RequiresClause, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.RequiresClause;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.SimpleRequirement)]
            public readonly struct SimpleRequirement : IHasSort<SimpleRequirement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.SimpleRequirement;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeRequirement)]
            public readonly struct TypeRequirement : IHasSort<TypeRequirement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TypeRequirement;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex type;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.CompoundRequirement)]
            public readonly struct CompoundRequirement : IHasSort<CompoundRequirement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.CompoundRequirement;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
                public readonly ExprIndex type_constraint;
                public readonly SourceLocation locus;
                public readonly SourceLocation right_curly;
                public readonly SourceLocation noexcept_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.NestedRequirement)]
            public readonly struct NestedRequirement : IHasSort<NestedRequirement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.NestedRequirement;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.RequirementBody)]
            public readonly struct RequirementBody : IHasSort<RequirementBody, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.RequirementBody;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex requirements;
                public readonly SourceLocation locus;
                public readonly SourceLocation right_curly;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeTemplateParameter)]
            public readonly struct TypeTemplateParameter : IHasSort<TypeTemplateParameter, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TypeTemplateParameter;
                public static SortType Type => SortType.Syntax;

                public readonly TextOffset name;
                public readonly ExprIndex type_constraint;
                public readonly SyntaxIndex default_argument;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateTemplateParameter)]
            public readonly struct TemplateTemplateParameter : IHasSort<TemplateTemplateParameter, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TemplateTemplateParameter;
                public static SortType Type => SortType.Syntax;

                public readonly TextOffset name;
                public readonly SyntaxIndex default_argument;
                public readonly SyntaxIndex parameters;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
                public readonly Keyword type_parameter_key;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeTemplateArgument)]
            public readonly struct TypeTemplateArgument : IHasSort<TypeTemplateArgument, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TypeTemplateArgument;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex argument;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.NonTypeTemplateArgument)]
            public readonly struct NonTypeTemplateArgument : IHasSort<NonTypeTemplateArgument, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.NonTypeTemplateArgument;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex argument;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateArgumentList)]
            public readonly struct TemplateArgumentList : IHasSort<TemplateArgumentList, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TemplateArgumentList;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex arguments;
                public readonly SourceLocation left_angle;
                public readonly SourceLocation right_angle;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateId)]
            public readonly struct TemplateId : IHasSort<TemplateId, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TemplateId;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex name;
                public readonly ExprIndex symbol;
                public readonly SyntaxIndex arguments;
                public readonly SourceLocation locus;
                public readonly SourceLocation template_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemInitializer)]
            public readonly struct MemInitializer : IHasSort<MemInitializer, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.MemInitializer;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex name;
                public readonly ExprIndex initializer;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.CtorInitializer)]
            public readonly struct CtorInitializer : IHasSort<CtorInitializer, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.CtorInitializer;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex initializers;
                public readonly SourceLocation colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.CaptureDefault)]
            public readonly struct CaptureDefault : IHasSort<CaptureDefault, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.CaptureDefault;
                public static SortType Type => SortType.Syntax;

                public readonly SourceLocation locus;
                public readonly SourceLocation comma;
                [MarshalAs(UnmanagedType.U1)]
                public readonly bool default_is_by_reference;
            }

            [Tag<SyntaxSort>(SyntaxSort.SimpleCapture)]
            public readonly struct SimpleCapture : IHasSort<SimpleCapture, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.SimpleCapture;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex name;
                public readonly SourceLocation ampersand;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.InitCapture)]
            public readonly struct InitCapture : IHasSort<InitCapture, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.InitCapture;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex name;
                public readonly ExprIndex initializer;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation ampersand;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.ThisCapture)]
            public readonly struct ThisCapture : IHasSort<ThisCapture, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ThisCapture;
                public static SortType Type => SortType.Syntax;

                public readonly SourceLocation locus;
                public readonly SourceLocation asterisk;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.LambdaIntroducer)]
            public readonly struct LambdaIntroducer : IHasSort<LambdaIntroducer, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.LambdaIntroducer;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex captures;
                public readonly SourceLocation left_bracket;
                public readonly SourceLocation right_bracket;
            }

            [Tag<SyntaxSort>(SyntaxSort.LambdaDeclarator)]
            public readonly struct LambdaDeclarator : IHasSort<LambdaDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.LambdaDeclarator;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex parameters;
                public readonly SyntaxIndex exception_specification;
                public readonly SyntaxIndex trailing_return_type;
                public readonly Keyword keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
                public readonly SourceLocation ellipsis;
            }

            [Tag<SyntaxSort>(SyntaxSort.UsingDeclaration)]
            public readonly struct UsingDeclaration : IHasSort<UsingDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.UsingDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex declarators;
                public readonly SourceLocation using_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.UsingEnumDeclaration)]
            public readonly struct UsingEnumDeclaration : IHasSort<UsingEnumDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.UsingEnumDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex name;
                public readonly SourceLocation using_keyword;
                public readonly SourceLocation enum_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.UsingDeclarator)]
            public readonly struct UsingDeclarator : IHasSort<UsingDeclarator, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.UsingDeclarator;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex qualified_name;
                public readonly SourceLocation typename_keyword;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.UsingDirective)]
            public readonly struct UsingDirective : IHasSort<UsingDirective, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.UsingDirective;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex qualified_name;
                public readonly SourceLocation using_keyword;
                public readonly SourceLocation namespace_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.NamespaceAliasDefinition)]
            public readonly struct NamespaceAliasDefinition : IHasSort<NamespaceAliasDefinition, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.NamespaceAliasDefinition;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex identifier;
                public readonly ExprIndex namespace_name;
                public readonly SourceLocation namespace_keyword;
                public readonly SourceLocation assign;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ArrayIndex)]
            public readonly struct ArrayIndex : IHasSort<ArrayIndex, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.ArrayIndex;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex array;
                public readonly ExprIndex index;
                public readonly SourceLocation left_bracket;
                public readonly SourceLocation right_bracket;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeTraitIntrinsic)]
            public readonly struct TypeTraitIntrinsic : IHasSort<TypeTraitIntrinsic, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.TypeTraitIntrinsic;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex arguments;
                public readonly SourceLocation locus;
                public readonly Operator intrinsic;
            }

            [Tag<SyntaxSort>(SyntaxSort.SEHTry)]
            public readonly struct SEHTry : IHasSort<SEHTry, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.SEHTry;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex statement;
                public readonly SyntaxIndex handler;
                public readonly SourceLocation try_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.SEHExcept)]
            public readonly struct SEHExcept : IHasSort<SEHExcept, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.SEHExcept;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex expression;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation except_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.SEHFinally)]
            public readonly struct SEHFinally : IHasSort<SEHFinally, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.SEHFinally;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex statement;
                public readonly SourceLocation finally_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.SEHLeave)]
            public readonly struct SEHLeave : IHasSort<SEHLeave, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.SEHLeave;
                public static SortType Type => SortType.Syntax;

                public readonly SourceLocation leave_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.Super)]
            public readonly struct Super : IHasSort<Super, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.Super;
                public static SortType Type => SortType.Syntax;

                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.UnaryFoldExpression)]
            public readonly struct UnaryFoldExpression : IHasSort<UnaryFoldExpression, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.UnaryFoldExpression;
                public static SortType Type => SortType.Syntax;

                public readonly FoldKind kind;
                public readonly ExprIndex expression;
                public readonly DyadicOperator op;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation operator_locus;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.BinaryFoldExpression)]
            public readonly struct BinaryFoldExpression : IHasSort<BinaryFoldExpression, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.BinaryFoldExpression;
                public static SortType Type => SortType.Syntax;

                public readonly FoldKind kind;
                public readonly ExprIndex left_expression;
                public readonly ExprIndex right_expression;
                public readonly DyadicOperator op;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation left_operator_locus;
                public readonly SourceLocation right_operator_locus;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.EmptyStatement)]
            public readonly struct EmptyStatement : IHasSort<EmptyStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.EmptyStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributedStatement)]
            public readonly struct AttributedStatement : IHasSort<AttributedStatement, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.AttributedStatement;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex statement;
                public readonly SyntaxIndex attributes;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributedDeclaration)]
            public readonly struct AttributedDeclaration : IHasSort<AttributedDeclaration, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.AttributedDeclaration;
                public static SortType Type => SortType.Syntax;

                public readonly SourceLocation locus;
                public readonly SyntaxIndex declaration;
                public readonly SyntaxIndex attributes;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributeSpecifierSeq)]
            public readonly struct AttributeSpecifierSeq : IHasSort<AttributeSpecifierSeq, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.AttributeSpecifierSeq;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex attributes;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributeSpecifier)]
            public readonly struct AttributeSpecifier : IHasSort<AttributeSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.AttributeSpecifier;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex using_prefix;
                public readonly SyntaxIndex attributes;
                public readonly SourceLocation left_bracket_1;
                public readonly SourceLocation left_bracket_2;
                public readonly SourceLocation right_bracket_1;
                public readonly SourceLocation right_bracket_2;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributeUsingPrefix)]
            public readonly struct AttributeUsingPrefix : IHasSort<AttributeUsingPrefix, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.AttributeUsingPrefix;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex attribute_namespace;
                public readonly SourceLocation using_locus;
                public readonly SourceLocation colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.Attribute)]
            public readonly struct Attribute : IHasSort<Attribute, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.Attribute;
                public static SortType Type => SortType.Syntax;

                public readonly ExprIndex identifier;
                public readonly ExprIndex attribute_namespace;
                public readonly SyntaxIndex argument_clause;
                public readonly SourceLocation double_colon;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributeArgumentClause)]
            public readonly struct AttributeArgumentClause : IHasSort<AttributeArgumentClause, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.AttributeArgumentClause;
                public static SortType Type => SortType.Syntax;

                public readonly SentenceIndex tokens;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.Alignas)]
            public readonly struct AlignasSpecifier : IHasSort<AlignasSpecifier, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.Alignas;
                public static SortType Type => SortType.Syntax;

                public readonly SyntaxIndex expression;
                public readonly SourceLocation locus;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.Tuple)]
            public readonly struct Tuple : IHasSort<Tuple, SyntaxSort>
            {
                public static SyntaxSort Sort => SyntaxSort.Tuple;
                public static SortType Type => SortType.Syntax;

                public readonly Index start;
                public readonly Cardinality cardinality;
            }

            namespace microsoft
            {
                public enum Kind : byte
                {
                    Unknown,
                    Declspec,
                    BuiltinAddressOf,
                    UUIDOfTypeID,
                    UUIDOfExpr,
                    BuiltinHugeValue,
                    BuiltinHugeValuef,
                    BuiltinNan,
                    BuiltinNanf,
                    BuiltinNans,
                    BuiltinNansf,
                    IfExists,
                    Count
                }

                public readonly struct TypeOrExprOperand
                {
                    [StructLayout(LayoutKind.Explicit)]
                    public readonly struct UnnamedUnion1
                    {
                        [FieldOffset(0)]
                        public readonly TypeIndex as_type;
                        [FieldOffset(0)]
                        public readonly ExprIndex as_expr;
                    }

                    private readonly UnnamedUnion1 unnamedUnion1;
                    public TypeIndex as_type => unnamedUnion1.as_type;
                    public ExprIndex as_expr => unnamedUnion1.as_expr;
                }

                public readonly struct Declspec
                {
                    public readonly SourceLocation left_paren;
                    public readonly SourceLocation right_paren;
                    public readonly SentenceIndex tokens;
                }

                public readonly struct BuiltinAddressOf
                {
                    public readonly ExprIndex expr;
                }

                public readonly struct UUIDOf
                {
                    public readonly SourceLocation left_paren;
                    public readonly SourceLocation right_paren;
                    public readonly TypeOrExprOperand operand;
                }

                public readonly struct Intrinsic
                {
                    public readonly SourceLocation left_paren;
                    public readonly SourceLocation right_paren;
                    public readonly ExprIndex argument;
                }

                public readonly struct IfExists
                {
                    public enum Kind : byte
                    {
                        Statement,
                        Initializer,
                        MemberDeclaration
                    }

                    public enum Keyword : byte
                    {
                        IfExists,
                        IfNotExists
                    }

                    public readonly Kind kind;
                    public readonly Keyword keyword;
                    public readonly ExprIndex subject;
                    public readonly SourceLocation left_paren;
                    public readonly SourceLocation right_paren;
                    public readonly SentenceIndex tokens;
                }

                [Tag<SyntaxSort>(SyntaxSort.VendorExtension)]
                public readonly struct VendorSyntax : IHasSort<VendorSyntax, SyntaxSort>
                {
                    public static SyntaxSort Sort => SyntaxSort.VendorExtension;
                    public static SortType Type => SortType.Syntax;

                    [StructLayout(LayoutKind.Explicit)]
                    public readonly struct UnnamedUnion1
                    {
                        [FieldOffset(0)]
                        public readonly Declspec ms_declspec;
                        [FieldOffset(0)]
                        public readonly BuiltinAddressOf ms_builtin_addressof;
                        [FieldOffset(0)]
                        public readonly UUIDOf ms_uuidof;
                        [FieldOffset(0)]
                        public readonly Intrinsic ms_intrinsic;
                        [FieldOffset(0)]
                        public readonly IfExists ms_if_exists;
                    }

                    public readonly Kind kind;
                    public readonly SourceLocation locus;
                    private readonly UnnamedUnion1 unnamedUnion1;
                    public Declspec ms_declspec => unnamedUnion1.ms_declspec;
                    public BuiltinAddressOf ms_builtin_addressof => unnamedUnion1.ms_builtin_addressof;
                    public UUIDOf ms_uuidof => unnamedUnion1.ms_uuidof;
                    public Intrinsic ms_intrinsic => unnamedUnion1.ms_intrinsic;
                    public IfExists ms_if_exists => unnamedUnion1.ms_if_exists;
                }

            }

        }

        namespace microsoft
        {
            public enum PragmaCommentSort : byte
            {
                Unknown,
                Compiler,
                Lib,
                Exestr,
                User,
                Nolib,
                Linker
            }

            [Tag<PragmaSort>(PragmaSort.VendorExtension)]
            public readonly struct PragmaComment : IHasSort<PragmaComment, PragmaSort>
            {
                public static PragmaSort Sort => PragmaSort.VendorExtension;
                public static SortType Type => SortType.Pragma;

                public readonly TextOffset comment_text;
                public readonly PragmaCommentSort sort;
            }

        }

        namespace preprocessing
        {
            [Tag<FormSort>(FormSort.Identifier)]
            public readonly struct IdentifierForm : IHasSort<IdentifierForm, FormSort>
            {
                public static FormSort Sort => FormSort.Identifier;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Number)]
            public readonly struct NumberForm : IHasSort<NumberForm, FormSort>
            {
                public static FormSort Sort => FormSort.Number;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Character)]
            public readonly struct CharacterForm : IHasSort<CharacterForm, FormSort>
            {
                public static FormSort Sort => FormSort.Character;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.String)]
            public readonly struct StringForm : IHasSort<StringForm, FormSort>
            {
                public static FormSort Sort => FormSort.String;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Operator)]
            public readonly struct OperatorForm : IHasSort<OperatorForm, FormSort>
            {
                public static FormSort Sort => FormSort.Operator;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
                public readonly PPOperator value;
            }

            [Tag<FormSort>(FormSort.Keyword)]
            public readonly struct KeywordForm : IHasSort<KeywordForm, FormSort>
            {
                public static FormSort Sort => FormSort.Keyword;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Whitespace)]
            public readonly struct WhitespaceForm : IHasSort<WhitespaceForm, FormSort>
            {
                public static FormSort Sort => FormSort.Whitespace;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
            }

            [Tag<FormSort>(FormSort.Parameter)]
            public readonly struct ParameterForm : IHasSort<ParameterForm, FormSort>
            {
                public static FormSort Sort => FormSort.Parameter;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Stringize)]
            public readonly struct StringizeForm : IHasSort<StringizeForm, FormSort>
            {
                public static FormSort Sort => FormSort.Stringize;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly FormIndex operand;
            }

            [Tag<FormSort>(FormSort.Catenate)]
            public readonly struct CatenateForm : IHasSort<CatenateForm, FormSort>
            {
                public static FormSort Sort => FormSort.Catenate;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly FormIndex first;
                public readonly FormIndex second;
            }

            [Tag<FormSort>(FormSort.Pragma)]
            public readonly struct PragmaForm : IHasSort<PragmaForm, FormSort>
            {
                public static FormSort Sort => FormSort.Pragma;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly FormIndex operand;
            }

            [Tag<FormSort>(FormSort.Header)]
            public readonly struct HeaderForm : IHasSort<HeaderForm, FormSort>
            {
                public static FormSort Sort => FormSort.Header;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Parenthesized)]
            public readonly struct ParenthesizedForm : IHasSort<ParenthesizedForm, FormSort>
            {
                public static FormSort Sort => FormSort.Parenthesized;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly FormIndex operand;
            }

            [Tag<FormSort>(FormSort.Junk)]
            public readonly struct JunkForm : IHasSort<JunkForm, FormSort>
            {
                public static FormSort Sort => FormSort.Junk;
                public static SortType Type => SortType.Form;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Tuple)]
            public readonly struct TupleForm : IHasSort<TupleForm, FormSort>
            {
                public static FormSort Sort => FormSort.Tuple;
                public static SortType Type => SortType.Form;

                public readonly Index start;
                public readonly Cardinality cardinality;
            }

        }

        namespace trait
        {
            public enum MsvcLabelKey : uint
            {
            }

            public enum MsvcLabelType : uint
            {
            }

            public enum MsvcLexicalScopeIndex : uint
            {
            }

            public enum MsvcFileHashSort : byte
            {
                None,
                MD5,
                SHA128,
                SHA256
            }

            [Tag<TraitSort>(TraitSort.MappingExpr)]
            public readonly struct MappingExpr : IHasSort<MappingExpr, TraitSort>
            {
                public static TraitSort Sort => TraitSort.MappingExpr;
                public static SortType Type => SortType.Trait;

                public readonly DeclIndex entity;
                public readonly MappingDefinition trait;
            }

            [Tag<TraitSort>(TraitSort.AliasTemplate)]
            public readonly struct AliasTemplate : IHasSort<AliasTemplate, TraitSort>
            {
                public static TraitSort Sort => TraitSort.AliasTemplate;
                public static SortType Type => SortType.Trait;

                public readonly DeclIndex entity;
                public readonly SyntaxIndex trait;
            }

            [Tag<TraitSort>(TraitSort.Friends)]
            public readonly struct Friends : IHasSort<Friends, TraitSort>
            {
                public static TraitSort Sort => TraitSort.Friends;
                public static SortType Type => SortType.Trait;

                public readonly DeclIndex entity;
                public readonly Sequence<Declaration> trait;
            }

            [Tag<TraitSort>(TraitSort.Specializations)]
            public readonly struct Specializations : IHasSort<Specializations, TraitSort>
            {
                public static TraitSort Sort => TraitSort.Specializations;
                public static SortType Type => SortType.Trait;

                public readonly DeclIndex entity;
                public readonly Sequence<Declaration> trait;
            }

            [Tag<TraitSort>(TraitSort.Requires)]
            public readonly struct Requires : IHasSort<Requires, TraitSort>
            {
                public static TraitSort Sort => TraitSort.Requires;
                public static SortType Type => SortType.Trait;

                public readonly DeclIndex entity;
                public readonly SyntaxIndex trait;
            }

            [Tag<TraitSort>(TraitSort.Attributes)]
            public readonly struct Attributes : IHasSort<Attributes, TraitSort>
            {
                public static TraitSort Sort => TraitSort.Attributes;
                public static SortType Type => SortType.Trait;

                public readonly SyntaxIndex entity;
                public readonly SyntaxIndex trait;
            }

            [Tag<TraitSort>(TraitSort.Deprecated)]
            public readonly struct Deprecated : IHasSort<Deprecated, TraitSort>
            {
                public static TraitSort Sort => TraitSort.Deprecated;
                public static SortType Type => SortType.Trait;

                public readonly DeclIndex entity;
                public readonly TextOffset trait;
            }

            [Tag<TraitSort>(TraitSort.DeductionGuides)]
            public readonly struct DeductionGuides : IHasSort<DeductionGuides, TraitSort>
            {
                public static TraitSort Sort => TraitSort.DeductionGuides;
                public static SortType Type => SortType.Trait;

                public readonly DeclIndex entity;
                public readonly DeclIndex trait;
            }

            public readonly struct LocusSpan
            {
                public readonly SourceLocation begin;
                public readonly SourceLocation end;
            }

            public readonly struct MsvcLabelProperties
            {
                public readonly MsvcLabelKey key;
                public readonly MsvcLabelType type;
            }

            public readonly struct MsvcFileBoundaryProperties
            {
                public readonly LineNumber first;
                public readonly LineNumber last;
            }

            public readonly struct MsvcFileHashData
            {
                public readonly byte_Array32 bytes;
                public readonly MsvcFileHashSort sort;
                public readonly byte_Array3 unused;
            }

            [System.Runtime.CompilerServices.InlineArray(3)]
            public struct byte_Array3
            {
                private byte _element;
            }
            [System.Runtime.CompilerServices.InlineArray(32)]
            public struct byte_Array32
            {
                private byte _element;
            }
            [Tag<MsvcTraitSort>(MsvcTraitSort.Uuid)]
            public readonly struct MsvcUuid : IHasSort<MsvcUuid, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.Uuid;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly StringIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.Segment)]
            public readonly struct MsvcSegment : IHasSort<MsvcSegment, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.Segment;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly DeclIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.SpecializationEncoding)]
            public readonly struct MsvcSpecializationEncoding : IHasSort<MsvcSpecializationEncoding, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.SpecializationEncoding;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly TextOffset trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.SalAnnotation)]
            public readonly struct MsvcSalAnnotation : IHasSort<MsvcSalAnnotation, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.SalAnnotation;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly TextOffset trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.FunctionParameters)]
            public readonly struct MsvcFunctionParameters : IHasSort<MsvcFunctionParameters, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.FunctionParameters;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly ChartIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.InitializerLocus)]
            public readonly struct MsvcInitializerLocus : IHasSort<MsvcInitializerLocus, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.InitializerLocus;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly SourceLocation trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenExpression)]
            public readonly struct MsvcCodegenExpression : IHasSort<MsvcCodegenExpression, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenExpression;
                public static SortType Type => SortType.MsvcTrait;

                public readonly ExprIndex entity;
                public readonly ExprIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.DeclAttributes)]
            public readonly struct DeclAttributes : IHasSort<DeclAttributes, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.DeclAttributes;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly AttrIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.StmtAttributes)]
            public readonly struct StmtAttributes : IHasSort<StmtAttributes, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.StmtAttributes;
                public static SortType Type => SortType.MsvcTrait;

                public readonly StmtIndex entity;
                public readonly AttrIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.Vendor)]
            public readonly struct MsvcVendor : IHasSort<MsvcVendor, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.Vendor;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly VendorTraits trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenMappingExpr)]
            public readonly struct MsvcCodegenMappingExpr : IHasSort<MsvcCodegenMappingExpr, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenMappingExpr;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly MappingDefinition trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.DynamicInitVariable)]
            public readonly struct MsvcDynamicInitVariable : IHasSort<MsvcDynamicInitVariable, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.DynamicInitVariable;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly DeclIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenLabelProperties)]
            public readonly struct MsvcCodegenLabelProperties : IHasSort<MsvcCodegenLabelProperties, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenLabelProperties;
                public static SortType Type => SortType.MsvcTrait;

                public readonly ExprIndex entity;
                public readonly MsvcLabelProperties trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenSwitchType)]
            public readonly struct MsvcCodegenSwitchType : IHasSort<MsvcCodegenSwitchType, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenSwitchType;
                public static SortType Type => SortType.MsvcTrait;

                public readonly StmtIndex entity;
                public readonly TypeIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenDoWhileStmt)]
            public readonly struct MsvcCodegenDoWhileStmt : IHasSort<MsvcCodegenDoWhileStmt, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenDoWhileStmt;
                public static SortType Type => SortType.MsvcTrait;

                public readonly StmtIndex entity;
                public readonly StmtIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.LexicalScopeIndex)]
            public readonly struct MsvcLexicalScopeIndices : IHasSort<MsvcLexicalScopeIndices, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.LexicalScopeIndex;
                public static SortType Type => SortType.MsvcTrait;

                public readonly DeclIndex entity;
                public readonly MsvcLexicalScopeIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.FileBoundary)]
            public readonly struct MsvcFileBoundary : IHasSort<MsvcFileBoundary, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.FileBoundary;
                public static SortType Type => SortType.MsvcTrait;

                public readonly NameIndex entity;
                public readonly MsvcFileBoundaryProperties trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.HeaderUnitSourceFile)]
            public readonly struct MsvcHeaderUnitSourceFile : IHasSort<MsvcHeaderUnitSourceFile, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.HeaderUnitSourceFile;
                public static SortType Type => SortType.MsvcTrait;

                public readonly TextOffset entity;
                public readonly NameIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.FileHash)]
            public readonly struct MsvcFileHash : IHasSort<MsvcFileHash, MsvcTraitSort>
            {
                public static MsvcTraitSort Sort => MsvcTraitSort.FileHash;
                public static SortType Type => SortType.MsvcTrait;

                public readonly NameIndex entity;
                public readonly MsvcFileHashData trait;
            }

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
        public enum SortKind : ushort
        {
            Expr,
            Decl,
            Type,
            Name,
            Scope,
            Sentence,
            Chart,
            Syntax,
            Stmt
        }

    }

}

