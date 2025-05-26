using System;

namespace LoggingFramework
{
    public class ConsoleLogger : ILogObserver
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"ConsoleLogger: {message}");
        }
    }
}