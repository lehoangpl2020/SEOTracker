using MediatR;
using SEOTracker.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Application.Trackers.Commands
{
    public class SearchCommandHandler : IRequestHandler<SearchCommand, string>
    {
        private readonly ISEOTrackerDbContext _trackerDbContext;

        //private readonly Func<SearchEngineType, ISearchEngineScraper> _searchEngineScraper;

        public SearchCommandHandler(ISEOTrackerDbContext trackerDatabaseContext)
        {
            _trackerDbContext = trackerDatabaseContext;
        }

        public async Task<string> Handle(SearchCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(5000);
            return await Task.FromResult("1,3,5");

        }
    }


}
