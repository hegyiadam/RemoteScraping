using ComponentInterfaces.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
