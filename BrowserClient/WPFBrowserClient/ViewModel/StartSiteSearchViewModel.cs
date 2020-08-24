using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBrowserClient.Model;

namespace WPFBrowserClient.ViewModel
{
    public class StartSiteSearchViewModel
    {
        private ActualPage actualPage = new ActualPage(ConfigManager.Instance.DefaultURL);

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
