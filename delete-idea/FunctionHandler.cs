using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input) {
            var client = new MongoClient(string.Format("mongodb://{0}", Environment.GetEnvironmentVariable("mongo_endpoint")));
            var clientDB = client.GetDatabase("ideasdb");
            var collection = clientDB.GetCollection<BsonDocument>("ideas");

            var filter = new BsonDocument("_id", input);

            collection.DeleteOne(filter);

            Console.WriteLine(JsonConvert.SerializeObject(new SuccessModel() { message = "idea deleted successfully" }));
        }
    }

    public class SuccessModel
    {
        public string message { get; set; }
    }
}
