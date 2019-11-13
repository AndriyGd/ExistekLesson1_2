using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Inheritance
{
    using Common;
    using Existek_Lesson_1_2.ExCommon;

    class Program
    {
        static void Main(string[] args)
        {
            var repos = new HumanRepository();

            var emp1 = new Employee
            {
                Age = 25,
                Name = "John",
                Salary = 4590
            };
            if (emp1.BuildCard())
            {
                repos.AddHuman(emp1);
            }
            var emp2 = new Employee()
            {
                Age = 50,
                Name = "Tom",
                Salary = 6790
            };
            if (emp2.BuildCard())
            {
                repos.AddHuman(emp2);
            }

            Console.WriteLine("----------");
            repos.PrintHumans();
            Console.WriteLine("----------");

            repos.AddHuman(new Manager(145.78)
            {
                Age = 28,
                Name = "Victor",
                CountEmployees = 5
            });

            var m1 = new Manager(350.56);
            m1.CountEmployees = 15;
            m1.Age = 31;
            m1.Name = "Olga";
            repos.AddHuman(m1);

            repos.PrintHumans();
            Console.WriteLine("----------");
            Human top = new TopManager(500.59)
            {
                Age = 35,
                Name = "Json",
                CountEmployees = 40,
                PhoneNumber = "+3(004)556-3535-22"
            };
            
            repos.AddHuman(top);
            repos.PrintHumans();
            Console.WriteLine("============");

            Employee emp = (Employee)repos.GetHumanBy(1);

            var m3 = repos.GetHumanBy(44) as Manager;

            try
            {
                if (repos.GetHumanBy(55) is TopManager topM)
                {
                    Console.WriteLine(topM.PhoneNumber);
                }
                else
                {
                    throw new HumanDoesNotExistException(55);
                }

                Console.WriteLine(emp.Salary);
                Console.WriteLine(emp.Id);

                Console.WriteLine(m3.Bonus);
            }
            catch (HumanDoesNotExistException hX)
            {
                Console.WriteLine(hX.Message);
                //TODO ..... Crete Human
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Human does not exist!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally code");
            }
            Console.ReadLine();
        }
    }
}
