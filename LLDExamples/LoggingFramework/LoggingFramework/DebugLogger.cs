using System;

namespace LoggingFramework
{
    public class DebugLogger : AbstractLogger
    {
        public DebugLogger(int level)
        {
            this.level = level;
        }

        protected override void DisplayMessage(LoggerNotifier notifier, string message)
        {
            Console.WriteLine($"Debug Log: {message}");
            notifier.NotifyAllObservers(this.level, message);
        }
    }
}