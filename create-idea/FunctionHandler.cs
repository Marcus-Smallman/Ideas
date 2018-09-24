using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input) {
            var client = new MongoClient(string.Format("mongodb://{0}", Environment.GetEnvironmentVariable("mongo_endpoint")));
            var clientDB = client.GetDatabase("ideasdb");
            var collection = clientDB.GetCollection<BsonDocument>("ideas");

            var id = Guid.NewGuid().ToString();
            var ideaModel = new IdeaModel()
                    {
                        id = id ,
                        idea = input
                    };

            collection.InsertOne(ideaModel.ToBsonDocument());

            Console.WriteLine(JsonConvert.SerializeObject(new CreatedIdeaModel() { id = id }));
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
