using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFBrowserClient.Model;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel
{
    public class SiteScrapingPageViewModel
    {
        private ActualPage actualPage = ActualPage.Instance;

        public SiteScrapingPageViewModel()
        {
            Commands = new ObservableCollection<DisplayableCommand>()
            {
                new DisplayableCommand()
                {
                    Name = "",
                    Command = new GetElementAtMousePositionCommand(Browser)
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

        public ChromiumWebBrowser Browser 
        { 
            get
            {
                return (WindowViewModel.MainFrame.Content as Page).FindName("Browser") as ChromiumWebBrowser;
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
