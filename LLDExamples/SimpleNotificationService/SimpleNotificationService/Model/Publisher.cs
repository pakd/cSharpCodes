namespace SimpleNotificationService.Model;

public class Publisher
{
    public string Name { get; }

    public Publisher(string name)
    {
        Name = name;
    }

    public void Publish(Topic topic, string content)
    {
        var message = new Message(content);
        Console.WriteLine($" Publisher {Name} publishing: {content}");
        topic.Publish(message);
    }
}