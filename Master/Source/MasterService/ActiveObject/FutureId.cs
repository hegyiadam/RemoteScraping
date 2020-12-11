using ComponentInterfaces.Tasks;
using MasterService.Tasks;

namespace MasterService.ActiveObject
{
    public class FutureId
    {
        public string Id { get; set; }

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

        public void ParseTaskId(ITaskId taskId)
        {
            Id = taskId.Serialize();
        }
    }
}