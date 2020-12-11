using System.Windows;
using System.Windows.Controls;
using CefSharp.Wpf;
using WPFBrowserClient.Model;
using WPFBrowserClient.View.UserControls;
using WPFBrowserClient.ViewModel;

namespace WPFBrowserClient.View.Pages
{
    /// <summary>
    /// Interaction logic for SiteScrapingPage.xaml
    /// </summary>
    public partial class SiteScrapingPage : Page, ISingletonPage
    {
        public SiteScrapingPage()
        {
            InitializeComponent();

            ChromiumWebBrowser browser = (FindName("BrowserUserControl") as BrowserUserControl).FindName("Browser") as ChromiumWebBrowser;
            DataContext = new SiteScrapingPageViewModel(this, browser);
        }

        public SiteScrapingPageViewModel ViewModel
        {
            get
            {
                return DataContext as SiteScrapingPageViewModel;
            }
        }

        private void CloseMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MenuIsVisible = false;
            /* CloseMenuButton.Visibility = Visibility.Collapsed;
             OpenMenuButton.Visibility = Visibility.Visible;*/
        }

        private void OpenMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MenuIsVisible = true;
            /*OpenMenuButton.Visibility = Visibility.Collapsed;
            CloseMenuButton.Visibility = Visibility.Visible;*/
        }
    }
}