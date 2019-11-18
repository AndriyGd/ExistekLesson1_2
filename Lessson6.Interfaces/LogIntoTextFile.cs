using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessson6.Interfaces
{
    public class LogIntoTextFile : ILogger
    {
        public void LogDebug(string message)
        {
            Console.WriteLine($"Log debug to Text file: {message}");
        }

        public void LogException(string message)
        {
            Console.WriteLine($"Log Exception to Text file: {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Log Info to Text file: {message}");
        }
    }
}
