namespace NotificationSystem
{
    public class SmsSender : IMessageSender
    {
        public void SendMessage(string messageContent)
        {
            Console.WriteLine($"Sending via Sms: {messageContent}");
        }
    }
}