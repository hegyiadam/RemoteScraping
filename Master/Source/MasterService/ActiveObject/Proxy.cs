using ComponentInterfaces.Tasks;

namespace MasterService.ActiveObject
{
    public class Proxy
    {
        public Future ProcessRequest(ITask task)
        {
            Scheduler.Scheduler scheduler = Scheduler.Scheduler.Instance;

            Future result = new Future(task);
            scheduler.Insert(task);
            return result;
        }
    }
}