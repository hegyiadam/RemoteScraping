using System;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using HubComponents.ClientInterface;

namespace HubComponents
{
    public class ProcessorHub : Hub
    {
        private static IHubContext context 
        {
            get
            {
                return GlobalHost.ConnectionManager.GetHubContext<ProcessorHub>();
            }
        }



        #region Methods
        public void Send(string message)
        {
            Console.WriteLine(message);
        }

        public static void DoSomething(string param)
        {
            Console.WriteLine(param);
            context.Clients.All.addMessage(param);
        }
        public static void DownloadTag(string selector)
        {
            Console.WriteLine(selector);
            context.Clients.All.find_tag_by_css_selector("http://localhost:5000/", "body > div > div > div:nth-child(1) > div.element-text > div");
        }
        #endregion

        #region Connection Related
        public override Task OnConnected()
        {
            string clientConnectionId = Context.ConnectionId;
            Console.WriteLine("Client connected with " + clientConnectionId + " connetionId");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled)
            {
                Console.WriteLine(String.Format("Client {0} explicitly closed the connection.", Context.ConnectionId));
            }
            else
            {
                Console.WriteLine(String.Format("Client {0} timed out .", Context.ConnectionId));
            }
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Console.WriteLine(Context.ConnectionId + " reconnected.");
            return base.OnReconnected();
        }

        public IExecutable GetExecutableClient()
        {
            IExecutable executable = (IExecutable)context.Clients.All;
            return executable;
        }
        #endregion
    }

}