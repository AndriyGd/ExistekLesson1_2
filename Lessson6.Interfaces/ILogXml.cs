using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessson6.Interfaces
{
    public class LogXml : ILogger
    {
        public void LogDebug(string message)
        {
            Console.WriteLine($"Log debug to XML file: {message}");
        }

        public void LogException(string message)
        {
            Console.WriteLine($"Log Exception to XML file: {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Log Info to XML file: {message}");
        }
    }
}
