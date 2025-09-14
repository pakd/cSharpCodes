namespace SimpleNotificationService.Model;

public class HttpSubscriber : ISubscriber
{
    public string Name { get; }

    public HttpSubscriber(string name)
    {
        Name = name;
    }

    public async Task ReceiveAsync(Message message)
    {
        await Task.Delay(150); // simulate http call
        if (message.Content.Contains("fail"))
        {
            throw new Exception("HTTP delivery failed");
        }
        Console.WriteLine($"[HTTP: topic: {Name}] received: {message.Content}");
    }
}