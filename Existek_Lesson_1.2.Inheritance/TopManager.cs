using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Inheritance
{
    public class TopManager: Manager
    {
        public string PhoneNumber { get; set; }

        public TopManager(double bonus) : base(bonus)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()}Phone Number: {PhoneNumber}\n";
        }
    }
}
