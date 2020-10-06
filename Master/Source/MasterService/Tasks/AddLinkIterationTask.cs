using ComponentInterfaces.Session;
using MasterService.RequestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class AddLinkIterationTask : TaskBase
    {
        public LinkIterationRequest Data { get; set; }

        public override void Call()
        {
            ActualState = ComponentInterfaces.Tasks.TaskState.Processing;
            ISession session = Session.SessionRepository.Instance.GetSession(Data.SessionId);
            session.AddIterationTask(new LinkIterationTask(Data.Selector, new PythonComponents.ProcessorFilter()));
            ActualState = ComponentInterfaces.Tasks.TaskState.Ready;
        }
    }
}
