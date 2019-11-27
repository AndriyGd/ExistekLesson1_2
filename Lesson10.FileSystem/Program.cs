using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson10.FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text to write to file: ");
            var text = Console.ReadLine();

            WriteToFile("Lesson10.txt", text);

            Console.ReadLine();
        }

        private static void WriteToFile(string fileName, string text)
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var sw = new StreamWriter(fs);
                sw.WriteLine(text);
                sw.Flush();
                Console.WriteLine("Test was wrote to file.");

                //var res = true;
            }

        }
    }
}
