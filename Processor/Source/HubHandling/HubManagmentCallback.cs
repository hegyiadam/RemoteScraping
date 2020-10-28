using DatabaseManagement;
using DatabaseManagement.Mongo;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubHandling
{
    public class HubManagmentCallback
    {
        IHubProxy _hubProxy;
        IDatabaseManager databaseManager = MongoDatabase.Instance;
        public HubManagmentCallback(IHubProxy hubProxy)
        {
            _hubProxy = hubProxy;
            SessionStartedCallback();
            SessionFinishedCallback();
        }

        public void SessionStartedCallback()
        {
            _hubProxy.On<String>("session_started", (sessionId) =>
            {
                ExecutionStack.Insert(() => {
                    ExecutionTracker.StartExecution("session_started");
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    keyValuePairs.Add("SessionId", sessionId);
                    databaseManager.CreateNewSession(keyValuePairs);
                    ExecutionTracker.StartExecution("session_started");
                    }, "session_started", new object[] { sessionId });
            });
        }
        public void SessionFinishedCallback()
        {
            _hubProxy.On<String>("session_finished", (sessionId) =>
            {
                ExecutionStack.Insert(() => {
                    ExecutionTracker.StartExecution("session_finished");
                    databaseManager.MergeCurrentResults("Url", sessionId);
                    ExecutionTracker.StartExecution("session_finished");
                }, "session_finished", new object[] { sessionId });
            });
        }
        public void GetSessionResults()
        {
            _hubProxy.On<String>("get_session_result", (sessionId) =>
            {
                List<JObject> results = databaseManager.GetResult("SessionId", sessionId);
                HubConnector.Instance.Proxy.Invoke<string>("SendResult", new object[] { "get_session_result_result", results });
            });
        }
    }
}
