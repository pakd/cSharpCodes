using System;

namespace LoggingFramework
{
    public interface ILogObserver
    {
        void LogMessage(string message);
    }
}