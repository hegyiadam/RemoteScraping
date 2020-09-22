using BrowserManagement;
using CefSharp.Wpf;
using MasterConnection;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WPFBrowserClient.Model;

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
            Browser.GetControl().Focus();
            Browser.AutoHighlightControl();
            Browser.ControlKeyPressed += BrowserWrapper_ControlKeyPressed;
        }

        private void BrowserWrapper_ControlKeyPressed()
        {
            Thread thread = new Thread(() =>
            {
                Browser.GetElementOnMousePosition().ContinueWith(t =>
                {
                    var response = t.Result;
                    if (response.Success && response.Result != null)
                    {
                        SelectorRequest selectorRequest = new SelectorRequest();
                        selectorRequest.Selector = (string)response.Result;
                        MasterConnection.MasterConnection.RunCommand("DownloadTagBySelector",selectorRequest);
                    }
                });
                Browser.RemoveAutoHighlightControl();
                Browser.ControlKeyPressed -= BrowserWrapper_ControlKeyPressed;
            });
            thread.Start();
        }
    }
}
