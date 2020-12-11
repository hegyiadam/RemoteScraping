using ComponentInterfaces.Tasks;

namespace MasterService.Tasks
{
    public abstract class TaskBase : ITask
    {
        public Session.ISessionRepository sessionRepository = Session.SessionRepository.Instance;
        private TaskState actualState;
        private ITaskId taskId;
        private ITaskIdFactory taskIdFactory = TaskIdFactory.Instance;

        public TaskBase()
        {
            taskId = taskIdFactory.CreateId();
        }

        public event TaskStateChangeHandler StateChangedEvent;

        public TaskState ActualState
        {
            get
            {
                return actualState;
            }
            set
            {
                actualState = value;
                if (StateChangedEvent != null)
                {
                    StateChangedEvent();
                }
            }
        }

        public ITaskId Id
        {
            get
            {
                return taskId;
            }
        }

        public object Result { get; protected set; }

        public abstract void Call();

        public bool CanRun()
        {
            return true;
        }
    }
}