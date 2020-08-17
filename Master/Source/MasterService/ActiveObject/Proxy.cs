using Controller.Tasks;
using Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
