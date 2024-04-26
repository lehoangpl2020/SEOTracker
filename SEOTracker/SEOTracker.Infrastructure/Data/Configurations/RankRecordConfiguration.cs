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
    public class RankRecordConfiguration : IEntityTypeConfiguration<RankRecord>
    {
        public void Configure(EntityTypeBuilder<RankRecord> builder)
        {
            builder.ToTable("RankRecords");
            builder.HasKey(e => e.RankRecordId);
            builder.Property(e => e.SearchEngine).IsRequired();
            builder.Property(e => e.Keywords).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Url).IsRequired().HasMaxLength(255);
            builder.Property(e => e.CheckedDate).IsRequired();

            builder.HasMany(e => e.Positions)
                .WithOne(e => e.RankRecord)
                .HasForeignKey(p => p.RankRecordId);
        }
    }
}
