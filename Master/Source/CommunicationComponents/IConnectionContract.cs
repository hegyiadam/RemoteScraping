using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationComponents
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IConnectionContract))]
    public interface IConnectionContract
    {
        [OperationContract(IsOneWay = true)]
        void Connect();
    }
}
