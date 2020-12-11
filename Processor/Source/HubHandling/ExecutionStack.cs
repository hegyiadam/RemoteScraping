using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;

namespace HubHandling
{
    public static partial class ExecutionStack
    {
        private static readonly ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();
        private static readonly ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
        private static Dispatcher _dispatcher;

        public static ObservableCollection<MethodCall> MethodCalls { get; } = new ObservableCollection<MethodCall>();

        public static void Insert(Action action, string functionName, object[] parameters)
        {
            AddToActions(action);
            AddToMethodCalls(functionName, parameters);

            _manualResetEvent.Set();
        }

        public static void StartExecution(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            new Thread(ExecutionLoop).Start();
        }

        private static void AddToActions(Action action)
        {
            _actions.Enqueue(action);
        }

        private static void AddToMethodCalls(string functionName, object[] parameters)
        {
            MethodCall newMethodCall = new MethodCall(functionName, parameters);

            //To avoid UI blocking
            _dispatcher.Invoke(() =>
            {
                MethodCalls.Add(newMethodCall);
            });
        }

        private static void ExecuteMethodFirstCall()
        {
            MethodCall firstMethodCall = GetFirstMethodCall();
            _actions.TryDequeue(out Action action);
            ExecutionTracker.StartExecution(firstMethodCall.MethodName);
            action();
            ExecutionTracker.FinishExecution(firstMethodCall.MethodName);

            UpdateMethodCalls();
        }

        private static void ExecutionLoop()
        {
            while (true)
            {
                if (_actions.IsEmpty)
                {
                    _manualResetEvent.WaitOne();
                }
                else
                {
                    ExecuteMethodFirstCall();
                    _manualResetEvent.Reset();
                }
            }
        }

        private static MethodCall GetFirstMethodCall()
        {
            return MethodCalls[0];
        }

        private static void UpdateMethodCalls()
        {
            _dispatcher.Invoke(() =>
            {
                MethodCalls.RemoveAt(0);
            });
        }
    }
}