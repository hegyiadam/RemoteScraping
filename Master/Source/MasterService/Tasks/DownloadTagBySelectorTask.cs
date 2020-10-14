using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using HubComponents;
using PythonComponents;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace MasterService.Tasks
{
    public class DownloadTagBySelectorTask : ProcessorTaskBase
    {
        public DownloadTagBySelectorTask(string selector ,IProcessorFilter processorFilter) : base(processorFilter)
        {
            Selector = selector;
        }

        private string Selector { get; set; }

        public override void Call()
        {
            new Thread(() =>
            {
                Processor.find_tag_by_css_selector(URL, Selector);
            }).Start();
            Result = Selector;
            ActualState = TaskState.Ready;
        }

        public override object Clone()
        {
            return new DownloadTagBySelectorTask(Selector, ProcessorFilter);
        }
    }
}
