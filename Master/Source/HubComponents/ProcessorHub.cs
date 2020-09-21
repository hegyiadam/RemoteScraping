using System;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace HubComponents
{
    public class ProcessorHub : Hub
    {
        #region Methods
        public void Send(string message)
        {
            Console.WriteLine(message);
        }

        public void DoSomething(string param)
        {
            Console.WriteLine(param);
            Clients.All.addMessage(param);
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
        #endregion
    }

}