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
    public class SessionIdFactory : ISessionIdFactory
	{
		IMongoCollection<BsonDocument> masteridsCollection;

		private static SessionIdFactory _instance = null;
		private SessionIdFactory() 
		{
			MongoClient mongoClient = new MongoClient("mongodb://localhost:27017/");
			IMongoDatabase mongoDatabase = mongoClient.GetDatabase("RemoteScrape");
			masteridsCollection = mongoDatabase.GetCollection<BsonDocument>("masterids");
			FilterDefinition<BsonDocument> lastSessionIdFilter = Builders<BsonDocument>.Filter.Eq("IdName", "LastSessionId");
			if( masteridsCollection.Find(lastSessionIdFilter).ToList().Count == 0)
            {
				BsonDocument bsonElement = new BsonDocument();
				bsonElement.Set("IdName", "LastSessionId");
				bsonElement.Set("Id", 1);
				masteridsCollection.InsertOne(bsonElement);
			}
		}
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
		public ISessionId CreateId()
		{
			FilterDefinition<BsonDocument> lastSessionIdFilter = Builders<BsonDocument>.Filter.Eq("IdName", "LastSessionId");
			BsonDocument id = masteridsCollection.Find(lastSessionIdFilter).ToList().Single();
			int lastId = id.GetValue("Id").AsInt32;
			var update = Builders<BsonDocument>.Update.Set("Id", lastId + 1);
			masteridsCollection.UpdateOne(lastSessionIdFilter, update);
			return new SessionId()
			{
				SerialNumber = lastId
			};
		}
    }
}
