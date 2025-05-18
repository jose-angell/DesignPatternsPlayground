
using DesignPatterns.Creational.FactoryMethod;

public abstract class NotificationCreator
{
    public abstract INotification CreateNotification();

    public void Send(string message)
    {
        var notification = CreateNotification();
        notification.Send(message);
    }
}