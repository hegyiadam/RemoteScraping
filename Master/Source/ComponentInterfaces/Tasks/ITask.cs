namespace ComponentInterfaces.Tasks
{
    public delegate void TaskStateChangeHandler();

    public interface ITask
    {
        event TaskStateChangeHandler StateChangedEvent;

        TaskState ActualState { get; }
        ITaskId Id { get; }
        object Result { get; }

        void Call();

        bool CanRun();
    }
}