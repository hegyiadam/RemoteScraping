using System;
using System.ComponentModel;
using CefSharp.Wpf;
using WPFBrowserClient.Model;

namespace WPFBrowserClient.ViewModel
{
    public class BrowserUserControlViewModel : INotifyPropertyChanged
    {
        private ActualWebPage actualWebPage = ActualWebPage.Instance;
        private string url;

        public BrowserUserControlViewModel(ChromiumWebBrowser chromiumWebBrowser)
        {
            actualWebPage.PropertyChanged += ActualWebPage_PropertyChanged;
            chromiumWebBrowser.AddressChanged += ChromiumWebBrowser_AddressChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string URL
        {
            get
            {
                return actualWebPage.URL;
            }
        }

        private void ActualWebPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        private void ChromiumWebBrowser_AddressChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != URL)
            {
                actualWebPage.URL = (string)e.NewValue;
            }
        }

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}