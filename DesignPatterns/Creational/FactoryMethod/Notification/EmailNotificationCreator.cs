


namespace DesignPatterns.Creational.FactoryMethod;

public class EmailNotificationCreator : NotificationCreator
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    } 
}