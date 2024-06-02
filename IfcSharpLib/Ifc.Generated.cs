// hash: ed905d602b318b70228cb079b06afbd4621c21dad90c8d0c09604c8ba208aa2f

using System.Runtime.InteropServices;

#pragma warning disable CS0649 // Field '...' is never assigned to, and will always have its default value 0

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

    [Flags]
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

    [Flags]
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

    [Flags]
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

    [Flags]
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

    [Flags]
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

    [Flags]
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

    [Flags]
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

    [Flags]
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

    [Flags]
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

    public readonly record struct FormatVersion
    {
        public readonly Version major;
        public readonly Version minor;
    }

    public readonly record struct SHA256Hash
    {
        public readonly uint_Array8 value;
    }

    [System.Runtime.CompilerServices.InlineArray(8)]
    public struct uint_Array8
    {
        private uint _element;
    }
    [Over<UnitSort>]
    public readonly record struct UnitIndex : IOver<UnitSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 3);
        public UnitSort Sort => (UnitSort)(IndexAndSort & 0b111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Unit;
        public override int GetHashCode() => (int)IndexAndSort;

        public UnitIndex(UnitSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 3);
        }

        public static UnitIndex Create(UnitSort sort, Index index) => new(sort, index);
    }

    public readonly record struct Header
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

    public readonly record struct PartitionSummaryData
    {
        public readonly TextOffset name;
        public readonly ByteOffset offset;
        public readonly Cardinality cardinality;
        public readonly EntitySize entry_size;
    }

    public readonly record struct IntegrityCheckFailed
    {
        public readonly SHA256Hash expected;
        public readonly SHA256Hash actual;
    }

    public readonly record struct UnsupportedFormatVersion
    {
        public readonly FormatVersion version;
    }

    public readonly record struct PPOperator
    {
        public enum Index : ushort
        {
        }

        private readonly ushort tag_bitfield;
        // ushort value (bitfield continuation)
        public ushort tag => (ushort)((tag_bitfield >> 0) & 0b111);
        public ushort value => (ushort)((tag_bitfield >> 3) & 0b1111111111111);
    }

    public readonly record struct Operator
    {
        public enum Index : ushort
        {
        }

        private readonly ushort tag_bitfield;
        // ushort value (bitfield continuation)
        public ushort tag => (ushort)((tag_bitfield >> 0) & 0b1111);
        public ushort value => (ushort)((tag_bitfield >> 4) & 0b111111111111);
    }

    [Over<FormSort>]
    public readonly record struct FormIndex : IOver<FormSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 4);
        public FormSort Sort => (FormSort)(IndexAndSort & 0b1111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Form;
        public override int GetHashCode() => (int)IndexAndSort;

        public FormIndex(FormSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 4);
        }

        public static FormIndex Create(FormSort sort, Index index) => new(sort, index);
    }

    [Over<StringSort>]
    public readonly record struct StringIndex : IOver<StringSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 3);
        public StringSort Sort => (StringSort)(IndexAndSort & 0b111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.String;
        public override int GetHashCode() => (int)IndexAndSort;

        public StringIndex(StringSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 3);
        }

        public static StringIndex Create(StringSort sort, Index index) => new(sort, index);
    }

    [Over<NameSort>]
    public readonly record struct NameIndex : IOver<NameSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 3);
        public NameSort Sort => (NameSort)(IndexAndSort & 0b111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Name;
        public override int GetHashCode() => (int)IndexAndSort;

        public NameIndex(NameSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 3);
        }

        public static NameIndex Create(NameSort sort, Index index) => new(sort, index);
    }

    [Over<ChartSort>]
    public readonly record struct ChartIndex : IOver<ChartSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 2);
        public ChartSort Sort => (ChartSort)(IndexAndSort & 0b11);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Chart;
        public override int GetHashCode() => (int)IndexAndSort;

        public ChartIndex(ChartSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 2);
        }

        public static ChartIndex Create(ChartSort sort, Index index) => new(sort, index);
    }

    [Over<DeclSort>]
    public readonly record struct DeclIndex : IOver<DeclSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 5);
        public DeclSort Sort => (DeclSort)(IndexAndSort & 0b11111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Decl;
        public override int GetHashCode() => (int)IndexAndSort;

        public DeclIndex(DeclSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 5);
        }

        public static DeclIndex Create(DeclSort sort, Index index) => new(sort, index);
    }

    [Over<TypeSort>]
    public readonly record struct TypeIndex : IOver<TypeSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 5);
        public TypeSort Sort => (TypeSort)(IndexAndSort & 0b11111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Type;
        public override int GetHashCode() => (int)IndexAndSort;

        public TypeIndex(TypeSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 5);
        }

        public static TypeIndex Create(TypeSort sort, Index index) => new(sort, index);
    }

    [Over<SyntaxSort>]
    public readonly record struct SyntaxIndex : IOver<SyntaxSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 7);
        public SyntaxSort Sort => (SyntaxSort)(IndexAndSort & 0b1111111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Syntax;
        public override int GetHashCode() => (int)IndexAndSort;

        public SyntaxIndex(SyntaxSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 7);
        }

        public static SyntaxIndex Create(SyntaxSort sort, Index index) => new(sort, index);
    }

    [Over<LiteralSort>]
    public readonly record struct LitIndex : IOver<LiteralSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 2);
        public LiteralSort Sort => (LiteralSort)(IndexAndSort & 0b11);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Literal;
        public override int GetHashCode() => (int)IndexAndSort;

        public LitIndex(LiteralSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 2);
        }

        public static LitIndex Create(LiteralSort sort, Index index) => new(sort, index);
    }

    [Over<StmtSort>]
    public readonly record struct StmtIndex : IOver<StmtSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 5);
        public StmtSort Sort => (StmtSort)(IndexAndSort & 0b11111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Stmt;
        public override int GetHashCode() => (int)IndexAndSort;

        public StmtIndex(StmtSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 5);
        }

        public static StmtIndex Create(StmtSort sort, Index index) => new(sort, index);
    }

    [Over<ExprSort>]
    public readonly record struct ExprIndex : IOver<ExprSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 6);
        public ExprSort Sort => (ExprSort)(IndexAndSort & 0b111111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Expr;
        public override int GetHashCode() => (int)IndexAndSort;

        public ExprIndex(ExprSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 6);
        }

        public static ExprIndex Create(ExprSort sort, Index index) => new(sort, index);
    }

    [Over<MacroSort>]
    public readonly record struct MacroIndex : IOver<MacroSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 1);
        public MacroSort Sort => (MacroSort)(IndexAndSort & 0b1);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Macro;
        public override int GetHashCode() => (int)IndexAndSort;

        public MacroIndex(MacroSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 1);
        }

        public static MacroIndex Create(MacroSort sort, Index index) => new(sort, index);
    }

    [Over<PragmaSort>]
    public readonly record struct PragmaIndex : IOver<PragmaSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 1);
        public PragmaSort Sort => (PragmaSort)(IndexAndSort & 0b1);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Pragma;
        public override int GetHashCode() => (int)IndexAndSort;

        public PragmaIndex(PragmaSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 1);
        }

        public static PragmaIndex Create(PragmaSort sort, Index index) => new(sort, index);
    }

    [Over<AttrSort>]
    public readonly record struct AttrIndex : IOver<AttrSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 4);
        public AttrSort Sort => (AttrSort)(IndexAndSort & 0b1111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Attr;
        public override int GetHashCode() => (int)IndexAndSort;

        public AttrIndex(AttrSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 4);
        }

        public static AttrIndex Create(AttrSort sort, Index index) => new(sort, index);
    }

    [Over<DirSort>]
    public readonly record struct DirIndex : IOver<DirSort>
    {
        private readonly uint IndexAndSort;
        public Index Index => (Index)(IndexAndSort >> 5);
        public DirSort Sort => (DirSort)(IndexAndSort & 0b11111);
        public bool IsNull => IndexAndSort == 0;
        public static SortType Type => SortType.Dir;
        public override int GetHashCode() => (int)IndexAndSort;

        public DirIndex(DirSort sort, Index index)
        {
            IndexAndSort = (uint)sort | ((uint)index << 5);
        }

        public static DirIndex Create(DirSort sort, Index index) => new(sort, index);
    }

    public readonly record struct TraitOrdering
    {
    }

    public record struct TableOfContents
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

        [Flags]
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

        public readonly record struct Declaration
        {
            public readonly DeclIndex index;
        }

        [Tag<NameSort>(NameSort.Conversion)]
        public readonly record struct ConversionFunctionId : ITag<ConversionFunctionId, NameSort>
        {
            public static SortType Type => SortType.Name;
            public static NameSort Sort => NameSort.Conversion;

            public readonly TypeIndex target;
            public readonly TextOffset name;
        }

        [Tag<NameSort>(NameSort.Operator)]
        public readonly record struct OperatorFunctionId : ITag<OperatorFunctionId, NameSort>
        {
            public static SortType Type => SortType.Name;
            public static NameSort Sort => NameSort.Operator;

            public readonly TextOffset name;
            public readonly Operator symbol;
        }

        [Tag<NameSort>(NameSort.Literal)]
        public readonly record struct LiteralOperatorId : ITag<LiteralOperatorId, NameSort>
        {
            public static SortType Type => SortType.Name;
            public static NameSort Sort => NameSort.Literal;

            public readonly TextOffset name_index;
        }

        [Tag<NameSort>(NameSort.Template)]
        public readonly record struct TemplateName : ITag<TemplateName, NameSort>
        {
            public static SortType Type => SortType.Name;
            public static NameSort Sort => NameSort.Template;

            public readonly NameIndex name;
        }

        [Tag<NameSort>(NameSort.Specialization)]
        public readonly record struct SpecializationName : ITag<SpecializationName, NameSort>
        {
            public static SortType Type => SortType.Name;
            public static NameSort Sort => NameSort.Specialization;

            public readonly NameIndex primary_template;
            public readonly ExprIndex arguments;
        }

        [Tag<NameSort>(NameSort.SourceFile)]
        public readonly record struct SourceFileName : ITag<SourceFileName, NameSort>
        {
            public static SortType Type => SortType.Name;
            public static NameSort Sort => NameSort.SourceFile;

            public readonly TextOffset name;
            public readonly TextOffset include_guard;
        }

        [Tag<NameSort>(NameSort.Guide)]
        public readonly record struct GuideName : ITag<GuideName, NameSort>
        {
            public static SortType Type => SortType.Name;
            public static NameSort Sort => NameSort.Guide;

            public readonly DeclIndex primary_template;
        }

        public readonly record struct ModuleReference
        {
            public readonly TextOffset owner;
            public readonly TextOffset partition;
        }

        public readonly record struct SourceLocation
        {
            public readonly LineIndex line;
            public readonly ColumnNumber column;
        }

        public readonly record struct Word
        {
            [StructLayout(LayoutKind.Explicit)]
            public readonly record struct UnnamedUnion1
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
            public readonly record struct UnnamedUnion2
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

        public readonly record struct WordSequence
        {
            public readonly Index start;
            public readonly Cardinality cardinality;
            public readonly SourceLocation locus;
        }

        public readonly record struct NoexceptSpecification
        {
            public readonly SentenceIndex words;
            public readonly NoexceptSort sort;
        }

        [Tag<TypeSort>(TypeSort.Fundamental)]
        public readonly record struct FundamentalType : ITag<FundamentalType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Fundamental;

            public readonly TypeBasis basis;
            public readonly TypePrecision precision;
            public readonly TypeSign sign;
            public readonly byte unused;
        }

        [Tag<TypeSort>(TypeSort.Designated)]
        public readonly record struct DesignatedType : ITag<DesignatedType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Designated;

            public readonly DeclIndex decl;
        }

        [Tag<TypeSort>(TypeSort.Tor)]
        public readonly record struct TorType : ITag<TorType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Tor;

            public readonly TypeIndex source;
            public readonly NoexceptSpecification eh_spec;
            public readonly CallingConvention convention;
        }

        [Tag<TypeSort>(TypeSort.Syntactic)]
        public readonly record struct SyntacticType : ITag<SyntacticType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Syntactic;

            public readonly ExprIndex expr;
        }

        [Tag<TypeSort>(TypeSort.Expansion)]
        public readonly record struct ExpansionType : ITag<ExpansionType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Expansion;

            public readonly TypeIndex pack;
            public readonly ExpansionMode mode;
        }

        [Tag<TypeSort>(TypeSort.Pointer)]
        public readonly record struct PointerType : ITag<PointerType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Pointer;

            public readonly TypeIndex pointee;
        }

        [Tag<TypeSort>(TypeSort.LvalueReference)]
        public readonly record struct LvalueReferenceType : ITag<LvalueReferenceType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.LvalueReference;

            public readonly TypeIndex referee;
        }

        [Tag<TypeSort>(TypeSort.RvalueReference)]
        public readonly record struct RvalueReferenceType : ITag<RvalueReferenceType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.RvalueReference;

            public readonly TypeIndex referee;
        }

        [Tag<TypeSort>(TypeSort.Unaligned)]
        public readonly record struct UnalignedType : ITag<UnalignedType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Unaligned;

            public readonly TypeIndex operand;
        }

        [Tag<TypeSort>(TypeSort.Decltype)]
        public readonly record struct DecltypeType : ITag<DecltypeType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Decltype;

            public readonly SyntaxIndex expression;
        }

        [Tag<TypeSort>(TypeSort.Placeholder)]
        public readonly record struct PlaceholderType : ITag<PlaceholderType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Placeholder;

            public readonly ExprIndex constraint;
            public readonly TypeBasis basis;
            public readonly TypeIndex elaboration;
        }

        [Tag<TypeSort>(TypeSort.PointerToMember)]
        public readonly record struct PointerToMemberType : ITag<PointerToMemberType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.PointerToMember;

            public readonly TypeIndex scope;
            public readonly TypeIndex type;
        }

        [Tag<TypeSort>(TypeSort.Tuple)]
        public readonly record struct TupleType : ITag<TupleType, TypeSort>, ITaggedSequence<TupleType, TypeIndex, HeapSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Tuple;
            public static SortType SequenceType => SortType.Heap;
            public static HeapSort SequenceSort => HeapSort.Type;
            public Sequence<TypeIndex> Sequence => new(start, cardinality);
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<TypeSort>(TypeSort.Forall)]
        public readonly record struct ForallType : ITag<ForallType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Forall;

            public readonly ChartIndex chart;
            public readonly TypeIndex subject;
        }

        [Tag<TypeSort>(TypeSort.Function)]
        public readonly record struct FunctionType : ITag<FunctionType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Function;

            public readonly TypeIndex target;
            public readonly TypeIndex source;
            public readonly NoexceptSpecification eh_spec;
            public readonly CallingConvention convention;
            public readonly FunctionTypeTraits traits;
        }

        [Tag<TypeSort>(TypeSort.Method)]
        public readonly record struct MethodType : ITag<MethodType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Method;

            public readonly TypeIndex target;
            public readonly TypeIndex source;
            public readonly TypeIndex class_type;
            public readonly NoexceptSpecification eh_spec;
            public readonly CallingConvention convention;
            public readonly FunctionTypeTraits traits;
        }

        [Tag<TypeSort>(TypeSort.Array)]
        public readonly record struct ArrayType : ITag<ArrayType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Array;

            public readonly TypeIndex element;
            public readonly ExprIndex bound;
        }

        [Tag<TypeSort>(TypeSort.Qualified)]
        public readonly record struct QualifiedType : ITag<QualifiedType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Qualified;

            public readonly TypeIndex unqualified_type;
            public readonly Qualifier qualifiers;
        }

        [Tag<TypeSort>(TypeSort.Typename)]
        public readonly record struct TypenameType : ITag<TypenameType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Typename;

            public readonly ExprIndex path;
        }

        [Tag<TypeSort>(TypeSort.Base)]
        public readonly record struct BaseType : ITag<BaseType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.Base;

            public readonly TypeIndex type;
            public readonly Access access;
            public readonly BaseClassTraits traits;
        }

        [Tag<TypeSort>(TypeSort.SyntaxTree)]
        public readonly record struct SyntaxTreeType : ITag<SyntaxTreeType, TypeSort>
        {
            public static SortType Type => SortType.Type;
            public static TypeSort Sort => TypeSort.SyntaxTree;

            public readonly SyntaxIndex syntax;
        }

        public readonly record struct FileAndLine
        {
            public readonly NameIndex file;
            public readonly LineNumber line;
        }

        public readonly record struct ParameterizedEntity
        {
            public readonly DeclIndex decl;
            public readonly SentenceIndex head;
            public readonly SentenceIndex body;
            public readonly SentenceIndex attributes;
        }

        public readonly record struct SpecializationForm
        {
            public readonly DeclIndex template_decl;
            public readonly ExprIndex arguments;
        }

        public readonly record struct MappingDefinition
        {
            public readonly ChartIndex parameters;
            public readonly ExprIndex initializers;
            public readonly StmtIndex body;
        }

        [Tag<DeclSort>(DeclSort.Function)]
        public readonly record struct FunctionDecl : ITag<FunctionDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Function;

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
        public readonly record struct IntrinsicDecl : ITag<IntrinsicDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Intrinsic;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly FunctionTraits traits;
        }

        [Tag<DeclSort>(DeclSort.Enumerator)]
        public readonly record struct EnumeratorDecl : ITag<EnumeratorDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Enumerator;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly ExprIndex initializer;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
        }

        [Tag<DeclSort>(DeclSort.Parameter)]
        public readonly record struct ParameterDecl : ITag<ParameterDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Parameter;

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
        public readonly record struct VariableDecl : ITag<VariableDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Variable;

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
        public readonly record struct FieldDecl : ITag<FieldDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Field;

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
        public readonly record struct BitfieldDecl : ITag<BitfieldDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Bitfield;

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
        public readonly record struct ScopeDecl : ITag<ScopeDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Scope;

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
        public readonly record struct EnumerationDecl : ITag<EnumerationDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Enumeration;

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
        public readonly record struct AliasDecl : ITag<AliasDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Alias;

            public readonly Identity<TextOffset> identity;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly TypeIndex aliasee;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
        }

        [Tag<DeclSort>(DeclSort.Temploid)]
        public readonly record struct TemploidDecl : ITag<TemploidDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Temploid;

            public readonly ParameterizedEntity ParameterizedEntity;
            public readonly ChartIndex chart;
            public readonly ReachableProperties properties;
        }

        public readonly record struct Template
        {
            public readonly Identity<NameIndex> identity;
            public readonly DeclIndex home_scope;
            public readonly ChartIndex chart;
            public readonly ParameterizedEntity entity;
        }

        [Tag<DeclSort>(DeclSort.Template)]
        public readonly record struct TemplateDecl : ITag<TemplateDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Template;

            public readonly Template Template;
            public readonly TypeIndex type;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.PartialSpecialization)]
        public readonly record struct PartialSpecializationDecl : ITag<PartialSpecializationDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.PartialSpecialization;

            public readonly Template Template;
            public readonly SpecFormIndex specialization_form;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Specialization)]
        public readonly record struct SpecializationDecl : ITag<SpecializationDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Specialization;

            public readonly SpecFormIndex specialization_form;
            public readonly DeclIndex decl;
            public readonly SpecializationSort sort;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.DefaultArgument)]
        public readonly record struct DefaultArgumentDecl : ITag<DefaultArgumentDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.DefaultArgument;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex home_scope;
            public readonly ExprIndex initializer;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
            public readonly ReachableProperties properties;
        }

        [Tag<DeclSort>(DeclSort.Concept)]
        public readonly record struct ConceptDecl : ITag<ConceptDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Concept;

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
        public readonly record struct NonStaticMemberFunctionDecl : ITag<NonStaticMemberFunctionDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Method;

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
        public readonly record struct ConstructorDecl : ITag<ConstructorDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Constructor;

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
        public readonly record struct InheritedConstructorDecl : ITag<InheritedConstructorDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.InheritedConstructor;

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
        public readonly record struct DestructorDecl : ITag<DestructorDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Destructor;

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
        public readonly record struct DeductionGuideDecl : ITag<DeductionGuideDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.DeductionGuide;

            public readonly Identity<NameIndex> identity;
            public readonly DeclIndex home_scope;
            public readonly ChartIndex source;
            public readonly ExprIndex target;
            public readonly GuideTraits traits;
            public readonly BasicSpecifiers basic_spec;
        }

        [Tag<DeclSort>(DeclSort.Barren)]
        public readonly record struct BarrenDecl : ITag<BarrenDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Barren;

            public readonly DirIndex directive;
            public readonly BasicSpecifiers basic_spec;
            public readonly Access access;
        }

        [Tag<DeclSort>(DeclSort.Reference)]
        public readonly record struct ReferenceDecl : ITag<ReferenceDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Reference;

            public readonly ModuleReference translation_unit;
            public readonly DeclIndex local_index;
        }

        [Tag<DeclSort>(DeclSort.Property)]
        public readonly record struct PropertyDecl : ITag<PropertyDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Property;

            public readonly DeclIndex data_member;
            public readonly TextOffset get_method_name;
            public readonly TextOffset set_method_name;
        }

        [Tag<DeclSort>(DeclSort.OutputSegment)]
        public readonly record struct SegmentDecl : ITag<SegmentDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.OutputSegment;

            public readonly TextOffset name;
            public readonly TextOffset class_id;
            public readonly SegmentTraits seg_spec;
            public readonly SegmentType type;
        }

        [Tag<DeclSort>(DeclSort.Using)]
        public readonly record struct UsingDecl : ITag<UsingDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Using;

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
        public readonly record struct FriendDecl : ITag<FriendDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Friend;

            public readonly ExprIndex index;
        }

        [Tag<DeclSort>(DeclSort.Expansion)]
        public readonly record struct ExpansionDecl : ITag<ExpansionDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Expansion;

            public readonly SourceLocation locus;
            public readonly DeclIndex operand;
        }

        [Tag<DeclSort>(DeclSort.SyntaxTree)]
        public readonly record struct SyntacticDecl : ITag<SyntacticDecl, DeclSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.SyntaxTree;

            public readonly SyntaxIndex index;
        }

        [Tag<DeclSort>(DeclSort.Tuple)]
        public readonly record struct TupleDecl : ITag<TupleDecl, DeclSort>, ITaggedSequence<TupleDecl, DeclIndex, HeapSort>
        {
            public static SortType Type => SortType.Decl;
            public static DeclSort Sort => DeclSort.Tuple;
            public static SortType SequenceType => SortType.Heap;
            public static HeapSort SequenceSort => HeapSort.Decl;
            public Sequence<DeclIndex> Sequence => new(start, cardinality);
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        public readonly record struct Scope : ISequence<Declaration>
        {
            public Sequence<Declaration> Sequence => new(start, cardinality);
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<ChartSort>(ChartSort.Unilevel)]
        public readonly record struct UnilevelChart : ITag<UnilevelChart, ChartSort>, ISequence<ParameterDecl>
        {
            public static SortType Type => SortType.Chart;
            public static ChartSort Sort => ChartSort.Unilevel;
            public Sequence<ParameterDecl> Sequence => new(start, cardinality);
            public readonly Index start;
            public readonly Cardinality cardinality;
            public readonly ExprIndex requires_clause;
        }

        [Tag<ChartSort>(ChartSort.Multilevel)]
        public readonly record struct MultiChart : ITag<MultiChart, ChartSort>, ITaggedSequence<MultiChart, ChartIndex, HeapSort>
        {
            public static SortType Type => SortType.Chart;
            public static ChartSort Sort => ChartSort.Multilevel;
            public static SortType SequenceType => SortType.Heap;
            public static HeapSort SequenceSort => HeapSort.Chart;
            public Sequence<ChartIndex> Sequence => new(start, cardinality);
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<StmtSort>(StmtSort.Block)]
        public readonly record struct BlockStmt : ITag<BlockStmt, StmtSort>, ITaggedSequence<BlockStmt, StmtIndex, HeapSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Block;
            public static SortType SequenceType => SortType.Heap;
            public static HeapSort SequenceSort => HeapSort.Stmt;
            public Sequence<StmtIndex> Sequence => new(start, cardinality);
            public readonly SourceLocation locus;
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<StmtSort>(StmtSort.Try)]
        public readonly record struct TryStmt : ITag<TryStmt, StmtSort>, ITaggedSequence<TryStmt, StmtIndex, HeapSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Try;
            public static SortType SequenceType => SortType.Heap;
            public static HeapSort SequenceSort => HeapSort.Stmt;
            public Sequence<StmtIndex> Sequence => new(start, cardinality);
            public readonly SourceLocation locus;
            public readonly Index start;
            public readonly Cardinality cardinality;
            public readonly StmtIndex handlers;
        }

        [Tag<StmtSort>(StmtSort.Expression)]
        public readonly record struct ExpressionStmt : ITag<ExpressionStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Expression;

            public readonly SourceLocation locus;
            public readonly ExprIndex expr;
        }

        [Tag<StmtSort>(StmtSort.If)]
        public readonly record struct IfStmt : ITag<IfStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.If;

            public readonly SourceLocation locus;
            public readonly StmtIndex init;
            public readonly StmtIndex condition;
            public readonly StmtIndex consequence;
            public readonly StmtIndex alternative;
        }

        [Tag<StmtSort>(StmtSort.While)]
        public readonly record struct WhileStmt : ITag<WhileStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.While;

            public readonly SourceLocation locus;
            public readonly StmtIndex condition;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.DoWhile)]
        public readonly record struct DoWhileStmt : ITag<DoWhileStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.DoWhile;

            public readonly SourceLocation locus;
            public readonly ExprIndex condition;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.For)]
        public readonly record struct ForStmt : ITag<ForStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.For;

            public readonly SourceLocation locus;
            public readonly StmtIndex init;
            public readonly StmtIndex condition;
            public readonly StmtIndex increment;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.Break)]
        public readonly record struct BreakStmt : ITag<BreakStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Break;

            public readonly SourceLocation locus;
        }

        [Tag<StmtSort>(StmtSort.Continue)]
        public readonly record struct ContinueStmt : ITag<ContinueStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Continue;

            public readonly SourceLocation locus;
        }

        [Tag<StmtSort>(StmtSort.Goto)]
        public readonly record struct GotoStmt : ITag<GotoStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Goto;

            public readonly SourceLocation locus;
            public readonly ExprIndex target;
        }

        [Tag<StmtSort>(StmtSort.Switch)]
        public readonly record struct SwitchStmt : ITag<SwitchStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Switch;

            public readonly SourceLocation locus;
            public readonly StmtIndex init;
            public readonly ExprIndex control;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.Labeled)]
        public readonly record struct LabeledStmt : ITag<LabeledStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Labeled;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex label;
            public readonly StmtIndex statement;
        }

        [Tag<StmtSort>(StmtSort.Decl)]
        public readonly record struct DeclStmt : ITag<DeclStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Decl;

            public readonly SourceLocation locus;
            public readonly DeclIndex decl;
        }

        [Tag<StmtSort>(StmtSort.Return)]
        public readonly record struct ReturnStmt : ITag<ReturnStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Return;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex expr;
            public readonly TypeIndex function_type;
        }

        [Tag<StmtSort>(StmtSort.Handler)]
        public readonly record struct HandlerStmt : ITag<HandlerStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Handler;

            public readonly SourceLocation locus;
            public readonly DeclIndex exception;
            public readonly StmtIndex body;
        }

        [Tag<StmtSort>(StmtSort.Expansion)]
        public readonly record struct ExpansionStmt : ITag<ExpansionStmt, StmtSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Expansion;

            public readonly SourceLocation locus;
            public readonly StmtIndex operand;
        }

        [Tag<StmtSort>(StmtSort.Tuple)]
        public readonly record struct TupleStmt : ITag<TupleStmt, StmtSort>, ITaggedSequence<TupleStmt, StmtIndex, HeapSort>
        {
            public static SortType Type => SortType.Stmt;
            public static StmtSort Sort => StmtSort.Tuple;
            public static SortType SequenceType => SortType.Heap;
            public static HeapSort SequenceSort => HeapSort.Stmt;
            public Sequence<StmtIndex> Sequence => new(start, cardinality);
            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        public readonly record struct StringLiteral
        {
            public readonly TextOffset start;
            public readonly Cardinality size;
            public readonly TextOffset suffix;
        }

        [Tag<ExprSort>(ExprSort.Type)]
        public readonly record struct TypeExpr : ITag<TypeExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Type;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex denotation;
        }

        [Tag<ExprSort>(ExprSort.String)]
        public readonly record struct StringExpr : ITag<StringExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.String;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly StringIndex @string;
        }

        [Tag<ExprSort>(ExprSort.FunctionString)]
        public readonly record struct FunctionStringExpr : ITag<FunctionStringExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.FunctionString;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TextOffset macro;
        }

        [Tag<ExprSort>(ExprSort.CompoundString)]
        public readonly record struct CompoundStringExpr : ITag<CompoundStringExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.CompoundString;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TextOffset prefix;
            public readonly ExprIndex @string;
        }

        [Tag<ExprSort>(ExprSort.StringSequence)]
        public readonly record struct StringSequenceExpr : ITag<StringSequenceExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.StringSequence;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex strings;
        }

        [Tag<ExprSort>(ExprSort.UnresolvedId)]
        public readonly record struct UnresolvedIdExpr : ITag<UnresolvedIdExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.UnresolvedId;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly NameIndex name;
        }

        [Tag<ExprSort>(ExprSort.TemplateId)]
        public readonly record struct TemplateIdExpr : ITag<TemplateIdExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.TemplateId;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex primary_template;
            public readonly ExprIndex arguments;
        }

        [Tag<ExprSort>(ExprSort.TemplateReference)]
        public readonly record struct TemplateReferenceExpr : ITag<TemplateReferenceExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.TemplateReference;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex member;
            public readonly NameIndex member_name;
            public readonly TypeIndex parent;
            public readonly ExprIndex template_arguments;
        }

        [Tag<ExprSort>(ExprSort.NamedDecl)]
        public readonly record struct NamedDeclExpr : ITag<NamedDeclExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.NamedDecl;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex decl;
        }

        [Tag<ExprSort>(ExprSort.Literal)]
        public readonly record struct LiteralExpr : ITag<LiteralExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Literal;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly LitIndex value;
        }

        [Tag<ExprSort>(ExprSort.Empty)]
        public readonly record struct EmptyExpr : ITag<EmptyExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Empty;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
        }

        [Tag<ExprSort>(ExprSort.Path)]
        public readonly record struct PathExpr : ITag<PathExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Path;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex scope;
            public readonly ExprIndex member;
        }

        [Tag<ExprSort>(ExprSort.Read)]
        public readonly record struct ReadExpr : ITag<ReadExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Read;

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
        public readonly record struct MonadicExpr : ITag<MonadicExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Monad;

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
        public readonly record struct DyadicExpr : ITag<DyadicExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Dyad;

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
        public readonly record struct TriadicExpr : ITag<TriadicExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Triad;

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
        public readonly record struct HierarchyConversionExpr : ITag<HierarchyConversionExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.HierarchyConversion;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex source;
            public readonly TypeIndex target;
            public readonly ExprIndex inheritance_path;
            public readonly ExprIndex override_inheritance_path;
            public readonly DyadicOperator assort;
        }

        [Tag<ExprSort>(ExprSort.DestructorCall)]
        public readonly record struct DestructorCallExpr : ITag<DestructorCallExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.DestructorCall;

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
        public readonly record struct TupleExpr : ITag<TupleExpr, ExprSort>, ITaggedSequence<TupleExpr, ExprIndex, HeapSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Tuple;
            public static SortType SequenceType => SortType.Heap;
            public static HeapSort SequenceSort => HeapSort.Expr;
            public Sequence<ExprIndex> Sequence => new(start, cardinality);
            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<ExprSort>(ExprSort.Placeholder)]
        public readonly record struct PlaceholderExpr : ITag<PlaceholderExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Placeholder;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
        }

        [Tag<ExprSort>(ExprSort.Expansion)]
        public readonly record struct ExpansionExpr : ITag<ExpansionExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Expansion;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex operand;
        }

        [Tag<ExprSort>(ExprSort.Tokens)]
        public readonly record struct TokenExpr : ITag<TokenExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Tokens;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly SentenceIndex tokens;
        }

        [Tag<ExprSort>(ExprSort.Call)]
        public readonly record struct CallExpr : ITag<CallExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Call;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex function;
            public readonly ExprIndex arguments;
        }

        [Tag<ExprSort>(ExprSort.Temporary)]
        public readonly record struct TemporaryExpr : ITag<TemporaryExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Temporary;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly uint index;
        }

        [Tag<ExprSort>(ExprSort.DynamicDispatch)]
        public readonly record struct DynamicDispatchExpr : ITag<DynamicDispatchExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.DynamicDispatch;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex postfix_expr;
        }

        [Tag<ExprSort>(ExprSort.VirtualFunctionConversion)]
        public readonly record struct VirtualFunctionConversionExpr : ITag<VirtualFunctionConversionExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.VirtualFunctionConversion;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex function;
        }

        [Tag<ExprSort>(ExprSort.Requires)]
        public readonly record struct RequiresExpr : ITag<RequiresExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Requires;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly SyntaxIndex parameters;
            public readonly SyntaxIndex body;
        }

        [Tag<ExprSort>(ExprSort.UnaryFold)]
        public readonly record struct UnaryFoldExpr : ITag<UnaryFoldExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.UnaryFold;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex expr;
            public readonly DyadicOperator op;
            public readonly Associativity assoc;
        }

        [Tag<ExprSort>(ExprSort.BinaryFold)]
        public readonly record struct BinaryFoldExpr : ITag<BinaryFoldExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.BinaryFold;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex left;
            public readonly ExprIndex right;
            public readonly DyadicOperator op;
            public readonly Associativity assoc;
        }

        [Tag<ExprSort>(ExprSort.Statement)]
        public readonly record struct StatementExpr : ITag<StatementExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Statement;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly StmtIndex stmt;
        }

        [Tag<ExprSort>(ExprSort.TypeTraitIntrinsic)]
        public readonly record struct TypeTraitIntrinsicExpr : ITag<TypeTraitIntrinsicExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.TypeTraitIntrinsic;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex arguments;
            public readonly Operator intrinsic;
        }

        [Tag<ExprSort>(ExprSort.MemberInitializer)]
        public readonly record struct MemberInitializerExpr : ITag<MemberInitializerExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.MemberInitializer;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly DeclIndex member;
            public readonly TypeIndex @base;
            public readonly ExprIndex expression;
        }

        [Tag<ExprSort>(ExprSort.MemberAccess)]
        public readonly record struct MemberAccessExpr : ITag<MemberAccessExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.MemberAccess;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex offset;
            public readonly TypeIndex parent;
            public readonly TextOffset name;
        }

        [Tag<ExprSort>(ExprSort.InheritancePath)]
        public readonly record struct InheritancePathExpr : ITag<InheritancePathExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.InheritancePath;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex path;
        }

        [Tag<ExprSort>(ExprSort.InitializerList)]
        public readonly record struct InitializerListExpr : ITag<InitializerListExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.InitializerList;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex elements;
        }

        [Tag<ExprSort>(ExprSort.Initializer)]
        public readonly record struct InitializerExpr : ITag<InitializerExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Initializer;

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
        public readonly record struct CastExpr : ITag<CastExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Cast;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex source;
            public readonly TypeIndex target;
            public readonly DyadicOperator assort;
        }

        [Tag<ExprSort>(ExprSort.Condition)]
        public readonly record struct ConditionExpr : ITag<ConditionExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Condition;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex expression;
        }

        [Tag<ExprSort>(ExprSort.SimpleIdentifier)]
        public readonly record struct SimpleIdentifierExpr : ITag<SimpleIdentifierExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.SimpleIdentifier;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly NameIndex name;
        }

        [Tag<ExprSort>(ExprSort.Pointer)]
        public readonly record struct PointerExpr : ITag<PointerExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Pointer;

            public readonly SourceLocation locus;
        }

        [Tag<ExprSort>(ExprSort.UnqualifiedId)]
        public readonly record struct UnqualifiedIdExpr : ITag<UnqualifiedIdExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.UnqualifiedId;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly NameIndex name;
            public readonly ExprIndex symbol;
            public readonly SourceLocation template_keyword;
        }

        [Tag<ExprSort>(ExprSort.QualifiedName)]
        public readonly record struct QualifiedNameExpr : ITag<QualifiedNameExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.QualifiedName;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex elements;
            public readonly SourceLocation typename_keyword;
        }

        [Tag<ExprSort>(ExprSort.DesignatedInitializer)]
        public readonly record struct DesignatedInitializerExpr : ITag<DesignatedInitializerExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.DesignatedInitializer;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TextOffset member;
            public readonly ExprIndex initializer;
        }

        [Tag<ExprSort>(ExprSort.ExpressionList)]
        public readonly record struct ExpressionListExpr : ITag<ExpressionListExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.ExpressionList;

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
        public readonly record struct AssignInitializerExpr : ITag<AssignInitializerExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.AssignInitializer;

            public readonly SourceLocation assign;
            public readonly ExprIndex initializer;
        }

        [Tag<ExprSort>(ExprSort.SizeofType)]
        public readonly record struct SizeofTypeExpr : ITag<SizeofTypeExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.SizeofType;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex operand;
        }

        [Tag<ExprSort>(ExprSort.Alignof)]
        public readonly record struct AlignofExpr : ITag<AlignofExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Alignof;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex type_id;
        }

        [Tag<ExprSort>(ExprSort.Label)]
        public readonly record struct LabelExpr : ITag<LabelExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Label;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex designator;
        }

        [Tag<ExprSort>(ExprSort.Nullptr)]
        public readonly record struct NullptrExpr : ITag<NullptrExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Nullptr;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
        }

        [Tag<ExprSort>(ExprSort.This)]
        public readonly record struct ThisExpr : ITag<ThisExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.This;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
        }

        [Tag<ExprSort>(ExprSort.PackedTemplateArguments)]
        public readonly record struct PackedTemplateArgumentsExpr : ITag<PackedTemplateArgumentsExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.PackedTemplateArguments;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex arguments;
        }

        [Tag<ExprSort>(ExprSort.Lambda)]
        public readonly record struct LambdaExpr : ITag<LambdaExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Lambda;

            public readonly SyntaxIndex introducer;
            public readonly SyntaxIndex template_parameters;
            public readonly SyntaxIndex declarator;
            public readonly SyntaxIndex requires_clause;
            public readonly SyntaxIndex body;
        }

        [Tag<ExprSort>(ExprSort.Typeid)]
        public readonly record struct TypeidExpr : ITag<TypeidExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.Typeid;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex operand;
        }

        [Tag<ExprSort>(ExprSort.SyntaxTree)]
        public readonly record struct SyntaxTreeExpr : ITag<SyntaxTreeExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.SyntaxTree;

            public readonly SyntaxIndex syntax;
        }

        [Tag<ExprSort>(ExprSort.ProductTypeValue)]
        public readonly record struct ProductTypeValueExpr : ITag<ProductTypeValueExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.ProductTypeValue;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex structure;
            public readonly ExprIndex members;
            public readonly ExprIndex base_class_values;
        }

        [Tag<ExprSort>(ExprSort.SumTypeValue)]
        public readonly record struct SumTypeValueExpr : ITag<SumTypeValueExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.SumTypeValue;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly TypeIndex variant;
            public readonly ActiveMemberIndex active_member;
            public readonly ExprIndex value;
        }

        [Tag<ExprSort>(ExprSort.ArrayValue)]
        public readonly record struct ArrayValueExpr : ITag<ArrayValueExpr, ExprSort>
        {
            public static SortType Type => SortType.Expr;
            public static ExprSort Sort => ExprSort.ArrayValue;

            public readonly SourceLocation locus;
            public readonly TypeIndex type;
            public readonly ExprIndex elements;
            public readonly TypeIndex element_type;
        }

        [Tag<MacroSort>(MacroSort.ObjectLike)]
        public readonly record struct ObjectLikeMacro : ITag<ObjectLikeMacro, MacroSort>
        {
            public static SortType Type => SortType.Macro;
            public static MacroSort Sort => MacroSort.ObjectLike;

            public readonly SourceLocation locus;
            public readonly TextOffset name;
            public readonly FormIndex replacement_list;
        }

        [Tag<MacroSort>(MacroSort.FunctionLike)]
        public readonly record struct FunctionLikeMacro : ITag<FunctionLikeMacro, MacroSort>
        {
            public static SortType Type => SortType.Macro;
            public static MacroSort Sort => MacroSort.FunctionLike;

            public readonly SourceLocation locus;
            public readonly TextOffset name;
            public readonly FormIndex parameters;
            public readonly FormIndex replacement_list;
            private readonly uint arity_bitfield;
            // uint variadic (bitfield continuation)
            public uint arity => ((arity_bitfield >> 0) & 0b1111111111111111111111111111111);
            public uint variadic => ((arity_bitfield >> 31) & 0b1);
        }

        public readonly record struct PragmaWarningRegion
        {
            public readonly SourceLocation start_locus;
            public readonly SourceLocation end_locus;
            public readonly SuppressedWarning suppressed_warning;
        }

        [Tag<LiteralSort>(LiteralSort.Integer)]
        public readonly record struct IntegerLiteral : ITag<IntegerLiteral, LiteralSort>
        {
            public static SortType Type => SortType.Literal;
            public static LiteralSort Sort => LiteralSort.Integer;

        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public readonly record struct LiteralReal
        {
            public readonly double value;
            public readonly ushort size;
        }

        [Tag<LiteralSort>(LiteralSort.FloatingPoint)]
        public readonly record struct FloatingPointLiteral : ITag<FloatingPointLiteral, LiteralSort>
        {
            public static SortType Type => SortType.Literal;
            public static LiteralSort Sort => LiteralSort.FloatingPoint;

        }

        public readonly record struct PragmaPushState
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
            public uint pack_size => ((pack_size_bitfield >> 0) & 0b11111111);
            public uint fp_control => ((pack_size_bitfield >> 8) & 0b11111111);
            public uint exec_charset => ((pack_size_bitfield >> 16) & 0b11111111);
            public uint vtor_disp => ((pack_size_bitfield >> 24) & 0b11111111);
            public uint std_for_scope => ((std_for_scope_bitfield >> 0) & 0b1);
            public uint unused => ((std_for_scope_bitfield >> 1) & 0b1);
            public uint strict_gs_check => ((std_for_scope_bitfield >> 2) & 0b1);
        }

        [Tag<AttrSort>(AttrSort.Basic)]
        public readonly record struct BasicAttr : ITag<BasicAttr, AttrSort>
        {
            public static SortType Type => SortType.Attr;
            public static AttrSort Sort => AttrSort.Basic;

            public readonly Word word;
        }

        [Tag<AttrSort>(AttrSort.Scoped)]
        public readonly record struct ScopedAttr : ITag<ScopedAttr, AttrSort>
        {
            public static SortType Type => SortType.Attr;
            public static AttrSort Sort => AttrSort.Scoped;

            public readonly Word scope;
            public readonly Word member;
        }

        [Tag<AttrSort>(AttrSort.Labeled)]
        public readonly record struct LabeledAttr : ITag<LabeledAttr, AttrSort>
        {
            public static SortType Type => SortType.Attr;
            public static AttrSort Sort => AttrSort.Labeled;

            public readonly Word label;
            public readonly AttrIndex attribute;
        }

        [Tag<AttrSort>(AttrSort.Called)]
        public readonly record struct CalledAttr : ITag<CalledAttr, AttrSort>
        {
            public static SortType Type => SortType.Attr;
            public static AttrSort Sort => AttrSort.Called;

            public readonly AttrIndex function;
            public readonly AttrIndex arguments;
        }

        [Tag<AttrSort>(AttrSort.Expanded)]
        public readonly record struct ExpandedAttr : ITag<ExpandedAttr, AttrSort>
        {
            public static SortType Type => SortType.Attr;
            public static AttrSort Sort => AttrSort.Expanded;

            public readonly AttrIndex operand;
        }

        [Tag<AttrSort>(AttrSort.Factored)]
        public readonly record struct FactoredAttr : ITag<FactoredAttr, AttrSort>
        {
            public static SortType Type => SortType.Attr;
            public static AttrSort Sort => AttrSort.Factored;

            public readonly Word factor;
            public readonly AttrIndex terms;
        }

        [Tag<AttrSort>(AttrSort.Elaborated)]
        public readonly record struct ElaboratedAttr : ITag<ElaboratedAttr, AttrSort>
        {
            public static SortType Type => SortType.Attr;
            public static AttrSort Sort => AttrSort.Elaborated;

            public readonly ExprIndex expr;
        }

        [Tag<AttrSort>(AttrSort.Tuple)]
        public readonly record struct TupleAttr : ITag<TupleAttr, AttrSort>, ITaggedSequence<TupleAttr, AttrIndex, HeapSort>
        {
            public static SortType Type => SortType.Attr;
            public static AttrSort Sort => AttrSort.Tuple;
            public static SortType SequenceType => SortType.Heap;
            public static HeapSort SequenceSort => HeapSort.Attr;
            public Sequence<AttrIndex> Sequence => new(start, cardinality);
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        [Tag<DirSort>(DirSort.Empty)]
        public readonly record struct EmptyDir : ITag<EmptyDir, DirSort>
        {
            public static SortType Type => SortType.Dir;
            public static DirSort Sort => DirSort.Empty;

            public readonly SourceLocation locus;
        }

        [Tag<DirSort>(DirSort.Attribute)]
        public readonly record struct AttributeDir : ITag<AttributeDir, DirSort>
        {
            public static SortType Type => SortType.Dir;
            public static DirSort Sort => DirSort.Attribute;

            public readonly SourceLocation locus;
            public readonly AttrIndex attr;
        }

        [Tag<DirSort>(DirSort.Pragma)]
        public readonly record struct PragmaDir : ITag<PragmaDir, DirSort>
        {
            public static SortType Type => SortType.Dir;
            public static DirSort Sort => DirSort.Pragma;

            public readonly SourceLocation locus;
            public readonly SentenceIndex words;
        }

        [Tag<DirSort>(DirSort.Using)]
        public readonly record struct UsingDir : ITag<UsingDir, DirSort>
        {
            public static SortType Type => SortType.Dir;
            public static DirSort Sort => DirSort.Using;

            public readonly SourceLocation locus;
            public readonly ExprIndex nominated;
            public readonly DeclIndex resolution;
        }

        [Tag<DirSort>(DirSort.DeclUse)]
        public readonly record struct UsingDeclarationDir : ITag<UsingDeclarationDir, DirSort>
        {
            public static SortType Type => SortType.Dir;
            public static DirSort Sort => DirSort.DeclUse;

            public readonly SourceLocation locus;
            public readonly ExprIndex path;
            public readonly DeclIndex result;
        }

        [Tag<DirSort>(DirSort.Expr)]
        public readonly record struct ExprDir : ITag<ExprDir, DirSort>
        {
            public static SortType Type => SortType.Dir;
            public static DirSort Sort => DirSort.Expr;

            public readonly SourceLocation locus;
            public readonly ExprIndex expr;
            public readonly Phases phases;
        }

        [Tag<DirSort>(DirSort.StructuredBinding)]
        public readonly record struct StructuredBindingDir : ITag<StructuredBindingDir, DirSort>
        {
            public static SortType Type => SortType.Dir;
            public static DirSort Sort => DirSort.StructuredBinding;

            public readonly SourceLocation locus;
            public readonly Sequence<DeclIndex> bindings;
            public readonly Sequence<TextOffset> names;
        }

        [Tag<DirSort>(DirSort.SpecifiersSpread)]
        public readonly record struct SpecifiersSpreadDir : ITag<SpecifiersSpreadDir, DirSort>
        {
            public static SortType Type => SortType.Dir;
            public static DirSort Sort => DirSort.SpecifiersSpread;

            public readonly SourceLocation locus;
        }

        [Tag<DirSort>(DirSort.Tuple)]
        public readonly record struct TupleDir : ITag<TupleDir, DirSort>, ITaggedSequence<TupleDir, DirIndex, HeapSort>
        {
            public static SortType Type => SortType.Dir;
            public static DirSort Sort => DirSort.Tuple;
            public static SortType SequenceType => SortType.Heap;
            public static HeapSort SequenceSort => HeapSort.Dir;
            public Sequence<DirIndex> Sequence => new(start, cardinality);
            public readonly Index start;
            public readonly Cardinality cardinality;
        }

        namespace syntax
        {
            [Flags]
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
            public readonly record struct DecltypeSpecifier : ITag<DecltypeSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.DecltypeSpecifier;

                public readonly ExprIndex expression;
                public readonly SourceLocation decltype_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.PlaceholderTypeSpecifier)]
            public readonly record struct PlaceholderTypeSpecifier : ITag<PlaceholderTypeSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.PlaceholderTypeSpecifier;

                public readonly PlaceholderType type;
                public readonly SourceLocation keyword;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.SimpleTypeSpecifier)]
            public readonly record struct SimpleTypeSpecifier : ITag<SimpleTypeSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.SimpleTypeSpecifier;

                public readonly TypeIndex type;
                public readonly ExprIndex expr;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeSpecifierSeq)]
            public readonly record struct TypeSpecifierSeq : ITag<TypeSpecifierSeq, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TypeSpecifierSeq;

                public readonly SyntaxIndex type_script;
                public readonly TypeIndex type;
                public readonly SourceLocation locus;
                public readonly Qualifier qualifiers;
                [MarshalAs(UnmanagedType.U1)]
                public readonly bool is_unhashed;
            }

            public readonly record struct Keyword
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
            public readonly record struct DeclSpecifierSeq : ITag<DeclSpecifierSeq, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.DeclSpecifierSeq;

                public readonly TypeIndex type;
                public readonly SyntaxIndex type_script;
                public readonly SourceLocation locus;
                public readonly StorageClass storage_class;
                public readonly SentenceIndex declspec;
                public readonly SyntaxIndex explicit_specifier;
                public readonly Qualifier qualifiers;
            }

            [Tag<SyntaxSort>(SyntaxSort.EnumSpecifier)]
            public readonly record struct EnumSpecifier : ITag<EnumSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.EnumSpecifier;

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
            public readonly record struct EnumeratorDefinition : ITag<EnumeratorDefinition, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.EnumeratorDefinition;

                public readonly TextOffset name;
                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
                public readonly SourceLocation assign;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.ClassSpecifier)]
            public readonly record struct ClassSpecifier : ITag<ClassSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ClassSpecifier;

                public readonly ExprIndex name;
                public readonly Keyword class_key;
                public readonly SyntaxIndex base_classes;
                public readonly SyntaxIndex members;
                public readonly SourceLocation left_brace;
                public readonly SourceLocation right_brace;
            }

            [Tag<SyntaxSort>(SyntaxSort.BaseSpecifierList)]
            public readonly record struct BaseSpecifierList : ITag<BaseSpecifierList, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.BaseSpecifierList;

                public readonly SyntaxIndex base_specifiers;
                public readonly SourceLocation colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.BaseSpecifier)]
            public readonly record struct BaseSpecifier : ITag<BaseSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.BaseSpecifier;

                public readonly ExprIndex name;
                public readonly Keyword access_keyword;
                public readonly SourceLocation virtual_keyword;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemberSpecification)]
            public readonly record struct MemberSpecification : ITag<MemberSpecification, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.MemberSpecification;

                public readonly SyntaxIndex declarations;
            }

            [Tag<SyntaxSort>(SyntaxSort.AccessSpecifier)]
            public readonly record struct AccessSpecifier : ITag<AccessSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.AccessSpecifier;

                public readonly Keyword keyword;
                public readonly SourceLocation colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemberDeclaration)]
            public readonly record struct MemberDeclaration : ITag<MemberDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.MemberDeclaration;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarators;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemberDeclarator)]
            public readonly record struct MemberDeclarator : ITag<MemberDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.MemberDeclarator;

                public readonly SyntaxIndex declarator;
                public readonly SyntaxIndex requires_clause;
                public readonly ExprIndex expression;
                public readonly ExprIndex initializer;
                public readonly SourceLocation locus;
                public readonly SourceLocation colon;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeId)]
            public readonly record struct TypeId : ITag<TypeId, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TypeId;

                public readonly SyntaxIndex type;
                public readonly SyntaxIndex declarator;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.TrailingReturnType)]
            public readonly record struct TrailingReturnType : ITag<TrailingReturnType, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TrailingReturnType;

                public readonly SyntaxIndex type;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.PointerDeclarator)]
            public readonly record struct PointerDeclarator : ITag<PointerDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.PointerDeclarator;

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
            public readonly record struct ArrayDeclarator : ITag<ArrayDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ArrayDeclarator;

                public readonly ExprIndex bounds;
                public readonly SourceLocation left_bracket;
                public readonly SourceLocation right_bracket;
            }

            [Tag<SyntaxSort>(SyntaxSort.FunctionDeclarator)]
            public readonly record struct FunctionDeclarator : ITag<FunctionDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.FunctionDeclarator;

                public readonly SyntaxIndex parameters;
                public readonly SyntaxIndex exception_specification;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation ref_qualifier;
                public readonly FunctionTypeTraits traits;
            }

            [Tag<SyntaxSort>(SyntaxSort.ArrayOrFunctionDeclarator)]
            public readonly record struct ArrayOrFunctionDeclarator : ITag<ArrayOrFunctionDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ArrayOrFunctionDeclarator;

                public readonly SyntaxIndex declarator;
                public readonly SyntaxIndex next;
            }

            [Tag<SyntaxSort>(SyntaxSort.ParameterDeclarator)]
            public readonly record struct ParameterDeclarator : ITag<ParameterDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ParameterDeclarator;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarator;
                public readonly ExprIndex default_argument;
                public readonly SourceLocation locus;
                public readonly ParameterSort sort;
            }

            [Tag<SyntaxSort>(SyntaxSort.VirtualSpecifierSeq)]
            public readonly record struct VirtualSpecifierSeq : ITag<VirtualSpecifierSeq, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.VirtualSpecifierSeq;

                public readonly SourceLocation locus;
                public readonly SourceLocation final_keyword;
                public readonly SourceLocation override_keyword;
                [MarshalAs(UnmanagedType.U1)]
                public readonly bool is_pure;
            }

            [Tag<SyntaxSort>(SyntaxSort.NoexceptSpecification)]
            public readonly record struct NoexceptSpecification : ITag<NoexceptSpecification, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.NoexceptSpecification;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.ExplicitSpecifier)]
            public readonly record struct ExplicitSpecifier : ITag<ExplicitSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ExplicitSpecifier;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.Declarator)]
            public readonly record struct Declarator : ITag<Declarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.Declarator;

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
            public readonly record struct InitDeclarator : ITag<InitDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.InitDeclarator;

                public readonly SyntaxIndex declarator;
                public readonly SyntaxIndex requires_clause;
                public readonly ExprIndex initializer;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.NewDeclarator)]
            public readonly record struct NewDeclarator : ITag<NewDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.NewDeclarator;

                public readonly SyntaxIndex declarator;
            }

            [Tag<SyntaxSort>(SyntaxSort.SimpleDeclaration)]
            public readonly record struct SimpleDeclaration : ITag<SimpleDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.SimpleDeclaration;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarators;
                public readonly SourceLocation locus;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ExceptionDeclaration)]
            public readonly record struct ExceptionDeclaration : ITag<ExceptionDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ExceptionDeclaration;

                public readonly SyntaxIndex type_specifier_seq;
                public readonly SyntaxIndex declarator;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
            }

            [Tag<SyntaxSort>(SyntaxSort.ConditionDeclaration)]
            public readonly record struct ConditionDeclaration : ITag<ConditionDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ConditionDeclaration;

                public readonly SyntaxIndex decl_specifier;
                public readonly SyntaxIndex init_statement;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.StaticAssertDeclaration)]
            public readonly record struct StaticAssertDeclaration : ITag<StaticAssertDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.StaticAssertDeclaration;

                public readonly ExprIndex expression;
                public readonly ExprIndex message;
                public readonly SourceLocation locus;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
                public readonly SourceLocation semi_colon;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.AliasDeclaration)]
            public readonly record struct AliasDeclaration : ITag<AliasDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.AliasDeclaration;

                public readonly TextOffset identifier;
                public readonly SyntaxIndex defining_type_id;
                public readonly SourceLocation locus;
                public readonly SourceLocation assign;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ConceptDefinition)]
            public readonly record struct ConceptDefinition : ITag<ConceptDefinition, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ConceptDefinition;

                public readonly SyntaxIndex parameters;
                public readonly SourceLocation locus;
                public readonly TextOffset identifier;
                public readonly ExprIndex expression;
                public readonly SourceLocation concept_keyword;
                public readonly SourceLocation assign;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.StructuredBindingDeclaration)]
            public readonly record struct StructuredBindingDeclaration : ITag<StructuredBindingDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.StructuredBindingDeclaration;

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
            public readonly record struct StructuredBindingIdentifier : ITag<StructuredBindingIdentifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.StructuredBindingIdentifier;

                public readonly ExprIndex identifier;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.AsmStatement)]
            public readonly record struct AsmStatement : ITag<AsmStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.AsmStatement;

                public readonly SentenceIndex tokens;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.ReturnStatement)]
            public readonly record struct ReturnStatement : ITag<ReturnStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ReturnStatement;

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
            public readonly record struct CompoundStatement : ITag<CompoundStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.CompoundStatement;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex statements;
                public readonly SourceLocation left_curly;
                public readonly SourceLocation right_curly;
            }

            [Tag<SyntaxSort>(SyntaxSort.IfStatement)]
            public readonly record struct IfStatement : ITag<IfStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.IfStatement;

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
            public readonly record struct WhileStatement : ITag<WhileStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.WhileStatement;

                public readonly SentenceIndex pragma_tokens;
                public readonly ExprIndex condition;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation while_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.DoWhileStatement)]
            public readonly record struct DoWhileStatement : ITag<DoWhileStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.DoWhileStatement;

                public readonly SentenceIndex pragma_tokens;
                public readonly ExprIndex condition;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation do_keyword;
                public readonly SourceLocation while_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ForStatement)]
            public readonly record struct ForStatement : ITag<ForStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ForStatement;

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
            public readonly record struct InitStatement : ITag<InitStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.InitStatement;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex expression_or_declaration;
            }

            [Tag<SyntaxSort>(SyntaxSort.RangeBasedForStatement)]
            public readonly record struct RangeBasedForStatement : ITag<RangeBasedForStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.RangeBasedForStatement;

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
            public readonly record struct ForRangeDeclaration : ITag<ForRangeDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ForRangeDeclaration;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarator;
            }

            [Tag<SyntaxSort>(SyntaxSort.LabeledStatement)]
            public readonly record struct LabeledStatement : ITag<LabeledStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.LabeledStatement;

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
            public readonly record struct BreakStatement : ITag<BreakStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.BreakStatement;

                public readonly SourceLocation break_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ContinueStatement)]
            public readonly record struct ContinueStatement : ITag<ContinueStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ContinueStatement;

                public readonly SourceLocation continue_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.SwitchStatement)]
            public readonly record struct SwitchStatement : ITag<SwitchStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.SwitchStatement;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex init_statement;
                public readonly ExprIndex condition;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation switch_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.GotoStatement)]
            public readonly record struct GotoStatement : ITag<GotoStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.GotoStatement;

                public readonly SentenceIndex pragma_tokens;
                public readonly TextOffset name;
                public readonly SourceLocation locus;
                public readonly SourceLocation label;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.DeclarationStatement)]
            public readonly record struct DeclarationStatement : ITag<DeclarationStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.DeclarationStatement;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex declaration;
            }

            [Tag<SyntaxSort>(SyntaxSort.ExpressionStatement)]
            public readonly record struct ExpressionStatement : ITag<ExpressionStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ExpressionStatement;

                public readonly SentenceIndex pragma_tokens;
                public readonly ExprIndex expression;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.TryBlock)]
            public readonly record struct TryBlock : ITag<TryBlock, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TryBlock;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex statement;
                public readonly SyntaxIndex handler_seq;
                public readonly SourceLocation try_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.Handler)]
            public readonly record struct Handler : ITag<Handler, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.Handler;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex exception_declaration;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation catch_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.HandlerSeq)]
            public readonly record struct HandlerSeq : ITag<HandlerSeq, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.HandlerSeq;

                public readonly SyntaxIndex handlers;
            }

            [Tag<SyntaxSort>(SyntaxSort.FunctionTryBlock)]
            public readonly record struct FunctionTryBlock : ITag<FunctionTryBlock, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.FunctionTryBlock;

                public readonly SyntaxIndex statement;
                public readonly SyntaxIndex handler_seq;
                public readonly SyntaxIndex initializers;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeIdListElement)]
            public readonly record struct TypeIdListElement : ITag<TypeIdListElement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TypeIdListElement;

                public readonly SyntaxIndex type_id;
                public readonly SourceLocation ellipsis;
            }

            [Tag<SyntaxSort>(SyntaxSort.DynamicExceptionSpec)]
            public readonly record struct DynamicExceptionSpec : ITag<DynamicExceptionSpec, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.DynamicExceptionSpec;

                public readonly SyntaxIndex type_list;
                public readonly SourceLocation throw_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.StatementSeq)]
            public readonly record struct StatementSeq : ITag<StatementSeq, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.StatementSeq;

                public readonly SyntaxIndex statements;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemberFunctionDeclaration)]
            public readonly record struct MemberFunctionDeclaration : ITag<MemberFunctionDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.MemberFunctionDeclaration;

                public readonly SyntaxIndex definition;
            }

            [Tag<SyntaxSort>(SyntaxSort.FunctionDefinition)]
            public readonly record struct FunctionDefinition : ITag<FunctionDefinition, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.FunctionDefinition;

                public readonly SyntaxIndex decl_specifier_seq;
                public readonly SyntaxIndex declarator;
                public readonly SyntaxIndex requires_clause;
                public readonly SyntaxIndex body;
            }

            [Tag<SyntaxSort>(SyntaxSort.FunctionBody)]
            public readonly record struct FunctionBody : ITag<FunctionBody, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.FunctionBody;

                public readonly SyntaxIndex statements;
                public readonly SyntaxIndex function_try_block;
                public readonly SyntaxIndex initializers;
                public readonly Keyword default_or_delete;
                public readonly SourceLocation assign;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.Expression)]
            public readonly record struct Expression : ITag<Expression, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.Expression;

                public readonly ExprIndex expression;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateParameterList)]
            public readonly record struct TemplateParameterList : ITag<TemplateParameterList, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TemplateParameterList;

                public readonly SyntaxIndex parameters;
                public readonly SyntaxIndex requires_clause;
                public readonly SourceLocation left_angle;
                public readonly SourceLocation right_angle;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateDeclaration)]
            public readonly record struct TemplateDeclaration : ITag<TemplateDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TemplateDeclaration;

                public readonly SyntaxIndex parameters;
                public readonly SyntaxIndex declaration;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.RequiresClause)]
            public readonly record struct RequiresClause : ITag<RequiresClause, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.RequiresClause;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.SimpleRequirement)]
            public readonly record struct SimpleRequirement : ITag<SimpleRequirement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.SimpleRequirement;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeRequirement)]
            public readonly record struct TypeRequirement : ITag<TypeRequirement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TypeRequirement;

                public readonly ExprIndex type;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.CompoundRequirement)]
            public readonly record struct CompoundRequirement : ITag<CompoundRequirement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.CompoundRequirement;

                public readonly ExprIndex expression;
                public readonly ExprIndex type_constraint;
                public readonly SourceLocation locus;
                public readonly SourceLocation right_curly;
                public readonly SourceLocation noexcept_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.NestedRequirement)]
            public readonly record struct NestedRequirement : ITag<NestedRequirement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.NestedRequirement;

                public readonly ExprIndex expression;
                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.RequirementBody)]
            public readonly record struct RequirementBody : ITag<RequirementBody, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.RequirementBody;

                public readonly SyntaxIndex requirements;
                public readonly SourceLocation locus;
                public readonly SourceLocation right_curly;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeTemplateParameter)]
            public readonly record struct TypeTemplateParameter : ITag<TypeTemplateParameter, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TypeTemplateParameter;

                public readonly TextOffset name;
                public readonly ExprIndex type_constraint;
                public readonly SyntaxIndex default_argument;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateTemplateParameter)]
            public readonly record struct TemplateTemplateParameter : ITag<TemplateTemplateParameter, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TemplateTemplateParameter;

                public readonly TextOffset name;
                public readonly SyntaxIndex default_argument;
                public readonly SyntaxIndex parameters;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
                public readonly Keyword type_parameter_key;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeTemplateArgument)]
            public readonly record struct TypeTemplateArgument : ITag<TypeTemplateArgument, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TypeTemplateArgument;

                public readonly SyntaxIndex argument;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.NonTypeTemplateArgument)]
            public readonly record struct NonTypeTemplateArgument : ITag<NonTypeTemplateArgument, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.NonTypeTemplateArgument;

                public readonly ExprIndex argument;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateArgumentList)]
            public readonly record struct TemplateArgumentList : ITag<TemplateArgumentList, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TemplateArgumentList;

                public readonly SyntaxIndex arguments;
                public readonly SourceLocation left_angle;
                public readonly SourceLocation right_angle;
            }

            [Tag<SyntaxSort>(SyntaxSort.TemplateId)]
            public readonly record struct TemplateId : ITag<TemplateId, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TemplateId;

                public readonly SyntaxIndex name;
                public readonly ExprIndex symbol;
                public readonly SyntaxIndex arguments;
                public readonly SourceLocation locus;
                public readonly SourceLocation template_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.MemInitializer)]
            public readonly record struct MemInitializer : ITag<MemInitializer, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.MemInitializer;

                public readonly ExprIndex name;
                public readonly ExprIndex initializer;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.CtorInitializer)]
            public readonly record struct CtorInitializer : ITag<CtorInitializer, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.CtorInitializer;

                public readonly SyntaxIndex initializers;
                public readonly SourceLocation colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.CaptureDefault)]
            public readonly record struct CaptureDefault : ITag<CaptureDefault, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.CaptureDefault;

                public readonly SourceLocation locus;
                public readonly SourceLocation comma;
                [MarshalAs(UnmanagedType.U1)]
                public readonly bool default_is_by_reference;
            }

            [Tag<SyntaxSort>(SyntaxSort.SimpleCapture)]
            public readonly record struct SimpleCapture : ITag<SimpleCapture, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.SimpleCapture;

                public readonly ExprIndex name;
                public readonly SourceLocation ampersand;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.InitCapture)]
            public readonly record struct InitCapture : ITag<InitCapture, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.InitCapture;

                public readonly ExprIndex name;
                public readonly ExprIndex initializer;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation ampersand;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.ThisCapture)]
            public readonly record struct ThisCapture : ITag<ThisCapture, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ThisCapture;

                public readonly SourceLocation locus;
                public readonly SourceLocation asterisk;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.LambdaIntroducer)]
            public readonly record struct LambdaIntroducer : ITag<LambdaIntroducer, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.LambdaIntroducer;

                public readonly SyntaxIndex captures;
                public readonly SourceLocation left_bracket;
                public readonly SourceLocation right_bracket;
            }

            [Tag<SyntaxSort>(SyntaxSort.LambdaDeclarator)]
            public readonly record struct LambdaDeclarator : ITag<LambdaDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.LambdaDeclarator;

                public readonly SyntaxIndex parameters;
                public readonly SyntaxIndex exception_specification;
                public readonly SyntaxIndex trailing_return_type;
                public readonly Keyword keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
                public readonly SourceLocation ellipsis;
            }

            [Tag<SyntaxSort>(SyntaxSort.UsingDeclaration)]
            public readonly record struct UsingDeclaration : ITag<UsingDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.UsingDeclaration;

                public readonly SyntaxIndex declarators;
                public readonly SourceLocation using_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.UsingEnumDeclaration)]
            public readonly record struct UsingEnumDeclaration : ITag<UsingEnumDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.UsingEnumDeclaration;

                public readonly ExprIndex name;
                public readonly SourceLocation using_keyword;
                public readonly SourceLocation enum_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.UsingDeclarator)]
            public readonly record struct UsingDeclarator : ITag<UsingDeclarator, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.UsingDeclarator;

                public readonly ExprIndex qualified_name;
                public readonly SourceLocation typename_keyword;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.UsingDirective)]
            public readonly record struct UsingDirective : ITag<UsingDirective, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.UsingDirective;

                public readonly ExprIndex qualified_name;
                public readonly SourceLocation using_keyword;
                public readonly SourceLocation namespace_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.NamespaceAliasDefinition)]
            public readonly record struct NamespaceAliasDefinition : ITag<NamespaceAliasDefinition, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.NamespaceAliasDefinition;

                public readonly ExprIndex identifier;
                public readonly ExprIndex namespace_name;
                public readonly SourceLocation namespace_keyword;
                public readonly SourceLocation assign;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.ArrayIndex)]
            public readonly record struct ArrayIndex : ITag<ArrayIndex, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.ArrayIndex;

                public readonly ExprIndex array;
                public readonly ExprIndex index;
                public readonly SourceLocation left_bracket;
                public readonly SourceLocation right_bracket;
            }

            [Tag<SyntaxSort>(SyntaxSort.TypeTraitIntrinsic)]
            public readonly record struct TypeTraitIntrinsic : ITag<TypeTraitIntrinsic, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.TypeTraitIntrinsic;

                public readonly SyntaxIndex arguments;
                public readonly SourceLocation locus;
                public readonly Operator intrinsic;
            }

            [Tag<SyntaxSort>(SyntaxSort.SEHTry)]
            public readonly record struct SEHTry : ITag<SEHTry, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.SEHTry;

                public readonly SyntaxIndex statement;
                public readonly SyntaxIndex handler;
                public readonly SourceLocation try_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.SEHExcept)]
            public readonly record struct SEHExcept : ITag<SEHExcept, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.SEHExcept;

                public readonly ExprIndex expression;
                public readonly SyntaxIndex statement;
                public readonly SourceLocation except_keyword;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.SEHFinally)]
            public readonly record struct SEHFinally : ITag<SEHFinally, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.SEHFinally;

                public readonly SyntaxIndex statement;
                public readonly SourceLocation finally_keyword;
            }

            [Tag<SyntaxSort>(SyntaxSort.SEHLeave)]
            public readonly record struct SEHLeave : ITag<SEHLeave, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.SEHLeave;

                public readonly SourceLocation leave_keyword;
                public readonly SourceLocation semi_colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.Super)]
            public readonly record struct Super : ITag<Super, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.Super;

                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.UnaryFoldExpression)]
            public readonly record struct UnaryFoldExpression : ITag<UnaryFoldExpression, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.UnaryFoldExpression;

                public readonly FoldKind kind;
                public readonly ExprIndex expression;
                public readonly DyadicOperator op;
                public readonly SourceLocation locus;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation operator_locus;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.BinaryFoldExpression)]
            public readonly record struct BinaryFoldExpression : ITag<BinaryFoldExpression, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.BinaryFoldExpression;

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
            public readonly record struct EmptyStatement : ITag<EmptyStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.EmptyStatement;

                public readonly SourceLocation locus;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributedStatement)]
            public readonly record struct AttributedStatement : ITag<AttributedStatement, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.AttributedStatement;

                public readonly SentenceIndex pragma_tokens;
                public readonly SyntaxIndex statement;
                public readonly SyntaxIndex attributes;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributedDeclaration)]
            public readonly record struct AttributedDeclaration : ITag<AttributedDeclaration, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.AttributedDeclaration;

                public readonly SourceLocation locus;
                public readonly SyntaxIndex declaration;
                public readonly SyntaxIndex attributes;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributeSpecifierSeq)]
            public readonly record struct AttributeSpecifierSeq : ITag<AttributeSpecifierSeq, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.AttributeSpecifierSeq;

                public readonly SyntaxIndex attributes;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributeSpecifier)]
            public readonly record struct AttributeSpecifier : ITag<AttributeSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.AttributeSpecifier;

                public readonly SyntaxIndex using_prefix;
                public readonly SyntaxIndex attributes;
                public readonly SourceLocation left_bracket_1;
                public readonly SourceLocation left_bracket_2;
                public readonly SourceLocation right_bracket_1;
                public readonly SourceLocation right_bracket_2;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributeUsingPrefix)]
            public readonly record struct AttributeUsingPrefix : ITag<AttributeUsingPrefix, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.AttributeUsingPrefix;

                public readonly ExprIndex attribute_namespace;
                public readonly SourceLocation using_locus;
                public readonly SourceLocation colon;
            }

            [Tag<SyntaxSort>(SyntaxSort.Attribute)]
            public readonly record struct Attribute : ITag<Attribute, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.Attribute;

                public readonly ExprIndex identifier;
                public readonly ExprIndex attribute_namespace;
                public readonly SyntaxIndex argument_clause;
                public readonly SourceLocation double_colon;
                public readonly SourceLocation ellipsis;
                public readonly SourceLocation comma;
            }

            [Tag<SyntaxSort>(SyntaxSort.AttributeArgumentClause)]
            public readonly record struct AttributeArgumentClause : ITag<AttributeArgumentClause, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.AttributeArgumentClause;

                public readonly SentenceIndex tokens;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.Alignas)]
            public readonly record struct AlignasSpecifier : ITag<AlignasSpecifier, SyntaxSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.Alignas;

                public readonly SyntaxIndex expression;
                public readonly SourceLocation locus;
                public readonly SourceLocation left_paren;
                public readonly SourceLocation right_paren;
            }

            [Tag<SyntaxSort>(SyntaxSort.Tuple)]
            public readonly record struct Tuple : ITag<Tuple, SyntaxSort>, ITaggedSequence<Tuple, SyntaxIndex, HeapSort>
            {
                public static SortType Type => SortType.Syntax;
                public static SyntaxSort Sort => SyntaxSort.Tuple;
                public static SortType SequenceType => SortType.Heap;
                public static HeapSort SequenceSort => HeapSort.Syntax;
                public Sequence<SyntaxIndex> Sequence => new(start, cardinality);
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

                public readonly record struct TypeOrExprOperand
                {
                    [StructLayout(LayoutKind.Explicit)]
                    public readonly record struct UnnamedUnion1
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

                public readonly record struct Declspec
                {
                    public readonly SourceLocation left_paren;
                    public readonly SourceLocation right_paren;
                    public readonly SentenceIndex tokens;
                }

                public readonly record struct BuiltinAddressOf
                {
                    public readonly ExprIndex expr;
                }

                public readonly record struct UUIDOf
                {
                    public readonly SourceLocation left_paren;
                    public readonly SourceLocation right_paren;
                    public readonly TypeOrExprOperand operand;
                }

                public readonly record struct Intrinsic
                {
                    public readonly SourceLocation left_paren;
                    public readonly SourceLocation right_paren;
                    public readonly ExprIndex argument;
                }

                public readonly record struct IfExists
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
                public readonly record struct VendorSyntax : ITag<VendorSyntax, SyntaxSort>
                {
                    public static SortType Type => SortType.Syntax;
                    public static SyntaxSort Sort => SyntaxSort.VendorExtension;

                    [StructLayout(LayoutKind.Explicit)]
                    public readonly record struct UnnamedUnion1
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
            public readonly record struct PragmaComment : ITag<PragmaComment, PragmaSort>
            {
                public static SortType Type => SortType.Pragma;
                public static PragmaSort Sort => PragmaSort.VendorExtension;

                public readonly TextOffset comment_text;
                public readonly PragmaCommentSort sort;
            }

        }

        namespace preprocessing
        {
            [Tag<FormSort>(FormSort.Identifier)]
            public readonly record struct IdentifierForm : ITag<IdentifierForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Identifier;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Number)]
            public readonly record struct NumberForm : ITag<NumberForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Number;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Character)]
            public readonly record struct CharacterForm : ITag<CharacterForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Character;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.String)]
            public readonly record struct StringForm : ITag<StringForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.String;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Operator)]
            public readonly record struct OperatorForm : ITag<OperatorForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Operator;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
                public readonly PPOperator value;
            }

            [Tag<FormSort>(FormSort.Keyword)]
            public readonly record struct KeywordForm : ITag<KeywordForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Keyword;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Whitespace)]
            public readonly record struct WhitespaceForm : ITag<WhitespaceForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Whitespace;

                public readonly SourceLocation locus;
            }

            [Tag<FormSort>(FormSort.Parameter)]
            public readonly record struct ParameterForm : ITag<ParameterForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Parameter;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Stringize)]
            public readonly record struct StringizeForm : ITag<StringizeForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Stringize;

                public readonly SourceLocation locus;
                public readonly FormIndex operand;
            }

            [Tag<FormSort>(FormSort.Catenate)]
            public readonly record struct CatenateForm : ITag<CatenateForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Catenate;

                public readonly SourceLocation locus;
                public readonly FormIndex first;
                public readonly FormIndex second;
            }

            [Tag<FormSort>(FormSort.Pragma)]
            public readonly record struct PragmaForm : ITag<PragmaForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Pragma;

                public readonly SourceLocation locus;
                public readonly FormIndex operand;
            }

            [Tag<FormSort>(FormSort.Header)]
            public readonly record struct HeaderForm : ITag<HeaderForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Header;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Parenthesized)]
            public readonly record struct ParenthesizedForm : ITag<ParenthesizedForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Parenthesized;

                public readonly SourceLocation locus;
                public readonly FormIndex operand;
            }

            [Tag<FormSort>(FormSort.Junk)]
            public readonly record struct JunkForm : ITag<JunkForm, FormSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Junk;

                public readonly SourceLocation locus;
                public readonly TextOffset spelling;
            }

            [Tag<FormSort>(FormSort.Tuple)]
            public readonly record struct TupleForm : ITag<TupleForm, FormSort>, ITaggedSequence<TupleForm, FormIndex, HeapSort>
            {
                public static SortType Type => SortType.Form;
                public static FormSort Sort => FormSort.Tuple;
                public static SortType SequenceType => SortType.Heap;
                public static HeapSort SequenceSort => HeapSort.Form;
                public Sequence<FormIndex> Sequence => new(start, cardinality);
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
            public readonly record struct MappingExpr : ITraitTag<MappingExpr, TraitSort>, IAssociatedTrait<DeclIndex, MappingDefinition>
            {
                public static SortType Type => SortType.Trait;
                public static TraitSort Sort => TraitSort.MappingExpr;

                public readonly DeclIndex entity;
                public readonly MappingDefinition trait;
            }

            [Tag<TraitSort>(TraitSort.AliasTemplate)]
            public readonly record struct AliasTemplate : ITraitTag<AliasTemplate, TraitSort>, IAssociatedTrait<DeclIndex, SyntaxIndex>
            {
                public static SortType Type => SortType.Trait;
                public static TraitSort Sort => TraitSort.AliasTemplate;

                public readonly DeclIndex entity;
                public readonly SyntaxIndex trait;
            }

            [Tag<TraitSort>(TraitSort.Friends)]
            public readonly record struct Friends : ITraitTag<Friends, TraitSort>, IAssociatedTrait<DeclIndex, Sequence<Declaration>>
            {
                public static SortType Type => SortType.Trait;
                public static TraitSort Sort => TraitSort.Friends;

                public readonly DeclIndex entity;
                public readonly Sequence<Declaration> trait;
            }

            [Tag<TraitSort>(TraitSort.Specializations)]
            public readonly record struct Specializations : ITraitTag<Specializations, TraitSort>, IAssociatedTrait<DeclIndex, Sequence<Declaration>>
            {
                public static SortType Type => SortType.Trait;
                public static TraitSort Sort => TraitSort.Specializations;

                public readonly DeclIndex entity;
                public readonly Sequence<Declaration> trait;
            }

            [Tag<TraitSort>(TraitSort.Requires)]
            public readonly record struct Requires : ITraitTag<Requires, TraitSort>, IAssociatedTrait<DeclIndex, SyntaxIndex>
            {
                public static SortType Type => SortType.Trait;
                public static TraitSort Sort => TraitSort.Requires;

                public readonly DeclIndex entity;
                public readonly SyntaxIndex trait;
            }

            [Tag<TraitSort>(TraitSort.Attributes)]
            public readonly record struct Attributes : ITraitTag<Attributes, TraitSort>, IAssociatedTrait<SyntaxIndex, SyntaxIndex>
            {
                public static SortType Type => SortType.Trait;
                public static TraitSort Sort => TraitSort.Attributes;

                public readonly SyntaxIndex entity;
                public readonly SyntaxIndex trait;
            }

            [Tag<TraitSort>(TraitSort.Deprecated)]
            public readonly record struct Deprecated : ITraitTag<Deprecated, TraitSort>, IAssociatedTrait<DeclIndex, TextOffset>
            {
                public static SortType Type => SortType.Trait;
                public static TraitSort Sort => TraitSort.Deprecated;

                public readonly DeclIndex entity;
                public readonly TextOffset trait;
            }

            [Tag<TraitSort>(TraitSort.DeductionGuides)]
            public readonly record struct DeductionGuides : ITraitTag<DeductionGuides, TraitSort>, IAssociatedTrait<DeclIndex, DeclIndex>
            {
                public static SortType Type => SortType.Trait;
                public static TraitSort Sort => TraitSort.DeductionGuides;

                public readonly DeclIndex entity;
                public readonly DeclIndex trait;
            }

            public readonly record struct LocusSpan
            {
                public readonly SourceLocation begin;
                public readonly SourceLocation end;
            }

            public readonly record struct MsvcLabelProperties
            {
                public readonly MsvcLabelKey key;
                public readonly MsvcLabelType type;
            }

            public readonly record struct MsvcFileBoundaryProperties
            {
                public readonly LineNumber first;
                public readonly LineNumber last;
            }

            public readonly record struct MsvcFileHashData
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
            public readonly record struct MsvcUuid : ITraitTag<MsvcUuid, MsvcTraitSort>, IAssociatedTrait<DeclIndex, StringIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.Uuid;

                public readonly DeclIndex entity;
                public readonly StringIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.Segment)]
            public readonly record struct MsvcSegment : ITraitTag<MsvcSegment, MsvcTraitSort>, IAssociatedTrait<DeclIndex, DeclIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.Segment;

                public readonly DeclIndex entity;
                public readonly DeclIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.SpecializationEncoding)]
            public readonly record struct MsvcSpecializationEncoding : ITraitTag<MsvcSpecializationEncoding, MsvcTraitSort>, IAssociatedTrait<DeclIndex, TextOffset>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.SpecializationEncoding;

                public readonly DeclIndex entity;
                public readonly TextOffset trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.SalAnnotation)]
            public readonly record struct MsvcSalAnnotation : ITraitTag<MsvcSalAnnotation, MsvcTraitSort>, IAssociatedTrait<DeclIndex, TextOffset>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.SalAnnotation;

                public readonly DeclIndex entity;
                public readonly TextOffset trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.FunctionParameters)]
            public readonly record struct MsvcFunctionParameters : ITraitTag<MsvcFunctionParameters, MsvcTraitSort>, IAssociatedTrait<DeclIndex, ChartIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.FunctionParameters;

                public readonly DeclIndex entity;
                public readonly ChartIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.InitializerLocus)]
            public readonly record struct MsvcInitializerLocus : ITraitTag<MsvcInitializerLocus, MsvcTraitSort>, IAssociatedTrait<DeclIndex, SourceLocation>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.InitializerLocus;

                public readonly DeclIndex entity;
                public readonly SourceLocation trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenExpression)]
            public readonly record struct MsvcCodegenExpression : ITraitTag<MsvcCodegenExpression, MsvcTraitSort>, IAssociatedTrait<ExprIndex, ExprIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenExpression;

                public readonly ExprIndex entity;
                public readonly ExprIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.DeclAttributes)]
            public readonly record struct DeclAttributes : ITraitTag<DeclAttributes, MsvcTraitSort>, IAssociatedTrait<DeclIndex, AttrIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.DeclAttributes;

                public readonly DeclIndex entity;
                public readonly AttrIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.StmtAttributes)]
            public readonly record struct StmtAttributes : ITraitTag<StmtAttributes, MsvcTraitSort>, IAssociatedTrait<StmtIndex, AttrIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.StmtAttributes;

                public readonly StmtIndex entity;
                public readonly AttrIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.Vendor)]
            public readonly record struct MsvcVendor : ITraitTag<MsvcVendor, MsvcTraitSort>, IAssociatedTrait<DeclIndex, VendorTraits>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.Vendor;

                public readonly DeclIndex entity;
                public readonly VendorTraits trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenMappingExpr)]
            public readonly record struct MsvcCodegenMappingExpr : ITraitTag<MsvcCodegenMappingExpr, MsvcTraitSort>, IAssociatedTrait<DeclIndex, MappingDefinition>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenMappingExpr;

                public readonly DeclIndex entity;
                public readonly MappingDefinition trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.DynamicInitVariable)]
            public readonly record struct MsvcDynamicInitVariable : ITraitTag<MsvcDynamicInitVariable, MsvcTraitSort>, IAssociatedTrait<DeclIndex, DeclIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.DynamicInitVariable;

                public readonly DeclIndex entity;
                public readonly DeclIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenLabelProperties)]
            public readonly record struct MsvcCodegenLabelProperties : ITraitTag<MsvcCodegenLabelProperties, MsvcTraitSort>, IAssociatedTrait<ExprIndex, MsvcLabelProperties>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenLabelProperties;

                public readonly ExprIndex entity;
                public readonly MsvcLabelProperties trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenSwitchType)]
            public readonly record struct MsvcCodegenSwitchType : ITraitTag<MsvcCodegenSwitchType, MsvcTraitSort>, IAssociatedTrait<StmtIndex, TypeIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenSwitchType;

                public readonly StmtIndex entity;
                public readonly TypeIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.CodegenDoWhileStmt)]
            public readonly record struct MsvcCodegenDoWhileStmt : ITraitTag<MsvcCodegenDoWhileStmt, MsvcTraitSort>, IAssociatedTrait<StmtIndex, StmtIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.CodegenDoWhileStmt;

                public readonly StmtIndex entity;
                public readonly StmtIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.LexicalScopeIndex)]
            public readonly record struct MsvcLexicalScopeIndices : ITraitTag<MsvcLexicalScopeIndices, MsvcTraitSort>, IAssociatedTrait<DeclIndex, MsvcLexicalScopeIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.LexicalScopeIndex;

                public readonly DeclIndex entity;
                public readonly MsvcLexicalScopeIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.FileBoundary)]
            public readonly record struct MsvcFileBoundary : ITraitTag<MsvcFileBoundary, MsvcTraitSort>, IAssociatedTrait<NameIndex, MsvcFileBoundaryProperties>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.FileBoundary;

                public readonly NameIndex entity;
                public readonly MsvcFileBoundaryProperties trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.HeaderUnitSourceFile)]
            public readonly record struct MsvcHeaderUnitSourceFile : ITraitTag<MsvcHeaderUnitSourceFile, MsvcTraitSort>, IAssociatedTrait<TextOffset, NameIndex>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.HeaderUnitSourceFile;

                public readonly TextOffset entity;
                public readonly NameIndex trait;
            }

            [Tag<MsvcTraitSort>(MsvcTraitSort.FileHash)]
            public readonly record struct MsvcFileHash : ITraitTag<MsvcFileHash, MsvcTraitSort>, IAssociatedTrait<NameIndex, MsvcFileHashData>
            {
                public static SortType Type => SortType.MsvcTrait;
                public static MsvcTraitSort Sort => MsvcTraitSort.FileHash;

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

