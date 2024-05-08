using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CppEnumStringGenerator;
using IfcBuilderLib;
using System.IO;
using System.Text;

namespace CppEnumApp
{
    internal class UserException(string userMessage) : Exception(userMessage)
    {
    }

    internal class IfcCreationException(Exception exception) : Exception(exception.Message, exception)
    {
    }

    internal class IfcProcessingException(Exception exception) : Exception(exception.Message, exception)
    {
    }

    internal class AppEnumData(string name, string @namespace, bool enumClass, string[] members) : IfcEnum(name, @namespace, enumClass, members)
    {
        public string LowerName { get; } = name.ToLower();
        public string LowerNamespace { get; } = @namespace.ToLower();
        public string EnumToString => _enumToString ??= CreateEnumToString();

        private string? _enumToString;

        private string CreateEnumToString()
        {
            var name = Namespace.Length == 0 ? Name : $"{Namespace}::{Name}";

            var sb = new StringBuilder();
            foreach (var member in Members)
            {
                if (sb.Length > 0)
                {
                    sb.Append(' ', 8);
                }
                sb.AppendLine($"case {name}::{member}: return \"{member}\";");
            }

            return
                $$"""
                constexpr std::string_view to_string(const {{name}} val) noexcept
                {
                    switch (val)
                    {
                        {{sb}}
                        default: return "<unnamed>";
                    }
                }
                """;
        }
    }

    internal partial class ViewModel : ObservableObject
    {
        // TODO: configuration
        private const string VcvarsPath1 = @"c:\Program Files\Microsoft Visual Studio\2022\Professional\VC\Auxiliary\Build\vcvars64.bat";
        private const string VcvarsPath2 = @"c:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat";

        private AppEnumData[] _enums = [];

        [ObservableProperty]
        private AppEnumData[] _filteredEnums = [new AppEnumData("Test", "", true, [])];

        [ObservableProperty]
        private string _inputPath = string.Empty;

        [ObservableProperty]
        private string _extensions = ".h .hxx";

        [ObservableProperty]
        private string _namespaceFilter = string.Empty;

        [ObservableProperty]
        private string _typeNameFilter = string.Empty;

        [ObservableProperty]
        private AppEnumData? _selectedEnum;

        [ObservableProperty]
        private string _errorText = string.Empty;

        [ObservableProperty]
        private bool _excludeGlobal = false;

        [ObservableProperty]
        private bool _excludeStd = false;

        [ObservableProperty]
        private bool _excludeNoMembers = true;

        [ObservableProperty]
        private bool _excludeInternal = true;

        partial void OnInputPathChanged(string value) => GoCommand.NotifyCanExecuteChanged();
        partial void OnNamespaceFilterChanged(string value) => ApplyFilters();
        partial void OnTypeNameFilterChanged(string value) => ApplyFilters();
        partial void OnExcludeGlobalChanged(bool value) => ApplyFilters();
        partial void OnExcludeStdChanged(bool value) => ApplyFilters();
        partial void OnExcludeNoMembersChanged(bool value) => ApplyFilters();
        partial void OnExcludeInternalChanged(bool value) => ApplyFilters();

        public delegate void ErrorHandler(string messageText);

        public event ErrorHandler? Error;

        private Task<DeveloperEnvironment> _environment = Task.Run(async () =>
        {
            var env = new DeveloperEnvironment();

            if (Directory.Exists(VcvarsPath1))
            {
                await env.ActivateDeveloperEnvironmentAsync(VcvarsPath1);
            }
            else if (Directory.Exists(VcvarsPath2))
            {
                await env.ActivateDeveloperEnvironmentAsync(VcvarsPath2);
            }
            else
            {
                var vcvarsPath = Environment.GetEnvironmentVariable("ENUM_VCVARS") ?? throw new IfcCreationException(new Exception("vcvars64.bat not found"));
                await env.ActivateDeveloperEnvironmentAsync(vcvarsPath);
            }

            return env;
        });

