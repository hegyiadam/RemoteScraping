using BrowserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFBrowserClient.ViewModel.Commands
{
    [InheritedExport]
    public interface IScrapingCommand : ICommand
    {
        IBrowserWrapper Browser { get; set; }
    }
}
