using Microsoft.EntityFrameworkCore;
using SEOTracker.Core.Entities;

namespace SEOTracker.Application.Interfaces
{
    public interface ISEOTrackerDbContext
    {
        public DbSet<RankRecord> RankRecords { get; set; }

        public DbSet<RankPosition> RankPositions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
