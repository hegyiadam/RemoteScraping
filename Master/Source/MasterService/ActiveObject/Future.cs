using Controller.Tasks;
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
            task.StateChangedEvent += StateChangeHandler;
        }
        private ITask Task { get; set; }

        public TaskState Result
        {
            get
            {
                return Task.ActualState;
            }

        }

        public void StateChangeHandler()
        {

        }
    }
}
