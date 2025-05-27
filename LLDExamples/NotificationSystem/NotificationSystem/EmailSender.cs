namespace NotificationSystem
{
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string messageContent)
        {
            Console.WriteLine($"Sending via Email: {messageContent}");
        }
    }
}