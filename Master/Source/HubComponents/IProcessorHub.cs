using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubComponents
{
    public interface IProcessorHub
    {
        void DownloadTag(string selector);
    }
}
