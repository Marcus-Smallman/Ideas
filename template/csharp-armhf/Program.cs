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
            string buffer = getStdin();
            if(buffer.EndsWith('\n')){
                buffer = buffer.Substring(0, buffer.Length - 1);
            }
            FunctionHandler f = new FunctionHandler();
            f.Handle(buffer);
        }
    }
}
