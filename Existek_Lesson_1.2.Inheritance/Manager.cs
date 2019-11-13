using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Inheritance
{
    using Common;

    public class Manager : Human
    {
        public double Bonus { get; }
        public int CountEmployees { get; set; }

        public Manager(double bonus)
        {
            Bonus = bonus;
            Console.WriteLine("Call Manager constructor");
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nBonus: {Bonus}\nCount Employees: {CountEmployees}\nId: {Id}\n";
        }
    }
}
