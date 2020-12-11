using ComponentInterfaces.Processor;

namespace HubComponents
{
    public class ProcessorId : IProcessorId
    {
        public string ConnectionId { get; set; }

        public bool EqualsTo(IProcessorId processorId)
        {
            return processorId.ConnectionId.Equals(ConnectionId);
        }
    }
}