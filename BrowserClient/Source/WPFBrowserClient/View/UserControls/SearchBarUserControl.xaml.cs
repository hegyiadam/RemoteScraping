using System.Windows.Controls;
using WPFBrowserClient.ViewModel;

namespace WPFBrowserClient.View
{
    /// <summary>
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBarUserControl : UserControl
    {
        public SearchBarUserControl()
        {
            InitializeComponent();
            DataContext = new SearchBarUserControlViewModel();
        }
    }
}