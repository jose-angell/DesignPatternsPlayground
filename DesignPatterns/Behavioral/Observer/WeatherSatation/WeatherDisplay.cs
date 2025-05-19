namespace DesignPatterns.Behavioral.Observer;
// Observador concreto. Representa una pantalla de teléfono que muestra el clima.
public class WeatherDisplay : IObserver
{
    private readonly string _displayName;
    public WeatherDisplay(string displayName)
    {
        _displayName = displayName;
    }
    public void Update(string weather)
    {
        Console.WriteLine($"{_displayName} Display: Weather updated to {weather}");
    }
}