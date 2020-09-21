using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationComponents
{
    interface IProcessingContract
    {
        [OperationContract(IsOneWay = true)]
        void DownloadTag(string url, string selector);
    }
}
