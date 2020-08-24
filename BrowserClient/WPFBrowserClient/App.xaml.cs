using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            mainWindow.DataContext = WindowViewModel.Instance;
            mainWindow.Show();
        }
    }
}
