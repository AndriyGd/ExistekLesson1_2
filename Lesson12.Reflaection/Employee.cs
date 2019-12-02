using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Reflaection
{
    [UpperCase(IsUpper = false)]
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
}
