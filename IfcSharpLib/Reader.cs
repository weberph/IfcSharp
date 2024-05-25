using ifc;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace IfcSharpLib
{
    public sealed class InvalidIfcFileSignatureException() : Exception("Invalid ifc signature") { }

    public class Reader
    {
        private static readonly uint InterfaceSignatureBe = 0x5451451A;

        private readonly ReadOnlyMemory<byte> _memory;
        private readonly ReadOnlyMemory<byte> _tocMemory;
        private readonly ReadOnlyMemory<byte> _stringMemory;
        private readonly Header _header;
        private readonly TableOfContents _toc;

        private ReadOnlySpan<PartitionSummaryData> PartitionTables => MemoryMarshal.Cast<byte, PartitionSummaryData>(_tocMemory.Span);

        public Reader(string file)
        {
            _memory = File.ReadAllBytes(file);

            var span = _memory.Span;
            if (BinaryPrimitives.ReadUInt32BigEndian(span) != InterfaceSignatureBe)
            {
                throw new InvalidIfcFileSignatureException();
            }

            var offset = 4;
            var headerSize = Marshal.SizeOf<Header>();
            _header = MemoryMarshal.Cast<byte, Header>(span.Slice(offset, headerSize))[0];

            var tocSize = (int)_header.partition_count * Marshal.SizeOf<PartitionSummaryData>();
            _tocMemory = _memory.Slice((int)_header.toc, tocSize);

            _stringMemory = _memory.Slice((int)_header.string_table_bytes, (int)_header.string_table_size);

            var tables = PartitionTables;
            foreach (var summary in tables)
            {
                TocMapping.SetSummaryByName(ref _toc, GetString(summary.name), summary);
            }
        }

        public ReadOnlySpan<T> Partition<T>()
            where T : struct, IHasSort
        {
            ref readonly var summary = ref PartitionSummary<T>();
            var size = (int)summary.cardinality * Marshal.SizeOf<T>();
            return MemoryMarshal.Cast<byte, T>(_memory.Span.Slice((int)summary.offset, size));
        }

        public ref readonly T Get<T>(TypeIndex index)
            where T : struct, IHasSort<TypeSort>
        {
            return ref Partition<T>(_toc.types[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(DeclIndex index)
            where T : struct, IHasSort<DeclSort>
        {
            return ref Partition<T>(_toc.decls[(int)index.Sort])[(int)index.Index];
        }

        public ReadOnlySpan<T> Sequence<T>(Sequence<T> sequence)
            where T : struct, IHasSort
        {
            return Partition<T>().Slice((int)sequence.start, (int)sequence.cardinality);
        }

        public string GetString(TextOffset index)
        {
            var span = _stringMemory.Span[(int)index..];
            return Encoding.UTF8.GetString(span[..span.IndexOf((byte)0)]);
        }

        public string GetString(Identity<TextOffset> index)
        {
            return GetString(index.name);
        }

        public string GetString(Identity<NameIndex> index)
        {
            if (index.name.Sort != NameSort.Identifier)
            {
                throw new NotImplementedException("TODO: NameIndex");
            }

            return GetString((TextOffset)index.name.Index);
        }

        private ReadOnlySpan<T> Partition<T>(in PartitionSummaryData summary)
            where T : struct, IHasSort
        {
            Debug.Assert(Marshal.SizeOf<T>() == (int)summary.entry_size);
            var size = (int)summary.cardinality * (int)summary.entry_size;
            return MemoryMarshal.Cast<byte, T>(_memory.Span.Slice((int)summary.offset, size));
        }

        private ref readonly PartitionSummaryData PartitionSummary<T>()
            where T : struct, IHasSort
        {
            switch (T.Type)
            {
                case SortType.Name: return ref _toc.names[T.Sort];
                case SortType.Decl: return ref _toc.decls[T.Sort];
                case SortType.Type: return ref _toc.types[T.Sort];
                case SortType.Stmt: return ref _toc.stmts[T.Sort];
                case SortType.Expr: return ref _toc.exprs[T.Sort];
                case SortType.Syntax: return ref _toc.elements[T.Sort];
                case SortType.Form: return ref _toc.forms[T.Sort];
                case SortType.Trait: return ref _toc.traits[T.Sort];
                case SortType.MsvcTrait: return ref _toc.msvc_traits[T.Sort];
                case SortType.Heap: return ref _toc.heaps[T.Sort];
                case SortType.Macro: return ref _toc.macros[T.Sort];
                case SortType.Pragma: return ref _toc.pragma_directives[T.Sort];
                case SortType.Attr: return ref _toc.attrs[T.Sort];
                case SortType.Dir: return ref _toc.dirs[T.Sort];
                case SortType.String: return ref _toc.string_literals;
                case SortType.Scope: return ref _toc.scopes;
                case SortType.Chart when ((ChartSort)T.Sort == ChartSort.Unilevel): return ref _toc.charts;
                case SortType.Chart when ((ChartSort)T.Sort == ChartSort.Multilevel): return ref _toc.multi_charts;
                case SortType.Literal when ((LiteralSort)T.Sort == LiteralSort.Integer): return ref _toc.u64s;
                case SortType.Literal when ((LiteralSort)T.Sort == LiteralSort.FloatingPoint): return ref _toc.fps;
            }
            throw new NotImplementedException();
        }
    }
}
