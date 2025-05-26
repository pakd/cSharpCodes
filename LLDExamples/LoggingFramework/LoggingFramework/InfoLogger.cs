using System;

namespace LoggingFramework
{
    public class InfoLogger : AbstractLogger
    {
        public InfoLogger(int level)
        {
            this.level = level;
        }
        
        protected override void DisplayMessage(LoggerNotifier notifier, string message)
        {
            Console.WriteLine($"Info Log: {message}");
            notifier.NotifyAllObservers(this.level, message);
        }
    }
}