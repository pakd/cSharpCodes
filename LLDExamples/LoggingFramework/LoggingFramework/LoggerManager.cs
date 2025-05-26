using System;

namespace LoggingFramework
{
    public class LoggerManager
    {
        public static AbstractLogger GetAbstractLoggerChain()
        {
            AbstractLogger infoLogger = new InfoLogger(1);

            AbstractLogger errorLogger = new ErrorLogger(2);
            infoLogger.SetNextLevelLogger(errorLogger);

            AbstractLogger debugLogger = new DebugLogger(3);
            errorLogger.SetNextLevelLogger(debugLogger);
            
            return infoLogger;
        }
        
        public static LoggerNotifier AddObservers(){
            LoggerNotifier loggerNotifier = new LoggerNotifier();
            
            ConsoleLogger consoleLogger = new ConsoleLogger();
            loggerNotifier.AddObserver(1,consoleLogger);
            loggerNotifier.AddObserver(2,consoleLogger);
            loggerNotifier.AddObserver(3,consoleLogger);
            
            FileLogger fileLogger = new FileLogger();
            loggerNotifier.AddObserver(2,fileLogger);
            
            return loggerNotifier;
        }
    }
    
}