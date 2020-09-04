using BrowserManagement;
using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFBrowserClient.ViewModel.Commands
{
    public class GetElementAtMousePositionCommand : ICommand
    {
        private IBrowserWrapper Browser;

        public GetElementAtMousePositionCommand(IBrowserWrapper browser)
        {
            Browser = browser;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Thread thread = new Thread(() =>
            {
                Browser.HighlightControl();
            });

            thread.Start();
        }
    }
}
