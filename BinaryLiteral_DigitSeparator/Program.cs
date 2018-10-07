using System;

namespace BinaryLiteral_DigitSeparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BinaryLiteral_DigitSeparator");

            // BinaryLiteral
            const int bin = 0b0101;
            Console.WriteLine($"bin = {bin}");

            // DigitSeparator
            const int number = 1_000_000;
            Console.WriteLine($"bin = {number}");
            var dsHex = 0xF_F;            
            Console.WriteLine($"dsHex = {dsHex}");

            // Real Literals
            float float1 = 1.1F;
            double double1 = 2.2;
            decimal decimal1 = 3.30M;
            Console.WriteLine($"float:{float1} - double1:{double1} - decimal1:{decimal1}");

            //Character Literals
            char c1 = 'a';
            char tab = '\t'; // Tab
            char hex = '\x04c';  // \
            char unicode = '\u0066'; // f
            Console.WriteLine($"c1:{c1} - tab:{tab} - hex:{hex} - unicode:{unicode}");

            Console.ReadLine();
        }
    }
}
