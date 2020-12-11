using System.Windows.Input;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel
{
    public class RootSitePageViewModel
    {
        public RootSitePageViewModel()
        {
        }

        public ICommand StartScrapingCommand
        {
            get
            {
                return new StartScrapingCommand();
            }
        }
    }
}