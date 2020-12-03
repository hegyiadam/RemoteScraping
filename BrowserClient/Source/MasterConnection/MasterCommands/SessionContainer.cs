using MasterConnection.MasterCommands.SwaggerGenerated;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterConnection.MasterCommands
{
    public class SessionContainer
    {

        private static SessionContainer _instance = null;
        private SessionContainer() { }
        public static SessionContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SessionContainer();
                }
                return _instance;
            }
        }
        public void CreateNewSession(string url)
        {
            CreateRootUrlRequest(url).ContinueWith((result) =>
             {
                 FutureId futureId = result.Result.Id;
                 SessionIdDAO sessionIdDAO = null;
                 while (sessionIdDAO == null)
                 {
                     string currentState = FutureHandling.GetState(futureId);
                     if (currentState == FutureState.READY)
                     {
                         sessionIdDAO = GetFutureResult(futureId);
                     }
                 }
                 ID = sessionIdDAO;
             });
        }

        public SessionIdDAO GetFutureResult(FutureId futureId)
        {
            IMethodClient methodClient = ProtocolClient.Instance.Client;
            JObject sessionResult = (JObject)methodClient.GetFutureResultAsync(futureId).Result;
            return (SessionIdDAO)sessionResult.ToObject(typeof(SessionIdDAO));
        }

        public Task<Future> CreateRootUrlRequest(string url)
        {
            IMethodClient methodClient = ProtocolClient.Instance.Client;
            RootURLRequest rootURLRequest = new RootURLRequest()
            {
                URL = url
            };
            return methodClient.RootUrlAsync(rootURLRequest);
        }

        public SessionIdDAO ID { get; set; }


    }
}
