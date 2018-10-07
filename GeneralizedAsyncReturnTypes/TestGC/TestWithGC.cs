using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralizedAsyncReturnTypes.TestGC
{
    public class TestWithGC
    {
        public void TestGCStart()
        {
            // ref: https://www.youtube.com/watch?v=HpwIvDVU1Lg
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var service = new Service();

            /* for test choose option */
            const int OPTION = 3;

            for (int i = 0; i < 30_000_000; i++)
            {
                switch (OPTION)
                {
                    case 1:
                        var result1 = service.GetPointsAsync_WithTask().Result;
                        break;
                    case 2:
                        var result2 = service.GetPointsAsync_WithAsyncValueTask().Result;
                        break;
                    case 3:
                        var result3 = service.GetPointsAsync_WithValueTaskOnly().Result;
                        break;
                }
            }

            sw.Stop();
            Console.WriteLine($"ElapsedMilliseconds = {sw.ElapsedMilliseconds}");

            Console.WriteLine($"{GC.CollectionCount(0)} - collections occurred at Generation 0");
        }
    }

    public class Service
    {
        private IEnumerable<Point> cachedPoints;
        private DateTime lastTime = DateTime.Now;
        private readonly TimeSpan cacheDuration = TimeSpan.FromSeconds(2);

        public async Task<IEnumerable<Point>> GetPointsAsync_WithTask()
        {
            if (DateTime.Now - lastTime < cacheDuration)
                return cachedPoints;

            return await GetPointsInternal();
        }

        public async ValueTask<IEnumerable<Point>> GetPointsAsync_WithAsyncValueTask()
        {
            if (DateTime.Now - lastTime < cacheDuration)
                return cachedPoints;

            return await GetPointsInternal();
        }

        public ValueTask<IEnumerable<Point>> GetPointsAsync_WithValueTaskOnly()
        {
            if (DateTime.Now - lastTime < cacheDuration)
                return new ValueTask<IEnumerable<Point>>(cachedPoints);

            return new ValueTask<IEnumerable<Point>>(GetPointsInternal());
        }

        private async Task<IEnumerable<Point>> GetPointsInternal()
        {
            cachedPoints = await Task.Run(() => new List<Point> { new Point(1, 3), new Point(3, 4) });
            lastTime = DateTime.Now;
            Console.WriteLine($"GetPointsInternal: {lastTime}");
            return cachedPoints;
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y) { X = x; Y = y; }
    }
}


