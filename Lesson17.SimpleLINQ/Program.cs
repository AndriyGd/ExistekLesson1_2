using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17.SimpleLINQ
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
#if false
            var numbers = new List<int> { 45, 68, 23, 678, 223, 56, 19, 25, 16, 18, 9 };

            var res = from number in numbers where number > 60 select number;
            foreach (int n in res)
            {
                //Console.WriteLine(n);
            }

            var rs = from num in numbers where num >= 20 && num <= 50 select num;
            foreach (var i in rs)
            {
                Console.WriteLine(i);
            } 
#endif

            var managers = new List<Manager>
            {
                new Manager{Name = "Jason", Id = 23},
                new Manager{Name = "Igor", Id = 33},
                new Manager{Name = "Iryna", Id = 45},
            };

            var employees = new List<Employee>
            {
                new Employee{Name = "Tom", Salary = 4590.23, Address = "Pokj, 45", ManagerId = 33},
                new Employee{Name = "John", Salary = 8590.23, Address = "Gloy, 145", ManagerId = 45},
                new Employee{Name = "Vika", Salary = 7590.23, Address = "Nopu, 353", ManagerId = 45},
                new Employee{Name = "Oleg", Salary = 8490.23, Address = "Kpol, 495", ManagerId = 33},
                new Employee{Name = "Viktor", Salary = 5790.23, Address = "Hlop, 245", ManagerId = 33},
                new Employee{Name = "Tom2", Salary = 8790.23, Address = "Pokj, 45", ManagerId = 45},
                new Employee{Name = "Tom3", Salary = 3590.23, Address = "GG, 485", ManagerId = 33},
                new Employee{Name = "Tom4", Salary = 6590.23, Address = "TRe, 425", ManagerId = 5},
                new Employee{Name = "Tom5", Salary = 5580.23, Address = "Hjk, 435", ManagerId = 5}
            };

            var resEmp = from emp in employees where emp.Salary >= 8000 select emp;
            var resEmpNames= from emp in employees where emp.Salary >= 8000 select emp.Name;
            var resNameSalary = 
                from emp in employees
                where emp.Salary >= 8000
            select new { HumanName = emp.Name, HumanSalary = emp.Salary };

            var empSalary = 
                (from emp in employees
                where emp.Salary >= 5000
                select new EmployeeSalary { Name = emp.Name, Salary = emp.Salary }).ToList();


            var empSalaryAndBonus =
                (from emp in employees
                    let isConfirmed = IsConfirmedToBonus(emp)
                    where emp.Salary >= 5000 && isConfirmed
                    select new EmployeeSalary { Name = emp.Name, Salary = emp.Salary }).ToList();

            var empMan = from emp in employees
                join man in managers on emp.ManagerId equals man.Id
                where emp.Salary >= 5000
                select new {EmpName = emp.Name, EmpSalary = emp.Salary, ManagerName = man.Name};

            foreach (var employee in resEmp)
            {
                //Console.WriteLine($"{employee.Name} - {employee.Salary}");
            }

            foreach (var name in resEmpNames)
            {
                //Console.WriteLine(name);
            }

            foreach (var a in resNameSalary)
            {
                //Console.WriteLine($"{a.HumanName} - {a.HumanSalary}");
            }

            foreach (var a in empSalary)
            {
                //Console.WriteLine($"{a.Name} - {a.Salary}");
            }

            foreach (var a in empSalaryAndBonus)
            {
                //Console.WriteLine($"{a.Name} - {a.Salary}");
            }

            foreach (var a in empMan)
            {
                //Console.WriteLine($"Employee: {a.EmpName}; Emp Salary: {a.EmpSalary}; Manager: {a.ManagerName}");
            }


            var empl = employees.Where(e => e.Salary >= 6000);
            var empConfirmed = employees.Where(IsConfirmedToBonus);

            foreach (var employee in empl)
            {
                //Console.WriteLine(employee.Salary);
            }

            foreach (var employee in empConfirmed)
            {
                //Console.WriteLine(employee.Salary);
            }

            var employ = employees.FirstOrDefault(emp => emp.Salary >= 8000);
            var employG = employees.FirstOrDefault(emp => emp.Salary >= 9000);

            Console.WriteLine(employ.Name);
            if (employG != null)
            {
                Console.WriteLine(employG.Salary);
            }

            var first = employees.First(e => e.Salary >= 5899);
            Console.WriteLine(first.Salary);

            var ids = managers.Select(m => m.Id);

            foreach (var id in ids)
            {
                Console.WriteLine(id);
            }

            Console.ReadLine();
        }

        private static bool IsConfirmedToBonus(Employee employee)
        {
            Thread.Sleep(100);
            return employee.Salary >= 8000;
        }
    }
}
