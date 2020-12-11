using ComponentInterfaces.Processor;

namespace PythonComponents
{
    public class Processor : ComponentInterfaces.Processor.IProcessor
    {
        public dynamic Client
        {
            get
            {
                return Hub.GetClient(Id.ConnectionId);
            }
        }

        public IProcessorHub Hub { get; set; }
        public IProcessorId Id { get; set; }
    }
}