using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBrowserClient.Model;

namespace WPFBrowserClient.ViewModel
{
    public class SearchBarUserControlViewModel
    {
        private ActualWebPage actualWebPage = ActualWebPage.Instance;

        public string URL
        {
            get
            {
                return actualWebPage.URL;
            }
            set
            {
                actualWebPage.URL = value;
            }
        }
    }
}
