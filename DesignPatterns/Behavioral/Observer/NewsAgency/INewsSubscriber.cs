namespace DesignPatterns.Behavioral.Observer;
//interfaz que define el observador, todos los obsevadores deben implementar esta interfaz
public interface INewsSubscriber
{
    void Update(News news);
}