namespace SimpleNotificationService.Model;

public class Topic
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();
    
    private Queue<Message> _messageQueue = new Queue<Message>();
    
    public string Name { get; }

    public Topic(string name)
    {
        this.Name = name;
    }

    public void Subscribe(ISubscriber subscriber)
    {
        this._subscribers.Add(subscriber);
        Console.WriteLine($"[Subscribers] subscribed for {Name}: subsriber Name: {subscriber.Name}");
    }

    public void Publish(Message message)
    {
        this._messageQueue.Enqueue(message);
        Console.WriteLine($" Message queued in {Name}: {message.Content}");
        _ = DispatchAsync(); // fire and forgot dispatcher
    }
    
    private async Task DispatchAsync()
    {
        while (_messageQueue.Count > 0)
        {
            var message = _messageQueue.Dequeue();
            foreach (var subscriber in _subscribers)
            {
                try
                {
                    await subscriber.ReceiveAsync(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed delivery to {subscriber.Name}: {ex.Message}");
                    // Here you could push to a DLQ
                }
            }
        }
    }
}