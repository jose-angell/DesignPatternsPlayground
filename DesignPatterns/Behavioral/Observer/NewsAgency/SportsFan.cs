
namespace DesignPatterns.Behavioral.Observer;

public class SportsFan : INewsSubscriber
{
    private readonly string _sportName;
    public SportsFan(string sportname)
    {
        _sportName = sportname;
    }
    public void Update(News news)
    {
        Console.WriteLine($"{_sportName} Fan received news: [{news.Category}] {news.Title} - {news.Content}");
    }
}