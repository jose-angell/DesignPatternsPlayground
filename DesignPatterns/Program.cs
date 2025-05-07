using System;
using DesignPatterns.Creational.Singleton;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Design Patterns Playground ===");
        Console.WriteLine("1 - Singleton");
        Console.Write("Selecciona una opción: ");
        var opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                SingletonDemo.Run();
                break;
            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
}