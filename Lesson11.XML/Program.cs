using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.XML
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var xml = new XmlHelper("employees.xml");
                //xml.CreateFile();

                var emp1 = new Employee
                {
                    Name = "John F.",
                    Age = 23,
                    Salary = 6634.33,
                    Address = "Glomn, 456",
                    Id = Guid.NewGuid()
                };

                //var emp2 = new Employee
                //{
                //    Name = "Lauren",
                //    Age = 25,
                //    Salary = 5834.45,
                //    Address = "Fortins, 156",
                //    Id = Guid.NewGuid()
                //};

                //xml.Save(emp2);

                //var employees = xml.LoadEmployees();
                //employees.ForEach(Console.WriteLine);

                //xml.Delete("caaf5d3b-3cb0-4664-9605-ed74f6079354");

                //xml.Save(emp1);

                var employees = xml.LoadEmployees();

                var emp = employees.FirstOrDefault();
                if (emp != null)
                {
                    emp.Salary = 12897.45;
                    emp.Address = "Bomn, 45F";

                    xml.Edit(emp);
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
