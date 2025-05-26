using System;

namespace LoggingFramework
{
    public class FileLogger : ILogObserver
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"FileLogger: {message}");
        }
    }
}