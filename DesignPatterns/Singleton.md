# Singleton Pattern
The Singleton Pattern is a creational design pattern that ensures a class has only one instance and provides a global point of access to that instance. It’s often used for things like logging, configuration, or a single shared resource.

# Example

## Thread unsafe example
```csharp

public sealed class Singleton
{
    private static Singleton? _instance = null;

    // Private constructor prevents external instantiation
    private Singleton()
    {
    }

    // Public static method to get the instance (lazy initialization)
    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }

    public void DoSomething()
    {
        Console.WriteLine("Singleton instance invoked!");
    }
}


```
Note:- If multiple threads access Instance at the same time when instance is still null, it's possible that more than one instance of Singleton could be created. This breaks the singleton guarantee.

## Thread safe example

```csharp
public sealed class Singleton
{
    private static Singleton? _instance = null;
    private static readonly object _lock = new object();

    private Singleton()
    {
    }

    // double checked locking:
    public static Singleton GetInstance()
    {
        if (_instance == null) // First check (no locking)
        {
            lock (_lock) // Lock to ensure only one thread can enter here at a time
            {
                if (_instance == null) // Double-check inside lock
                {
                    _instance = new Singleton();
                }
            }
        }
        return _instance;
    }

    public void DoSomething()
    {
        Console.WriteLine("Singleton instance invoked!");
    }
}
```
Note:- Double-checking allows us to avoid unnecessary locking while still guaranteeing thread safety during the creation phase.


## Eager initialization

```csharp
public sealed class Singleton
{
    // Eagerly create the single instance when the class is loaded
    private static readonly Singleton _instance = new Singleton();

    // Private constructor prevents instantiation from other classes
    private Singleton()
    {
    }

    // Public static property to access the instance
    public static Singleton Instance
    {
        get
        {
            return _instance;
        }
    }

    public void DoSomething()
    {
        Console.WriteLine("Singleton instance invoked!");
    }
}

```

# Reference
1. https://www.youtube.com/watch?v=tSZn4wkBIu8