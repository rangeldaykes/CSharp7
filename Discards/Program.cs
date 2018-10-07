using System;
using System.Collections.Generic;
using System.Linq;

namespace Discards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Discards");

            var dates = new List<DateTime>
            {
                new DateTime(2017,1,1), new DateTime(2018,1,1), new DateTime(2018,4,2),
                new DateTime(2018,2,4), new DateTime(2017,8,9), new DateTime(2018,8,1)
            };

            Console.WriteLine("Use discard in tuple");
            // Use discard in tuple 
            var (_, MaxDate) = GetMinMaxDateTime(dates, new DateTime(2018, 1, 1));
            Console.WriteLine(MaxDate);

            Console.WriteLine();

            Console.WriteLine("Discard in out parameters");
            // Discard in out parameters
            var DicResult = new Dictionary<int, string>
            {
                [1] = "database error",
                [2] = "cache error"
            };

            if (DicResult.TryGetValue(2, out var _))
            {
                Console.WriteLine("Value Exists");
            }

            Console.ReadLine();
        }

        private static (DateTime MinDate, DateTime MaxDate) GetMinMaxDateTime(List<DateTime> dates, DateTime minDateTimeLimit)
        {
            var minDate = dates.Where(x => x > minDateTimeLimit).Min();
            var maxDate = dates.Max();

            return (minDate, maxDate);
        }
    }
}
