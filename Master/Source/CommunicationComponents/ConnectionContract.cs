using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationComponents
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ConnectionContract
    {
        IProcessingContract callback = null;

        public ConnectionContract()
        {
            callback = OperationContext.Current.GetCallbackChannel<IProcessingContract>();
        }

        public void Connect()
        {
        }
    }
}
