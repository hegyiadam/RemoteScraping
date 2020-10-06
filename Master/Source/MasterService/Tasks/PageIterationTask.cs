using ComponentInterfaces.Processor;
using HubComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentInterfaces.Tasks;
using PythonComponents;
using Newtonsoft.Json;

namespace MasterService.Tasks
{
    public class PageIterationTask : ProcessorTaskBase, IIterationTask
    {
        public string Selector { get; set; }

        public List<IProcessorTask> NextTasks { get; } = new List<IProcessorTask>();

        public PageIterationTask(string selector, IProcessorFilter processorFilter) : base(processorFilter)
        {
            Selector = selector;
        }
        public override void Call()
        {
            ActualState = TaskState.Processing;

            int[] pageNumers = JsonConvert.DeserializeObject<int[]>(Processor.get_page_numbers(URL, Selector).ToString());


            foreach (IProcessorTask nextTask in NextTasks)
            {
                for (int i = 0; i < pageNumers.Length; i++)
                {
                    IProcessor processor = GetNextProcessor();
                    nextTask.PageNumber = pageNumers[i];
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
