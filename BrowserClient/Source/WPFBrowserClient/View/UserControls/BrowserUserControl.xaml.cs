using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
