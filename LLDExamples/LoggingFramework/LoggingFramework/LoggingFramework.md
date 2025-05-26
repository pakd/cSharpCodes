# Logging Framework
## Requirements
- Should be able to log in more than one place like console, Log file, database, etc.
- Should be able to multiple categories of messages like Info, Debug, Error, etc.
- Category and place of logging should be configurable.

## Entities
- LoggingFramework — main class, exposed to application
- AbstractLogger - base abstract class which is extended by DebugLogger, ErrorLogger, InfoLogger.
- LoggerManager - for making some configuration changes, e.g. making AbstractLogger chaining, a config should be used in the long term.
- ILogObserver - Interface which is implemented by FileLogger, ConsoleLogger, DatabaseLogger.
- LoggerNotifier - class which contains logic to add different observers for a given level

[LoggingFramework.md](LoggingFramework.md)
## Important

There are a total of three design patterns used.
- Singleton for the main Logger class
- Chain of Responsibility for different log levels.
- Observer for different places of log

# Reference
1. https://www.youtube.com/watch?v=RljSBrZeJ3w