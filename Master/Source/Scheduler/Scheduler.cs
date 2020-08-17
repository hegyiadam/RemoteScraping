using Controller.Tasks;
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
		private static readonly ConcurrentQueue<ITask> queue = new ConcurrentQueue<ITask>();
		private static Scheduler _instance = null;
		private Scheduler() { }
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

		}

		public void Dispatch()
		{
			ITask task;
			queue.TryDequeue(out task);
			task.CanRun();
			task.Call();

		}


    }
}
