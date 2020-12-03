using ComponentInterfaces.Session;
using ComponentInterfaces.Tasks;
using MasterService.RequestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class AddScrapingTask : TaskBase
    {
        public AddScrapingTaskRequest Data{ get; set; }
        public IProcessorTask Task { get; set; }

        public override void Call()
        {


            ActualState = ComponentInterfaces.Tasks.TaskState.Processing;
            ISession session = sessionRepository.GetSession(Data.SessionId);
            session.AddScrapingTask(Task);
            ActualState = ComponentInterfaces.Tasks.TaskState.Ready;
        }
    }
}
