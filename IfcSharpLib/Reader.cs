using ifc;
using ifc.symbolic;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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

            var headerSize = Marshal.SizeOf<Header>();
            _header = MemoryMarshal.Cast<byte, Header>(span.Slice(4, headerSize))[0];

            var tocSize = (int)_header.partition_count * Marshal.SizeOf<PartitionSummaryData>();
            _tocMemory = _memory.Slice((int)_header.toc, tocSize);

            _stringMemory = _memory.Slice((int)_header.string_table_bytes, (int)_header.string_table_size);

            var tables = PartitionTables;
            foreach (var summary in tables)
            {
                TocMapping.SetSummaryByName(ref _toc, GetString(summary.name), summary);
            }
        }

        public ref readonly T Get<T>(TypeIndex index)
            where T : struct, ITag<T, TypeSort>
        {
            return ref Partition<T>(_toc.types[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(DeclIndex index)
            where T : struct, ITag<T, DeclSort>
        {
            return ref Partition<T>(_toc.decls[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(NameIndex index)
            where T : struct, ITag<T, NameSort>
        {
            ArgumentOutOfRangeException.ThrowIfEqual((byte)index.Sort, (byte)NameSort.Identifier, nameof(index));
            return ref Partition<T>(_toc.names[(int)index.Sort - 1])[(int)index.Index];
        }

        public ReadOnlySpan<T> Sequence<T>(Sequence<T> sequence)
            where T : struct, ITag
        {
            return Partition<T>().Slice((int)sequence.start, (int)sequence.cardinality);
        }

        public LiteralSort GetLiteral(LitIndex index, out ulong integer, out double fp)
        {
            (integer, fp) = index.Sort switch
            {
                LiteralSort.Immediate => ((ulong)index.Index, 0.0),
                LiteralSort.Integer => (Partition<ulong>(_toc.u64s)[(int)index.Index], 0.0),
                LiteralSort.FloatingPoint => (0UL, (Partition<FloatingPointLiteral>(_toc.fps)[(int)index.Index]).Value),
                _ => throw new ArgumentException("Invalid LiteralSort", nameof(index))
            };

            return index.Sort;
        }

        public string GetString(StringIndex index)
        {
            var literal = Partition<StringLiteral>(_toc.string_literals)[(int)index.Index];
            var span = _stringMemory.Span.Slice((int)literal.start, (int)literal.size);
            return index.Sort switch
            {
                StringSort.Ordinary or StringSort.UTF8 => Encoding.UTF8.GetString(span[..^1]),
                StringSort.UTF16 or StringSort.Wide => Encoding.Unicode.GetString(span[..^2]),
                StringSort.UTF32 => Encoding.UTF32.GetString(span[..^4]),
                _ => throw new ArgumentException("Invalid StringSort", nameof(index))
            };
        }

        public string GetString(TextOffset index)
        {
            var span = _stringMemory.Span[(int)index..];
            return Encoding.UTF8.GetString(span[..span.IndexOf((byte)0)]);
        }

        public string GetString(Identity<TextOffset> identity)
        {
            return GetString(identity.name);
        }

        public string GetString(NameIndex index)
        {
            if (index.Sort == NameSort.Guide)
            {
                return "<GuideName>"; // "TODO: complicated." -- ifc/test/basic.cxx
            }

            TextOffset GetTextOffset(NameIndex index_) => index_.Sort switch
            {
                NameSort.Identifier => (TextOffset)index_.Index,
                NameSort.Operator => Get<OperatorFunctionId>(index_).name,
                NameSort.Conversion => Get<ConversionFunctionId>(index_).name,
                NameSort.Literal => Get<LiteralOperatorId>(index_).name_index,
                NameSort.Template => GetTextOffset(Get<TemplateName>(index_).name),
                NameSort.Specialization => GetTextOffset(Get<SpecializationName>(index_).primary_template),
                NameSort.SourceFile => Get<SourceFileName>(index_).name,
                // NameSort.Guide => handled above
                _ => throw new ArgumentException("Invalid NameSort", nameof(index))
            };

            return GetString(GetTextOffset(index));
        }

        public string GetString(Identity<NameIndex> identity)
        {
            return GetString(identity.name);
        }

        public ReadOnlySpan<T> Partition<T>()
            where T : struct, ITag
        {
            return Partition<T>(PartitionSummary<T>());
        }

        private ReadOnlySpan<T> Partition<T>(in PartitionSummaryData summary)
            where T : struct
        {
            Debug.Assert(Marshal.SizeOf<T>() == (int)summary.entry_size || summary.cardinality == 0);
            var size = (int)summary.cardinality * (int)summary.entry_size;
            return MemoryMarshal.Cast<byte, T>(_memory.Span.Slice((int)summary.offset, size));
        }

        private ref readonly PartitionSummaryData PartitionSummary<T>()
            where T : struct, ITag
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
                case SortType.Scope: return ref _toc.scopes;
                case SortType.Chart when ((ChartSort)T.Sort == ChartSort.Unilevel): return ref _toc.charts;
                case SortType.Chart when ((ChartSort)T.Sort == ChartSort.Multilevel): return ref _toc.multi_charts;

                // remove? there are no types tagged with LiteralSort or StringSort
                case SortType.String: return ref _toc.string_literals;
                case SortType.Literal when ((LiteralSort)T.Sort == LiteralSort.Integer): return ref _toc.u64s;
                case SortType.Literal when ((LiteralSort)T.Sort == LiteralSort.FloatingPoint): return ref _toc.fps;
            }
            throw new NotImplementedException();
        }

        // for testing
        public ref readonly T GetGeneric<T, U, TOver>(TOver index)
            where T : struct, ITag<T, U>
            where U : unmanaged, Enum
            where TOver : IOver<U>
        {
#if DEBUG
            // The following check should never fail due to type constraints
            if (TOver.Type != T.Type || Unsafe.BitCast<U, byte>(index.Sort) != Unsafe.BitCast<U, byte>(T.Sort)) // avoid BitCast?
            {
                throw new SortMismatchException($"Sort mismatch: requested type/sort {T.Type}/{T.Sort} using index of type/sort {TOver.Type}/{index.Sort}");
            }
#endif

            return ref Partition<T>()[(int)index.Index];
        }

        public T[] SequenceAsArray<T>(Sequence<T> sequence)
            where T : struct, ITag
        {
            return [.. Sequence(sequence)];
        }

        public T[] PartitionAsArray<T>()
            where T : struct, ITag
        {
            return [.. Partition<T>(PartitionSummary<T>())];
        }
    }

    /// <summary>
    /// The first 8 bytes represent a 64-bit floating point value, in IEEE 754 little endian format.
    /// The remaining 4 bytes have indeterminate values.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal readonly struct FloatingPointLiteral
    {
        public readonly double Value;
        public readonly uint Indeterminate;
    }

    public sealed class SortMismatchException(string message) : Exception(message) { }
}
