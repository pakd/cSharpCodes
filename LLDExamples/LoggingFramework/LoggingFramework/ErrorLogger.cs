using System;

namespace LoggingFramework
{
    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(int level)
        {
            this.level = level;
        }
        
        protected override void DisplayMessage(LoggerNotifier notifier, string message)
        {
            Console.WriteLine($"Error Log: {message}");
            notifier.NotifyAllObservers(this.level, message);
        }
    }
}

