using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.ActiveObject
{
    public class Future
    {
        public Future(ITask task)
        {
            Task = task;
            task.StateChangedEvent += Task_StateChangedEvent; 
        }

        private void Task_StateChangedEvent()
        {
        }

        private ITask Task { get; set; }

        public event TaskStateChangeHandler StateChangedEvent;

        public ITaskId Id
        {
            get
            {
                return Task.Id;
            }
        }

        public object Result
        {
            get
            {
                return Task.Result;
            }

        }

        public TaskState State
        {
            get
            {
                return Task.ActualState;
            }
        }
    }
}
