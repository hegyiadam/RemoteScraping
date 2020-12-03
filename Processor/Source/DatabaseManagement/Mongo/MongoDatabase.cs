using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManagement.Mongo
{
    public class MongoDatabase : IDatabaseManager
    {
        IMongoCollection<BsonDocument> currentResultCollection;
        IMongoCollection<BsonDocument> resultCollection;

        private static MongoDatabase _instance = null;
        private MongoDatabase() 
        {
            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017/");
            IMongoDatabase mongoDatabase =  mongoClient.GetDatabase("RemoteScrape");
            currentResultCollection = mongoDatabase.GetCollection<BsonDocument>("currentsessionresults");
            resultCollection = mongoDatabase.GetCollection<BsonDocument>("result");

        }
        public static MongoDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MongoDatabase();
                }
                return _instance;
            }
        }

        public void Dispose()
        {

        }

public void MergeCurrentResults(string by, SessionId sessionId)
{
    List<BsonValue> filterValues = currentResultCollection.Find(_ => true)
        .ToList()
        .Select(element => element.GetValue(by))
        .Distinct()
        .ToList();
    
    foreach (BsonValue value in filterValues)
    {
        String filterValue = value.AsString;
        FilterDefinition<BsonDocument> currentFilter = 
            Builders<BsonDocument>.Filter.Eq(by, filterValue);
        List<BsonDocument> documents = 
            currentResultCollection.Find(currentFilter).ToList();

        BsonDocument newResult = new BsonDocument();
        foreach (BsonDocument bsonElement in documents)
        {
            newResult.Merge(bsonElement);
        }
        newResult.Add("SessionId", sessionId.Id);

        CreateResult(newResult);
    }
    currentResultCollection.DeleteMany(_=>true);
}

        public string GetResult(SessionId sessionId)
        {
            FilterDefinition<BsonDocument> currentFilter = Builders<BsonDocument>.Filter.Eq("SessionId", sessionId.Id);
            List<BsonDocument> documents = resultCollection.Find(currentFilter).ToList();
            List<JObject> jObjects = new List<JObject>();
            foreach(BsonDocument document in documents)
            {
                document.Remove("_id");
                document.Remove("SessionId");
                jObjects.Add(JObject.Parse(document.ToJson()));
            }
            return JsonConvert.SerializeObject(jObjects);
        }

        public void CreateNewSession(SessionId sessionId)
        {
            currentResultCollection.DeleteMany(_ => true);
            BsonDocument document = CreateSessionIdDocument(sessionId); 
            currentResultCollection.InsertOne(document);
        }

        private BsonDocument CreateSessionIdDocument(SessionId sessionId)
        {
            return new BsonDocument(new BsonElement("SessionId", sessionId.Id));
        }

        public void CreateResult(BsonDocument result)
        {
            result.Remove("_id");
            resultCollection.InsertOne(result);
        }
    }
}
