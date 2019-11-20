using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Events
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
#if false
            var p = new Person("John");
            var p2 = new Person("Tom");
            var m = new Manager(new List<Person> { p, p2 });
            p.EndWork += Person_EndWork;

            p.WorkStarted += name =>
            {
                Console.WriteLine($"Person {name} started hard working");
            };

            var t1 = new Thread(p.StartWork);
            var t2 = new Thread(p2.StartWork);
            t1.Start(7);
            t2.Start(10);

            //p.EndWork -= Person_EndWork;
            //Console.WriteLine("-----");
            //p.StartWork(5);

            Console.WriteLine("End"); 
#endif
            var a = new Point<int>
            {
                X = 56,
                Y = 45
            };

            var b = new Point<double>
            {
                Y = 78.51,
                X = 23.19
            };

            //var c = new Point<string>
            //{
            //    X = "Hello",
            //    Y = "Person"
            //};

            //var p = new Point<Person>
            //{
            //    Y = new Person("KJ"),
            //    X = new Person("BNM")
            //};

            Console.WriteLine(a);
            Console.WriteLine(b);
            //Console.WriteLine(c);
            //Console.WriteLine(p);

            Console.ReadLine();
        }

        private static void Person_EndWork()
        {
            Console.WriteLine("Some Person finished working");
        }
    }
}
