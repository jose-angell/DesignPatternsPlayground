
using DesignPatterns.Behavioral.Observer;
using System;
using System.IO;
using Xunit;

public class WeatherStationTests
{
    [Fact]
    public void WeatherStation_ShouldNotifyAllDisplays()
    {
        var station = new WeatherStation();
        var display1 = new WeatherDisplay("Living Room");
        var display2 = new WeatherDisplay("Kitchen");
        var sw = new StringWriter();
        Console.SetOut(sw);
        station.RegisterObserver(display1);
        station.RegisterObserver(display2);
        station.SetWeather("Rainy");
        var output = sw.ToString();

        Assert.Contains("Living Room Display: Weather updated to Rainy", output);
        Assert.Contains("Kitchen Display: Weather updated to Rainy", output);
    }

    [Fact]
    public void RemovedObserver_ShouldNotReceiveUpdate()
    {
        var weatherSation = new WeatherStation();
        var output = new StringWriter();
        Console.SetOut(output);

        var display1 = new WeatherDisplay("ToRemove");
        weatherSation.RegisterObserver(display1);
        weatherSation.RemoveObserver(display1);

        //act
        weatherSation.SetWeather("Sunny");
        // Assert
        var consoleOutput = output.ToString();
        Assert.DoesNotContain("ToRemove", consoleOutput);
    }
    [Fact]
    public void NoObservers_ShouldNotThrowException()
    {
        // Arrange
        var weatherStation = new WeatherStation();
        var output = new StringWriter();
        Console.SetOut(output);

        // Act (no observer registered)
        weatherStation.SetWeather("Foggy");

        // Assert
        var consoleOutput = output.ToString();
        Assert.Contains("New weather: Foggy", consoleOutput);
        // No exceptions should be thrown
    }
    
}