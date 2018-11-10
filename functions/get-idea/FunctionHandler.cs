﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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

            var response = new ResponseModel()
            {
                status = 404
            };

            var filter = new BsonDocument("_id", input);
            var ideaDoc = collection.Find(filter).FirstOrDefault();
            if (ideaDoc != null)
            {
                ideaDoc.TryGetValue("_id", out BsonValue id);
                ideaDoc.TryGetValue("idea", out BsonValue idea);

                response = new ResponseModel()
                {
                    response = new IdeaModel()
                    {
                        id = id?.ToString(),
                        idea = idea?.ToString()
                    },
                    status = 200
                };
            }
            
            return Task.FromResult(JsonConvert.SerializeObject(response));
        }
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
