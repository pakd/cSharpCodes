namespace NotificationSystem
{
    public class WhatsAppSender : IMessageSender
    {
        public void SendMessage(string messageContent)
        {
            Console.WriteLine($"Sending via WhatsApp: {messageContent}");
        }
    }
}