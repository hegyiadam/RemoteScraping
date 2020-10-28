using ComponentInterfaces.Processor;
using ComponentInterfaces.Session;
using HubComponents;
using PythonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MasterService.Tasks
{
    public class GetResultTask : ProcessorTaskBase
    {
        public ISessionId SessionId { get; set; }

        public object Result { get; set; }

        public GetResultTask(IProcessorFilter processorFilter) : base(processorFilter)
        {
        }

        public override void Call()
        {
            foreach (IProcessor process in GetAllProcessors())
            {
                process.get_session_result(SessionId.Serialize());
                Action<string> action = (data) => ResultHandling(data);
                ProcessorManager.Instance.AddResultListener("get_session_result_result", action, Processor.Id);
            }
        }

        private void ResultHandling(string data)
        {
            Result = data;
        }

        private IList<IProcessor> GetAllProcessors()
        {
            return ProcessorManager.Instance.GetProcessors(ProcessorFilter);
        }

        public override object Clone()
        {
            return new GetResultTask(ProcessorFilter) 
            {
                SessionId = SessionId
            };
        }
    }
}
