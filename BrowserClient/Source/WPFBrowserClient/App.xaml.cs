using System.Windows;
using View.WPFBrowserClient;
using WPFBrowserClient.ViewModel;

namespace WPFBrowserClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new WindowViewModel();
            mainWindow.Show();
        }
    }
}