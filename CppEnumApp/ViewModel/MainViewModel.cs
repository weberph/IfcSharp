using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ifc;
using ifc.symbolic;
using IfcBuilderLib;
using IfcSharpLib;
using IfcSharpLib.Util;
using System.IO;
using System.Text;

namespace CppEnumApp
{
    internal sealed class UserException(string userMessage) : Exception(userMessage) { }
    internal sealed class IfcBuildException(string message) : Exception(message) { }
    internal sealed class IfcCreationException(Exception exception) : Exception(exception.Message, exception) { }
    internal sealed class IfcProcessingException(Exception exception) : Exception(exception.Message, exception) { }

    internal class IfcEnum(string name, string @namespace, bool enumClass, string[] members)
    {
        public string Name { get; } = name;
        public string Namespace { get; } = @namespace;
        public bool EnumClass { get; } = enumClass;
        public string[] Members { get; } = members;
    }

    internal sealed class AppEnumData(string name, string @namespace, bool enumClass, string[] members) : IfcEnum(name, @namespace, enumClass, members)
    {
        public string LowerName { get; } = name.ToLowerInvariant();
        public string LowerNamespace { get; } = @namespace.ToLowerInvariant();
        public string EnumToString => _enumToString ??= CreateEnumToString();

        private string? _enumToString;

        private string CreateEnumToString()
        {
            var (qualifier, name) = (Namespace.Length, EnumClass) switch
            {
                (0, false) => (string.Empty, Name),
                (_, false) => (Namespace, $"{Namespace}::{Name}"),
                (0, true) => (Name, Name),
                (_, true) => ($"{Namespace}::{Name}", $"{Namespace}::{Name}")
            };

            var sb = new StringBuilder();
            foreach (var member in Members)
            {
                if (sb.Length > 0)
                {
                    sb.Append(' ', 8);
                }
                sb.AppendLine($"case {qualifier}::{member}: return \"{member}\";");
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

    internal sealed partial class MainViewModel : ObservableObject
    {
        private AppEnumData[] _enums = [];

        [ObservableProperty]
        private AppEnumData[] _filteredEnums = [];

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

        private Task<DeveloperEnvironment?> _environment;
        private string? _currentVcvarsPath;

        public MainViewModel()
        {
            _environment = Task.Run(async () =>
            {
                if (SettingsViewModel.TryGetVcvarsPath(out var vcvarsPath))
                {
                    return await CreateEnvironmentAsync(vcvarsPath);
                }

                return null;
            });

            Properties.Settings.Default.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Properties.Settings.VcvarsPath))
                {
                    var value = Properties.Settings.Default.VcvarsPath;
                    if (value != _currentVcvarsPath && File.Exists(value))
                    {
                        _currentVcvarsPath = value;

                        (_environment = CreateEnvironmentAsync(value))
                            .ContinueWith(_ => GoCommand.NotifyCanExecuteChanged(), TaskScheduler.FromCurrentSynchronizationContext());
                        GoCommand.NotifyCanExecuteChanged();
                    }
                }
            };
        }

        private static async Task<DeveloperEnvironment?> CreateEnvironmentAsync(string vcvarsPath)
        {
            var env = new DeveloperEnvironment();
            await env.ActivateDeveloperEnvironmentAsync(vcvarsPath);
            return env;
        }

        private async Task<string> CreateIfcAsync(string[] filesOrDirectory)
        {
            var extensions = Extensions.Split([' ', ',', ';', '|'], StringSplitOptions.TrimEntries); // keeping empty entries intentionally

            var includeDirs = new List<string>();

            foreach (var path in filesOrDirectory)
            {
                if (Directory.Exists(path))
                {
                    includeDirs.Add(path);
                }

                if (Path.GetDirectoryName(path) is { } parent && Directory.Exists(parent))
                {
                    includeDirs.Add(parent);
                }
            }

            var env = _environment.Result ?? throw new UserException("Could not load developer environment. Check vcvars path in settings."); ;

            using var amalgamation = await Task.Run(() => new Amalgamation(filesOrDirectory, extensions)).ConfigureAwait(false);

            var inputFile = amalgamation.FilePath;

            var outputFile = Path.Combine(Directory.GetCurrentDirectory(), "current.ifc");

            includeDirs.AddRange((Properties.Settings.Default.IncludeDirectories ?? []).Cast<string>());

            var (stdout, stderr, exitCode) = await env.CreateIfcAsync(inputFile, [.. includeDirs], outputFile).ConfigureAwait(false);
            if (exitCode != 0)
            {
                throw new IfcBuildException($"Failed to build the ifc. Exit code of cl.exe: {exitCode}. Error:\n{stdout}\n{stderr}");
            }

            return outputFile;
        }

