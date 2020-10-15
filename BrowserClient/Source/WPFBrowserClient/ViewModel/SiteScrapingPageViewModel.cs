using BrowserManagement;
using BrowserManagement.Wrappers.CefSharpWrapper;
using CefSharp;
using CefSharp.Wpf;
using MasterConnection.MasterCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class SiteScrapingPageViewModel : INotifyPropertyChanged
    {
        private IBrowserWrapper _browserWrapeer = null;
        private SiteScrapingPage _siteScrapingPage;
        private static SiteScrapingPageViewModel instance;
        private bool menuIsVisible = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public SiteScrapingPageViewModel(SiteScrapingPage siteScrapingPage, ChromiumWebBrowser browser)
        {
            Browser = browser;
            InitializeCommands();
            _siteScrapingPage = siteScrapingPage;
            instance = this;
            SessionContainer.Instance.CreateNewSession(ActualWebPage.Instance.URL);
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
        public bool MenuIsVisible
        {
            get
            {
                return menuIsVisible;
            }
            set
            {
                menuIsVisible = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("MenuIsHidden");
            }
        }
        public bool MenuIsHidden
        {
            get
            {
                return !MenuIsVisible;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
