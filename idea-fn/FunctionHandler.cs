using System;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Function
{
    public class FunctionHandler
    {
        public void Handle(string input) {
            Console.WriteLine("Hi there - your input was: "+ input);
        }
    }
}
