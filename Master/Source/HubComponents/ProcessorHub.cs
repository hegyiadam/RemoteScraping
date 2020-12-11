using ComponentInterfaces.Processor;
using Microsoft.AspNet.SignalR;
using PythonComponents;
using PythonComponents.ClientInterface;
using System;
using System.Threading.Tasks;

namespace HubComponents
{
    public class ProcessorHub : Hub, IProcessorHub
    {
        public static dynamic Clients => context.Clients.All;

        private static IHubContext context
        {
            get
            {
                return GlobalHost.ConnectionManager.GetHubContext<ProcessorHub>();
            }
        }

        public static void SubscribeToEvent(string name, Action<string> action, IProcessor processor)
        {
            /**(processor.Client).On<string>(name, (data) =>
            {
                action(data);
            });*/
        }

        #region Methods

        public void DownloadTag(string selector)
        {
            Console.WriteLine(selector);
            context.Clients.All.find_tag_by_css_selector("http://localhost:5000/", "body > div > div > div:nth-child(1) > div.element-text > div");
        }

        public void SendResult(string methodName, string result)
        {
            IProcessorId processorId = ProcessorManager.Instance.GetProcessorId(Context.ConnectionId);
            ProcessorManager.Instance.ResultTriggered(methodName, result, processorId);
        }

        #endregion Methods

        #region Connection Related

        public dynamic GetClient(string connectionId)
        {
            return context.Clients.Client(connectionId);
        }

        public IExecutable GetExecutableClient()
        {
            IExecutable executable = (IExecutable)context.Clients.All;
            return executable;
        }

        public override Task OnConnected()
        {
            string clientConnectionId = Context.ConnectionId;
            Console.WriteLine("Client connected with " + clientConnectionId + " connetionId");
            Processor processor = new Processor()
            {
                Id = new ProcessorId()
                {
                    ConnectionId = clientConnectionId
                },

                Hub = this
            };
            ProcessorManager.Instance.AddProcessor(processor);
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

        #endregion Connection Related
    }
}