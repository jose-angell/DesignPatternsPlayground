using Xunit;
using DesignPatterns.Creational.Singleton;
using System.IO;

namespace DesignPatterns.Tests;

public class DatabaseConnectionTests
{
    [Fact]
    public void Connection_ShouldBeSameInstance()
    {//Instancia unica
        var conn1 = DatabaseConnection.Instance;
        var conn2 = DatabaseConnection.Instance;
        Assert.Same(conn1, conn2);
    }
    [Fact]
    public void Connection_ShouldhasAccesToConnection(){
        //Verifica acceso a la propiedad Connection
        var conn = DatabaseConnection.Instance.Connection;
        Assert.NotNull(conn);
    }
    [Fact]
    public void Connection_ShouldBeConnectionOpen()
    { // Simula abrir la conexión y verifica que el estado cambia.
        var conn = DatabaseConnection.Instance.Connection;
        conn.Open();
        Assert.True(conn.IsOpen);
    }
    [Fact]
    public void Connection_ShouldBeConnectionClose()
    { // Simula cerrar la conexión y verifica que el estado cambia.
        var conn = DatabaseConnection.Instance.Connection;
        conn.Open();
        conn.Close();
        Assert.False(conn.IsOpen);
    }

    [Fact]
    public void Connection_ShouldBeSameInstanceAndConnection()
    {//Asegura que abrir y cerrar varias veces funciona correctamente sin cambiar la instancia.
        var db1 = DatabaseConnection.Instance;
        var db2 = DatabaseConnection.Instance;
        //Valida que es la misma instancia
        Assert.Same(db1, db2);

        var conn1 = db1.Connection;
        var conn2 = db2.Connection;
        // Valida que es la misma conexion
        Assert.Same(conn1, conn2);

        conn1.Open();
        Assert.True(conn2.IsOpen);// Debe estar abierta, porque es la misma instancia.

        conn2.Close();
        Assert.False(conn1.IsOpen);// Debe estar cerrada.

    }

}