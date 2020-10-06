using ComponentInterfaces.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.RequestData
{
    public class PageIterationRequest
    {
        public ISessionId SessionId { get; set; }
        public string Selector { get; set; }
    }
}
