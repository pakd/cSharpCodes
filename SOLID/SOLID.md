# SOLID

- S: Single Responsibility Principle
- O: Open/Closed Principle
- L: Liskov Substitution Principle
- I: Interface Segregation Principle
- D: Dependency Inversion Principle

## 1. Single Responsibility Principle (SRP)
Class should have only one reason to change.

Every class should focus on one job or responsibility. This makes the class easier to maintain, test, and understand. If a class has multiple responsibilities, a change to one responsibility might break the other.

```csharp
public class EmailSender
{
    public void SendEmail(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

```
- This class only handles sending emails, nothing else.

## 2. Open/Closed Principle (OCP)
Software entities should be open for extension, but closed for modification.  

You should be able to add new features without changing existing code. This reduces the risk of introducing bugs in existing functionality.



```csharp
public abstract class NotificationSender
{
    public abstract void Send(string message);
}

public class EmailSender : NotificationSender
{
    public override void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class SmsSender : NotificationSender
{
    public override void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

```
- You can add new notification types by extending NotificationSender without modifying existing code.

## 3. Liskov Substitution Principle (LSP)

Derived classes must be substitutable for their base classes.  

Derived classes must behave in a way that their base class promises. Otherwise, substituting a subclass object in place of a base class breaks the program.

```csharp
public void NotifyUser(NotificationSender sender, string message)
{
    sender.Send(message);  // Can pass any subclass of NotificationSender
}
```
- Any subclass like EmailSender or SmsSender can replace NotificationSender without breaking functionality.

## 4. Interface Segregation Principle (ISP)

Clients should not be forced to depend on interfaces they do not use.  

Split large interfaces into smaller, more specific ones so clients only implement or depend on what they really need.

```csharp
public interface IEmailSender
{
    void SendEmail(string message);
}

public interface ISmsSender
{
    void SendSms(string message);
}

public class EmailSender : IEmailSender
{
    public void SendEmail(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

```

- Separate interfaces for email and SMS senders so clients only depend on what they use.

## 5. Dependency Inversion Principle (DIP)

Depend on abstractions, not on concrete implementations.

High-level modules should not depend on low-level modules directly. Both should depend on abstractions (interfaces or abstract classes).
```csharp
public class NotificationService
{
    private readonly NotificationSender _sender;

    public NotificationService(NotificationSender sender)
    {
        _sender = sender;
    }

    public void Notify(string message)
    {
        _sender.Send(message);
    }
}
```

- NotificationService depends on the abstraction NotificationSender, not concrete classes like EmailSender.