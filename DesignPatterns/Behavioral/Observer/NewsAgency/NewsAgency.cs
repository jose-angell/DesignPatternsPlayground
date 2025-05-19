namespace DesignPatterns.Behavioral.Observer;
// Implemetacion de el subjeto que sera observado por los subscritores
// Aqui se implementan todos los metodos definidosen la interfaz
// tambien se controla la lista de Observadores (Subscritores) que esperan la notificacion
public class NewsAgency : INewsAgency
{
    private readonly List<INewsSubscriber> _newsSubscribers = new(); // lista de observadordes registrados
    private News _news = new();

    public void SetNews(News news)
    {
        Console.WriteLine($"[{news.Category}] Title: {news.Title}, {news.Content}");
        _news = news;
        Notify();
    }
    public void Attach(INewsSubscriber newsSubscriber) => _newsSubscribers.Add(newsSubscriber);
    public void Detach(INewsSubscriber newsSubscriber) => _newsSubscribers.Remove(newsSubscriber);
    public void Notify()
    {//Notifica a todos los observadores registrados
        foreach (var subscriber in _newsSubscribers)
        {
            subscriber.Update(_news);
        }
    }
}