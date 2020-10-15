﻿using BrowserManagement;
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
    public class GetNavigationIteratorCommand : IScrapingCommand
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
                                MethodClient methodClient = new MethodClient(new HttpClient());
                                PageIterationRequest pageIterationRequest = new PageIterationRequest() { Selector = (string)response.Result, SessionId = SessionContainer.Instance.ID };
                                methodClient.PageIterationAsync(pageIterationRequest);
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
