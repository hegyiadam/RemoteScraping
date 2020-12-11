﻿using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using HubComponents;
using Newtonsoft.Json;
using PythonComponents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterService.Tasks
{
    public class PageIterationTask : ProcessorTaskBase, IIterationTask
    {
        public PageIterationTask(string selector, IProcessorFilter processorFilter) : base(processorFilter)
        {
            Selector = selector;
        }

        public List<IProcessorTask> NextTasks { get; } = new List<IProcessorTask>();
        public string Selector { get; set; }

        public override void Call()
        {
            ActualState = TaskState.Processing;
            Processor.get_page_numbers(URL, Selector);
            Action<string> action = (data) => ProcessResult(data);
            ProcessorManager.Instance.AddResultListener("get_page_numbers_result", action, Processor.Id);
        }

        public override object Clone()
        {
            PageIterationTask clone = new PageIterationTask(Selector, ProcessorFilter);
            clone.NextTasks.AddRange(NextTasks);
            return clone;
        }

        private IProcessor GetNextProcessor()
        {
            return ProcessorManager.Instance.GetProcessors(ProcessorFilter).FirstOrDefault();
        }

        private void ProcessResult(string data)
        {
            int[] pageNumers = JsonConvert.DeserializeObject<int[]>(data);

            for (int i = 0; i < pageNumers.Length; i++)
            {
                IProcessor processor = GetNextProcessor();
                foreach (IProcessorTask nextTask in NextTasks)
                {
                    IProcessorTask nextTaskInstance = (IProcessorTask)nextTask.Clone();
                    nextTaskInstance.URL = URL;
                    nextTaskInstance.PageNumber = pageNumers[i];
                    nextTaskInstance.PageSelector = Selector;
                    nextTaskInstance.Processor = processor;
                    Scheduler.Scheduler.Instance.Insert(nextTaskInstance);
                }
            }
            Result = Selector;
            System.Threading.Thread.Sleep(10000);
            ActualState = TaskState.Ready;
        }
    }
}