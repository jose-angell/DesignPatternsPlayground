
namespace DesignPatterns.Creational.Singleton;

public sealed class DatabaseConnection
{
    private static DatabaseConnection? _instance; //Campo estático que guarda la única instancia.
    private static readonly object _lock = new(); //Objeto para sincronización en entornos multi-hilo.
    private readonly FakeConnection _connection; // El "recurso" compartido que queremos exponer.
    private DatabaseConnection() //Constructor privado, evita que se cree desde fuera.
    {
        _connection  = new FakeConnection();
    }
    public static DatabaseConnection Instance //Propiedad de acceso global. Devuelve siempre la misma instancia.
    {
        get  
        {
            lock(_lock) //Asegura que solo un hilo a la vez puede crear la instancia (thread-safe).
            {
                _instance ??= new DatabaseConnection(); //Si aún no se ha creado la instancia, la crea.
                return _instance;
            }
        }
    }
    public FakeConnection Connection => _connection; //Expone el recurso (la conexión simulada) de forma controlada.
}