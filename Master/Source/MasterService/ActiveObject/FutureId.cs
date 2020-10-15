using ComponentInterfaces.Tasks;
using MasterService.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.ActiveObject
{
    public class FutureId
    {
        public string Id { get; set; }

        public void ParseTaskId(ITaskId taskId)
        {
            Id = taskId.Serialize();
        }

        public ITaskId CreateTaskId()
        {
            ITaskId taskId = new TaskId();
            return taskId.Deserialize(Id);
        }

        public override bool Equals(object obj)
        {
            return obj is FutureId id &&
                   Id == id.Id;
        }
    }
}
