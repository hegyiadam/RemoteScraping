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
