using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using MasterService.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class SetRootUrlTask : TaskBase
    {
        private SessionRepository sessionRepository = SessionRepository.Instance;
        private string _url;

        public SetRootUrlTask(string url)
        {
            _url = url;
        }

        public override void Call()
        {
            Session.Session session = new Session.Session();
            session.SetRootUrl(_url);
            SessionRepository.Instance.AddSession(session);
            Result = session.Id;
            ActualState = TaskState.Ready;
        }
    }
}
