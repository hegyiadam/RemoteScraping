using System.Collections.Concurrent;
using System.Threading;

namespace MasterConnection.MasterCommands
{
    public class CommandScheduler
    {
        private static CommandScheduler _instance = null;
        private readonly ConcurrentQueue<IMasterCommand> queue = new ConcurrentQueue<IMasterCommand>();
        private ManualResetEvent manualResetEvent = new ManualResetEvent(false);

        private CommandScheduler()
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (queue.IsEmpty)
                    {
                        manualResetEvent.WaitOne();
                    }
                    Dispatch();
                }
            });
            thread.Start();
        }

        public static CommandScheduler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommandScheduler();
                }
                return _instance;
            }
        }

        public void Dispatch()
        {
            IMasterCommand task;
            queue.TryDequeue(out task);
            task.Call();
            manualResetEvent.Reset();
        }

        public void Insert(IMasterCommand task)
        {
            queue.Enqueue(task);
            manualResetEvent.Set();
        }
    }
}