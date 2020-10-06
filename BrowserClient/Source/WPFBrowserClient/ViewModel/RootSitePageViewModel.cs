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
