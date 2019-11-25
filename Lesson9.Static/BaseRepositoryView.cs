using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9.Static
{
    public partial class BaseRepository
    {
        partial void Connected()
        {
            Console.WriteLine("Connected to database!!!");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnected!!!");
        }
    }
}
