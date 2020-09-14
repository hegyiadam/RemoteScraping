using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public abstract class ProcessorTaskBase : TaskBase
    {
        PythonComponents.ProcessorRepo processorRepo = PythonComponents.ProcessorRepo.Instance;
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
