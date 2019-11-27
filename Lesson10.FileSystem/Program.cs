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
            var fileName = "Lesson10.txt";
            //Console.Write("Enter text to write to file: ");
            //var text = Console.ReadLine();
            //WriteToFile(fileName, text);

            //ReadDataFromFile(fileName);

            //WriteToFile(fileName, 25);
            //ReadDataFromFile(fileName);

#if false
            var f = new FileInfo(fileName);
            //f.Create();
            Console.WriteLine(f.CreationTime);

            //f.Delete();
            f.MoveTo("D://Lesson123.txt"); 
#endif

#if false
            byte[] buffer = File.ReadAllBytes(
                    $@"D:\projects\net\Existek\Group_2\Existek_Lesson_1.2\Lesson10.FileSystem\bin\Debug\Lesson10.FileSystem.exe");

            Console.Write("Enter file name: ");
            var fn = Console.ReadLine();

            File.WriteAllBytes($"D://Lesson{fn}.exe", buffer); 
#endif

            var di = new DirectoryInfo(Directory.GetCurrentDirectory());

            //Console.WriteLine(Environment.UserName);

            //var files = di.GetFiles();
            //var files = di.GetFiles("*.txt");

            //foreach (var fileInfo in files)
            //{
            //    Console.WriteLine($"File Name: {fileInfo.Name}; Creation time: {fileInfo.CreationTime}");
            //}

            var dirs = di.GetDirectories();

            foreach (var directoryInfo in dirs)
            {
                directoryInfo.GetFiles();
                var ds = directoryInfo.GetDirectories();
                Console.WriteLine($"Dir Name: {directoryInfo.Name}");
            }

            Console.ReadLine();
        }

        private static void WriteToFile(string fileName, string text)
        {
            using (var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                //sw.Flush();
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(text);
                    Console.WriteLine("Text was wrote to file.");
                }
            }
        }

        private static void WriteToFile(string fileName, int n)
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                //sw.Flush();
                using (var sw = new StreamWriter(fs))
                {
                    var rn = new Random();
                    var range = n + 1000;

                    for (int i = 0; i < n; i++)
                    {
                        sw.WriteLine(rn.Next(range));
                    }

                    Console.WriteLine("Data was wrote to the file.");
                }
            }
        }

        private static void ReadDataFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"The file {fileName} does not exist!\nPlease enter correct file name.");
                return;
            }

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    //var data = sr.ReadToEnd();
                    //Console.WriteLine(data);
                    var sum = 0;
                    while (sr.Peek() != -1)
                    {
                        if (int.TryParse(sr.ReadLine(), out var number))
                        {
                            sum += number;
                            Console.WriteLine(number);
                        }
                    }

                    Console.WriteLine($"Total sum: {sum}");
                }
            }
        }
    }
}
