# Chain of Responsibility Pattern
The Chain of Responsibility is a behavioral design pattern that allows you to pass a request along a chain of handlers. Each handler decides whether to process the request or pass it to the next handler in the chain.

# Example
```csharp

public abstract class SupportHandler
{
    protected SupportHandler nextHandler;

    public void SetNext(SupportHandler next)
    {
        nextHandler = next;
    }

    public abstract void HandleRequest(string issueType);
}

public class Level1Support : SupportHandler
{
    public override void HandleRequest(string issueType)
    {
        if (issueType == "basic")
        {
            Console.WriteLine("Level 1 handled the basic issue.");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(issueType);
        }
    }
}

public class Level2Support : SupportHandler
{
    public override void HandleRequest(string issueType)
    {
        if (issueType == "intermediate")
        {
            Console.WriteLine("Level 2 handled the intermediate issue.");
        }
        else if (nextHandler != null)
        {
            nextHandler.HandleRequest(issueType);
        }
    }
}

public class Manager : SupportHandler
{
    public override void HandleRequest(string issueType)
    {
        if (issueType == "critical")
        {
            Console.WriteLine("Manager handled the critical issue.");
        }
        else
        {
            Console.WriteLine("Issue could not be handled.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create handlers
        var level1 = new Level1Support();
        var level2 = new Level2Support();
        var manager = new Manager();

        // Set up the chain: Level1 → Level2 → Manager
        level1.SetNext(level2);
        level2.SetNext(manager);

        // Make requests
        level1.HandleRequest("basic");       // Handled by Level 1
        level1.HandleRequest("intermediate"); // Handled by Level 2
        level1.HandleRequest("critical");     // Handled by Manager
        level1.HandleRequest("unknown");      // Not handled
    }
}


```

# Reference
1. https://www.youtube.com/watch?v=FafNcoBvVQo