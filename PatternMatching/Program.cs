using System;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PatternMatching");

            // --------- is - PatternMatching
            var value = GetValue();

            // now can check is null
            if (value is null)
                Console.WriteLine("value null");

            if (value is 10)
                Console.WriteLine("value max");

            // check if int and assign to number
            if (value is int number)
                Console.WriteLine($"is int value = {number}");
            else
                Console.WriteLine("not int");

            // --------- is - PatternMatching

            Console.WriteLine("");

            // --------- switch - PatternMatching

            switch (value)
            {
                case 10:
                    Console.WriteLine("value max");
                    break;
                case int val:
                    Console.WriteLine($"is int value = {val}");
                    break;
                case null:
                    Console.WriteLine("value null");
                    break;
                default:
                    Console.WriteLine("I do not understand the value");
                    break;
            }

            // --------- switch - PatternMatching

            // --------- switch case when

            switch (value)
            {
                case 10:
                    Console.WriteLine("value max");
                    break;
                case int val when val >= 8 && val < 10:
                    Console.WriteLine($"is int value and almost = {val}");
                    break;
                case null:
                    Console.WriteLine("value null");
                    break;
                default:
                    Console.WriteLine("I do not understand the value");
                    break;
            }

            // --------- switch case when 


            Console.ReadLine();
        }

        static object GetValue()
        {
            object value = new Random().Next(-10, 10);

            if ((int)value < 0)
                value = null;

            if ((int)value == 0)
                return "zero";

            return value;
        }
    }
}
