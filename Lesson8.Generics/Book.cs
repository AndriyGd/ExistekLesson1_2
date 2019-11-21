using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Generics
{
    public class Book
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\n";
        }
    }
}
