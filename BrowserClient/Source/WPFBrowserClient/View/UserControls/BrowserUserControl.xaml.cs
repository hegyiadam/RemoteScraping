using System.Windows.Controls;
using CefSharp.Wpf;
using WPFBrowserClient.ViewModel;

namespace WPFBrowserClient.View.UserControls
{
    /// <summary>
    /// Interaction logic for BrowserUserControl.xaml
    /// </summary>
    public partial class BrowserUserControl : UserControl
    {
        public BrowserUserControl()
        {
            InitializeComponent();
            DataContext = new BrowserUserControlViewModel(FindName("Browser") as ChromiumWebBrowser);
        }
    }
}