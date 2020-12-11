using ComponentInterfaces.Processor;
using ComponentInterfaces.Session;
using HubComponents;
using PythonComponents;
using System.Collections.Generic;

namespace MasterService.Tasks
{
    public class GetResultTask : ProcessorTaskBase
    {
        public GetResultTask(IProcessorFilter processorFilter) : base(processorFilter)
        {
        }

        public ISessionId SessionId { get; set; }

        public override void Call()
        {
            foreach (IProcessor process in GetAllProcessors())
            {
                process.get_session_result(SessionId.Serialize());
                ProcessorManager.Instance.AddResultListener("get_session_result_result", ResultHandling, Processor.Id);
            }
        }

        public override object Clone()
        {
            return new GetResultTask(ProcessorFilter)
            {
                SessionId = SessionId
            };
        }

        private IList<IProcessor> GetAllProcessors()
        {
            return ProcessorManager.Instance.GetProcessors(ProcessorFilter);
        }

        private void ResultHandling(string data)
        {
            Result = "{\"results\":" + data + "}";
        }
    }
}