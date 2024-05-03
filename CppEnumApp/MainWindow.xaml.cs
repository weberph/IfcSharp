using System.Windows;

namespace CppEnumApp
{
    public partial class MainWindow : Window
    {
        private readonly ViewModel _vm;

        public MainWindow()
        {
            DataContext = _vm = new ViewModel();

            InitializeComponent();

            _vm.Error += OnViewModelError;
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