using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterConnection.MasterCommands
{
    public class CommandScheduler
    {
		private readonly ConcurrentQueue<IMasterCommand> queue = new ConcurrentQueue<IMasterCommand>();
		private ManualResetEvent manualResetEvent = new ManualResetEvent(false);

		private static CommandScheduler _instance = null;
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

		public void Insert(IMasterCommand task)
		{
			queue.Enqueue(task);
			manualResetEvent.Set();

		}

		public void Dispatch()
		{
			IMasterCommand task;
			queue.TryDequeue(out task);
			task.Call();
			manualResetEvent.Reset();
		}
	}
}
