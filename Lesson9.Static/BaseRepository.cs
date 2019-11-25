using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9.Static
{
    public partial class BaseRepository
    {
        partial void Connected();

        public void Connect()
        {
            Console.WriteLine("Connected");

            Connected();
        }
    }
}
