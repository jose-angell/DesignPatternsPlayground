namespace DesignPatterns.Behavioral.Observer;

public class TechEnthusiast : INewsSubscriber
{
    private readonly string _techName;
    public TechEnthusiast(string techName)
    {
        _techName = techName;
    }
    public void Update(News news)
    {
        Console.WriteLine($"{_techName} Fan received news: [{news.Category}] {news.Title} - {news.Content}");
    }
}