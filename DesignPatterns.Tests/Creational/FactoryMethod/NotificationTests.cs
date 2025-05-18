
using Xunit;
using DesignPatterns.Creational.FactoryMethod;
using System;

namespace DesignPatterns.Tests;

public class NotificationTests
{

    [Fact]
    public void Notification_ShouldCreateEmail()
    {
        var email = new EmailNotificationCreator();
        var notification = email.CreateNotification();
        Assert.IsType<EmailNotification>(notification);
    }


    [Fact]
    public void Notification_ShouldCreateSms()
    {
        var sms = new SmsNotificationCreator();
        var notification = sms.CreateNotification();
        Assert.IsType<SmsNotification>(notification);
    }

    [Fact]
    public void Notification_ShouldCreatePush()
    {
        var push = new PushNotificationCreator();
        var notification = push.CreateNotification();
        Assert.IsType<PushNotification>(notification);
    }

    [Fact]
    public void Notification_MessageEmeal_ShouldWriteToConsole()
    {
        var originalOut = Console.Out;

        //Redirige la salida de consola a un stringWriter temporal
        using var sw = new StringWriter();

        try
        {

            Console.SetOut(sw);

            var message = "Test message";
            var notification = new EmailNotificationCreator();
            notification.Send(message);

            var output = sw.ToString().Trim();
            Assert.Equal($"Message by Email - {message}", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void Notification_MessageSms_ShouldWriteToConsole()
    {
        var originalOut = Console.Out;

        //Redirige la salida de consola a un stringWriter temporal
        using var sw = new StringWriter();

        try
        {

            Console.SetOut(sw);

            var message = "Test message";
            var notification = new SmsNotificationCreator();
            notification.Send(message);

            var output = sw.ToString().Trim();
            Assert.Equal($"Message by Sms - {message}", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
    
    [Fact]
    public void Notification_MessagePush_ShouldWriteToConsole()
    {
        var originalOut = Console.Out;

        //Redirige la salida de consola a un stringWriter temporal
        using var sw = new StringWriter();

        try
        {

            Console.SetOut(sw);

            var message = "Test message";
            var notification = new PushNotificationCreator();
            notification.Send(message);

            var output = sw.ToString().Trim();
            Assert.Equal($"Message by Push - {message}", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
    
    [Theory]
    [InlineData(typeof(EmailNotificationCreator), "Test message", "Message by Email - Test message")]
    [InlineData(typeof(SmsNotificationCreator), "Hello SMS", "Message by Sms - Hello SMS")]
    [InlineData(typeof(PushNotificationCreator), "Push now", "Message by Push - Push now")]
    public void Notification_ShouldBehavePolymorphically(Type creatorType, string inputMessage, string expectedOutput)
    {// Esta prueba valida 
        //Que el método Send se comporta correctamente independientemente de la subclase concreta de NotificationCreator.
        //Que el polimorfismo ocurre: no necesitas conocer si es EmailNotificationCreator, SmsNotificationCreator, o PushNotificationCreator
        //para invocar Send.
        //Que se imprime el mensaje esperado para cada implementación concreta.


        var originalOut = Console.Out;
        using var sw = new StringWriter();

        try
        {
            Console.SetOut(sw);

            var creator = (NotificationCreator)Activator.CreateInstance(creatorType)!;
            creator.Send(inputMessage);

            var output = sw.ToString().Trim();
            Assert.Equal(expectedOutput, output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

}