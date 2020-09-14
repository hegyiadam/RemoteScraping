using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentInterfaces.Tasks
{
    public delegate void TaskStateChangeHandler();

    public interface ITask
    {
        Processor.IProcessorFilter ProcessorFilter { get; }

        ITaskId Id { get; }

        event TaskStateChangeHandler StateChangedEvent;

        object Result { get; }

        TaskState ActualState { get; }

        bool CanRun();

        void Call();
    }
}
