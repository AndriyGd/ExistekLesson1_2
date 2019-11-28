using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.XML
{
    class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nAddress: {Address}\nSalary: {Salary}\nId: {Id}\n";
        }
    }
}
