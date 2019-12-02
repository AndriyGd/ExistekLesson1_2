using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Reflaection
{
    using System.Reflection;

    class Program
    {
        static void Main(string[] args)
        {
#if false
            var h = new Human
            {
                Name = "Victor",
                Age = 28
            };

            PrintInfo(h);
            h.PrintAddresses();

            Console.WriteLine();
            MathHelper(20, 81); 
#endif

            var h = new Human
            {
                Name = "viCtoR",
                Age = 28
            };

            var emp = new Employee
            {
                Name = "JASON",
                Position = "TEStER"
            };

            Console.WriteLine("Before");
            Console.WriteLine($"Name: {h.Name}\nAge: {h.Age}");
            Console.WriteLine($"Name: {emp.Name}\nPosition: {emp.Position}");

            UpperCaseHelper(h);
            UpperCaseHelper(emp);

            Console.WriteLine("After");
            Console.WriteLine($"Name: {h.Name}\nAge: {h.Age}");
            Console.WriteLine($"Name: {emp.Name}\nPosition: {emp.Position}");

            Console.ReadLine();
        }

        static void PrintInfo(Human human)
        {
            var type = human.GetType();

            var properties = type.GetProperties();
            var methods = type.GetMethods();

            Console.WriteLine("----=Properties=----");
            foreach (var property in properties)
            {
                Console.WriteLine($"Name: {property.Name}; Value: {property.GetValue(human)}");
            }

            Console.WriteLine("-----Methods-----");
            foreach (var methodInfo in methods)
            {
                Console.WriteLine($"Name: {methodInfo.Name}");
            }

            Console.WriteLine("Calling methods");

            var add = type.GetMethod("AddAddress");

            add?.Invoke(human, new object[] { "Bolliwood, 556" });
        }

        static void MathHelper(int x, int y)
        {
            var tp = typeof(SimpleMath);
            var instance = Activator.CreateInstance(tp, x, y);

            var mType = instance.GetType();

            var sumM = mType.GetMethod("Sum");

            var res = sumM?.Invoke(instance, new object[] { });

            Console.WriteLine($"Sum of {x} + {y} = {res}");
        }

        static void UpperCaseHelper(object item)
        {
            var type = item.GetType();

            var upperCaseAttribute = type.GetCustomAttribute<UpperCaseAttribute>();
            if (upperCaseAttribute != null)
            {
                var props = type.GetProperties().Where(p => p.PropertyType.Name.Equals("String"));

                foreach (var prop in props)
                {
                    var value = prop.GetValue(item).ToString();
                    if(string.IsNullOrWhiteSpace(value)) continue;

                    if (upperCaseAttribute.IsUpper)
                    {
                        prop.SetValue(item, value.ToUpper());
                    }
                    else
                    {
                        prop.SetValue(item, value.ToLower());
                    }
                }
            }
        }
    }
}
