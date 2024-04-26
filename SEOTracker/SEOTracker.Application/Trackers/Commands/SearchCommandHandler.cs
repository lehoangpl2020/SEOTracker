using MediatR;
using SEOTracker.Application.Interfaces;
using SEOTracker.Core.Entities;
using SEOTracker.Core.Enums;

namespace SEOTracker.Application.Trackers.Commands
{
    public class SearchCommandHandler : IRequestHandler<SearchCommand, string>
    {
        private readonly ISEOTrackerDbContext _trackerDbContext;

        private readonly Func<SearchEngineType, ISearchEngineScraper> _searchEngineScraper;

        public SearchCommandHandler(ISEOTrackerDbContext trackerDatabaseContext, Func<SearchEngineType, ISearchEngineScraper> searchEngineScraper)
        {
            _trackerDbContext = trackerDatabaseContext;
            _searchEngineScraper = searchEngineScraper;
        }

        public async Task<string> Handle(SearchCommand request, CancellationToken cancellationToken)
        {
            var scraper = _searchEngineScraper(request.SearchEngine);

            var positions = scraper.FindPositions(request.Keywords, request.Url);

            var rankRecord = new RankRecord
            {
                Keywords = request.Keywords,
                Url = request.Url,
                CheckedDate = DateTime.Now,
                SearchEngine = request.SearchEngine.ToString(),
                Positions = positions.Select(x=>new RankPosition { Position = x}).ToList()
            };

            _trackerDbContext.RankRecords.Add(rankRecord);
            await _trackerDbContext.SaveChangesAsync(cancellationToken);

            return string.Join(",", positions);
        }
    }


}
