using System.Windows;
using System.Windows.Controls;
using WPFBrowserClient.View.Pages;

namespace WPFBrowserClient.ViewModel
{
    public class WindowViewModel
    {
        public static Page ActualPage { get; set; } = new RootSitePage();

        public static Frame MainFrame
        {
            get
            {
                return MainWindow.FindName("mainFrame") as Frame;
            }
        }

        public static Window MainWindow
        {
            get
            {
                return Application.Current.MainWindow;
            }
        }
    }
}