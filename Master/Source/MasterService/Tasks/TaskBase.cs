using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public abstract class TaskBase : ITask
    {
        ITaskIdFactory taskIdFactory = TaskIdFactory.Instance;
        ITaskId taskId;


        public TaskBase()
        {
            taskId = taskIdFactory.CreateId();
        }

        private TaskState actualState;

        public TaskState ActualState
        {
            get
            {
                return actualState;
            }
            set
            {
                actualState = value;
                StateChangedEvent();
            }
        }

        public object Result { get; protected set; }

        public ITaskId Id
        {
            get
            {
                return taskId;
            }
        }


        public event TaskStateChangeHandler StateChangedEvent;

        public abstract void Call();

        public bool CanRun()
        {
            return true;
        }
    }
}
