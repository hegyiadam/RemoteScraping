using ComponentInterfaces.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubComponents
{
    public class ProcessorProxy : IProcessor
    {

		private static ProcessorProxy _instance = null;
		private ProcessorProxy() { }
		public static ProcessorProxy Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ProcessorProxy();
				}
				return _instance;
			}
		}	
        public void DownloadTag(string Selector)
        {
			ProcessorHub.DownloadTag(Selector);
        }
    }
}
