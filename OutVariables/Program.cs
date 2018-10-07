using System;
using System.Collections.Generic;

namespace OutVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Init");

            var DicResult = new Dictionary<int, string>
            {
                [1] = "database error",
                [2] = "cache error"
            };

            // old declare ver before
            string result;
            if (DicResult.TryGetValue(2, out result))
            {
                Console.WriteLine(result);
            }

            // new initialize var in declaration
            if (DicResult.TryGetValue(2, out string result2))
            {
                Console.WriteLine(result2);
            }

            // new can be implicit typed
            if (DicResult.TryGetValue(2, out var result3))
            {
                Console.WriteLine(result3);
            }

            Console.ReadLine();
        }
    }
}
