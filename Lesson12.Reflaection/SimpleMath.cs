using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Reflaection
{
    public class SimpleMath
    {
        private readonly int _x;
        private readonly int _y;

        public SimpleMath(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int Sum()
        {
            return _x + _y;
        }
    }
}
