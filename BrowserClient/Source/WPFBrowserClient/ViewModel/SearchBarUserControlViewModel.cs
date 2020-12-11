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