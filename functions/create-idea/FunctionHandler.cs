using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Function
{
    public class FunctionHandler
    {
        public static IMongoDatabase ClientDB;

        public Task<string> Handle(string input) {
            if (ClientDB == null)
            {
                var client = new MongoClient(string.Format("mongodb://{0}", Environment.GetEnvironmentVariable("mongo_endpoint")));
                ClientDB = client.GetDatabase("ideasdb");
            }

            var collection = ClientDB.GetCollection<BsonDocument>("ideas");

            var id = Guid.NewGuid().ToString();
            var ideaModel = new IdeaModel()
                    {
                        id = id ,
                        idea = input
                    };

            collection.InsertOne(ideaModel.ToBsonDocument());

            return Task.FromResult(JsonConvert.SerializeObject(new CreatedIdeaModel() { id = id }));
        }
    }

    public class IdeaModel
    {
        [BsonId]
        public string id { get; set; }

        public string idea { get; set; }
    }

    public class CreatedIdeaModel
    {
        public string id { get; set; }
    }
}
