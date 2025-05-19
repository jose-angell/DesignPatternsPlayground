using DesignPatterns.Behavioral.Observer;
using Xunit;

public class NewsAgencyTests
{
    private class TestSubscriber : INewsSubscriber
    {
        public News? ReceivedNews { get; private set; }

        public void Update(News news)
        {
            ReceivedNews = news;
        }
    }

    [Fact]
    public void NewsAgency_ShouldNotifySubscriber_WhenNewsIsSet()
    {
        // Arrange
        var agency = new NewsAgency();
        var testSubscriber = new TestSubscriber();
        agency.Attach(testSubscriber);

        var news = new News
        {
            Title = "Breaking News",
            Content = "Test content",
            Category = "General"
        };

        // Act
        agency.SetNews(news);

        // Assert
        Assert.NotNull(testSubscriber.ReceivedNews);
        Assert.Equal("Breaking News", testSubscriber.ReceivedNews!.Title);
        Assert.Equal("Test content", testSubscriber.ReceivedNews.Content);
        Assert.Equal("General", testSubscriber.ReceivedNews.Category);
    }
}
