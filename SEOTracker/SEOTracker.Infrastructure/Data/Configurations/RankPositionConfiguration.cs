using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEOTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Infrastructure.Data.Configurations
{
    public class RankPositionConfiguration : IEntityTypeConfiguration<RankPosition>
    {
        public void Configure(EntityTypeBuilder<RankPosition> builder)
        {
            builder.ToTable("RankPositions");
            builder.HasKey(e => e.RankPositionId);
            builder.Property(e => e.Position).IsRequired();
        }
    }
}