        private async Task<string> CreateIfcAsync(string[] filesOrDirectory)
        {
            var extensions = Extensions.Split((char[])[' ', ',', ';', '|'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var isOnlyFiles = filesOrDirectory.All(File.Exists);
            var isAnyDirectory = filesOrDirectory.Any(Directory.Exists);

            if (filesOrDirectory.Length > 1 && isAnyDirectory)
            {
                throw new UserException("Files and directories can't be mixed. Either provide a list of files or a single directory.");
            }

            Amalgamation? CreateAmalgamation()
            {
                if (filesOrDirectory.Length == 1 && isAnyDirectory)
                {
                    return new Amalgamation(filesOrDirectory[0], extensions);
                }

                if (filesOrDirectory.Length > 1)
                {
                    return new Amalgamation(filesOrDirectory);
                }

                return null;
            }

            using var amalgamation = await Task.Run(CreateAmalgamation).ConfigureAwait(false);

            var inputFile = amalgamation?.FilePath ?? filesOrDirectory[0];

            var outputFile = Path.Combine(Directory.GetCurrentDirectory(), "current.ifc");

            // TODO: configuration
            // string[] includeDirs = [@"d:\workspace\.source\Microsoft\GSL\include", @"d:\workspace\.source\Microsoft\ifc\include"];

            string[] includeDirs = Environment.GetEnvironmentVariable("ENUM_INCLUDES")?.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ?? [];

            var env = _environment.Result;
            var (stdout, stderr, exitCode) = await env.CreateIfcAsync(inputFile, includeDirs, outputFile).ConfigureAwait(false);
            if (exitCode != 0)
            {
                throw new Exception($"Failed to build the ifc. Exit code of cl.exe: {exitCode}. Error:\n{stdout}\n{stderr}");
            }

            return outputFile;
        }

        private Task<AppEnumData[]> GetEnums(string[] filesOrDirectory)
        {
            var isAnyIfc = filesOrDirectory.Any(f => f.ToLower().EndsWith(".ifc"));
            if (filesOrDirectory.Length > 1 && isAnyIfc)
            {
                throw new UserException("Only a single ifc file can be loaded.");
            }

            return Task.Run(async () =>
            {
                var ifcPath = filesOrDirectory[0];
                if (!isAnyIfc)
                {
                    try
                    {
                        ifcPath = await CreateIfcAsync(filesOrDirectory);
                    }
                    catch (Exception e)
                    {
                        throw new IfcCreationException(e);
                    }
                }

                try
                {
                    using var ifc = new Ifc(ifcPath);
                    var rawEnums = ifc.GetEnums();
                    var enums = new AppEnumData[rawEnums.Count];
                    for (int i = 0; i < enums.Length; i++)
                    {
                        enums[i] = new AppEnumData(rawEnums[i].Name, rawEnums[i].Namespace, rawEnums[i].EnumClass, rawEnums[i].Members);
                    }
                    return enums;
                }
                catch (Exception e)
                {
                    throw new IfcProcessingException(e);
                }
            });
        }

        private bool CanGo() => !string.IsNullOrWhiteSpace(InputPath) && Path.Exists(InputPath);

        [RelayCommand(CanExecute = nameof(CanGo))]
        private async Task Go(object? argument)
        {
            try
            {
                ErrorText = string.Empty;
                FilteredEnums = [];

                _enums = await GetEnums(argument as string[] ?? [InputPath]);

                ApplyFilters();
            }
            catch (Exception exception)
            {
                var (messageText, outputText) = exception switch
                {
                    UserException e => (e.Message, string.Empty),
                    IfcCreationException e => ("Failed to create the ifc file.", e.InnerException?.ToString() ?? string.Empty),
                    IfcProcessingException e => ("Failed to process the ifc file.", e.InnerException?.ToString() ?? string.Empty),
                    Exception e => ("Unhandled exception: " + e.Message, e.ToString()),
                };

                ErrorText = outputText;
                Error?.Invoke(messageText);
            }
        }

        private void ApplyFilters()
        {
            var namespaceFilter = NamespaceFilter.ToLower();
            var typeNameFilter = TypeNameFilter.ToLower();
            FilteredEnums = _enums
                                  .Where(e => !ExcludeGlobal || e.Namespace.Length > 0)
                                  .Where(e => !ExcludeStd || !e.Namespace.StartsWith("std"))
                                  .Where(e => !ExcludeNoMembers || e.Members.Length > 0)
                                  .Where(e => !ExcludeInternal || (e.Namespace.Length == 0 || e.Namespace[0] is not ('_' or '?')))
                                  .Where(e => string.IsNullOrWhiteSpace(namespaceFilter) || e.LowerNamespace.Contains(namespaceFilter))
                                  .Where(e => string.IsNullOrWhiteSpace(typeNameFilter) || e.LowerName.Contains(typeNameFilter))
                                  .OrderBy(e => e.Name)
                                  .ToArray();
        }
    }
}
