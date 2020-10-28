using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentInterfaces.Tasks;
using PythonComponents;
using HubComponents;

namespace MasterService.Tasks
{
    public class LinkIterationTask : ProcessorTaskBase, IIterationTask
    {
        public string Selector { get; set; }
        public List<IProcessorTask> NextTasks { get; } = new List<IProcessorTask>();

        public LinkIterationTask(string selector, IProcessorFilter processorFilter) : base(processorFilter)
        {
            Selector = selector;
        }
        public override void Call()
        {
            ActualState = TaskState.Processing;
            if (PageNumber != null)
            {
                Processor.get_iteration_links2(URL, PageSelector, PageNumber.ToString(), Selector);
                ProcessorManager.Instance.AddResultListener("get_iteration_links2_result", resultProcessing, Processor.Id);
            }
            else
            {
                Processor.get_iteration_links(URL, Selector);
                ProcessorManager.Instance.AddResultListener("get_iteration_links_result", resultProcessing, Processor.Id);
            }
        }

        private void resultProcessing(string result)
        {
            string[] links = JsonConvert.DeserializeObject<string[]>(result);
            TaskBatch taskBatch = new TaskBatch();
            for (int i = 0; i < links.Length; i++)
            {
                IProcessor processor = GetNextProcessor();
                foreach (IProcessorTask nextTask in NextTasks)
                {
                    IProcessorTask nextTaskInstance = (IProcessorTask)nextTask.Clone();
                    nextTaskInstance.URL = links[i];
                    nextTaskInstance.Processor = processor;
                    taskBatch.Tasks.Add(nextTaskInstance);
                }
            }
            Scheduler.Scheduler.Instance.Insert(taskBatch);
            Result = Selector;
            ActualState = TaskState.Ready;
        }


        private IProcessor GetNextProcessor()
        {
            return ProcessorManager.Instance.GetProcessors(ProcessorFilter).FirstOrDefault();
        }

        public override object Clone()
        {
            LinkIterationTask clone = new LinkIterationTask(Selector, ProcessorFilter);
            clone.NextTasks.AddRange(NextTasks);
            return clone;
        }
    }
}
