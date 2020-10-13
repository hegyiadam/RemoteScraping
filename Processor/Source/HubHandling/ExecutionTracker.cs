using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubHandling
{
    public delegate void ExecutionDelegate(string commandName);
    public class ExecutionTracker
    {
        public static event ExecutionDelegate ExecutionStarted;
        public static event ExecutionDelegate ExecutionEnded;
        public static void StartExecution(string commandName)
        {
            if (ExecutionStarted != null)
            {
                ExecutionStarted(commandName);
            }
        }
        public static void FinishExecution(string commandName)
        {
            if (ExecutionStarted != null)
            {
                ExecutionEnded(commandName);
            }
        }

    }
}
