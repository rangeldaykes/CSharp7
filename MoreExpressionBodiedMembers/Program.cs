using System;

namespace MoreExpressionBodiedMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MoreExpressionBodiedMembers");

            var p = new People(156);
            p.Name = "Jhon";
            Console.WriteLine($"{p.Id} - {p.Name}");
            
            Console.ReadLine();
        }
    }

    class People
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get => name;
            set => name = value ?? "People";
            // Expression-bodied get / set accessors.
        }

        // Expression-bodied constructor - only one expressions
        public People(int id) => this.Id = id;

        // Expression-bodied finalizer
        ~People() => Console.Error.WriteLine("Finalized!");
    }
}
