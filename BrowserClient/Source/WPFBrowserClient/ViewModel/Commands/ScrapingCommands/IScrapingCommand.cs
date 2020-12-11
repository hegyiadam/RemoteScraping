using BrowserManagement;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace WPFBrowserClient.ViewModel.Commands
{
    [InheritedExport]
    public interface IScrapingCommand : ICommand
    {
        IBrowserWrapper Browser { get; set; }
    }
}