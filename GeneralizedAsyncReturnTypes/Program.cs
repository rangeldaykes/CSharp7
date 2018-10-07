using GeneralizedAsyncReturnTypes.CacheTask;
using GeneralizedAsyncReturnTypes.TestGC;
using System;

namespace GeneralizedAsyncReturnTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GeneralizedAsyncReturnTypes");

            /* for test choose option */
            const int OPTION = 2;

            switch (OPTION)
            {
                case 1:
                    new TestWithGC().TestGCStart();
                    break;
                case 2:
                    new CacheTaskApplication().Application();
                    break;
            }
                    
            Console.ReadLine();
        }
    }
}