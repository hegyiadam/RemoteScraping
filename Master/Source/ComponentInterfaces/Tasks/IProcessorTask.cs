using ComponentInterfaces.Processor;
using System;

namespace ComponentInterfaces.Tasks
{
    public interface IProcessorTask : IPageTask, ICloneable
    {
        IProcessor Processor { get; set; }
        string URL { get; set; }
    }
}