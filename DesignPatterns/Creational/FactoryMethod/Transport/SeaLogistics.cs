

namespace DesignPatterns.Creational.FactoryMethod;
//Estas clases concretas deciden qué tipo de transporte instanciar.
//Sobrescriben el método CreateTransport de la clase base Logistics y devuelven el transporte específico requerido.
public class SeaLogistics : Logistics
{
    public override ITransport CreateTransport(){
        return new Ship();
    }
}