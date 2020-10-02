using ComponentInterfaces.Processor;
using PythonComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubComponents
{
    public class ProcessorManager
    {
		private List<IProcessor> processors = new List<IProcessor>();

		private static ProcessorManager _instance = null;
		private ProcessorManager() { }
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

		public IList<IProcessor> GetProcessors(IProcessorFilter processorFilter)
		{

			return processors;
		}
	}
}
