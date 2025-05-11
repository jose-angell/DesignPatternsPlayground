using System;
namespace DesignPatterns.Creational.Singleton;

public class FakeConnection 
{
    public bool IsOpen {get; private set;}

    public void Open()
    {
        IsOpen = true;
        Console.WriteLine("Fake connection opened.");
    }

    public void Close()
    {
        IsOpen = false;
        Console.WriteLine("Fake connection closed.");
    }
}