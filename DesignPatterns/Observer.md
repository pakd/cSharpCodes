# Observer Pattern
The Observer Design Pattern is a behavioral design pattern that defines a one-to-many dependency between objects so that when one object (called the subject) changes its state, all its dependent objects (called observers) are automatically notified and updated.

# Example
```csharp

public enum Event
{
    NewItem,
    Sale
}

public interface IListener
{
    void Update(Event eventType);
}


public class EmailMsgListener : IListener
{
    private readonly string _email;

    public EmailMsgListener(string email)
    {
        _email = email;
    }

    public void Update(Event eventType)
    {
        Console.WriteLine($"Sending mail to {_email} concerning {eventType}");
    }
}


public class NotificationService
{
    private readonly Dictionary<Event, List<IListener>> _customers;

    public NotificationService()
    {
        _customers = new Dictionary<Event, List<IListener>>();
        foreach (Event evt in Enum.GetValues(typeof(Event)))
        {
            _customers[evt] = new List<IListener>();
        }
    }

    public void Subscribe(Event eventType, IListener listener)
    {
        _customers[eventType].Add(listener);
    }

    public void Unsubscribe(Event eventType, IListener listener)
    {
        _customers[eventType].Remove(listener);
    }

    public void NotifyCustomers(Event eventType)
    {
        foreach (var listener in _customers[eventType])
        {
            listener.Update(eventType);
        }
    }
}

public class Store
{
    private readonly NotificationService _notificationService;

    public Store()
    {
        _notificationService = new NotificationService();
    }

    public void NewItemPromotion()
    {
        _notificationService.NotifyCustomers(Event.NewItem);
    }

    public void SalePromotion()
    {
        _notificationService.NotifyCustomers(Event.Sale);
    }

    public NotificationService GetService()
    {
        return _notificationService;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();

        IListener alice = new EmailMsgListener("alice@example.com");
        IListener bob = new EmailMsgListener("bob@example.com");

        store.GetService().Subscribe(Event.NewItem, alice);
        store.GetService().Subscribe(Event.Sale, alice);

        store.GetService().Subscribe(Event.Sale, bob);

        store.NewItemPromotion();  // Notifies Alice (NewItem)
        store.SalePromotion();     // Notifies Alice and Bob (Sale)

        store.GetService().Unsubscribe(Event.Sale, bob);

        store.SalePromotion();     // Notifies Alice only
    }
}


```

# Reference
1. https://www.youtube.com/watch?v=Nrwj3gZiuJU