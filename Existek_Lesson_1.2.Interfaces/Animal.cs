using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Interfaces
{
    public class Animal
    {
        public Animal(string @class)
        {
            Class = @class;
        }

        public string Class { get;}
        public string Name { get; set; }
        public virtual string FullName => $"{Class} {Name}";

        public virtual void Voice()
        {
            Console.WriteLine("Gav-Gav-Gav");
        }
    }
}
