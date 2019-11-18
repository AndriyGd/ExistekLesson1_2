using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lessson6.Interfaces
{
    public class HardWorker
    {
        private readonly ILogger _logger;

        public HardWorker(ILogger logger)
        {
            _logger = logger;

#if DEBUG
        _logger.LogDebug("Create instance of Hard Worker");
#endif
        }

        public void Work(int n)
        {
            _logger.LogInfo("Start working...");
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine($"I = {i}");
#if DEBUG
                _logger.LogDebug($"Current value is: {i}");
#endif
                Thread.Sleep(500);
            }

            _logger.LogInfo("Finish working");
        }
    }
}
