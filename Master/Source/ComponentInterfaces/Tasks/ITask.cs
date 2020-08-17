using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Tasks
{
    public delegate void TaskStateChangeHandler();

    public interface ITask
    {
        event TaskStateChangeHandler StateChangedEvent;

        TaskState ActualState { get; }

        bool CanRun();

        void Call();
    }
}
