using ComponentInterfaces.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Session
{
    public class SessionRepository 
    {

		private static SessionRepository _instance = null;
		
		private SessionRepository() { }
		public static SessionRepository Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new SessionRepository();
				}
				return _instance;
			}
		}

		private Dictionary<ISessionId, ISession> Sessions { get; set; } = new Dictionary<ISessionId, ISession>();

		public void AddSession(ISession session)
		{
			Sessions.Add(session.Id, session);
		}
		
		public ISession GetSession(ISessionId sessionId) 
		{
			
			return Sessions.Where(session => session.Key.EqualsTo(sessionId)).FirstOrDefault().Value;
		}

	}
}
