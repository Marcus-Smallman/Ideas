// Copyright (c) Alex Ellis 2017. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Text;
using Function;

namespace root
{
    class Program
    {
        private static string getStdin() {
            StringBuilder buffer = new StringBuilder();
            string s;
            while ((s = Console.ReadLine()) != null)
            {
                buffer.AppendLine(s);
            }
            return buffer.ToString();
        }

        static void Main(string[] args)
        {
            FunctionHandler f = new FunctionHandler();

            // The watchdog supports the following HTTP Methods: GET, POST, PUT, DELETE, UPDATE.
            // The only method that does not contain a body is a GET, so the following is performed.
            if (Environment.GetEnvironmentVariable("Http_Method").Equals("GET"))
            {
                f.Handle();
            }
            else
            {
                string buffer = getStdin();
                f.Handle(buffer);
            }
        }
    }
}
