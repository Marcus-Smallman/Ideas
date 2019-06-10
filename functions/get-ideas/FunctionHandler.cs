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
        public async Task<string> Handle(string input)
        {
            var response = new ResponseModel()
            {
                status = 404
            };

            var filter = Builders<BsonDocument>.Filter.Empty;
            var ideasDoc = await this.GetCollection().Find(filter).ToListAsync();
            if (ideasDoc != null)
            {
                var ideas = new List<IdeaModel>();
                foreach (var ideaDoc in ideasDoc)
                {
                    ideaDoc.TryGetValue("_id", out BsonValue id);
                    ideaDoc.TryGetValue("idea", out BsonValue idea);
                    ideaDoc.TryGetValue("createdUtc", out BsonValue createdUtc);

                    ideas.Add(new IdeaModel()
                    {
                        id = id?.ToString(),
                        idea = idea?.ToString(),
                        createdUtc = createdUtc?.ToNullableUniversalTime()
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

            return JsonConvert.SerializeObject(response);
        }
    }
}
