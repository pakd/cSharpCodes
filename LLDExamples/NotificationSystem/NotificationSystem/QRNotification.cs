namespace NotificationSystem
{
    public class QRNotification : Notification
    {
        public QRNotification(IMessageSender sender) : base(sender) { }
    
        public override void Send(string content)
        {
            string message = $"[QR] Generated QR Code for: {content}";
            messageSender.SendMessage(message);
        }
    }
}