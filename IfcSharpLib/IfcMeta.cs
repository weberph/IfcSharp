using ifc;
using System.Collections.Frozen;
using System.Reflection;

namespace IfcSharpLib
{
    public enum IndexablePartition
    {
        Names, Decls, Types, Stmts, Exprs, Elements, Forms, Traits, MsvcTraits, Heaps, Macros, PragmaDirectives, Attrs, Dirs
    }

    public static class IfcMeta
    {
        private static FrozenDictionary<Type, Type> _sortTypeByTaggedType = new Dictionary<Type, Type>().ToFrozenDictionary();

        private static IndexablePartition PartitionByType(Type sortType)
        {
            if (sortType == typeof(NameSort))
            {
                return IndexablePartition.Names;
            }

            if (sortType == typeof(DeclSort))
            {
                return IndexablePartition.Decls;
            }

            if (sortType == typeof(TypeSort))
            {
                return IndexablePartition.Types;
            }

            if (sortType == typeof(ExprSort))
            {
                return IndexablePartition.Exprs;
            }

            if (sortType == typeof(SyntaxSort))
            {
                return IndexablePartition.Elements;
            }

            if (sortType == typeof(FormSort))
            {
                return IndexablePartition.Decls;
            }

            if (sortType == typeof(TraitSort))
            {
                return IndexablePartition.Traits;
            }

            if (sortType == typeof(MsvcTraitSort))
            {
                return IndexablePartition.MsvcTraits;
            }

            if (sortType == typeof(HeapSort))
            {
                return IndexablePartition.Heaps;
            }

            if (sortType == typeof(MacroSort))
            {
                return IndexablePartition.Macros;
            }

            if (sortType == typeof(PragmaSort))
            {
                return IndexablePartition.PragmaDirectives;
            }

            if (sortType == typeof(AttrSort))
            {
                return IndexablePartition.Attrs;
            }

            if (sortType == typeof(DirSort))
            {
                return IndexablePartition.Dirs;
            }

            throw new Exception("Unexpected sort type: " + sortType.FullName);
        }

        public static IndexablePartition PartitionByType<T>()
            where T : IHasSort
        {
            if (_sortTypeByTaggedType.TryGetValue(typeof(T), out var sortType))
            {
                return PartitionByType(sortType);
            }

            throw new Exception("Unexpected type: " + typeof(T).FullName);
        }

        public static void Init()
        {
            var sortTypeByTaggedType = new Dictionary<Type, Type>();

            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var tag = type.GetCustomAttribute<TagAttribute>();
                if (tag != null)
                {
                    var sortType = tag.GetType().GenericTypeArguments.First();
                    sortTypeByTaggedType.Add(type, sortType);
                }
            }

            _sortTypeByTaggedType = sortTypeByTaggedType.ToFrozenDictionary();
        }
    }

    //static class MemoryCast
    //{
    //    public static Memory<TTo> Cast<TFrom, TTo>(Memory<TFrom> from)
    //        where TFrom : unmanaged
    //        where TTo : unmanaged
    //    {
    //        // avoid the extra allocation/indirection, at the cost of a gen-0 box
    //        if (typeof(TFrom) == typeof(TTo)) return (Memory<TTo>)(object)from;

    //        return new CastMemoryManager<TFrom, TTo>(from).Memory;
    //    }

    //    private sealed class CastMemoryManager<TFrom, TTo> : MemoryManager<TTo>
    //        where TFrom : unmanaged
    //        where TTo : unmanaged
    //    {
    //        private readonly Memory<TFrom> _from;

    //        public CastMemoryManager(Memory<TFrom> from) => _from = from;

    //        public override Span<TTo> GetSpan() => MemoryMarshal.Cast<TFrom, TTo>(_from.Span);

    //        protected override void Dispose(bool disposing) { }
    //        public override MemoryHandle Pin(int elementIndex = 0) => throw new NotSupportedException();
    //        public override void Unpin() => throw new NotSupportedException();
    //    }
    //}
}
