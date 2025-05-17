

namespace DesignPatterns.Creational.FactoryMethod;
//Es la clase que define el Factory Method CreateTransport().
//No sabe qué transporte concreto se usará. Solo sabe que necesita uno y que puede usarlo mediante la interfaz ITransport.
//La lógica común (PlanDelivery) usa CreateTransport() para obtener el objeto adecuado sin acoplarse a su tipo concreto. 
public abstract class Logistics
{
    public abstract ITransport CreateTransport();
    public void PlanDelivery(){
        var transport =  CreateTransport();
        transport.Deliver();
    }
}