using DesignPatterns.Creational.Singleton;
using Xunit;

namespace DesignPatterns.Tests;

public class SingletonTests
{
    [Fact]
    public void Logger_ShouldBeSameInstance()
    {
        var logger1 = Logger.Instance();
        var logger2 = Logger.Instance();
        Assert.Same(logger1, logger2);
    }
}
