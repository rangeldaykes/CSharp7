using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tuples");

            // declaration 1
            (int Id, string Name, string LastName) person = (1, "Jhon", "Kruger");
            Console.WriteLine("---------------");
            Console.WriteLine(nameof(person));
            Console.WriteLine(person);
            Console.WriteLine($"{person.Id} - {person.Name} - {person.LastName}");
            Console.WriteLine("---------------");

            // declaration 2
            var person2 = (Id: 2, Name: "Maria");
            Console.WriteLine("---------------");
            Console.WriteLine(nameof(person2));
            Console.WriteLine(person);
            Console.WriteLine($"{person.Id} - {person.Name}");
            Console.WriteLine("---------------");

            // declaration 3
            var person3 = (3, "kevin");
            Console.WriteLine("---------------");
            Console.WriteLine(nameof(person3));
            Console.WriteLine(person3);
            Console.WriteLine("---------------");

            var dates = new List<DateTime>
            {
                new DateTime(2017,1,1), new DateTime(2018,1,1), new DateTime(2018,4,2),
                new DateTime(2018,2,4), new DateTime(2017,8,9), new DateTime(2018,8,1)
            };

            Console.WriteLine(" Normal use ---------------");
            var minMaxDate = GetMinMaxDateTime(dates, new DateTime(2018, 1, 1));
            Console.WriteLine(minMaxDate);
            Console.WriteLine(minMaxDate.MinDate);
            Console.WriteLine(minMaxDate.MaxDate);
            Console.WriteLine(" Normal use ---------------");

            Console.WriteLine("");

            Console.WriteLine(" Exemple 1 - Desconstrutor ---------------");
            // Exemple 1- Desconstrutor put values in variables
            var (Desconstrutor1MinDate, Desconstrutor1MaxDate) = GetMinMaxDateTime(dates, new DateTime(2018, 1, 1));
            Console.WriteLine(Desconstrutor1MinDate);
            Console.WriteLine(Desconstrutor1MaxDate);
            Console.WriteLine(" Exemple 1 - Desconstrutor ---------------");

            Console.WriteLine("");

            Console.WriteLine(" Exemple 2 - Desconstrutor ---------------");
            // Exemple 2- Desconstrutor _ discard minDate
            var (_, DesconstrutorMaxDate2) = GetMinMaxDateTime(dates, new DateTime(2018, 1, 1));
            Console.WriteLine(DesconstrutorMaxDate2);
            Console.WriteLine(" Exemple 2 - Desconstrutor ---------------");

            Console.WriteLine("");

            Console.WriteLine(" Exemple 3 - Desconstrutor ---------------");
            // Exemple 3- Desconstrutor declare variables and use for results
            DateTime DesconstrutorMinDate3;
            DateTime DesconstrutorMaxDate3;
            (DesconstrutorMinDate3, DesconstrutorMaxDate3) = GetMinMaxDateTime(dates, new DateTime(2018, 1, 1));
            Console.WriteLine(DesconstrutorMinDate3);
            Console.WriteLine(DesconstrutorMaxDate3);
            Console.WriteLine(" Exemple 3 - Desconstrutor ---------------");

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
