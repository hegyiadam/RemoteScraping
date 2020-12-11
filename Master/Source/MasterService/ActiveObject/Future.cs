using ComponentInterfaces.Tasks;
using System;

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

        private ITask Task { get; set; }

        private FutureState ConvertTaskStateToFutureState(TaskState actualState)
        {
            return (FutureState)Enum.Parse(typeof(FutureState), Enum.GetName(typeof(TaskState), actualState));
        }

        private void Task_StateChangedEvent()
        {
        }
    }
}