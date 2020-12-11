using ComponentInterfaces.Tasks;
using MasterService.Session;

namespace MasterService.Tasks
{
    public class SetRootUrlTask : TaskBase
    {
        private string _url;
        private SessionRepository sessionRepository = SessionRepository.Instance;

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