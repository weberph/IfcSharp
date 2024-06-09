using ifc.symbolic;
using IfcSharpLib;
using IfcSharpLibTest;

namespace IfcSharpLibUnitTests
{
    public class StringLiteralTests
    {
        [Fact]
        public void TestStringLiterals()
        {
            HashSet<string> remaining = ["test_default", "test_u8", "test_u16", "test_u32", "test_wide"];

            var reader = new Reader(TestFileLocator.GetTestFilePath("StringLiteralTests.ixx.ifc"));

            var stringExprs = reader.Partition<StringExpr>();
            foreach (ref readonly var stringExpr in stringExprs)
            {
                if (reader.GetString(reader.Get(stringExpr.locus.line).file).EndsWith("StringLiteralTests.ixx"))
                {
                    remaining.Remove(reader.GetString(stringExpr.@string));
                }
            }

            Assert.False(remaining.Contains("test_default"), "ordinal string literal was not found");
            Assert.False(remaining.Contains("test_u8"), "u8 string literal was not found");
            Assert.False(remaining.Contains("test_u16"), "u16 string literal was not found");
            Assert.False(remaining.Contains("test_u32"), "u32 string literal was not found");
            Assert.False(remaining.Contains("test_wide"), "wide string literal was not found");
            Assert.True(remaining.Count == 0, "all test strings have been found");
        }
    }
}
