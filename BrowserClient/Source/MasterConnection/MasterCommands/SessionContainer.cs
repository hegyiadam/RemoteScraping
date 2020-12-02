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
            MethodClient methodClient = new MethodClient(new System.Net.Http.HttpClient());
            RootURLRequest rootURLRequest = new RootURLRequest()
            {
                URL = url
            };
            methodClient.RootUrlAsync(rootURLRequest).ContinueWith((result) =>
             {
                 FutureId futureId = result.Result.Id;
                 SessionIdDAO sessionIdDAO = null;
                 while (sessionIdDAO == null)
                 {
                     string currentState = FutureHandling.GetState(futureId);
                     if (currentState == FutureState.READY)
                     {
                         JObject sessionResult = (JObject)methodClient.GetFutureResultAsync(futureId).Result;
                         sessionIdDAO = (SessionIdDAO)sessionResult.ToObject(typeof(SessionIdDAO));
                     }
                 }
                 ID = sessionIdDAO;
             });
        }

        public SessionIdDAO ID { get; set; }


    }
}
