using BrowserManagement;
using BrowserManagement.Wrappers.CefSharpWrapper;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFBrowserClient.Model;
using WPFBrowserClient.View.Pages;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel
{
    public class SiteScrapingPageViewModel
    {
        private ActualWebPage actualPage = ActualWebPage.Instance;

        public SiteScrapingPageViewModel(ChromiumWebBrowser browser)
        {
            Browser = browser;
            Commands = new ObservableCollection<DisplayableCommand>()
            {
                new DisplayableCommand()
                {
                    Name = "Highlight clicked elements",
                    Command = new GetElementAtMousePositionCommand(BrowserWrapper)
                },
                new DisplayableCommand()
                {
                    Name = "Hello2",
                    Command = new TestCommand("2")
                },
                new DisplayableCommand()
                {
                    Name = "Hello3",
                    Command = new TestCommand("3")
                },
            };
        }

        public ChromiumWebBrowser Browser { get; set; }

        public BrowserManagement.IBrowserWrapper BrowserWrapper
        {
            get
            {
                return BrowserWrapperFactory.CreateBrowserWrapper(Browser);
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

        public ObservableCollection<DisplayableCommand> Commands { get; set; }
    }
}
