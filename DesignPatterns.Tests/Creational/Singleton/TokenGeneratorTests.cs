using Xunit;
using DesignPatterns.Creational.Singleton;
using System.IO;

namespace DesignPatterns.Tests.Creational.Singleton;

public class TokenGeneratorTests
{
    [Fact]
    public void Token_ShouldBeSameInstance()
    {//Instancia unica
        var token1 = TokenGenerator.Instance;
        var token2 = TokenGenerator.Instance;
        Assert.Same(token1, token2);
    }

    [Fact]
    public void Token_ShouldBeUsableWithoutAnySetup()
    {
        var originalOut = Console.Out;

        //Verifica que el acceso a GenerateToken funciona sin necesidad de ninguna configuracion previa
        var exception = Record.Exception(() =>
        {
            TokenGenerator.Instance.GenerateToken();
        });
        Assert.Null(exception); // NO debe lanzar exception
        Console.SetOut(originalOut);

    }
    
    [Fact]
    public void Token_ShouldHaveExpectedFormat()
    {
        //Asegura que el token tenga el formato esperado
        var tokenString =   TokenGenerator.Instance.GenerateToken();
        Assert.StartsWith("TOKEN-", tokenString);
        
    }
}