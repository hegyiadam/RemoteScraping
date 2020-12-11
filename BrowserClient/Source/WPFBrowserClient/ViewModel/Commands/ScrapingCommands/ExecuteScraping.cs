using BrowserManagement;
using MasterConnection.MasterCommands;
using MasterConnection.MasterCommands.SwaggerGenerated;
using System;

namespace WPFBrowserClient.ViewModel.Commands.ScrapingCommands
{
    public class ExecuteScraping : IScrapingCommand
    {
        public event EventHandler CanExecuteChanged;

        public IBrowserWrapper Browser { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IMethodClient methodClient = ProtocolClient.Instance.Client;
            ExecuteSessionRequest executeSessionRequest = new ExecuteSessionRequest() { SessionId = SessionContainer.Instance.ID };
            methodClient.ExecuteSessionAsync(executeSessionRequest);
        }
    }
}