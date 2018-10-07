using System;

namespace ThrowExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ThrowExpressions");

            try
            {
                var p = new People(12);
                p.Name = "";
                Console.WriteLine(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }            

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
            // ------------------------------------------------- now use thorw in expression
            set => name = !string.IsNullOrEmpty(value) ? value : throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
        }

        public People(int id) => this.Id = id;

        public override string ToString() => $"{Id} - {Name}";
    }
}
