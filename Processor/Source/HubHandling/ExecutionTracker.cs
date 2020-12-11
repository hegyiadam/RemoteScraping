namespace HubHandling
{
    public delegate void ExecutionDelegate(string commandName);

    public class ExecutionTracker
    {
        public static event ExecutionDelegate ExecutionEnded;

        public static event ExecutionDelegate ExecutionStarted;

        public static void FinishExecution(string commandName)
        {
            if (ExecutionStarted != null)
            {
                ExecutionEnded(commandName);
            }
        }

        public static void StartExecution(string commandName)
        {
            if (ExecutionStarted != null)
            {
                ExecutionStarted(commandName);
            }
        }
    }
}