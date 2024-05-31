using System.Diagnostics;

namespace IfcBuilderLib
{
    public sealed class DeveloperEnvironmentException(string message) : Exception(message) { }

    public class DeveloperEnvironment
    {
        private const string CmdPath = @"c:\windows\system32\cmd.exe";

        private Dictionary<string, string>? _environment;

        public async Task ActivateDeveloperEnvironmentAsync(string? vcvarsPath)
        {
            _environment = vcvarsPath == null ? null : await CaptureDeveloperEnvironmentAsync(vcvarsPath);
        }

        private static async Task<Dictionary<string, string>> CaptureDeveloperEnvironmentAsync(string vcvarsPath)
        {
            var process = Process.Start(new ProcessStartInfo(CmdPath)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true
            }) ?? throw new DeveloperEnvironmentException("Failed to execute cmd.exe with vcvars script");

            var stdout = process.StandardOutput.ReadToEndAsync();
            var stderr = process.StandardError.ReadToEndAsync();

            process.StandardInput.WriteLine($@"""{vcvarsPath}""");
            process.StandardInput.WriteLine("set");
            process.StandardInput.WriteLine("exit");

            await Task.WhenAll(stdout, stderr, process.WaitForExitAsync());

            var lines = stdout.Result.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            return lines.SkipWhile(l => !l.EndsWith(">set"))
                        .Skip(1)
                        .TakeWhile(l => l.Contains('='))
                        .Select(l => l.Split('=', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                        .Where(kvp => kvp.Length == 2)
                        .ToDictionary(kvp => kvp[0], kvp => kvp[1]);
        }

        private string FindClExe()
        {
            var pathVariable = (_environment != null ? _environment.GetValueOrDefault("Path") : Environment.GetEnvironmentVariable("Path"))
                               ?? throw new DeveloperEnvironmentException("Path variable not found");

            return pathVariable.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                               .Select(p => Path.Combine(p, "cl.exe"))
                               .FirstOrDefault(File.Exists) ?? throw new DeveloperEnvironmentException("cl.exe not found");
        }

        public async Task<(string stdout, string stderr, int exitCode)> CreateIfcAsync(string rawInputFile, string[] rawIncludeDirs, string rawOutputFile, string[] additionalCompilerOptions)
        {
            if (!Sanitizer.TryFilePath(rawInputFile, out var inputFile))
            {
                throw new DeveloperEnvironmentException("Invalid input file: " + rawInputFile);
            }

            if (!Sanitizer.TryFilePath(rawOutputFile, out var outputFile) || Path.GetExtension(outputFile) != ".ifc" || !Directory.Exists(Path.GetDirectoryName(outputFile)))
            {
                throw new DeveloperEnvironmentException("Invalid output file: " + rawOutputFile);
            }

            string[] includeArguments = rawIncludeDirs.Select(rawDir =>
            {
                if (!Sanitizer.TryDirectory(rawDir, out var sanitizedIncludeDir))
                {
                    throw new DeveloperEnvironmentException("Invalid include directory: " + rawDir);
                }

                return $"/I{sanitizedIncludeDir}";
            }).ToArray();

            var clExe = FindClExe();

            string[] defaultOptions = ["/c", "/nologo", "/W4", "/O2", "/Gm-", "/EHsc", "/MD", "/GS", "/Gd", "/FC", "/TP",
                                       "/fp:precise", "/Zc:wchar_t", "/Zc:forScope", "/Zc:inline", "/std:c++20"];

            string[] output = ["/ifcOutput", outputFile];
            string[] input = ["/exportHeader", inputFile];

            string[] arguments = [.. includeArguments, .. defaultOptions, .. additionalCompilerOptions, .. output, .. input];

            var startInfo = new ProcessStartInfo(clExe, arguments)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };

            if (_environment != null)
            {
                foreach (var (key, value) in _environment)
                {
                    startInfo.EnvironmentVariables[key] = value;
                }
            }

            if (Debugger.IsAttached)
            {
                Debug.WriteLine("Executing: " + clExe);
                Debug.WriteLine("Arguments: " + string.Join(' ', arguments));
            }

            var process = Process.Start(startInfo) ?? throw new DeveloperEnvironmentException("Failed to execute cl.exe");

            var stdout = process.StandardOutput.ReadToEndAsync();
            var stderr = process.StandardError.ReadToEndAsync();

            await Task.WhenAll(stdout, stderr, process.WaitForExitAsync());
            return (stdout.Result.Trim(), stderr.Result.Trim(), process.ExitCode);
        }
    }
}
