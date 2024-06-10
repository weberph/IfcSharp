#pragma warning disable CA1051 // Do not declare visible instance fields

namespace ifc
{
    public readonly record struct Sequence<T>(Index start, Cardinality cardinality)
        where T : struct
    {
        public readonly Index start = start;
        public readonly Cardinality cardinality = cardinality;
    }

    public readonly record struct Identity<T>
        where T : struct
    {
        public readonly T name;
        public readonly symbolic.SourceLocation locus;
    }
}
