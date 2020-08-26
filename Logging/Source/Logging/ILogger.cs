using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    interface ILogger
    {
        void Info(string message);
        void Debug(string message);
        void Error(LoggingLevel level, string message);
        void Warning(LoggingLevel level, string message);
    }
}
