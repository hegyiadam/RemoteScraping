using ComponentInterfaces.Session;
using MasterService.RequestData;
using MasterService.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PythonComponents;

namespace MasterService.Tasks
{
    public class AddLinkIterationTask : TaskBase
    {
        public LinkIterationRequest Data { get; set; }

        public override void Call()
        {
            ActualState = ComponentInterfaces.Tasks.TaskState.Processing;
            ISession session = sessionRepository.GetSession(new SessionId()
            {
                SerialNumber = Data.SessionId.SerialNumber
            });
            PythonComponents.ProcessorFilter filter = new PythonComponents.ProcessorFilter();
            session.AddIterationTask(new LinkIterationTask(Data.Selector, filter));
            ActualState = ComponentInterfaces.Tasks.TaskState.Ready;
        }
    }
}
