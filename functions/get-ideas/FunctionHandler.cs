using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            var response = new ResponseModel()
            {
                status = 404
            };

            var filter = Builders<BsonDocument>.Filter.Empty;
            var ideasDoc = collection.Find(filter).ToList();
            if (ideasDoc != null)
            {
                var ideas = new List<IdeaModel>();
                foreach (var ideaDoc in ideasDoc)
                {
                    ideaDoc.TryGetValue("_id", out BsonValue id);
                    ideaDoc.TryGetValue("idea", out BsonValue idea);

                    ideas.Add(new IdeaModel()
                    {
                        id = id?.ToString(),
                        idea = idea?.ToString()
                    });
                }

                response = new ResponseModel()
                {
                    response = new IdeasModel()
                    {
                        ideas = ideas
                    },
                    status = 200
                };
            }

            return Task.FromResult(JsonConvert.SerializeObject(response));
        }
    }

    public class IdeasModel
    {
        public IEnumerable<IdeaModel> ideas { get; set; }
    }

    public class IdeaModel
    {
        [BsonId]
        public string id { get; set; }

        public string idea { get; set; }
    }

    public class ResponseModel
    {
        public object response { get; set; }

        public int status { get; set; }
    }
}
