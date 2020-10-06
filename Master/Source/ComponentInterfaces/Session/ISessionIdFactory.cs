using ComponentInterfaces.Session;
using ComponentInterfaces.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentInterfaces.Session
{
    public interface ISessionIdFactory
    {
        ISessionId CreateId();
    }
}
