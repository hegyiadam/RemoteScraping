using ComponentInterfaces.Tasks;

namespace MasterService.Tasks
{
    public class TaskId : ITaskId
    {
        public int Id { get; set; }

        public ITaskId Deserialize(string source)
        {
            return new TaskId()
            {
                Id = int.Parse(source)
            };
        }

        public string Serialize()
        {
            return Id.ToString();
        }
    }
}