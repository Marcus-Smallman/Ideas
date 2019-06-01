using MongoDB.Bson;
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
            var filter = new BsonDocument("_id", input);
            await this.GetCollection().DeleteOneAsync(filter);

            var response = new ResponseModel() 
            { 
                status = 204
            };

            return JsonConvert.SerializeObject(response);
        }
    }
}
