using Microsoft.AspNet.SignalR.Client;
using PythonExecution;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HubHandling
{
    public class HubConnector
    {
        private const string HUB_SERVER_URL = "http://localhost:8080//";
        private const string HUB_NAME = "ProcessorHub";

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

        public HubConnection Connection { get; private set; }

        public IHubProxy Proxy { get; private set; }

        public bool Connected => Connection?.State == ConnectionState.Connected;

        public Task Start()
        {
            Connection = new HubConnection(HUB_SERVER_URL);
            Proxy = Connection.CreateHubProxy(HUB_NAME);
            return Connection.Start();
        }

        public void Stop()
        {
            Connection.Dispose();
        }

        public void SubscribeToEvent()
        {
            new HubCallback(Proxy);
            new HubManagmentCallback(Proxy);
        }
    }
}
