using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace CppEnumApp
{
    internal record IncludeDirectory(string Path)
    {
    }

    internal partial class SettingsViewModel : ObservableObject
    {
        private const string VcvarsPath1 = @"c:\Program Files\Microsoft Visual Studio\2022\Professional\VC\Auxiliary\Build\vcvars64.bat";
        private const string VcvarsPath2 = @"c:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat";

        public ObservableCollection<IncludeDirectory> IncludeDirectories { get; } = [];

        [ObservableProperty]
        private IncludeDirectory? _selectedIncludeDirectory;

        [ObservableProperty]
        private string _addInput = string.Empty;

        [ObservableProperty]
        private string _vcvarsPath = string.Empty;

        partial void OnSelectedIncludeDirectoryChanged(IncludeDirectory? value) => RemoveCommand.NotifyCanExecuteChanged();
        partial void OnAddInputChanged(string value) => AddCommand.NotifyCanExecuteChanged();

        private bool _saveVcvarsOnChange = false;
        partial void OnVcvarsPathChanged(string value)
        {
            if (_saveVcvarsOnChange && File.Exists(value))
            {
                SaveVcvarsPath();
            }
        }

        public event EventHandler? FocusAddInput;
        public event EventHandler? SelectAllAddInput;

        public SettingsViewModel()
        {
            foreach (var includeDirectory in Properties.Settings.Default.IncludeDirectories ?? [])
            {
                if (!string.IsNullOrWhiteSpace(includeDirectory))
                {
                    IncludeDirectories.Add(new IncludeDirectory(includeDirectory));
                }
            }

            if (TryGetVcvarsPath(out var vcvarsPath))
            {
                VcvarsPath = vcvarsPath;
            }

            _saveVcvarsOnChange = true;
        }

        public static bool TryGetVcvarsPath([NotNullWhen(true)] out string? vcvarsPath)
        {
            ReadOnlySpan<string> paths = [Properties.Settings.Default.VcvarsPath, VcvarsPath1, VcvarsPath2];
            foreach (var path in paths)
            {
                if (File.Exists(path))
                {
                    vcvarsPath = path;
                    return true;
                }
            }

            vcvarsPath = null;
            return false;
        }

        private bool CanAdd() => AddInput.Length > 0;

        [RelayCommand(CanExecute = nameof(CanAdd))]
        private void Add()
        {
            IncludeDirectories.Add(new IncludeDirectory(AddInput));
            AddInput = string.Empty;

            FocusAddInput?.Invoke(this, EventArgs.Empty);

            SaveIncludes();
        }

        private bool CanRemove() => SelectedIncludeDirectory != null;

        [RelayCommand(CanExecute = nameof(CanRemove))]
        private void Remove()
        {
            var selectedIncludeDirectory = SelectedIncludeDirectory;
            if (selectedIncludeDirectory != null)
            {
                SelectedIncludeDirectory = null;
                IncludeDirectories.Remove(selectedIncludeDirectory);
                AddInput = selectedIncludeDirectory.Path;

                FocusAddInput?.Invoke(this, EventArgs.Empty);
                SelectAllAddInput?.Invoke(this, EventArgs.Empty);

                SaveIncludes();
            }
        }

        private void SaveVcvarsPath()
        {
            Properties.Settings.Default.VcvarsPath = VcvarsPath;
            Properties.Settings.Default.Save();
        }

        private void SaveIncludes()
        {
            Properties.Settings.Default.IncludeDirectories = [.. IncludeDirectories.Select(id => id.Path)];
            Properties.Settings.Default.Save();
        }
    }
}
