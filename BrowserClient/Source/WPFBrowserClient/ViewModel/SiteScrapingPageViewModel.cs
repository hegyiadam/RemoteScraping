using BrowserManagement;
using BrowserManagement.Wrappers.CefSharpWrapper;
using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
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
        private ActualWebPage actualWebPage = ActualWebPage.Instance;

        public SiteScrapingPageViewModel(ChromiumWebBrowser browser)
        {
            Browser = browser;
            InitializeCommands();
        }

        [ImportMany]
        public IScrapingCommand[] ScrapingCommands { get; set; }

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
            InitializeScrapingCommands();
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

        private void InitializeScrapingCommands()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IScrapingCommand).Assembly));
            CompositionContainer container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);
        }
    }
}
