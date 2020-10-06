using BrowserManagement;
using BrowserManagement.Wrappers.CefSharpWrapper;
using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFBrowserClient.CompositionManagement;
using WPFBrowserClient.Model;
using WPFBrowserClient.View.Pages;
using WPFBrowserClient.View.UserControls;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel
{
    public class SiteScrapingPageViewModel
    {
        private ActualWebPage actualWebPage = ActualWebPage.Instance;
        private IBrowserWrapper _browserWrapeer = null;
        private SiteScrapingPage _siteScrapingPage;
        private static SiteScrapingPageViewModel instance;

        public SiteScrapingPageViewModel(SiteScrapingPage siteScrapingPage, ChromiumWebBrowser browser)
        {
            Browser = browser;
            InitializeCommands();
            _siteScrapingPage = siteScrapingPage;
            instance = this;
        }

        [ImportMany]
        public IScrapingCommand[] ScrapingCommands { get; set; }

        public ChromiumWebBrowser Browser { get; set; }

        public BrowserManagement.IBrowserWrapper BrowserWrapper
        {
            get
            {
                if(_browserWrapeer == null)
                {
                    _browserWrapeer = BrowserWrapperFactory.CreateBrowserWrapper(Browser);
                }
                return _browserWrapeer;
            }
        }

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

        public ObservableCollection<DisplayableCommand> Commands { get; set; }

        private void InitializeCommands()
        {
            CompositionHandler.Compose(typeof(IScrapingCommand), this);
            Commands = new ObservableCollection<DisplayableCommand>();
            foreach (IScrapingCommand command in ScrapingCommands)
            {
                command.Browser = BrowserWrapper;

                Commands.Add(new DisplayableCommand()
                {
                    Command = command
                });
            }
        }

        public static Grid RootGrid
        {
            get
            {
                return instance._siteScrapingPage.RootGrid;
            }
        }
    }
}
