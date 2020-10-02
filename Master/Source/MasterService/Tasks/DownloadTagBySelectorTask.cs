using ComponentInterfaces.Processor;
using ComponentInterfaces.Tasks;
using HubComponents;
using PythonComponents;
using System.Linq;

namespace MasterService.Tasks
{
    public class DownloadTagBySelectorTask : ProcessorTaskBase
    {
        public DownloadTagBySelectorTask(IProcessorFilter processorFilter) : base(processorFilter)
        {
        }

        public string Selector { get; set; }

        public override void Call()
        {
            ProcessorManager.Instance.GetProcessors(ProcessorFilter).FirstOrDefault().find_tag_by_css_selector("http://localhost:5000",Selector);
            Result = Selector;
            System.Threading.Thread.Sleep(10000);
            ActualState = TaskState.Ready;
        }
    }
}
