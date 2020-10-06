using ComponentInterfaces.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class ExecuteSessionTask : TaskBase
    {
        public ISessionId SessionId { get; set; }

        public override void Call()
        {
            ActualState = ComponentInterfaces.Tasks.TaskState.Processing;
            ISession session = Session.SessionRepository.Instance.GetSession(SessionId);
            session.Execute();
            ActualState = ComponentInterfaces.Tasks.TaskState.Ready;
        }
    }
}
