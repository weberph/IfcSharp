namespace IfcBuilderLib
{
    public sealed class Amalgamation : IDisposable
    {
        public string FilePath { get; } = Path.GetTempFileName();

        public Amalgamation(string[] paths, string[] extensions)
        {
            var files = new List<string>();

            foreach (var path in paths)
            {
                if (Directory.Exists(path))
                {
                    files.AddRange(Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)
                                            .Where(p => extensions.Contains(Path.GetExtension(p)?.ToLowerInvariant() ?? string.Empty)));
                }
                else if (File.Exists(path))
                {
                    files.Add(path);
                }
            }

            WriteIncludes(files);
        }

        public void WriteIncludes(IEnumerable<string> files)
        {
            File.WriteAllLines(FilePath, files.Select(i => $"#include \"{i}\""));
        }

        public void Dispose()
        {
            File.Delete(FilePath);
        }
    }
}
