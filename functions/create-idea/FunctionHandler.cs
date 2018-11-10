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

        public Task<string> Handle(string input) 
        {
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

            // Cannot change status code: https://github.com/openfaas/faas/issues/157
            // Suggested to add status code in body response
            var response = new ResponseModel() 
            { 
                response = new CreatedIdeaModel()
                { 
                    id = id 
                }, 
                status = 201 
            };
            
            return Task.FromResult(JsonConvert.SerializeObject(response));
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

    public class ResponseModel
    {
        public object response { get; set; }

        public int status { get; set; }
    }
}
