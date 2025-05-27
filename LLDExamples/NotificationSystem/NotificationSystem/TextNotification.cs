namespace NotificationSystem
{
    public class TextNotification : Notification
    {
        public TextNotification(IMessageSender sender) : base(sender) { }

        public override void Send(string content)
        {
            string message = $"[TEXT] {content}";
            messageSender.SendMessage(message);
        }
    }
}