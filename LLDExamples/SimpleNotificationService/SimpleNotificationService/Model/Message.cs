namespace SimpleNotificationService.Model;

public class Message
{
    public string Content { get;  }
    public DateTime createdAt { get;  }

    public Message(string content)
    {
        this.Content = content;
        this.createdAt = DateTime.UtcNow;
    }
}