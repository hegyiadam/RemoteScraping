using BrowserManagement;
using System;

namespace WPFBrowserClient.ViewModel.Commands
{
    public class HighlightClickedElement //: IScrapingCommand
    {
        public event EventHandler CanExecuteChanged;

        public IBrowserWrapper Browser { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Browser.AutoHighlightControl();
        }
    }
}