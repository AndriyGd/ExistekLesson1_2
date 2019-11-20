using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Events
{
    public class Point<TCord> where TCord: struct
    {
        public TCord X { get; set; }
        public TCord Y { get; set; }

        public override string ToString()
        {
            return $"X: {X} Y: {Y}\n";
        }
    }
}
