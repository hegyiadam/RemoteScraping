using ComponentInterfaces.Session;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Session
{
    public class SessionRepository : ISessionRepository
	{
		public IMongoCollection<BsonDocument> mastersessiondataCollection;

		private static SessionRepository _instance = null;
		
		private SessionRepository()
		{
			MongoClient mongoClient = new MongoClient("mongodb://localhost:27017/");
			IMongoDatabase mongoDatabase = mongoClient.GetDatabase("RemoteScrape");
			mastersessiondataCollection = mongoDatabase.GetCollection<BsonDocument>("mastersessiondata");
		}
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
			string date = DateTime.Now.ToString();
			SessionData sessionData = new SessionData()
			{
				SessionId = session.Id.Serialize(),
				Date = date
			};
			mastersessiondataCollection.InsertOne(sessionData.ToBson());
		}
		
		public ISession GetSession(ISessionId sessionId) 
		{
			
			return Sessions.Where(session => session.Key.EqualsTo(sessionId)).FirstOrDefault().Value;
		}

		public List<SessionData> GetAllSessionData()
        {
			return mastersessiondataCollection.Find<BsonDocument>(_ => true).ToList().Select(e => SessionData.Parse(e)).ToList();

		}
	}

    public interface ISessionRepository
    {

		void AddSession(ISession session);

		ISession GetSession(ISessionId sessionId);

		List<SessionData> GetAllSessionData();
	}
}
