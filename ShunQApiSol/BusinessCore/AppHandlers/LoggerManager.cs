using BusinessCore.AppHandlers.Models;
using System;

namespace BusinessCore.AppHandlers
{
    public class LoggerManager : ILoggerManager
    {
        public LoggerManager()
        {
        }

        public void LogDebug(string message)
        {
           Console.WriteLine(message);
        }

        public void LogError(string message)
        {
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }

        public void LogWarn(string message)
        {
            Console.WriteLine(message);
        }
    }
}
