using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Function
{
    public class FunctionHandler
    {
        public async Task<string> Handle(string input) 
        {
            var response = new ResponseModel()
            {
                status = 404
            };

            var filter = new BsonDocument("_id", input);
            var ideaDoc = await this.GetCollection().Find(filter).FirstOrDefaultAsync();
            if (ideaDoc != null)
            {
                ideaDoc.TryGetValue("_id", out BsonValue id);
                ideaDoc.TryGetValue("idea", out BsonValue idea);
                ideaDoc.TryGetValue("createdUtc", out BsonValue createdUtc);

                response = new ResponseModel()
                {
                    response = new IdeaModel()
                    {
                        id = id?.ToString(),
                        idea = idea?.ToString(),
                        createdUtc = createdUtc?.ToNullableUniversalTime()
                    },
                    status = 200
                };
            }
            
            return JsonConvert.SerializeObject(response);
        }
    }
}
