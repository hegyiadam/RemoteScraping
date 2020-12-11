using BrowserManagement;
using MasterConnection.MasterCommands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using CefSharp.Wpf;
using WPFBrowserClient.CompositionManagement;
using WPFBrowserClient.Model;
using WPFBrowserClient.View.Pages;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel
{
    public class SiteScrapingPageViewModel : INotifyPropertyChanged
    {
        private static SiteScrapingPageViewModel instance;
        private IBrowserWrapper _browserWrapeer = null;
        private SiteScrapingPage _siteScrapingPage;
        private bool menuIsVisible = false;

        public SiteScrapingPageViewModel(SiteScrapingPage siteScrapingPage, ChromiumWebBrowser browser)
        {
            Browser = browser;
            InitializeCommands();
            _siteScrapingPage = siteScrapingPage;
            instance = this;
            SessionContainer.Instance.CreateNewSession(ActualWebPage.Instance.URL);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static Grid RootGrid
        {
            get
            {
                return instance._siteScrapingPage.RootGrid;
            }
        }

        public ChromiumWebBrowser Browser { get; set; }

        public BrowserManagement.IBrowserWrapper BrowserWrapper
        {
            get
            {
                if (_browserWrapeer == null)
                {
                    _browserWrapeer = BrowserWrapperFactory.CreateBrowserWrapper(Browser);
                }
                return _browserWrapeer;
            }
        }

        public ObservableCollection<DisplayableCommand> Commands { get; set; }

        public bool MenuIsHidden
        {
            get
            {
                return !MenuIsVisible;
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

        [ImportMany]
        public IScrapingCommand[] ScrapingCommands { get; set; }

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

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}