using System.Windows;
using System.Windows.Input;

namespace CppEnumApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm;

        public MainWindow()
        {
            DataContext = _vm = new MainViewModel();

            InitializeComponent();

            _vm.Error += OnViewModelError;

            _vm.GoCommand.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(_vm.GoCommand.IsRunning))
                {
                    Mouse.OverrideCursor = _vm.GoCommand.IsRunning ? Cursors.Wait : null;
                }
            };
        }

        private void OnViewModelError(string messageText)
        {
            MessageBox.Show(this, messageText, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                _vm.GoCommand.Execute(files);
            }
        }
    }
}