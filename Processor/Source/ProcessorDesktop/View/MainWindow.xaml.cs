using ProcessorDesktop.ViewModel;
using System.Windows;

namespace ProcessorDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
            Closing += ViewModel.CloseHandler;
            ViewModel.StartHandler();
        }

        public MainWindowViewModel ViewModel { get; }

        private void MasterConnection_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ConnectToMaster();
        }

        private void ProcessorConnection_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DetectProcessor();
        }
    }
}