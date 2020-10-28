using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class TaskBatch : TaskBase
    {
        public List<ITask> Tasks { get; set; } = new List<ITask>();
        public override void Call()
        {
            foreach (ITask task in Tasks)
            {
                task.Call();
                Thread.Sleep(1000);
            }
            Thread.Sleep(1000);
        }
    }
}
