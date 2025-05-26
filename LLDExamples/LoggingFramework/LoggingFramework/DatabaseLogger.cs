using System;

namespace LoggingFramework
{
    public class DatabaseLogger : ILogObserver
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"DatabaseLogger: {message}");
        }
    }
}