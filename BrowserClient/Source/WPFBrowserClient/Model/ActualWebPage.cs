using System.ComponentModel;

namespace WPFBrowserClient.Model
{
    public class ActualWebPage : INotifyPropertyChanged
    {
        private static ActualWebPage _instance = null;

        private string url;

        private ActualWebPage()
        {
            URL = ConfigManager.Instance.DefaultURL;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static ActualWebPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ActualWebPage();
                }
                return _instance;
            }
        }

        public string URL
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged("URL");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}