using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1_2.SimpleClasses
{
    using System.Collections;
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee();
            var emp2 = new Employee("Oleg");
            var emp3 = new Employee("Json");
#if false
            var res = emp.ToString();
            Console.WriteLine(res);
            emp.ChangeCardId(783);
            Console.WriteLine();
            Console.WriteLine(emp);
            Console.WriteLine();
            Console.WriteLine(emp2);

            Employee.ReloadBonus();
            Console.WriteLine("-----------------------------");
            Console.WriteLine(emp);
            Console.WriteLine();
            Console.WriteLine(emp2); 
#endif
            //Console.WriteLine(emp);
            //Console.WriteLine(emp2);
            //Console.WriteLine(emp3);

            //var h1 = new Human(12);
            //Console.WriteLine(h1.Age);
            //h1.Age = 7;
            //h1.Address = "dfd";
            //h1.Name = "dfdfd";

            //var h2 = new Human
            //{
            //    Age = 27,
            //    Address = "Rerer",
            //    Name = "Json"
            //};

            //Console.WriteLine(h2.Address);

            var dep = new Department();
            dep.AddEmployee(emp);
            dep.AddEmployee(emp2);
            dep.AddEmployee(emp3);

            //Console.WriteLine(dep.GetEmployeeBy(4));

            foreach (var employee in dep)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine("------");

            Console.WriteLine(dep[3]);

            dep[3] = new Employee("Petro");
            Console.WriteLine("------");

            Console.WriteLine(dep[3]);

            Console.ReadLine();
        }
    }

    class Employee
    {
        public static int Bonus { get; set; }

        private const string Position = "QA";
        private readonly string _name;
        private readonly int _age = 18;
        private int _cardId = -1;

        public int Id { get; }

        static Employee()
        {
            Bonus = 4;
        }

        public static void ReloadBonus()
        {
            Bonus = 6;
        }

        public Employee() : this("Tom")
        {
            //Console.WriteLine("Employee was created!");
            Id = IdHelper.GetNextId();
        }

        public Employee(string name)
        {
            this._name = name;
            //Console.WriteLine($"Name: {_name}");
            Id = IdHelper.GetNextId();
        }

        public void ChangeName(string name)
        {
            //_name = name; //readonly поле можна присвоїти значення лише під час оголошення або в конструкторі
        }

        public void ChangeCardId(int cardId)
        {
            _cardId = cardId;
            //ReloadBonus();
        }

        public override string ToString()
        {
            return $"Name: {_name}\nAge: {_age}\nPosition: {Position}\nCard Id: {_cardId}\nBonus: {Bonus}\nId: {Id}";
        }
    }

    class Human
    {
        public const string Position = "QA";

        private int _age;

        public string Name { get; set; }
        public int Age
        {
            get { return _age; }
            set
            {
                if(value <= 0 || value > 30) throw  new ArgumentOutOfRangeException();

                _age = value;
            }
        }

        public string Address { get; set; }

        public Human()
        {
            
        }

        public Human(int age)
        {
            Age = age;
        }
    }

    class Department : IEnumerable<Employee>
    {
        private readonly List<Employee> _employees;
        public int CountEmployees => _employees.Count;

        public int NumbersOfEmployee
        {
            get { return _employees.Count; }
        }

        public Department()
        {
            _employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public Employee GetEmployeeBy(int id)
        {
            foreach (var employee in _employees)
            {
                if (employee.Id == id) return employee;
            }

            return null;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Employee this[int id]
        {
            get => GetEmployeeBy(id);
            set
            {
                for (int i = 0; i < _employees.Count; i++)
                {
                    if (_employees[i].Id == id)
                    {
                        _employees[i] = value;
                        break;
                    }
                }
            }
        }
    }
}
