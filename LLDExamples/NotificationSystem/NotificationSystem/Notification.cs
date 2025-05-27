namespace NotificationSystem
{
    public abstract class Notification
    {
        protected IMessageSender messageSender;

        protected Notification(IMessageSender sender)
        {
            this.messageSender = sender;
        }

        public abstract void Send(string content);
    }
}