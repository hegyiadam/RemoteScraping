using BrowserManagement;
using MasterConnection.MasterCommands;
using MasterConnection.MasterCommands.SwaggerGenerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPFBrowserClient.ViewModel.Commands.ScrapingCommands
{
    public class ExecuteScraping : IScrapingCommand
    {
        public IBrowserWrapper Browser { get; set; }

        public event EventHandler CanExecuteChanged;

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
