using Microsoft.EntityFrameworkCore;
using SEOTracker.Application.Interfaces;
using SEOTracker.Core.Entities;
using SEOTracker.Infrastructure.Data.Configurations;

namespace SEOTracker.Infrastructure.Data
{
    public class SEOTrackerDbContext : DbContext, ISEOTrackerDbContext
    {
        public DbSet<RankRecord> RankRecords { get; set; }
        public DbSet<RankPosition> RankPositions { get; set; }

        public SEOTrackerDbContext(DbContextOptions<SEOTrackerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RankRecordConfiguration());
            modelBuilder.ApplyConfiguration(new RankPositionConfiguration());
        }
    }
}
