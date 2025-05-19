namespace DesignPatterns.Behavioral.Observer;
// Interfaz del sujeto observado. Define cómo los observadores pueden suscribirse/desuscribirse.
public interface IWeatherStation
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}