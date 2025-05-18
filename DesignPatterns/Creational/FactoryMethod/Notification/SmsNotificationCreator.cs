


namespace DesignPatterns.Creational.FactoryMethod;

public class SmsNotificationCreator : NotificationCreator
{
    public override INotification CreateNotification()
    {
        return new SmsNotification();
    } 
}