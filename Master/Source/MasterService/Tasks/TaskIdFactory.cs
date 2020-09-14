using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Tasks
{
    public class TaskIdFactory : ITaskIdFactory
    {


        private static TaskIdFactory _instance = null;
        private TaskIdFactory() { }
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

        private static int counter = 0;
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
