using System;

namespace LoggingFramework
{
    public abstract class AbstractLogger
    {
        protected int level;
        private AbstractLogger nextLevelLogger;
        
        public void LogMessage(int level, LoggerNotifier loggerNotifier, string message)
        {
            if (this.level == level)
            {
                DisplayMessage(loggerNotifier, message);
            }

            if (nextLevelLogger != null)
            {
                nextLevelLogger.LogMessage(level, loggerNotifier, message);
            }
        }

        public void SetNextLevelLogger(AbstractLogger nextLevelLogger)
        {
            this.nextLevelLogger = nextLevelLogger;
        }
        
        protected abstract void DisplayMessage(LoggerNotifier loggerNotifier, string message);
    }
}