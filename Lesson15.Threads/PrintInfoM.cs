using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15.Threads
{
    using System.Threading;

    class PrintInfoM
    {
        private readonly int _count;
        public Mutex Mutex { get; set; }
        public int Number { get; set; }
        
        public PrintInfoM(int count)
        {
            _count = count;
            try
            {
                Mutex = new Mutex(false, "Lesson15");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Increment(object state)
        {
            Console.WriteLine("Increment. Wait Mutex");
            Mutex.WaitOne();
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine($"Increment, Number {++Number}");
                Thread.Sleep(200);
            }
            Mutex.ReleaseMutex();
        }

        public void Decrement(object state)
        {
            Console.WriteLine("Decrement. Wait Mutex");
            Mutex.WaitOne();
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine($"Decrement, Number {--Number}");
                Thread.Sleep(200);
            }
            Mutex.ReleaseMutex();
        }
    }
}
