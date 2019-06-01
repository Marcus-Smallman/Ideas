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
        public async Task<string> Handle(string input) 
        {
            var id = Guid.NewGuid().ToString();
            var ideaModel = new IdeaModel()
            {
                id = id ,
                idea = input
            };

            await this.GetCollection().InsertOneAsync(ideaModel.ToBsonDocument());

            var response = new ResponseModel() 
            { 
                response = new CreatedIdeaModel()
                { 
                    id = id 
                }, 
                status = 201 
            };
            
            return JsonConvert.SerializeObject(response);
        }
    }
}
