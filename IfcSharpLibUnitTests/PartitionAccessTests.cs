using ifc;
using IfcSharpLib;
using IfcSharpLibTest;

namespace IfcSharpLibUnitTests
{
    public class PartitionAccessTests
    {
        private readonly Reader _ifcHeaderUnit;
        private readonly Reader _importExportModule;

        public PartitionAccessTests()
        {
            _ifcHeaderUnit = new Reader(TestFileLocator.GetTestFilePath("IfcHeaderUnit.ixx.ifc"));
            _importExportModule = new Reader(TestFileLocator.GetTestFilePath("ImportExportModuleTests.ixx.ifc"));
        }

        [Fact]
        public void AccessCommandLine() => Assert.True(_ifcHeaderUnit.CommandLine().Length > 0);

        [Fact]
        public void AccessPragmaWarnings() => Assert.True(_ifcHeaderUnit.PragmaWarnings().Length > 0);

        [Fact]
        public void AccessStates() => Assert.True(_ifcHeaderUnit.States().Length > 0);

        [Fact]
        public void AccessScopes() => Assert.True(_ifcHeaderUnit.Scopes().Length > 0);

        [Fact]
        public void AccessDeclarations() => Assert.True(_ifcHeaderUnit.Declarations().Length > 0);

        [Fact]
        public void AccessImplementationPragmas() => Assert.True(_ifcHeaderUnit.ImplementationPragmas() is { Length: 1 } pragmas && pragmas[0].IsNull);

        [Fact]
        public void AccessImportedModules() => Assert.True(_importExportModule.ImportedModules().Length == 1);

        [Fact]
        public void AccessExportedModules() => Assert.True(_importExportModule.ExportedModules().Length == 1);

        [Fact]
        public void GetFileAndLine() => _ifcHeaderUnit.Get((LineIndex)0);

        [Fact]
        public void GetWordIndex() => _ifcHeaderUnit.Get((WordIndex)0);

        [Fact]
        public void GetSentenceIndex() => _ifcHeaderUnit.Get((SentenceIndex)0);

        [Fact]
        public void GetSpecFormIndex() => _ifcHeaderUnit.Get((SpecFormIndex)0);
    }
}
