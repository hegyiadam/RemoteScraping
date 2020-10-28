using ComponentInterfaces.Processor;
using ComponentInterfaces.Session;
using HubComponents;
using MasterService.Session;
using PythonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class FinishSessionTask : ProcessorTaskBase
    {
        public ISessionId SessionId { get; set; }
        public FinishSessionTask(IProcessorFilter processorFilter) : base(processorFilter)
        {
            ProcessorFilter = processorFilter;
        }

        public override void Call()
        {
            Processor.session_finished(SessionId.Serialize());
        }
        public override object Clone()
        {
            FinishSessionTask clone = new FinishSessionTask(ProcessorFilter) 
            {
                SessionId = SessionId
            };

            return clone;
        }

    }
}
