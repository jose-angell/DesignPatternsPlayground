using Xunit;
using DesignPatterns.Creational.Singleton;
using System.IO;

namespace DesignPatterns.Tests;

public class SingletonTests
{
    [Fact]
    public void Logger_ShouldBeSameInstance()
    {//Instancia unica
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;
        Assert.Same(logger1, logger2);
    }
    
    [Fact]
    public void Logger_ShouldRemainSingleton_InMultithreadedContext()
    {
        //verifica que solo se cree una instancia con multiples hilos
        Logger? instance1 = null;
        Logger? instance2 = null;

        Parallel.Invoke(
            () => instance1 = Logger.Instance,
            () => instance2 = Logger.Instance
        );
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void Logger_Log_ShouldWriteToConsole()
    {
        //Funcionalidad basica del logger
        //Redirige la salida de consola a un stringWriter temporal
        using var sw = new StringWriter();
        
        // cualquier cosa dirgida a conosle.writeline se enviara a mi espacion en memoria sw, en lugar de la consola
        Console.SetOut(sw);

        var message = "Test message";
        Logger.Instance.Log(message);

        var output = sw.ToString().Trim();
        Assert.Equal($"[LOG] {message}", output);
    }

    [Fact]
    public void Logger_ShouldBeUsableWithoutAnySetup()
    {
        //Verifica que el acceso a Logger.Instance.Log(...) funciona sin necesidad de ninguna configuracion previa
        var exception = Record.Exception(() =>
        {
            Logger.Instance.Log("Message without prioo setup");
        });
        Assert.Null(exception); // NO debe lanzar exception
    }
    
    [Fact] 
    public void Logger_ShouldHaveSameReference()
    {
        // Validad que son la misma referencia, misma instancia en memoria
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;

        Assert.True(object.ReferenceEquals(logger1,logger2));
    }

    [Fact]
    public void Logger_Log_ShouldHaveExpectedFormat()
    {
        //Asegura que el log tenga el formato esperado
        using var sw = new StringWriter();
        Console.SetOut(sw);
        Logger.Instance.Log("Hello");

        var output = sw.ToString().Trim();
        Assert.StartsWith("[LOG]", output);
        Assert.Contains("Hello", output);
    }
    [Fact]
    public void Logger_Constructor_ShouldBePrivate()
    {
        //Validar queno puede ser instanciado externamente
        // Esto no es un test ejecutable, pero se puee confirmarr por reflexion
        var constructors = typeof(Logger).GetConstructors(
        System.Reflection.BindingFlags.Instance |
        System.Reflection.BindingFlags.Public |
        System.Reflection.BindingFlags.NonPublic
        );

        // Debe existir un constructor privado y ningún público
        Assert.Single(constructors);
        Assert.True(constructors[0].IsPrivate);
    }
}
