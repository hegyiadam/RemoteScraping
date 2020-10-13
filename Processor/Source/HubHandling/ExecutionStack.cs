using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HubHandling
{
	public class ExecutionStack
	{
		public class MethodCall
        {
			public string MethodName { get; set; }
			public string Parameters { get; set; }
        }
		private static readonly ConcurrentQueue<Action> queue = new ConcurrentQueue<Action>();
		private static Dispatcher _dispatcher;
		public static readonly ObservableCollection<MethodCall> methodCalls = new ObservableCollection<MethodCall>();
		private static ManualResetEvent manualResetEvent = new ManualResetEvent(false);

		public static void Insert(Action action, string functionName, object[] parameters)
		{
			queue.Enqueue(action);
			_dispatcher.Invoke((Action)delegate
			{
				methodCalls.Add(new MethodCall()
				{
					MethodName = functionName,
					Parameters = String.Join(",", parameters)
				});
			});
			
			manualResetEvent.Set();

		}

		public static void StartExecution(Dispatcher dispatcher)
		{
			_dispatcher = dispatcher;
			new Thread(() =>
			{
				while (true)
				{
					if (queue.IsEmpty)
					{
						manualResetEvent.WaitOne();
						Action action;
						queue.TryDequeue(out action);
						action();
					}
                    else
                    {
						Action action;
						queue.TryDequeue(out action);
						action();
					}
					_dispatcher.Invoke((Action)delegate
					{
						methodCalls.RemoveAt(0);
					});
					manualResetEvent.Reset();
				}
			}).Start();

		}
	}
}
