using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using HubComponents;
using System.Linq;

namespace MasterService.Tasks
{
    public abstract class ProcessorTaskBase : TaskBase, IProcessorTask
    {
        private IProcessor processor;
        private ProcessorManager processorRepo = ProcessorManager.Instance;

        public ProcessorTaskBase(ComponentInterfaces.Processor.IProcessorFilter processorFilter)
        {
            ProcessorFilter = processorFilter;
        }

        public int PageNumber { get; set; }
        public string PageSelector { get; set; }

        public IProcessor Processor
        {
            get
            {
                if (processor == null)
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

        public IProcessorFilter ProcessorFilter { get; protected set; }
        public string URL { get; set; }

        public bool CanRun()
        {
            return processorRepo.GetProcessors(ProcessorFilter).Count != 0;
        }

        public abstract object Clone();
    }
}