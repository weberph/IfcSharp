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
            return partitionType switch
            {
                PartitionType.CommandLine => new(in toc.command_line),
                PartitionType.ExportedModules => new(in toc.exported_modules),
                PartitionType.ImportedModules => new(in toc.imported_modules),
                PartitionType.U64s => new(in toc.u64s),
                PartitionType.Fps => new(in toc.fps),
                PartitionType.StringLiterals => new(in toc.string_literals),
                PartitionType.States => new(in toc.states),
                PartitionType.Lines => new(in toc.lines),
                PartitionType.Words => new(in toc.words),
                PartitionType.Sentences => new(in toc.sentences),
                PartitionType.Scopes => new(in toc.scopes),
                PartitionType.Entities => new(in toc.entities),
                PartitionType.SpecForms => new(in toc.spec_forms),
                PartitionType.Names => toc.names,
                PartitionType.Decls => toc.decls,
                PartitionType.Types => toc.types,
                PartitionType.Stmts => toc.stmts,
                PartitionType.Exprs => toc.exprs,
                PartitionType.Elements => toc.elements,
                PartitionType.Forms => toc.forms,
                PartitionType.Traits => toc.traits,
                PartitionType.MsvcTraits => toc.msvc_traits,
                PartitionType.Charts => new(in toc.charts),
                PartitionType.MultiCharts => new(in toc.multi_charts),
                PartitionType.Heaps => toc.heaps,
                PartitionType.SuppressedWarnings => new(in toc.suppressed_warnings),
                PartitionType.Macros => toc.macros,
                PartitionType.PragmaDirectives => toc.pragma_directives,
                PartitionType.Attrs => toc.attrs,
                PartitionType.Dirs => toc.dirs,
                PartitionType.ImplementationPragmas => new(in toc.implementation_pragmas),
                _ => throw new InvalidPartitionTypeException("Invalid PartitionType"),
            };
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
