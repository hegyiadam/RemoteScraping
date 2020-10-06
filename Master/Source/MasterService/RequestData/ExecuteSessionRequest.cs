using ComponentInterfaces.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.RequestData
{
    public class ExecuteSessionRequest
    {
        public ISessionId SessionId { get; set; }
    }
}
