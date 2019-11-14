using MetroLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LoggerService
{
    public interface ILoginService
    {
        void WriteToLog<T>(string message, LogLevel logLevel = LogLevel.Trace, Exception exception = null);
    }
}
