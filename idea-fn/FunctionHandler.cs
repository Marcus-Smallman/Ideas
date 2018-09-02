using System;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input) {

            var client = new MongoClient("mongodb://192.168.0.7:27017");
            var clientDB = client.GetDatabase("ideasdb");
            var collection = clientDB.GetCollection<BsonDocument>("ideas");
            
            var id = Guid.NewGuid().ToString();
            var document = new BsonDocument
            {
                { "id", id },
                { "input", BsonValue.Create(input) }
            };

            collection.InsertOne(document);

            Console.WriteLine(id);
        }
    }
}