        private Task<(string, AppEnumData[])> GetEnums(string[] filesOrDirectory)
        {
            var isAnyIfc = filesOrDirectory.Any(f => f.ToLowerInvariant().EndsWith(".ifc"));
            if (filesOrDirectory.Length > 1 && isAnyIfc)
            {
                throw new UserException("Only a single ifc file can be loaded.");
            }

            return Task.Run(() =>
            {
                var ifcPath = filesOrDirectory[0];
                if (!isAnyIfc)
                {
                    try
                    {
                        ifcPath = CreateIfcAsync(filesOrDirectory).Result;
                    }
                    catch (Exception e)
                    {
                        throw new IfcCreationException(e);
                    }
                }

                try
                {
                    var reader = new Reader(ifcPath);
                    var decls = reader.Partition<EnumerationDecl>();

                    var enums = new AppEnumData[decls.Length];
                    var index = 0;
                    foreach (var decl in decls)
                    {
                        var name = reader.GetString(decl.identity);
                        if (name.StartsWith('<')
                            || decl.type.Sort != TypeSort.Fundamental
                            || !QualifiedName.TryBuildFullyQualifiedName(reader, decl.home_scope, out var @namespace))
                        {
                            continue;
                        }

                        bool enumClass = reader.Get<FundamentalType>(decl.type).basis is TypeBasis.Class or TypeBasis.Struct;
                        var initializers = reader.Sequence(decl.initializer);
                        var members = new string[initializers.Length];
                        for (int j = 0; j < initializers.Length; j++)
                        {
                            members[j] = reader.GetString(initializers[j].identity);
                        }

                        enums[index++] = new AppEnumData(name, @namespace, enumClass, members);
                    }

                    Array.Resize(ref enums, index);
                    return (ifcPath, enums);
                }
                catch (Exception e)
                {
                    throw new IfcProcessingException(e);
                }
            });
        }

        private bool CanGo() => !string.IsNullOrWhiteSpace(InputPath) && Path.Exists(InputPath) && _environment.IsCompletedSuccessfully && _environment.Result != null;

        [RelayCommand(CanExecute = nameof(CanGo))]
        private async Task Go(object? argument)
        {
            try
            {
                ErrorText = string.Empty;
                FilteredEnums = [];

                var (ifcPath, enums) = await GetEnums(argument as string[] ?? [InputPath]);
                if (string.IsNullOrWhiteSpace(InputPath))
                {
                    InputPath = ifcPath;
                }

                _enums = enums;
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
            var namespaceFilter = NamespaceFilter.ToLowerInvariant();
            var typeNameFilter = TypeNameFilter.ToLowerInvariant();
            FilteredEnums = [.. _enums
                                  .Where(e => !ExcludeGlobal || e.Namespace.Length > 0)
                                  .Where(e => !ExcludeStd || !e.Namespace.StartsWith("std"))
                                  .Where(e => !ExcludeNoMembers || e.Members.Length > 0)
                                  .Where(e => !ExcludeInternal || (e.Namespace.Length == 0 || e.Namespace[0] is not ('_' or '?')))
                                  .Where(e => string.IsNullOrWhiteSpace(namespaceFilter) || e.LowerNamespace.Contains(namespaceFilter))
                                  .Where(e => string.IsNullOrWhiteSpace(typeNameFilter) || e.LowerName.Contains(typeNameFilter))
                                  .OrderBy(e => e.Name)];
        }
    }
}
