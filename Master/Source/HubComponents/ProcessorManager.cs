using ComponentInterfaces.Processor;
using PythonComponents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HubComponents
{
    public class ProcessorManager
    {
        private static ProcessorManager _instance = null;
        private List<IProcessor> processors = new List<IProcessor>();
        private Dictionary<ResultKey, Stack<Action<string>>> resultListeners = new Dictionary<ResultKey, Stack<Action<string>>>();

        private ProcessorManager()
        {
        }

        public static ProcessorManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProcessorManager();
                }
                return _instance;
            }
        }

        public void AddProcessor(Processor processor)
        {
            processors.Add(processor);
        }

        public void AddResultListener(string methodName, Action<string> action, IProcessorId processorId)
        {
            ResultKey resultKey = CreateResultKey(methodName, processorId);
            try
            {
                KeyValuePair<ResultKey, Stack<Action<string>>> listeners = FindResultListener(resultKey);
                listeners.Value.Push(action);
            }
            catch (InvalidOperationException e)
            {
                Stack<Action<string>> stack = new Stack<Action<string>>();
                resultListeners.Add(resultKey, stack);
                stack.Push(action);
            }
        }

        public IProcessorId GetProcessorId(string connectionId)
        {
            return new ProcessorId()
            {
                ConnectionId = connectionId
            };
        }

        public IList<IProcessor> GetProcessors(IProcessorFilter processorFilter)
        {
            return processors;
        }

        public void ResultTriggered(string methodName, string result, IProcessorId processorId)
        {
            ResultKey resultKey = CreateResultKey(methodName, processorId);

            KeyValuePair<ResultKey, Stack<Action<string>>> listener = FindResultListener(resultKey);
            Action<string> resultListener = listener.Value.Pop();
            resultListener(result);
            if (listener.Value.Count == 0)
            {
                resultListeners.Remove(listener.Key);
            }
        }

        private ResultKey CreateResultKey(string methodName, IProcessorId processorId)
        {
            ResultKey resultKey = new ResultKey();
            resultKey.ProcessorId = processorId;
            resultKey.MethodName = methodName;
            return resultKey;
        }

        private KeyValuePair<ResultKey, Stack<Action<string>>> FindResultListener(ResultKey resultKey)
        {
            return resultListeners.Where(listeners =>
                                                listeners.Key.ProcessorId.EqualsTo(resultKey.ProcessorId)
                                                && listeners.Key.MethodName.Equals(resultKey.MethodName))
                                                .First();
        }

        private struct ResultKey
        {
            public string MethodName;
            public IProcessorId ProcessorId;
        }
    }
}