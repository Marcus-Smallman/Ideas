using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input) {
            var client = new MongoClient(string.Format("mongodb://{0}", Environment.GetEnvironmentVariable("mongo_endpoint")));
            var clientDB = client.GetDatabase("ideasdb");
            var collection = clientDB.GetCollection<BsonDocument>("ideas");

            var response = JsonConvert.SerializeObject(new ErrorModel() { error = "not found" });

            var filter = new BsonDocument("_id", input);
            var ideaDoc = collection.Find(filter).FirstOrDefault();
            if (ideaDoc != null)
            {
                ideaDoc.TryGetValue("_id", out BsonValue id);
                ideaDoc.TryGetValue("idea", out BsonValue idea);

                response = JsonConvert.SerializeObject(new IdeaModel()
                {
                    id = id?.ToString(),
                    idea = idea?.ToString()
                });
            }
            
            Console.WriteLine(response.ToLower());
        }
    }

    public class IdeaModel
    {
        [BsonId]
        public string id { get; set; }

        public string idea { get; set; }
    }

    public  class ErrorModel
    {
        public string error { get; set; }
    }
}
