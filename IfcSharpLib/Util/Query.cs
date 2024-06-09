using ifc;

namespace IfcSharpLib.Util
{
    public readonly ref struct RefType<T, TSort>(ref readonly T value)
        where T : struct, ITag<T, TSort>
        where TSort : unmanaged, Enum
    {
        private readonly ref readonly T _value = ref value;
        public ref readonly T Value => ref _value;
    }

    public readonly struct QueryIndex<TIndex, TSort>(Reader reader, TIndex index)
        where TIndex : struct, IOver<TIndex, TSort>
        where TSort : unmanaged, Enum
    {
        public ref readonly T Get<T>()
            where T : struct, ITag<T, TSort>
        {
            return ref reader.GetGeneric<T, TSort, TIndex>(index);
        }

        public FluentQuery Get<T>(out T result)
            where T : struct, ITag<T, TSort>
        {
            result = Get<T>();
            return new(reader);
        }

        public FluentQuery GetRef<T>(out RefType<T, TSort> result)
            where T : struct, ITag<T, TSort>
        {
            result = new(in Get<T>());
            return new(reader);
        }
    }

    public readonly struct FluentQuery(Reader reader)
    {
        public QueryIndex<TIndex, TSort> Query<TIndex, TSort>(IOver<TIndex, TSort> index)
            where TIndex : struct, IOver<TIndex, TSort>
            where TSort : unmanaged, Enum
        {
            return new(reader, (TIndex)index);
        }

        public QueryIndex<ExprIndex, ExprSort> Query(ExprIndex index) => new(reader, index);

        public ReadOnlySpan<T> Sequence<TImpl, T, TSort>(in ITaggedSequence<TImpl, T, TSort> taggedSequence)
            where T : struct
            where TSort : unmanaged, Enum
            where TImpl : struct, ITaggedSequence<TImpl, T, TSort>
        {
            return reader.Sequence(in taggedSequence);
        }
    }

    public static class ReaderQueryExtensions
    {
        public static QueryIndex<TIndex, TSort> Query<TIndex, TSort>(this Reader reader, IOver<TIndex, TSort> index)
            where TIndex : struct, IOver<TIndex, TSort>
            where TSort : unmanaged, Enum
        {
            return new QueryIndex<TIndex, TSort>(reader, (TIndex)index);
        }

        public static QueryIndex<ExprIndex, ExprSort> Query(this Reader reader, ExprIndex index) => new(reader, index);
    }
}
