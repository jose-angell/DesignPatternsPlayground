namespace DesignPatterns.Behavioral.Observer;
// La interfaz que deben implementar todos los observadores (subscriptores).
public interface IObserver
{
    void Update(string weather);
}