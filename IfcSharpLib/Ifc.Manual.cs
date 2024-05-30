namespace ifc
{
    public readonly struct Sequence<T>(Index start_, Cardinality cardinality_)
    {
        public readonly Index start = start_;
        public readonly Cardinality cardinality = cardinality_;
    }

    public readonly struct Identity<T>
    {
        public readonly T name;
        public readonly symbolic.SourceLocation locus;
    }
}
