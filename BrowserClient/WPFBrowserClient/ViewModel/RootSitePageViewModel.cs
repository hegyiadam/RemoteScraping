using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFBrowserClient.Model;
using WPFBrowserClient.View.Pages;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel
{
    public class RootSitePageViewModel
    {
        private ActualPage actualPage = new ActualPage(ConfigManager.Instance.DefaultURL);

        public ICommand StartScrapingCommand
        {
            get
            {
                return new StartScrapingCommand(new SiteScrapingPage());
            }
        }
        public string URL
        {
            get
            {
                return actualPage.URL;
            }
            set
            {
                actualPage.URL = value;
            }
        }
    }
}
