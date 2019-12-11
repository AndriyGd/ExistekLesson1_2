using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lesson16.AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            var th = new Thread(Print) {IsBackground = true};
            th.Start();

            Thread.Sleep(5000);
            th.Abort();

            Console.ReadLine();
        }

        static void Print()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(900);
            }
        }
    }
}
