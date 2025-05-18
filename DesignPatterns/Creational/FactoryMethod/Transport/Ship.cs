
namespace DesignPatterns.Creational.FactoryMethod;


public class Ship: ITransport
{
    public void Deliver() {
         Console.WriteLine("Delivering by ship.");
    }
}