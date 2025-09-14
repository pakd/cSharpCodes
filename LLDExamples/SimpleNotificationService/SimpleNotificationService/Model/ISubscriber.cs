namespace SimpleNotificationService.Model;

public interface ISubscriber
{
    string Name { get;  }
    Task ReceiveAsync(Message message);
}