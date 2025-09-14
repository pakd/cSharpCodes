using SimpleNotificationService.Model;

public class Program
{
    public static async Task Main()
    {
        var topic = new Topic("Orders");

        // Subscribers
        var emailSub = new EmailSubscriber("Alice");
        var httpSub = new HttpSubscriber("OrderService");

        topic.Subscribe(emailSub);
        topic.Subscribe(httpSub);

        // Publisher
        var publisher = new Publisher("EcomApp");

        // Publish messages
        publisher.Publish(topic, "Order #1001 created");
        publisher.Publish(topic, "Order #1002 fail"); // will fail for HTTP subscriber
        publisher.Publish(topic, "Order #1003 shipped");

        // Keep app alive long enough for async tasks to finish
        await Task.Delay(1000);
    }
}