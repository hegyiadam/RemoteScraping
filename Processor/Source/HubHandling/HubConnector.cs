using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace HubHandling
{
    public class HubConnector
    {
        private const string HUB_NAME = "ProcessorHub";
        private const string HUB_SERVER_URL = "http://localhost:8080//";
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

        public bool Connected => Connection?.State == ConnectionState.Connected;
        public HubConnection Connection { get; private set; }

        public IHubProxy Proxy { get; private set; }

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