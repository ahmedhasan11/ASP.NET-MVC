using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging_api
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //created an object of the LoggerFactory class and assigned it to the ILoggerFactory type variable
            ILoggerFactory loggerFactory = new LoggerFactory(
            new[] { new ConsoleLoggerProvider((_, __) => true, true) }
         );
            //or
            //ILoggerFactory loggerFactory = new LoggerFactory().AddConsole((_, __) => true);

            ILogger logger = loggerFactory.CreateLogger<Program>(); // creates a logger specific to the Program class
                                                                    // so that the logger will display a message with context info

            //log levels
            logger.LogInformation("Logging information.");
            logger.LogCritical("Logging critical information.");
            logger.LogDebug("Logging debug information.");
            logger.LogError("Logging error information.");
            logger.LogTrace("Logging trace");
            logger.LogWarning("Logging warning.");
        }
    }
}
