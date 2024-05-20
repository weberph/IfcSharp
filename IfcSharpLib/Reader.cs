using ifc;
using System.Buffers.Binary;
using System.Runtime.InteropServices;
using System.Text;

namespace IfcSharpLib
{
    public class Reader
    {
        private static readonly uint InterfaceSignatureBe = 0x5451451A;

        private readonly ReadOnlyMemory<byte> _memory;
        private readonly ReadOnlyMemory<byte> _tocMemory;
        private readonly ReadOnlyMemory<byte> _stringMemory;

        private ReadOnlySpan<PartitionSummaryData> PartitionTables => MemoryMarshal.Cast<byte, PartitionSummaryData>(_tocMemory.Span);

        private Header _header;
        private TableOfContents _toc;

        public Reader(string file)
        {
            _memory = File.ReadAllBytes(file);

            var span = _memory.Span;
            if (BinaryPrimitives.ReadUInt32BigEndian(span) != InterfaceSignatureBe)
            {
                throw new Exception("Invalid ifc signature");
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

        public ref readonly T Get<T, U>(IOver<U> index) where T : struct, IHasSort<U> where U : Enum
        {
            return ref Partition<T>()[(int)index.Index];
        }

        public ReadOnlySpan<T> Sequence<T>(Sequence<T> sequence) where T : struct, IHasSort
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

        public ref readonly PartitionSummaryData PartitionSummary<T>()
            where T : struct, IHasSort
        {
            var indexablePartition = IfcMeta.PartitionByType<T>();

            switch (indexablePartition)
            {
                case IndexablePartition.Names: return ref _toc.names[T.Sort];
                case IndexablePartition.Decls: return ref _toc.decls[T.Sort];
                case IndexablePartition.Types: return ref _toc.types[T.Sort];
                case IndexablePartition.Stmts: return ref _toc.states;
                case IndexablePartition.Exprs: return ref _toc.exprs[T.Sort];
                case IndexablePartition.Elements: return ref _toc.elements[T.Sort];
                case IndexablePartition.Forms: return ref _toc.forms[T.Sort];
                case IndexablePartition.Traits: return ref _toc.traits[T.Sort];
                case IndexablePartition.MsvcTraits: return ref _toc.msvc_traits[T.Sort];
                case IndexablePartition.Heaps: return ref _toc.heaps[T.Sort];
                case IndexablePartition.Macros: return ref _toc.macros[T.Sort];
                case IndexablePartition.PragmaDirectives: return ref _toc.pragma_directives[T.Sort];
                case IndexablePartition.Attrs: return ref _toc.attrs[T.Sort];
                case IndexablePartition.Dirs: return ref _toc.dirs[T.Sort];
                default:
                    throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }

        public ReadOnlySpan<T> Partition<T>()
            where T : struct, IHasSort
        {
            ref readonly var summary = ref PartitionSummary<T>();
            var size = (int)summary.cardinality * Marshal.SizeOf<T>();
            return MemoryMarshal.Cast<byte, T>(_memory.Span.Slice((int)summary.offset, size));
        }
    }
}
