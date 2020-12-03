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
                        CreateScrapingRequest((string)response.Result);
                    }
                });
                Browser.RemoveAutoHighlightControl();
                Browser.ControlKeyPressed -= BrowserWrapper_ControlKeyPressed;
            });
            thread.Start();
        }

        public void CreateScrapingRequest(string selector)
        {

            SelectorRequest selectorRequest = new SelectorRequest();
            selectorRequest.Selector = selector;
            IMethodClient methodClient = ProtocolClient.Instance.Client;
            DownloadTagBySelectorRequest downloadTagBySelectorRequest = new DownloadTagBySelectorRequest();
            downloadTagBySelectorRequest.Selector = selector;
            downloadTagBySelectorRequest.SessionId = SessionContainer.Instance.ID;
            methodClient.DownloadTagBySelectorAsync(downloadTagBySelectorRequest);
        }
    }
}
