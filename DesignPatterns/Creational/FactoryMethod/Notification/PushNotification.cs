

namespace DesignPatterns.Creational.FactoryMethod;

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Message by Push - {message}");
    }
}