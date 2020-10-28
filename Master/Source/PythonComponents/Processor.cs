using ComponentInterfaces.Processor;
using PythonComponents.ClientInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IProcessorId Id { get; set; }

        public IProcessorHub Hub { get; set; }
    }
}
