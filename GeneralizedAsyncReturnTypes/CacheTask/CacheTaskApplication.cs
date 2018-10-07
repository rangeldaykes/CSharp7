using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace GeneralizedAsyncReturnTypes.CacheTask
{
    public class CacheTaskApplication
    {
        public void Application()
        {
            // ref: http://blog.i3arnon.com/2015/11/30/valuetask/
            IPeopleService service = new PeopleService(new RepositoryPeople());
            service.AddPeople(new People(1, "John"));
            service.AddPeople(new People(2, "Lisa"));

            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 10; i++)
            {
                var p = service.GetPeopleAsync("John").Result;
                Console.WriteLine($"{i} - {p.Id} - {p.Nome}");
            }

            sw.Stop();
            Console.WriteLine($"ElapsedMilliseconds = {sw.ElapsedMilliseconds}");
        }
    }
}
