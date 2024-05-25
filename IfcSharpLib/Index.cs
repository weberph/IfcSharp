namespace ifc
{
    public enum Index : uint { }

    public enum SortType
    {
        String,
        Name,
        Chart,
        Decl,
        Type,
        Syntax,
        Literal,
        Stmt,
        Expr,
        Macro,
        Pragma,
        Attr,
        Dir,
        Unit,
        Form,
        Trait,
        MsvcTrait,
        Heap,
        Scope
    }

    public interface IHasSort
    {
        static abstract int Sort { get; }

        static abstract SortType Type { get; }
    }

    public interface IHasSort<T> : IHasSort where T : Enum
    {
    }

    public interface IOver
    {
        Index Index { get; }
        bool IsNull { get; }
    }

    public interface IOver<T> : IOver
    {
        T Sort { get; }

        static abstract SortType Type { get; }
    }


    public class OverAttribute : Attribute { }

    public class OverAttribute<T> : OverAttribute { }

    public class TagAttribute : Attribute { }

    public class TagAttribute<T>(T sort) : TagAttribute { public T Sort { get; } = sort; }
}
