namespace SEOTracker.Application.Interfaces
{
    public interface ISearchEngineScraper
    {
        List<int> FindPositions(string keyWords, string url);
    }
}
