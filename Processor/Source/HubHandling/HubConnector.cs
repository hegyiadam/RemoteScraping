using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubHandling
{
    public class HubConnector
    {
        private const string exitCommand = "exit";
        private static HubConnection hubConnection;
        private static IHubProxy hubProxy;

        public async static void Start()
        {
            hubConnection = new HubConnection("http://localhost:8080//");
            hubProxy = hubConnection.CreateHubProxy("ProcessorHub");
            hubConnection.Start().Wait();
        }

        public static void Stop()
        {
            hubConnection.Dispose();
        }

        public async static void SendCommand()
        {
             hubProxy.Invoke<string>("DoSomething", "Hello");
        }
    }
}
