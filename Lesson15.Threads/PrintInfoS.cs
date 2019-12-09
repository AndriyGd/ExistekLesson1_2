using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15.Threads
{
    using System.Threading;

    class PrintInfoS
    {
        private int _sleep;
        private readonly Semaphore _semaphore;
        private int _numbers;

        public PrintInfoS(int numbers, int sleep, Semaphore semaphore)
        {
            _numbers = numbers;
            _sleep = sleep;
            _semaphore = semaphore;
        }

        public void PrintNumbers(object state)
        {
            _semaphore.WaitOne();

            Thread.Sleep(10);
            var rn = new Random();
            var s = rn.Next(_sleep, _sleep * 2);

            Console.WriteLine($"PrintNumbers ThreadId: {Thread.CurrentThread.ManagedThreadId}: State {state}");
            for (int i = 0; i < _numbers; i++)
            {
                Console.WriteLine($"I = {i}; Thread Id:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(s);
            }

            Console.WriteLine($"Finished work. Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            _semaphore.Release();
        }
    }
}
