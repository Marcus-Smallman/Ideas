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

        public Task<string> Handle(string input) 
        {
            if (ClientDB == null)
            {
                var client = new MongoClient(string.Format("mongodb://{0}", Environment.GetEnvironmentVariable("mongo_endpoint")));
                ClientDB = client.GetDatabase("ideasdb");
            }

            var collection = ClientDB.GetCollection<BsonDocument>("ideas");

            var filter = new BsonDocument("_id", input);
            collection.DeleteOne(filter);

            var response = new ResponseModel() 
            { 
                status = 204
            };

            return Task.FromResult(JsonConvert.SerializeObject(response));
        }
    }

    public class ResponseModel
    {
        public object response { get; set; }

        public int status { get; set; }
    }
}
