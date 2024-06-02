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
        Scope,
        Count
    }

    public interface ITag
    {
        static abstract byte Sort { get; }

        static abstract SortType Type { get; }
    }

    public interface ITag<TImpl, T> : ITag
        where T : unmanaged, Enum
        where TImpl : struct, ITag<TImpl, T>
    {
        static byte ITag.Sort => Unsafe.BitCast<T, byte>(TImpl.Sort);
        static new abstract T Sort { get; }
    }

    public interface IAssociatedTrait<TKey, TValue>
        where TKey : struct
        where TValue : struct
    {
        //TKey entity { get; }
        //TValue value { get; }
    }

    public interface ITraitTag : ITag
    {
    }

    public interface ITraitTag<TImpl, T> : ITag<TImpl, T>, ITraitTag
        where T : unmanaged, Enum
        where TImpl : struct, ITag<TImpl, T>
    {
    }

    public interface ISequence<TElem>
        where TElem : struct
    {
        Sequence<TElem> Sequence { get; }
    }

    public interface ITaggedSequence<TImpl, TElem, T> : ISequence<TElem>
        where TElem : struct
        where T : unmanaged, Enum
        where TImpl : ITaggedSequence<TImpl, TElem, T>
    {
        static abstract SortType SequenceType { get; }
        static abstract T SequenceSort { get; }
    }

    public interface IOver
    {
        Index Index { get; }
        bool IsNull { get; }
        byte UntypedSort { get; }

        static abstract SortType Type { get; }
    }

    public interface IOver<TImpl> : IOver
        where TImpl : struct, IOver<TImpl>
    {
    }

    public interface IOver<TImpl, T> : IOver<TImpl>
        where T : unmanaged, Enum
        where TImpl : struct, IOver<TImpl, T>
    {
        T Sort { get; }

        byte IOver.UntypedSort => Unsafe.BitCast<T, byte>(Sort);

        static abstract TImpl Create(T sort, Index index);
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
