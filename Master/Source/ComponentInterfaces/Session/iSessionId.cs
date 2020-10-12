using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentInterfaces.Session
{
    public interface ISessionId
    {
        int SerialNumber { get; set; }
        string Serialize();

        bool EqualsTo(ISessionId sessionId);
        ISessionId Deserialize(string source);
    }
}
