using System;
using System.Collections;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Function
{
    public class FunctionHandler
    {
        public string RequestMethod { get; set; } = Environment.GetEnvironmentVariable("Http_Method");

        public void Handle(string input) {

            var client = new MongoClient(string.Format("mongodb://{0}", Environment.GetEnvironmentVariable("mongo_endpoint")));
            var clientDB = client.GetDatabase("ideasdb");
            var collection = clientDB.GetCollection<BsonDocument>("ideas");

            switch (RequestMethod)
            {
                case "GET":
                    var filter = new BsonDocument("_id", Environment.GetEnvironmentVariable("Http_Query"));

                    var idea = collection.Find(filter).FirstOrDefault() ;

                    if (idea == null)
                    {
                        // Set status code to 404
                        Console.WriteLine("Not Found");
                    }

                    // Return idea only.
                    // This means creating an idea model and mapping/binding the response
                    // so that the idea can be retrieved from the bson document.
                    // Example response: '{ id: 11111111-2222-3333-4444-55555555555 }'
                    Console.WriteLine(idea);

                    break;
                case "POST":
                    var id = Guid.NewGuid().ToString();
                    
                    // Use idea model once created.
                    var document = new BsonDocument
                    {
                        { "_id", id },
                        { "idea", BsonValue.Create(input) }
                    };

                    collection.InsertOne(document);

                    Console.WriteLine(id);
                    break;
                case "PUT":
                    break;
                case "DELETE":
                    break;
                case "UPDATE":
                    break;
                default:
                    Console.WriteLine("Http Method in request is not supported.");
                    break;
            }
        }

        public void Handle()
        {
            Handle(string.Empty);
        }
    }
}
