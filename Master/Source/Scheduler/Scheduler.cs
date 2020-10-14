using System.Threading;
using ComponentInterfaces.Tasks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Scheduler
{
	public class Scheduler
	{
		private readonly ConcurrentQueue<ITask> queue = new ConcurrentQueue<ITask>();
		private ManualResetEvent manualResetEvent = new ManualResetEvent(false);

		private static Scheduler _instance = null;
		private Scheduler() 
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

		public static Scheduler Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Scheduler();
				}
				return _instance;
			}
		}

		public void Insert(ITask task)
		{
			queue.Enqueue(task);
			manualResetEvent.Set();

		}

		public void Dispatch()
		{
			ITask task;
			queue.TryDequeue(out task);
			if (task.CanRun())
			{
				task.Call();
				manualResetEvent.Reset();
			}
			else
			{
				Insert(task);
			}

		}
    }
}
