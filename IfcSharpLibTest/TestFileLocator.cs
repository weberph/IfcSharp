using System.Runtime.CompilerServices;

namespace IfcSharpLibTest
{
    public static class TestFileLocator
    {
        public static string GetTestFilePath(string fileName)
        {
#if RELEASE
            string config = "Release";
#else
            string config = "Debug";
#endif
            static string GetSourceFileDirectory([CallerFilePath] string? path = null)
                => Path.GetDirectoryName(path) ?? throw new NotSupportedException("Failed to get source location");

            return Path.Combine(GetSourceFileDirectory(), "..", "build/x64", config, "IfcTestData", fileName);
        }
    }
}
