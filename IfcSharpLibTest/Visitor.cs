using ifc;
using IfcSharpLib;
using System.Runtime.CompilerServices;

namespace IfcSharpLibTest
{
    internal readonly struct ChildIndex(SortType type, ifc.Index index)
    {
        public readonly SortType Type = type;
        public readonly ifc.Index Index = index;

        public static ChildIndex Create<T>(T index)
            where T : struct, IOver
        {
            return new(T.Type, Unsafe.BitCast<T, ifc.Index>(index));
        }

        public T To<T>()
            where T : struct, IOver
        {
            return Unsafe.BitCast<ifc.Index, T>(Index);
        }
    }

    internal partial class TestVisitor(Reader reader)
    {
        private readonly Reader _reader = reader;

        private readonly Stack<ChildIndex> _stack = [];
        private readonly HashSet<int>[] _visited = new HashSet<int>[(int)SortType.Count];

        public void Start<T>(T index)
            where T : struct, IOver
        {
            for (int i = 0; i < _visited.Length; i++)
            {
                _visited[i] ??= [];
                _visited[i].Clear();
            }

            AddChild(index);

            while (_stack.TryPop(out var next))
            {
                Dispatch(next);
            }
        }

        private void AddChild<T>(T index)
            where T : struct, IOver
        {
            if (!index.IsNull)
            {
                if (_visited[(int)T.Type].Add(index.GetHashCode()))
                {
                    _stack.Push(ChildIndex.Create(index));
                }
            }
        }

        partial void Dispatch(ChildIndex childIndex);
    }
}
