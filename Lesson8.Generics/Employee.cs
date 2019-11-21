using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Generics
{
    public class Employee : IHuman
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
    }
}
