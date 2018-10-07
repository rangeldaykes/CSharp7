using System;

namespace LocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LocalFunctions");

            // can reference functions not yet declared
            // not necessary create delegate
            Console.WriteLine(soma(2, 3));

            int soma(int a, int b)
            {
                return a + b;
            }

            // ----------- can use out ref
            CanUseOutRef();
            // ----------- can use out ref

            // ----------- use with Generics
            UseWithGenerics();
            // ----------- use with Generics

            Console.ReadLine();
        }

        static void CanUseOutRef()
        {
            Console.WriteLine();
            Console.WriteLine("CanUseOutRef");

            int[] list = new[] { 1, 2, 3, 4, 5 };
            bool TryGetPositionValue(int value, int[] arr, out int position)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == value)
                    {
                        position = i;
                        return true;
                    }
                }

                position = -1;
                return false;
            }

            int number = 3;
            if (TryGetPositionValue(number, list, out var pos))
                Console.WriteLine($"{nameof(number)} = {number} exist - in {nameof(list)} - in position {pos}");
            else
                Console.WriteLine("not found");
        }

        static void UseWithGenerics()
        {
            Console.WriteLine();
            Console.WriteLine("UseWithGenerics");

            void Print<T>(T value)
            {
                Console.WriteLine(value);
            }

            Print("test1");
            Print(34);
            Print(false);
        }
    }
}
