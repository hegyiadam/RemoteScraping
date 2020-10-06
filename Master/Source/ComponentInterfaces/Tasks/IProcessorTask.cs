using ComponentInterfaces.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentInterfaces.Tasks
{
    public interface IProcessorTask : IPageTask
    {
        IProcessor Processor { get; set; }
        string URL{ get; set; }
    }
}
