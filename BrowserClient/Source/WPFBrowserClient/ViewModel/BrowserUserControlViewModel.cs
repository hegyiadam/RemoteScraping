using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFBrowserClient.Model;

namespace WPFBrowserClient.ViewModel
{
    public class BrowserUserControlViewModel : INotifyPropertyChanged
    {
        private string url;
        private ActualWebPage actualWebPage = ActualWebPage.Instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public BrowserUserControlViewModel(ChromiumWebBrowser chromiumWebBrowser)
        {
            actualWebPage.PropertyChanged += ActualWebPage_PropertyChanged;
            chromiumWebBrowser.AddressChanged += ChromiumWebBrowser_AddressChanged;
        }

        private void ChromiumWebBrowser_AddressChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue != URL)
            {
                actualWebPage.URL = (string)e.NewValue;
            }
        }

        private void ActualWebPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        public string URL
        {
            get
            {
                return actualWebPage.URL;
            }
        }
        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
