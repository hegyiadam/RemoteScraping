using System.Windows.Controls;
using WPFBrowserClient.Model;
using WPFBrowserClient.ViewModel;

namespace WPFBrowserClient.View.Pages
{
    /// <summary>
    /// Interaction logic for RootSitePage.xaml
    /// </summary>
    public partial class RootSitePage : Page, ISingletonPage
    {
        public RootSitePage()
        {
            InitializeComponent();
            DataContext = new RootSitePageViewModel();
        }
    }
}