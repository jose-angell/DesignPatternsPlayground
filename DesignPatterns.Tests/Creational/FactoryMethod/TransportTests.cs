

using Xunit;
using DesignPatterns.Creational.FactoryMethod;
using System;

namespace DesignPatterns.Tests;

public class TransportTests 
{
    [Fact]
    public void RoadLogistics_ShouldCreateTruck(){
        //valida que la subclase RoadLogistics crea un Truck, como esperamos según la implementación del Factory Method
        var logistics = new RoadLogistics();
        var transport = logistics.CreateTransport();

        Assert.IsType<Truck>(transport);
    }

    [Fact]
    public void SeaLogistics_ShouldCreateShip()
    {
        var logistics = new SeaLogistics();
        var transport = logistics.CreateTransport();
        Assert.IsType<Ship>(transport);
    }

    [Fact]
    public void RoadLogistics_PlanDelivery_ShouldWriteTruckMessage()
    {
        // Prueba que PlanDelivery de RoadLogistics ejecuta correctamente Deliver
        var originalOut = Console.Out;
        var logistics = new RoadLogistics();
        using var sw = new StringWriter();
        Console.SetOut(sw);

        logistics.PlanDelivery();
        var output = sw.ToString().Trim();
        Assert.Equal("Delivering by truck.", output);
        Console.SetOut(originalOut);
    }
    [Fact]
    public void SeaLogistics_PlanDelivery_ShouldWriteShipMessage()
    {
        var originalOut = Console.Out;
        var logistics = new SeaLogistics();
        using var sw = new StringWriter();
        Console.SetOut(sw);

        logistics.PlanDelivery();
        var output = sw.ToString().Trim();
        Assert.Equal("Delivering by ship.", output);
        Console.SetOut(originalOut);
    }
}