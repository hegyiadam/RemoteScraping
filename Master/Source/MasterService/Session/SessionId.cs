using ComponentInterfaces.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Session
{
    public class SessionId : ISessionId
    {
        public int SerialNumber { get; set; }

        public string Serialize()
        {
            return SerialNumber.ToString();
        }

        public ISessionId Deserialize(string source)
        {
            return new SessionId()
            {
                SerialNumber = int.Parse(source)
            };
        }
    }
}
