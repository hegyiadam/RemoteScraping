using BrowserManagement;
using MasterConnection.MasterCommands;
using MasterConnection.MasterCommands.SwaggerGenerated;
using System;
using System.Windows;
using System.Windows.Controls;
using WPFBrowserClient.View.UserControls;

namespace WPFBrowserClient.ViewModel.Commands
{
    public class GetNavigationIteratorCommand : IScrapingCommand
    {
        public event EventHandler CanExecuteChanged;

        public IBrowserWrapper Browser { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void CreatePageIterationRequest(string selector)
        {
            IMethodClient methodClient = ProtocolClient.Instance.Client;
            PageIterationRequest pageIterationRequest = new PageIterationRequest() { Selector = selector, SessionId = SessionContainer.Instance.ID };
            methodClient.PageIterationAsync(pageIterationRequest);
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
                        questionDialog = new QuestionDialog("Do you want to iterate through these elements?", (answere) =>
                        {
                            if (answere)
                            {
                                CreatePageIterationRequest((string)response.Result);
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
    }
}