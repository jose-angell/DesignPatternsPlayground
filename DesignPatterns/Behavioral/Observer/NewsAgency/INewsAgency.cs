namespace DesignPatterns.Behavioral.Observer;
// Interfaz que define el comportamiento de un sujeto observable (agencia de noticias).
// Todas las clases que puedan ser observadas deben implementar esta interfaz.
public interface INewsAgency
{
    void Attach(INewsSubscriber newsSubscriber);// Para registrar un nuevo observador
    void Detach(INewsSubscriber newsSubscriber);// para remover un observador
    void Notify();// para avisar a todos los observadores registrados de un nuevo evento ocambios
}