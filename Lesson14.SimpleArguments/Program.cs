using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14.SimpleArguments
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                foreach (var s in args)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("Hello");
            }

            Console.ReadLine();
        }
    }
}
