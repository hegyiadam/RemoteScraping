using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using HubComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public abstract class ProcessorTaskBase : TaskBase, IProcessorTask
    {
        private IProcessor processor;
        public IProcessorFilter ProcessorFilter { get; protected set; }
        public IProcessor Processor
        {
            get
            {
                if(processor == null)
                {
                    return processorRepo.GetProcessors(ProcessorFilter).FirstOrDefault();
                }
                return processor;
            }
            set
            {
                processor = value;
            }
                
        }

        public int PageNumber { get; set; }
        public string URL { get; set; }

        ProcessorManager processorRepo = ProcessorManager.Instance;
        public ProcessorTaskBase(ComponentInterfaces.Processor.IProcessorFilter processorFilter)
        {
            ProcessorFilter = processorFilter;
        }

        public bool CanRun()
        {
            return processorRepo.GetProcessors(ProcessorFilter).Count != 0;
        }
    }
}
