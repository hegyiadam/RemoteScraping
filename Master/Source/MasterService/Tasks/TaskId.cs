using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class TaskId : ITaskId
    {
        public int Id { get; set; }

        public string Serialize()
        {
            return Id.ToString();
        }

        public ITaskId Deserialize(string source)
        {
            return new TaskId()
            {
                Id = int.Parse(source)
            };
        }
    }
}
