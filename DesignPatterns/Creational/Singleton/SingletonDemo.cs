using System;
namespace DesignPatterns.Creational.Singleton;

public static class SingletonDemo
{
    public static void Run()
    {
        var loggerA = Logger.Instance();
        var loggerB = Logger.Instance();

        loggerA.Log("Mensaje desde loggerA");
        loggerB.Log("Mensaje desde loggerB");

        Console.WriteLine($"¿Son la misma instancia? {ReferenceEquals(loggerA, loggerB)}");
    }
}
