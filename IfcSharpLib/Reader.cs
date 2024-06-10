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
    public sealed class SortMismatchException(string message) : Exception(message) { }

    public class Reader
    {
        private static readonly uint InterfaceSignatureBe = 0x5451451A;

        private readonly ReadOnlyMemory<byte> _memory;
        private readonly ReadOnlyMemory<byte> _tocMemory;
        private readonly ReadOnlyMemory<byte> _stringMemory;
        private readonly Header _header;
        private readonly TableOfContents _toc;
        private readonly Dictionary<StringIndex, string> _stringIndexCache = [];
        private readonly Dictionary<NameIndex, string> _nameIndexCache = [];
        private readonly Dictionary<TextOffset, string> _textOffsetCache = [];

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
            return ref Partition<T>(in _toc.types[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(DeclIndex index)
            where T : struct, ITag<T, DeclSort>
        {
            return ref Partition<T>(in _toc.decls[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(SyntaxIndex index)
            where T : struct, ITag<T, SyntaxSort>
        {
            return ref Partition<T>(in _toc.elements[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(StmtIndex index)
            where T : struct, ITag<T, StmtSort>
        {
            return ref Partition<T>(in _toc.stmts[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(ExprIndex index)
            where T : struct, ITag<T, ExprSort>
        {
            return ref Partition<T>(in _toc.exprs[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(PragmaIndex index)
            where T : struct, ITag<T, PragmaSort>
        {
            return ref Partition<T>(in _toc.pragma_directives[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(MacroIndex index)
            where T : struct, ITag<T, MacroSort>
        {
            return ref Partition<T>(in _toc.macros[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(AttrIndex index)
            where T : struct, ITag<T, AttrSort>
        {
            return ref Partition<T>(in _toc.attrs[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(DirIndex index)
            where T : struct, ITag<T, DirSort>
        {
            return ref Partition<T>(in _toc.dirs[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(FormIndex index)
            where T : struct, ITag<T, FormSort>
        {
            return ref Partition<T>(in _toc.forms[(int)index.Sort])[(int)index.Index];
        }

        public ref readonly T Get<T>(ChartIndex index)
            where T : struct, ITag<T, ChartSort>
        {
            switch (index.Sort)
            {
                case ChartSort.Unilevel: return ref Partition<T>(in _toc.charts)[(int)index.Index];
                case ChartSort.Multilevel: return ref Partition<T>(in _toc.multi_charts)[(int)index.Index];
            }

            throw new ArgumentOutOfRangeException(nameof(index));
        }

        public ref readonly T Get<T>(NameIndex index)
            where T : struct, ITag<T, NameSort>
        {
            ArgumentOutOfRangeException.ThrowIfEqual((byte)index.Sort, (byte)NameSort.Identifier, nameof(index));
            return ref Partition<T>(in _toc.names[(int)index.Sort - 1])[(int)index.Index];
        }

        public ref readonly FileAndLine Get(LineIndex index)
        {
            return ref Partition<FileAndLine>(in _toc.lines)[(int)index];
        }

        public ref readonly Word Get(WordIndex index)
        {
            return ref Partition<Word>(in _toc.words)[(int)index];
        }

        public ref readonly WordSequence Get(SentenceIndex index)
        {
            return ref Partition<WordSequence>(in _toc.sentences)[(int)index];
        }

        public ref readonly SpecializationForm Get(SpecFormIndex index)
        {
            return ref Partition<SpecializationForm>(in _toc.spec_forms)[(int)index];
        }

        public TIndex IndexOf<TIndex, TSort, T>(in T type)
            where T : struct, ITag<T, TSort>
            where TSort : unmanaged, Enum
            where TIndex : struct, IOver<TIndex, TSort>
        {
            byte sort = Unsafe.BitCast<TSort, byte>(T.Sort);
            ref readonly var summary = ref PartitionSummary(T.Type, sort);

            Debug.Assert(Marshal.SizeOf<T>() == (int)summary.entry_size);

            var size = (int)summary.cardinality * (int)summary.entry_size;
            var span = MemoryMarshal.Cast<byte, T>(_memory.Span.Slice((int)summary.offset, size));

            var offset = Unsafe.ByteOffset(in span[0], in type);
            if (offset < 0 || offset > size)
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }

            Debug.Assert(offset % (int)summary.entry_size == 0);
            return TIndex.Create(T.Sort, (ifc.Index)(offset / (int)summary.entry_size));
        }

        public void IndexOf<T, TIndex>(in T type, out TIndex index)
            where T : struct, ITag
            where TIndex : struct, IOver<TIndex>
        {
            ref readonly var summary = ref PartitionSummary(T.Type, T.Sort);

            Debug.Assert(Marshal.SizeOf<T>() == (int)summary.entry_size);

            var size = (int)summary.cardinality * (int)summary.entry_size;
            var span = MemoryMarshal.Cast<byte, T>(_memory.Span.Slice((int)summary.offset, size));

            var offset = Unsafe.ByteOffset(in span[0], in type);
            if (offset < 0 || offset > size)
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }

            Debug.Assert(offset % (int)summary.entry_size == 0);
            index = TIndex.Create(T.Sort, (ifc.Index)(offset / (int)summary.entry_size));
        }

        public ReadOnlySpan<T> Sequence<T>(Sequence<T> sequence)
            where T : struct, ITag
        {
            return Partition<T>().Slice((int)sequence.start, (int)sequence.cardinality);
        }

        public ReadOnlySpan<T> Sequence<T>(ISequence<T> sequence) where T : struct, ITag => Sequence(sequence.Sequence);

        public ReadOnlySpan<T> Sequence<TImpl, T, TSort>(in ITaggedSequence<TImpl, T, TSort> taggedSequence)
            where T : struct
            where TSort : unmanaged, Enum
            where TImpl : struct, ITaggedSequence<TImpl, T, TSort>
        {
            var sequence = taggedSequence.Sequence;
            return Partition<T>(in PartitionSummary(TImpl.SequenceType, Unsafe.BitCast<TSort, byte>(TImpl.SequenceSort)))
                   .Slice((int)sequence.start, (int)sequence.cardinality);
        }

        public ReadOnlySpan<T> Sequence<TImpl, T, TSort>(ref readonly TImpl taggedSequence)
            where T : struct
            where TSort : unmanaged, Enum
            where TImpl : struct, ITaggedSequence<TImpl, T, TSort>
        {
            var sequence = taggedSequence.Sequence;
            return Partition<T>(in PartitionSummary(TImpl.SequenceType, Unsafe.BitCast<TSort, byte>(TImpl.SequenceSort)))
                   .Slice((int)sequence.start, (int)sequence.cardinality);
        }

        public LiteralSort GetLiteral(LitIndex index, out ulong integer, out double fp)
        {
            (integer, fp) = index.Sort switch
            {
                LiteralSort.Immediate => ((ulong)index.Index, 0.0),
                LiteralSort.Integer => (Partition<ulong>(_toc.u64s)[(int)index.Index], 0.0),
                LiteralSort.FloatingPoint => (0UL, (Partition<LiteralReal>(_toc.fps)[(int)index.Index]).value),
                _ => throw new ArgumentException("Invalid LiteralSort", nameof(index))
            };

            return index.Sort;
        }

        public string GetString(StringIndex index)
        {
            if (_stringIndexCache.TryGetValue(index, out var cached))
            {
                return cached;
            }

            var literal = Partition<StringLiteral>(_toc.string_literals)[(int)index.Index];
            var span = _stringMemory.Span.Slice((int)literal.start, (int)literal.size);
            var str = index.Sort switch
            {
                StringSort.Ordinary or StringSort.UTF8 => Encoding.UTF8.GetString(span[..^1]),
                StringSort.UTF16 or StringSort.Wide => Encoding.Unicode.GetString(span[..^2]),
                StringSort.UTF32 => Encoding.UTF32.GetString(span[..^4]),
                _ => throw new ArgumentException("Invalid StringSort", nameof(index))
            };
            _stringIndexCache.Add(index, str);
            return str;
        }

        public string GetString(TextOffset index)
        {
            if (_textOffsetCache.TryGetValue(index, out var cached))
            {
                return cached;
            }

            var span = _stringMemory.Span[(int)index..];
            var str = Encoding.UTF8.GetString(span[..span.IndexOf((byte)0)]);
            _textOffsetCache.Add(index, str);
            return str;
        }

        public string GetString(NameIndex index)
        {
            if (index.Sort == NameSort.Guide)
            {
                return "<GuideName>"; // "TODO: complicated." -- ifc/test/basic.cxx
            }

            if (_nameIndexCache.TryGetValue(index, out var cached))
            {
                return cached;
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

            var str = GetString(GetTextOffset(index));
            _nameIndexCache.Add(index, str);
            return str;
        }
        public string GetString(Identity<TextOffset> identity)
        {
            return GetString(identity.name);
        }

        public string GetString(Identity<NameIndex> identity)
        {
            return GetString(identity.name);
        }

        public ReadOnlySpan<StringIndex> CommandLine() => Partition<StringIndex>(in _toc.command_line);
        public ReadOnlySpan<ModuleReference> ExportedModules() => Partition<ModuleReference>(in _toc.exported_modules);
        public ReadOnlySpan<ModuleReference> ImportedModules() => Partition<ModuleReference>(in _toc.imported_modules);
        public ReadOnlySpan<Scope> Scopes() => Partition<Scope>(in _toc.scopes);
        public ReadOnlySpan<Declaration> Declarations() => Partition<Declaration>(in _toc.entities);
        public ReadOnlySpan<Declaration> Declarations(Sequence<Declaration> sequence) => Declarations().Slice((int)sequence.start, (int)sequence.cardinality);
        public ReadOnlySpan<PragmaWarningRegion> PragmaWarnings() => Partition<PragmaWarningRegion>(in _toc.suppressed_warnings);
        public ReadOnlySpan<PragmaPushState> States() => Partition<PragmaPushState>(in _toc.states);
        public ReadOnlySpan<PragmaIndex> ImplementationPragmas() => Partition<PragmaIndex>(in _toc.implementation_pragmas);

        public ReadOnlySpan<T> Partition<T>()
            where T : struct, ITag
        {
            return Partition<T>(PartitionSummary<T>());
        }

        private ReadOnlySpan<T> Partition<T>(in PartitionSummaryData summary)
            where T : struct
        {
            Debug.Assert(summary.cardinality == 0
                || (typeof(T) is { IsEnum: true } enumType && Marshal.SizeOf(enumType.GetEnumUnderlyingType()) == (int)summary.entry_size)
                || Marshal.SizeOf<T>() == (int)summary.entry_size);

            var size = (int)summary.cardinality * (int)summary.entry_size;
            return MemoryMarshal.Cast<byte, T>(_memory.Span.Slice((int)summary.offset, size));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref readonly PartitionSummaryData PartitionSummary<T>()
            where T : struct, ITag
        {
            return ref PartitionSummary(T.Type, T.Sort);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref readonly PartitionSummaryData PartitionSummary(SortType type, byte sort)
        {
            switch (type)
            {
                case SortType.Name: return ref _toc.names[sort];
                case SortType.Decl: return ref _toc.decls[sort];
                case SortType.Type: return ref _toc.types[sort];
                case SortType.Stmt: return ref _toc.stmts[sort];
                case SortType.Expr: return ref _toc.exprs[sort];
                case SortType.Syntax: return ref _toc.elements[sort];
                case SortType.Form: return ref _toc.forms[sort];
                case SortType.Trait: return ref _toc.traits[sort];
                case SortType.MsvcTrait: return ref _toc.msvc_traits[sort];
                case SortType.Heap: return ref _toc.heaps[sort];
                case SortType.Macro: return ref _toc.macros[sort];
                case SortType.Pragma: return ref _toc.pragma_directives[sort];
                case SortType.Attr: return ref _toc.attrs[sort];
                case SortType.Dir: return ref _toc.dirs[sort];
                case SortType.Chart when ((ChartSort)sort == ChartSort.Unilevel): return ref _toc.charts;
                case SortType.Chart when ((ChartSort)sort == ChartSort.Multilevel): return ref _toc.multi_charts;

                // remove? there are no types tagged with that index
                case SortType.Scope: return ref _toc.scopes;
                case SortType.String: return ref _toc.string_literals;
                case SortType.Literal when ((LiteralSort)sort == LiteralSort.Integer): return ref _toc.u64s;
                case SortType.Literal when ((LiteralSort)sort == LiteralSort.FloatingPoint): return ref _toc.fps;
                case SortType.Unit: throw new NotImplementedException(); // only used in Header
            }
            throw new NotImplementedException();
        }

        public ReadOnlySpan<PartitionSummaryData> PartitionSummaries(PartitionType partitionType)
        {
            return PartitionTypes.GetPartitionSummaries(partitionType, in _toc);
        }

        // for testing
        public ref readonly T GetGeneric<T, TSort, TOver>(TOver index)
            where T : struct, ITag<T, TSort>
            where TSort : unmanaged, Enum
            where TOver : struct, IOver<TOver, TSort>
        {
#if DEBUG
            // The following check should never fail due to type constraints
            if (TOver.Type != T.Type || Unsafe.BitCast<TSort, byte>(index.Sort) != Unsafe.BitCast<TSort, byte>(T.Sort)) // avoid BitCast?
            {
                throw new SortMismatchException($"Sort mismatch: requested type/sort {T.Type}/{T.Sort} using index of type/sort {TOver.Type}/{index.Sort}");
            }
#endif

            return ref Partition<T>()[(int)index.Index];
        }

        public T[] SequenceAsArray<T>(Sequence<T> sequence) where T : struct, ITag => [.. Sequence(sequence)];

        public T[] SequenceAsArray<T>(ISequence<T> sequence) where T : struct, ITag => SequenceAsArray(sequence.Sequence);

        public T[] SequenceAsArray<TImpl, T, TSort>(ITaggedSequence<TImpl, T, TSort> taggedSequence)
            where T : struct
            where TSort : unmanaged, Enum
            where TImpl : struct, ITaggedSequence<TImpl, T, TSort>
        {
            return [.. Sequence(taggedSequence)];
        }

        public T[] PartitionAsArray<T>()
            where T : struct, ITag
        {
            return [.. Partition<T>(PartitionSummary<T>())];
        }
    }
}
