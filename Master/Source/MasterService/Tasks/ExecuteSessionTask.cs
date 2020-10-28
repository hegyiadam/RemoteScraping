using ComponentInterfaces.Processor;
using ComponentInterfaces.Session;
using HubComponents;
using PythonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class ExecuteSessionTask : ProcessorTaskBase
    {
        public ExecuteSessionTask(IProcessorFilter processorFilter) : base(processorFilter)
        {
            ProcessorFilter = processorFilter;
        }

        public ISessionId SessionId { get; set; }

        public override void Call()
        {
            ActualState = ComponentInterfaces.Tasks.TaskState.Processing;
            IList<IProcessor> processors = GetAllProcessors();
            ISession session = Session.SessionRepository.Instance.GetSession(SessionId);
            session.Execute();
            ActualState = ComponentInterfaces.Tasks.TaskState.Ready;
        }

        public override object Clone()
        {
            ExecuteSessionTask clone = new ExecuteSessionTask(ProcessorFilter);
            return clone;
        }

        private IList<IProcessor> GetAllProcessors()
        {
            return ProcessorManager.Instance.GetProcessors(ProcessorFilter);
        }
    }
}
