using System.Runtime.CompilerServices;

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

    public interface ITag
    {
        static abstract byte Sort { get; }

        static abstract SortType Type { get; }
    }

    public interface ITag<TImpl, T> : ITag
        where T : unmanaged, Enum
        where TImpl : ITag<TImpl, T>
    {
        static byte ITag.Sort => Unsafe.BitCast<T, byte>(TImpl.Sort);
        static new abstract T Sort { get; }
    }

    public interface IOver
    {
        Index Index { get; }
        bool IsNull { get; }
        byte UntypedSort { get; }

        static abstract SortType Type { get; }
    }

    public interface IOver<T> : IOver where T : unmanaged, Enum
    {
        T Sort { get; }

        byte IOver.UntypedSort => Unsafe.BitCast<T, byte>(Sort);
    }

    [AttributeUsage(AttributeTargets.Struct)]
    public class OverAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Struct)]
    public class OverAttribute<T> : OverAttribute { }

    [AttributeUsage(AttributeTargets.Struct)]
    public class TagAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Struct)]
    public class TagAttribute<T>(T sort) : TagAttribute { public T Sort { get; } = sort; }
}
