using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

using Existek_Lesson_1_2.ExCommon;

namespace Lesson14.ProcessesThreads
{
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
            //PrintProcessesInfo();

            //StartProcess();

            //var path = $@"D:\projects\net\Existek\Group_2\Existek_Lesson_1.2\Lesson14.SimpleArguments\bin\Debug\Lesson14.SimpleArguments.exe";

            //var th = new Thread(new ParameterizedThreadStart(StartProcess));
            //th.Start(path);

            AppDomains();

            Console.ReadLine();
        }

        private static void PrintProcessesInfo()
        {
            var processes = Process.GetProcesses();
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var process in processes)
            {
                try
                {
                    Console.WriteLine($"Name: {process.ProcessName}; Id: {process.Id}; Start Time {process.StartTime}");

                    if (process.Id == 49564)
                    {
                        Console.WriteLine("Waiting for exit....");
                        process.WaitForExit();
                    }

                    Console.WriteLine("------Modules----");
                    foreach (ProcessModule module in process.Modules)
                    {
                        Console.WriteLine($"\tModule Name: {module.ModuleName}");
                    }

                    Console.WriteLine("=====Thread======");
                    foreach (ProcessThread thread in process.Threads)
                    {
                        Console.WriteLine($"\tId {thread.Id}; ProcessorTimeMilliseconds: {thread.TotalProcessorTime.TotalMilliseconds}");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        private static void StartProcess()
        {
            var proc = Process.Start("iexplore.exe", "www.google.com.ua");
            proc.WaitForExit();

            Console.Write("Press any key to kill process... ");
            Console.ReadLine();

            proc?.Kill();
        }

        private static void StartProcess(object name)
        {
            var startInfo = new ProcessStartInfo(name.ToString())
            {
                Arguments = "\"Hello World\" \"Lesson BLA BLA\" NET",
                WindowStyle = ProcessWindowStyle.Maximized
            };
            var proc = Process.Start(startInfo);
            proc.WaitForExit();

            Console.Write("Press any key to kill process... ");
            Console.ReadLine();
        }

        private static void AppDomains()
        {
            var app = AppDomain.CurrentDomain;
            
            Console.WriteLine("Assemblies");

            List<Assembly> assemblies = app.GetAssemblies().ToList();
            foreach (var assembly in assemblies)
            {
                Console.WriteLine($"Some Id: {IdHelper.GetNextId()}");
                Console.WriteLine($"Full Name: {assembly.FullName}");
                Console.WriteLine("-----Modules-----");
                foreach (var assemblyModule in assembly.Modules)
                {
                    Console.WriteLine($"\tName: {assemblyModule.Name}");
                }
            }
        }
    }
}
