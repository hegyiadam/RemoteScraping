using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBrowserClient.ViewModel.Commands;

namespace WPFBrowserClient.ViewModel
{
    public class SiteScrapingPageViewModel
    {
        public ObservableCollection<DisplayableCommand> Commands { get; set; } = new ObservableCollection<DisplayableCommand>()
        {
            new DisplayableCommand()
            {
                Name = "Hello",
                Command = new TestCommand("1")
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
}
