using MetroLog;
using MetroLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LoggerService
{
    class LogerService : ILoginService
    {
        public static LogerService Instance { get; }

        public static int RetainDays { get; } = 3;
        public static bool Enabled { get; set; }

        static LogerService()
        {
            Instance = Instance ?? new LogerService();
            LogManagerFactory.DefaultConfiguration.AddTarget(LogLevel.Trace, LogLevel.Fatal, new StreamingFileTarget { RetainDays = RetainDays });
        }
        public void WriteToLog<T>(string message, LogLevel logLevel = LogLevel.Trace, Exception exception = null)
        {
            if (Enabled)
            {
                var logger = LogManagerFactory.DefaultLogManager.GetLogger<T>();
                if(logLevel == LogLevel.Trace && logger.IsTraceEnabled)
                {
                    logger.Trace(message);
                }
                if(logLevel == LogLevel.Debug && logger.IsDebugEnabled)
                {
                    System.Diagnostics.Debug.WriteLine($"{DateTime.Now.TimeOfDay.ToString()} {message}");
                }
                if (logLevel == LogLevel.Error && logger.IsErrorEnabled)
                {
                    logger.Error(message);
                }
                if (logLevel == LogLevel.Fatal && logger.IsFatalEnabled)
                {
                    logger.Fatal(message);
                }
                if (logLevel == LogLevel.Info && logger.IsInfoEnabled)
                {
                    logger.Info(message);
                }
                if (logLevel == LogLevel.Warn && logger.IsWarnEnabled)
                {
                    logger.Warn(message);
                }
            }
        }

    }
}
