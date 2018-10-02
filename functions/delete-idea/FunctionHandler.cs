using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

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
            var filter = new BsonDocument("_id", input);

            collection.DeleteOne(filter);

            return Task.FromResult(JsonConvert.SerializeObject(new SuccessModel() { message = "idea deleted successfully" }));
        }
    }

    public class SuccessModel
    {
        public string message { get; set; }
    }
}
