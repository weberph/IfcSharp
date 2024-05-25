using System.Diagnostics.CodeAnalysis;

namespace IfcBuilderLib
{
    internal static class Sanitizer
    {
        private static readonly char[] InvalidDirChars = [.. Path.GetInvalidPathChars(), '"', '\'', '´', '`'];
        private static readonly char[] InvalidFileChars = [.. Path.GetInvalidFileNameChars(), '"', '\'', '´', '`'];

        public static bool TryFilePath(string directoryPath, string fileName, [NotNullWhen(true)] out string? sanitizedPath)
        {
            if (TryDirectory(directoryPath, out var sanitizedDir) && TryFileName(fileName, out var sanitizedName))
            {
                var path = Path.Combine(sanitizedDir, sanitizedName);
                if (!Directory.Exists(path))
                {
                    sanitizedPath = path;
                    return true;
                }
            }

            sanitizedPath = null;
            return false;
        }

        public static bool TryFilePath(string filePath, [NotNullWhen(true)] out string? sanitizedPath)
        {
            return TryFilePath(Path.GetDirectoryName(filePath) ?? string.Empty, Path.GetFileName(filePath), out sanitizedPath);
        }

        public static bool TryFileName(string fileName, [NotNullWhen(true)] out string? sanitizedPath)
        {
            sanitizedPath = null;

            if (string.IsNullOrWhiteSpace(fileName) || fileName.Any(c => InvalidFileChars.Contains(c)) || fileName.Contains(".."))
            {
                return false;
            }

            if (Path.GetFileName(fileName) != fileName)
            {
                return false;
            }

            sanitizedPath = fileName;
            return true;
        }

        public static bool TryDirectory(string directoryPath, [NotNullWhen(true)] out string? sanitizedPath)
        {
            sanitizedPath = null;

            if (string.IsNullOrWhiteSpace(directoryPath) || directoryPath.Any(c => InvalidDirChars.Contains(c)))
            {
                return false;
            }

            if (!Path.IsPathFullyQualified(directoryPath) || !Path.IsPathRooted(directoryPath) || directoryPath.Contains(".."))
            {
                return false;
            }

            if (Path.GetFullPath(directoryPath) != directoryPath)
            {
                return false;
            }

            if (File.Exists(directoryPath))
            {
                return false;
            }

            sanitizedPath = directoryPath;
            return true;
        }
    }
}
