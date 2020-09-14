using ComponentInterfaces.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythonComponents
{
    public class ProcessorRepo
    {

        private static ProcessorRepo _instance = null;
        private ProcessorRepo() { }
        public static ProcessorRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProcessorRepo();
                }
                return _instance;
            }
        }

        private static IProcessor processor = new Processor();
        public IProcessor GetProcessor(IProcessorId processorId)
        {
            return processor;
        }
        public IList<IProcessor> GetProcessors(IProcessorFilter processorFilter)
        {
            return new List<IProcessor>() { processor };
        }
    }
}
