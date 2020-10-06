using ComponentInterfaces.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Session
{
    public class SessionIdFactory : ISessionIdFactory
    {

		private static SessionIdFactory _instance = null;
		private SessionIdFactory() { }
		public static SessionIdFactory Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new SessionIdFactory();
				}
				return _instance;
			}
		}
		private static int counter = 0;
		public ISessionId CreateId()
		{
			counter++;
			return new SessionId()
			{
				SerialNumber = counter
			};
		}
    }
}
