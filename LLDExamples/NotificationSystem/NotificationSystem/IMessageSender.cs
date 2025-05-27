namespace NotificationSystem
{
    public interface IMessageSender
    {
        void SendMessage(string messageContent);
    }
}