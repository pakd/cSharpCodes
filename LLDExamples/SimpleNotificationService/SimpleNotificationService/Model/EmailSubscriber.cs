namespace SimpleNotificationService.Model;

public class EmailSubscriber : ISubscriber
{
    public string Name { get;  }

    public EmailSubscriber(string name)
    {
        this.Name = name;
    }
    
    public async Task ReceiveAsync(Message message)
    {
        await Task.Delay(100); // simualted email delay
        Console.WriteLine($"Email Received for {Name}, message:  {message.Content}");
    }
}