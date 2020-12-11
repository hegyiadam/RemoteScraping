using ComponentInterfaces.Tasks;

namespace MasterService.Tasks
{
    public class TaskIdFactory : ITaskIdFactory
    {
        private static TaskIdFactory _instance = null;

        private static int counter = 0;

        private TaskIdFactory()
        {
        }

        public static TaskIdFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TaskIdFactory();
                }
                return _instance;
            }
        }

        public ITaskId CreateId()
        {
            counter++;
            return new TaskId()
            {
                Id = counter
            };
        }
    }
}