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
        private FutureId id;
        public Future(ITask task)
        {
            Task = task;
            id = new FutureId();
            id.ParseTaskId(task.Id);
            task.StateChangedEvent += Task_StateChangedEvent; 
        }

        private void Task_StateChangedEvent()
        {
        }

        private ITask Task { get; set; }

        public event TaskStateChangeHandler StateChangedEvent;

        public FutureId Id
        {
            get
            {
                return id;
            }
        }

        public object Result
        {
            get
            {
                return Task.Result;
            }

        }

        public FutureState State
        {
            get
            {
                return ConvertTaskStateToFutureState(Task.ActualState);
            }
        }

        private FutureState ConvertTaskStateToFutureState(TaskState actualState)
        {
            return (FutureState)Enum.Parse(typeof(FutureState),Enum.GetName(typeof(TaskState), actualState));
        }
    }
}
