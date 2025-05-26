using System;

namespace LoggingFramework
{
    public class LoggerNotifier
    {
        private readonly Dictionary<int, List<ILogObserver>> logObservers = new();

        public void AddObserver(int level, ILogObserver logObserver)
        {
            if (!logObservers.TryGetValue(level, out var currentLogger))
            {
                currentLogger = new List<ILogObserver>();
                logObservers[level] = currentLogger;
            }

            currentLogger.Add(logObserver);
        }

        public void RemoveObserver(ILogObserver logObserver)
        {
            foreach (var entry in logObservers)
            {
                entry.Value.Remove(logObserver);
            }
        }

        public void NotifyAllObservers(int level, string message)
        {
            if (logObservers.TryGetValue(level, out var observers))
            {
                foreach (var observer in observers)
                {
                    observer.LogMessage(message);
                }
            }
        }
    }
}