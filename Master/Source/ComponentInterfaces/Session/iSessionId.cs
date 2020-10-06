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

        ISessionId Deserialize(string source);
    }
}
