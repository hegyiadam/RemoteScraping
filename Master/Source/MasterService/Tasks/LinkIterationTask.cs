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
            string[] links = null;
            if (PageNumber != null)
            {
                links = JsonConvert.DeserializeObject<string[]>(Processor.get_iteration_links2(URL,PageNumber.ToString(), Selector).ToString());
            }
            else
            {
                links = JsonConvert.DeserializeObject<string[]>(Processor.get_iteration_links(URL, Selector).ToString());
            }

            foreach(IProcessorTask nextTask in NextTasks)
            {
                for (int i = 0; i < links.Length; i++)
                {
                    IProcessor processor = GetNextProcessor();
                    nextTask.URL = links[i];
                    nextTask.Processor = processor;
                    nextTask.Call();
                }
            }
            Result = Selector;
            System.Threading.Thread.Sleep(10000);
            ActualState = TaskState.Ready;
        }
        private IProcessor GetNextProcessor()
        {
            return ProcessorManager.Instance.GetProcessors(ProcessorFilter).FirstOrDefault();
        }
    }
}
