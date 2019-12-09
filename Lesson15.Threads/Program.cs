using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lesson15.Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main ThreadId: {Thread.CurrentThread.ManagedThreadId}");
#if false
            var p = new PrintInfo(15, 200);

            //var th = new Thread(p.PrintNumbers);
            //th.Name = "First Thread";
            //var th2 = new Thread(p.PrintNumbers);
            //th2.Name = "Second Thread";
            //th.Start();
            //th2.Start();

            for (int i = 0; i < 10; i++)
            {
                //var th = new Thread(p.PrintNumbers);
                //th.Name = $"Th{i + 1}";
                //th.Start();
                //th.Join();

                ThreadPool.QueueUserWorkItem(p.PrintNumbers, $"Hello From Main: {i}");
            }

            Console.WriteLine("Done"); 
#endif
#if Semaphore
            var semaphore = new Semaphore(3, 3);
            var pS = new PrintInfoS(10, 200, semaphore);

            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(pS.PrintNumbers);
            } 
#endif

            var pM = new PrintInfoM(10);
            Console.WriteLine("Press any key to start");
            Console.ReadLine();

            var thI = new Thread(new ParameterizedThreadStart(pM.Increment));
            thI.Start("");
            var thD = new Thread(new ParameterizedThreadStart(pM.Decrement));
            thD.Start("");

            Console.ReadLine();
        }
    }
}
