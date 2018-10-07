using System;

namespace RefLocalsRefReturns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RefLocalsRefReturns");

            // ------- ref local
            int i = 1;
            ref int j = ref i;
            j = 2;

            Console.WriteLine($"The var {nameof(i)} was alter to : {i}");
            // ------- ref local

            // ------- ref return

            Console.WriteLine(string.Join(",", list));
            ref var pos = ref GetPositionValue(3);
            Console.WriteLine(pos);
            pos++;
            Console.WriteLine(string.Join(",", list));

            // ------- ref return

            Console.ReadLine();
        }

        static int[] list = new[] { 1, 2, 3, 4, 5 };

        static ref int GetPositionValue(int value)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == value)
                    return ref list[i];
            }

            throw new InvalidOperationException("not fount");
        }
    }
}
