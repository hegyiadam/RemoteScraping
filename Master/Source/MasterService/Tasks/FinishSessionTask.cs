using ComponentInterfaces.Processor;
using ComponentInterfaces.Session;
using PythonComponents;

namespace MasterService.Tasks
{
    public class FinishSessionTask : ProcessorTaskBase
    {
        public FinishSessionTask(IProcessorFilter processorFilter) : base(processorFilter)
        {
            ProcessorFilter = processorFilter;
        }

        public ISessionId SessionId { get; set; }

        public override void Call()
        {
            Processor.session_finished(SessionId.Serialize());
        }

        public override object Clone()
        {
            FinishSessionTask clone = new FinishSessionTask(ProcessorFilter)
            {
                SessionId = SessionId
            };

            return clone;
        }
    }
}