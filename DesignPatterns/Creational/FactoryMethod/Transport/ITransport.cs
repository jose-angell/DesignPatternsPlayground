

namespace  DesignPatterns.Creational.FactoryMethod;
// Define una interfaz común que todos los tipos de transporte deben implementar. Gracias a esta interfaz, 
// el cliente (Logistics) puede usar cualquier transporte sin conocer su tipo concreto (camión o barco).
public interface ITransport {
    void Deliver();
}