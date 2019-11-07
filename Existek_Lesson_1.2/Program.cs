using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2
{

    class Program
    {
        static void Main(string[] args)
        {
#if false
            int a = 67;
            float f = 46.546f;
            double d = 56.54646432333;

            int b = a;
            var h = 56;
            var st = "Hello";
            h = b;
            string name = "John";

            Console.WriteLine($"A = {a}");
            Console.WriteLine($"F = {f}");
            Console.WriteLine($"D: {d}");
            Console.WriteLine($"D: {d:N}");
            Console.WriteLine($"Name: {name}; Length: {name.Length}");
            var sum = d + f;
            sum = Math.Round(sum, 2);
            name += " Json Dn.";
            Console.WriteLine(name);
            Console.WriteLine();
            StringBuilder builder = new StringBuilder(name);

            builder.Append(" New York");
            string all = builder.ToString();
            Console.WriteLine(all);

            Console.WriteLine($"Sum = {sum}"); 
#endif
            #region Enter login, password
            var a = 89;
            var str = "Hello";
            #endregion

#if false
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Enter first number: ");
            string strX = Console.ReadLine();
            int x = int.Parse(strX);

            Console.Write("Enter second number: ");
            var strY = Console.ReadLine();

            if (int.TryParse(strY, out var y))
            {
                Console.WriteLine($"Sum: {x + y}");
            }
            else
            {
                Console.WriteLine($"{name} you are invalid!!!");
            }

            Console.WriteLine();

            var result = int.TryParse(strY, out var z)
                ? $"Sum: {x + z}"
                : $"{name} you are invalid!!!";

            Console.WriteLine(result);

            Console.Write("Enter salary: ");
            var salaryS = Console.ReadLine();

            if (float.TryParse(salaryS, out var salary))
            {
                Console.WriteLine($"Salary = {salary * 1.45}");
            }
            else
            {
                Console.WriteLine("Salary = 0");
            } 
#endif
            Console.WriteLine($"Current DateTime: {DateTime.Now}");

#if false
            var rn = new Random();
            var n = 20;

            for (int i = 0; i < n; i++)
            {
                if (i == 13) break; //Достроково виходимо з циклу

                if (i == 9) continue; //Прорускаэмо одну ітерацыю циклу

                Console.WriteLine($"Rn: {rn.Next(500, 1000)}");
            } 
#endif
            var strT = "Hello World!!!";

            foreach (var c in strT)
            {
                Console.WriteLine(c);
            }

            var ch = "Q";

            do
            {
                Console.WriteLine("Hello!!");
                Console.WriteLine("Press 'Q' to Exit");

                ch = Console.ReadLine();
            } while (ch != "Q");

            //while (ch != "Q")
            //{
            //    Console.WriteLine("Hello!!");
            //    Console.WriteLine("Press 'Q' to Exit");

            //    ch = Console.ReadLine();
            //}
            Run(TypeOs.Linux);
            
            Console.ReadLine();
        }

        private static void Run(TypeOs typeOs)
        {
            Console.WriteLine($"OS: {typeOs}");
            Console.WriteLine((int)typeOs);
        }
    }

    enum TypeOs
    {
        Windows, Android, iOS, Linux
    }
}
