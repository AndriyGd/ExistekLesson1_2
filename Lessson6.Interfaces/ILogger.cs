using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessson6.Interfaces
{
    public interface ILogger
    {
        void LogDebug(string message);
        void LogException(string message);
        void LogInfo(string message);
    }
}
