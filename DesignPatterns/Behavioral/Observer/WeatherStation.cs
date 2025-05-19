namespace DesignPatterns.Behavioral.Observer;
// Implementación concreta del sujeto. Notifica a los observadores cuando el clima cambia.
public class WeatherStation : IWeatherStation
{
    private readonly List<IObserver> _observers = new(); // Lista de observadores registrados
    private string _weather = "Sunny";// Estado interno que se observa

    public void SetWeather(string weather)
    {
        Console.WriteLine($"[WeatherStation] New weather: {weather}");
        _weather = weather;
        NotifyObservers();
    }
    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
    // Notifica a todos los observadores con el nuevo estado del clima.
    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_weather);
        }
    }
}