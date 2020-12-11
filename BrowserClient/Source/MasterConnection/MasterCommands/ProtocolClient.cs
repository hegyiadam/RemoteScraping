using MasterConnection.MasterCommands.SwaggerGenerated;
using System.Net.Http;

namespace MasterConnection.MasterCommands
{
    public class ProtocolClient
    {
        private static ProtocolClient _instance = null;

        private ProtocolClient()
        {
            Client = new MethodClient(new HttpClient());
        }

        public static ProtocolClient Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProtocolClient();
                }
                return _instance;
            }
        }

        public IMethodClient Client { get; set; }
    }
}