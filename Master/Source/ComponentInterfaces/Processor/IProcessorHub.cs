using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentInterfaces.Processor
{
    public interface IProcessorHub
    {
        dynamic GetClient(string connectionId);
        void DownloadTag(string selector);
    }
}
