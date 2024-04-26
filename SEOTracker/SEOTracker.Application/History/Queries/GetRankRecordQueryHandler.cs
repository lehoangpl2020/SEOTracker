using MediatR;
using Microsoft.EntityFrameworkCore;
using SEOTracker.Application.Interfaces;

namespace SEOTracker.Application.History.Queries
{
    public class GetRankRecordQueryHandler : IRequestHandler<GetRankRecordQuery, List<RankRecordDto>>
    {
        private readonly ISEOTrackerDbContext _trackerDbContext;
        public GetRankRecordQueryHandler(ISEOTrackerDbContext trackerDbContext)
        {
            _trackerDbContext = trackerDbContext;
        }

        public async Task<List<RankRecordDto>> Handle(GetRankRecordQuery request, CancellationToken cancellationToken)
        {
            var records = await _trackerDbContext
                .RankRecords
                .Include(x => x.Positions)
                .OrderByDescending(x => x.CheckedDate)
                .ToListAsync(cancellationToken);

            var dtos = records.Select(x => new RankRecordDto
            {
                CheckedDate = x.CheckedDate,
                Keywords = x.Keywords,
                SearchEngine = x.SearchEngine,
                Url = x.Url,
                Positions = x.Positions.Any() ? string.Join(",", x.Positions.Select(p => p.Position)) : ""
            }).ToList();
            return dtos;
        }
    }
}
