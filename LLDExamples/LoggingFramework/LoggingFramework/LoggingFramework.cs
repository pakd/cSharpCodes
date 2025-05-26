using System;

namespace LoggingFramework
{
    public class LoggingFramework
    {
        private static LoggingFramework instance;
        private static AbstractLogger abstractLogger;
        private static LoggerNotifier loggerNotifier;

        private LoggingFramework()
        {
            
        }

        public static LoggingFramework GetInstance()
        {
            if (instance == null)
            {
                instance = new LoggingFramework();
                abstractLogger = LoggerManager.GetAbstractLoggerChain();
                loggerNotifier = LoggerManager.AddObservers();
            }
            return instance;
        }

        public void LogInfo(string message)
        {
            Log(1, message);
        }
        
        public void LogError(string message)
        {
            Log(2, message);
        }
        
        public void LogDebug(string message)
        {
            Log(3, message);
        }

        private void Log(int level, string message)
        {
            abstractLogger.LogMessage(level, loggerNotifier, message);
        }
    }
}