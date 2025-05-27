namespace NotificationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IMessageSender whatsapp = new WhatsAppSender();
            IMessageSender email = new EmailSender();
            IMessageSender sms = new SmsSender();

            Notification textViaWhatsApp = new TextNotification(whatsapp);
            textViaWhatsApp.Send("Hello from Bridge Pattern!");

            Notification qrViaEmail = new QRNotification(email);
            qrViaEmail.Send("https://example.com/bridge");

            Notification textViaSMS = new TextNotification(sms);
            textViaSMS.Send("Security code: 123456");
        }
    }
}