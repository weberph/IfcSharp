#pragma warning disable CA1051 // Do not declare visible instance fields

namespace ifc
{
    public readonly struct Sequence<T>(Index start, Cardinality cardinality)
    {
        public readonly Index start = start;
        public readonly Cardinality cardinality = cardinality;
    }

    public readonly struct Identity<T>
    {
        public readonly T name;
        public readonly symbolic.SourceLocation locus;
    }
}
