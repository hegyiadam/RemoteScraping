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
            GetSessionResults();
        }

        public void SessionStartedCallback()
        {
            _hubProxy.On<String>("session_started", (sessionId) =>
            {
                ExecutionStack.Insert(() => {
                    databaseManager.CreateNewSession(new SessionId()
                    {
                        Id = sessionId
                    });
                }, "session_started", new object[] { sessionId });
            });
        }

        public void SessionFinishedCallback()
        {
            _hubProxy.On<String>("session_finished", (sessionId) =>
            {
                ExecutionStack.Insert(() => {
                    databaseManager.MergeCurrentResults("Url", new SessionId()
                    {
                        Id = sessionId
                    });
                }, "session_finished", new object[] { sessionId });
            });
        }

        public void GetSessionResults()
        {
            _hubProxy.On<String>("get_session_result", (sessionId) =>
            {
                string results = databaseManager.GetResult(new SessionId()
                {
                    Id =  sessionId
                });

                HubConnector.Instance.Proxy.Invoke<string>("SendResult", new object[] { "get_session_result_result", results });
            });
        }
    }
}
