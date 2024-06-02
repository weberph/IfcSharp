using ifc;

namespace IfcSharpLib
{
    public enum PartitionType
    {
        CommandLine,
        ExportedModules,
        ImportedModules,
        U64s,
        Fps,
        StringLiterals,
        States,
        Lines,
        Words,
        Sentences,
        Scopes,
        Entities,
        SpecForms,
        Names,
        Decls,
        Types,
        Stmts,
        Exprs,
        Elements,
        Forms,
        Traits,
        MsvcTraits,
        Charts,
        MultiCharts,
        Heaps,
        SuppressedWarnings,
        Macros,
        PragmaDirectives,
        Attrs,
        Dirs,
        ImplementationPragmas,
    }

    public static class PartitionTypes
    {
        public static ReadOnlySpan<PartitionSummaryData> GetPartitionSummaries(PartitionType partitionType, ref readonly TableOfContents toc)
        {
            switch (partitionType)
            {
                case PartitionType.CommandLine: return new(in toc.command_line);
                case PartitionType.ExportedModules: return new(in toc.exported_modules);
                case PartitionType.ImportedModules: return new(in toc.imported_modules);
                case PartitionType.U64s: return new(in toc.u64s);
                case PartitionType.Fps: return new(in toc.fps);
                case PartitionType.StringLiterals: return new(in toc.string_literals);
                case PartitionType.States: return new(in toc.states);
                case PartitionType.Lines: return new(in toc.lines);
                case PartitionType.Words: return new(in toc.words);
                case PartitionType.Sentences: return new(in toc.sentences);
                case PartitionType.Scopes: return new(in toc.scopes);
                case PartitionType.Entities: return new(in toc.entities);
                case PartitionType.SpecForms: return new(in toc.spec_forms);
                case PartitionType.Names: return toc.names;
                case PartitionType.Decls: return toc.decls;
                case PartitionType.Types: return toc.types;
                case PartitionType.Stmts: return toc.stmts;
                case PartitionType.Exprs: return toc.exprs;
                case PartitionType.Elements: return toc.elements;
                case PartitionType.Forms: return toc.forms;
                case PartitionType.Traits: return toc.traits;
                case PartitionType.MsvcTraits: return toc.msvc_traits;
                case PartitionType.Charts: return new(in toc.charts);
                case PartitionType.MultiCharts: return new(in toc.multi_charts);
                case PartitionType.Heaps: return toc.heaps;
                case PartitionType.SuppressedWarnings: return new(in toc.suppressed_warnings);
                case PartitionType.Macros: return toc.macros;
                case PartitionType.PragmaDirectives: return toc.pragma_directives;
                case PartitionType.Attrs: return toc.attrs;
                case PartitionType.Dirs: return toc.dirs;
                case PartitionType.ImplementationPragmas: return new(in toc.implementation_pragmas);
            }

            throw new InvalidPartitionTypeException("Invalid PartitionType");
        }

        public static bool TryGetPartitionType(SortType sortType, out PartitionType partitionType)
        {
            var (success, type) = sortType switch
            {
                SortType.String => (true, PartitionType.StringLiterals),
                SortType.Name => (true, PartitionType.Names),
                SortType.Decl => (true, PartitionType.Decls),
                SortType.Type => (true, PartitionType.Types),
                SortType.Syntax => (true, PartitionType.Elements),
                SortType.Stmt => (true, PartitionType.Stmts),
                SortType.Expr => (true, PartitionType.Exprs),
                SortType.Macro => (true, PartitionType.Macros),
                SortType.Pragma => (true, PartitionType.PragmaDirectives),
                SortType.Attr => (true, PartitionType.Attrs),
                SortType.Dir => (true, PartitionType.Dirs),
                SortType.Form => (true, PartitionType.Forms),
                SortType.Trait => (true, PartitionType.Traits),
                SortType.MsvcTrait => (true, PartitionType.MsvcTraits),
                SortType.Heap => (true, PartitionType.Heaps),
                SortType.Scope => (true, PartitionType.Scopes),

                // SortType.Literal, SortType.Chart: no 1-1 from SortType to PartitionType
                // SortType.Unit: not associated with any partition
                _ => (false, (PartitionType)0)
            };

            partitionType = type;
            return success;
        }
    }

    public sealed class InvalidPartitionTypeException(string message) : ArgumentOutOfRangeException(message) { }
}
