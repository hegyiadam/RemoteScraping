using System.Collections.Generic;

namespace ComponentInterfaces.Tasks
{
    public interface IIterationTask : IProcessorTask
    {
        List<IProcessorTask> NextTasks { get; }
    }
}