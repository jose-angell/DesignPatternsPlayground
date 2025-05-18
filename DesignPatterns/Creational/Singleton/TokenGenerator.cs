

namespace DesignPatterns.Creational.Singleton;

public class TokenGenerator
{
    //Esta es una instanciacion temprana de esta clase, es valido y seguro para multiples hilos, pero a diferencia de la otra forma
    //aqui siempre se genera aunque nunca se llame a la instancia
    private static readonly TokenGenerator _instance = new();
    private static readonly object _lock = new();
    private int _counter = 0;

    private TokenGenerator() { }

    public static TokenGenerator Instance => _instance;

    public string GenerateToken()
    {
        lock (_lock)
        {
            return $"TOKEN-{DateTime.UtcNow.Ticks}-{_counter++}";
        }
    }
}
