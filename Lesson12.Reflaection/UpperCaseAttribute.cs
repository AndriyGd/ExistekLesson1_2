using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12.Reflaection
{
    public class UpperCaseAttribute : Attribute
    {
        public bool IsUpper { get; set; }
    }
}
