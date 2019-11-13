using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Inheritance
{
    using Common;

    public class Employee : Human
    {
        public double Salary { get; set; }

        public bool BuildCard()
        {
            if (Age >= 18 && Age <= 45)
            {
                Console.WriteLine("Card was built.");
                Console.WriteLine("\tHuman Information");
                Console.WriteLine(ToString());
                return true;
            }

            Console.WriteLine("Card was not built!");

            return false;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nSalary: {Salary}\nId: {Id}";
        }
    }
}
