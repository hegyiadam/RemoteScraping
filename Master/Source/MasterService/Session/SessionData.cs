using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterService.Session
{
    public class SessionData
    {
        public string SessionId { get; set; }
        public string Date { get; set; }

        public static SessionData Parse(BsonDocument bson)
        {
            return new SessionData()
            {
                SessionId = bson.GetValue("SessionId").AsString,
                Date = bson.GetValue("Date").AsString,
            };
        }

        public BsonDocument ToBson()
        {
            BsonDocument bson = new BsonDocument();
            bson.Set("SessionId", SessionId);
            bson.Set("Date", Date);
            return bson;
        }
    }
}
