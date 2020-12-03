using BrowserManagement;
using CefSharp.Wpf;
using MasterConnection;
using MasterConnection.MasterCommands;
using MasterConnection.MasterCommands.SwaggerGenerated;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFBrowserClient.Model;
using WPFBrowserClient.View.UserControls;

namespace WPFBrowserClient.ViewModel.Commands
{
    public class GetClickIteratorCommand : IScrapingCommand
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
            Browser.GetSiblingsOnMousePosition().ContinueWith(t =>
            {
                var response = t.Result;
                if (response.Success && response.Result != null)
                {
                    string selector = (string)response.Result; 
                    Browser.RemoveAutoHighlightControl();
                    Browser.HighlightControl((string)response.Result);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        QuestionDialog questionDialog = null;
                        Grid rootGrid = SiteScrapingPageViewModel.RootGrid;
                        questionDialog = new QuestionDialog("Do you want to iterate through these elements?",(answere) => {
                            if (answere)
                            {
                                CreateLinkIterationRequest((string)response.Result);
                            }
                            rootGrid.Children.Remove(questionDialog);
                            Browser.RemoveAutoHighlightControl();
                        });
                        rootGrid.Children.Add(questionDialog);
                    });

                }
                Browser.ControlKeyPressed -= BrowserWrapper_ControlKeyPressed;
            });
        }

        public void CreateLinkIterationRequest(string selector)
        {
            IMethodClient methodClient = ProtocolClient.Instance.Client;
            LinkIterationRequest linkIterationRequest = new LinkIterationRequest() { Selector = selector, SessionId = SessionContainer.Instance.ID };
            methodClient.LinkIterationAsync(linkIterationRequest);
        }
    }
}
