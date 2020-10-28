using Microsoft.AspNet.SignalR.Client;
using PythonExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HubHandling
{
    public class HubConnector
    {
        private const string exitCommand = "exit";
        private static HubConnection hubConnection;
        private static IHubProxy hubProxy;


        private static HubConnector _instance = null;
        private HubConnector()
        {
        }
        public static HubConnector Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HubConnector();
                }
                return _instance;
            }
        }

        public HubConnection Connection 
        {
            get
            {
                return hubConnection;
            }
        }

        public IHubProxy Proxy
        {
            get
            {
                return hubProxy;
            }
        }

        public async static void Start()
        {
            hubConnection = new HubConnection("http://localhost:8080//");
            hubProxy = hubConnection.CreateHubProxy("ProcessorHub");
            hubConnection.Start().Wait();
        }

        public static bool Connected 
        {
            get
            {
                return hubConnection!=null && hubConnection.State == ConnectionState.Connected;
            }
        }

        public static void Stop()
        {
            hubConnection.Dispose();
        }

        public async static void SendCommand()
        {
            hubProxy.Invoke<string>("Send", "Hello");
        }
        public async static void SubscribeToEvent()
        {
            new HubCallback(hubProxy);
            new HubManagmentCallback(hubProxy);
        }

    }
}
