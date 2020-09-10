using BrowserManagement;
using CefSharp.Wpf;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPFBrowserClient.ViewModel.Commands
{
    public class GetElementAtMousePositionCommand : IScrapingCommand
    {
        public IBrowserWrapper Browser { get; set; }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Browser.GetBrowser<ChromiumWebBrowser>().Focus();
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(2000);
                Browser.GetElementOnMousePosition().ContinueWith(t =>
                {
                    var response = t.Result;
                    if (response.Success && response.Result != null)
                    {
                        MessageBox.Show((string)response.Result);
                    }
                });
            });
            thread.Start();
        }
    }
}
