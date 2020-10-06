using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using HubComponents;
using PythonComponents;
using System.Linq;
using System.Reflection;

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
            Processor.find_tag_by_css_selector(URL,Selector);
            Result = Selector;
            System.Threading.Thread.Sleep(10000);
            ActualState = TaskState.Ready;
        }
    }
}
