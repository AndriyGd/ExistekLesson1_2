using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15.Threads
{
    using System.Threading;

    class PrintInfo
    {
        private readonly int _numbers;
        private readonly int _sleep;
        private int _n;
        private object _marker = new object();

        public int N
        {
            get => _n;
            set
            {
                _n = value;
                //Console.WriteLine($"Thread Name: {Thread.CurrentThread.Name}; Value: {value}");
            }
        }

        public PrintInfo(int numbers, int sleep)
        {
            _numbers = numbers;
            _sleep = sleep;
        }

        public void PrintNumbers(object state)
        {
            lock (_marker)
            {
                Thread.Sleep(10);
                var rn = new Random();
                var s = rn.Next(_sleep, _sleep * 2);

                Console.WriteLine($"PrintNumbers ThreadId: {Thread.CurrentThread.ManagedThreadId}: State {state}");
                for (int i = 0; i < _numbers; i++)
                {
                    Console.WriteLine($"I = {i}; Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                    //Console.WriteLine($"N Value: {N}");

                    N = i;
                    Thread.Sleep(s);
                } 
            }
        }
    }
}
