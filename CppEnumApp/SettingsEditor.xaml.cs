using System.Windows.Controls;

namespace CppEnumApp
{
    public partial class SettingsEditor : UserControl
    {
        private readonly SettingsViewModel _vm;

        public SettingsEditor()
        {
            DataContext = _vm = new SettingsViewModel();

            InitializeComponent();

            _vm.FocusAddInput += (s, e) => AddTextBox.Focus();
            _vm.SelectAllAddInput += (s, e) => AddTextBox.SelectAll();
        }
    }
}
