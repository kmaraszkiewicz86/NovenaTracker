using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovenaTracker.Domain.Entities;

namespace NovenaTracker.Infrastructure.DbConfiguration;

/// <summary>
/// Entity configuration for NovenaDayPrayer entity
/// </summary>
public class NovenaDayPrayerConfiguration : IEntityTypeConfiguration<NovenaDayPrayer>
{
    public void Configure(EntityTypeBuilder<NovenaDayPrayer> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.NovenaId)
            .IsRequired();
            
        builder.Property(e => e.DayNumber)
            .IsRequired();
            
        builder.Property(e => e.PrayerText)
            .IsRequired()
            .HasColumnType("TEXT");
            
        builder.Property(e => e.PrayerTitle)
            .HasMaxLength(200);
        
        // Create index for efficient querying
        builder.HasIndex(e => new { e.NovenaId, e.DayNumber });
        
        // Seed sample prayers for the novena (first 3 days as example)
        builder.HasData(
            new NovenaDayPrayer
            {
                Id = 1,
                NovenaId = 1,
                DayNumber = 1,
                PrayerTitle = "Day 1 - Trust in Mary",
                PrayerText = "O Mother of Perpetual Help, grant that I may ever invoke your powerful name..."
            },
            new NovenaDayPrayer
            {
                Id = 2,
                NovenaId = 1,
                DayNumber = 2,
                PrayerTitle = "Day 2 - Hope in Mary",
                PrayerText = "O Mary, you are the hope of Christians, hear the prayer of a sinner who loves you tenderly..."
            },
            new NovenaDayPrayer
            {
                Id = 3,
                NovenaId = 1,
                DayNumber = 3,
                PrayerTitle = "Day 3 - Love for Mary",
                PrayerText = "O Mother of Perpetual Help, I come to you with confidence and love..."
            }
        );
    }
}
