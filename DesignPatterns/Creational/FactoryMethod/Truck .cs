

namespace DesignPatterns.Creational.FactoryMethod;

// Implementan la interfaz ITransport y contienen la lógica específica para su tipo de entrega.
// Esto permite que el cliente no tenga que preocuparse por los detalles de cómo se entrega un paquete; 
// solo sabe que hay un método Deliver().

public class Truck : ITransport
{
    public void Deliver() {
          Console.WriteLine("Delivering by truck.");
    }
}