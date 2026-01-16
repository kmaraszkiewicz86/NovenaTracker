using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovenaTracker.Domain.Entities;

namespace NovenaTracker.Infrastructure.DbConfiguration;

/// <summary>
/// Entity configuration for Novena entity
/// </summary>
public class NovenaConfiguration : IEntityTypeConfiguration<Novena>
{
    public void Configure(EntityTypeBuilder<Novena> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(2000);
            
        builder.Property(e => e.DaysDuration)
            .IsRequired();
        
        // Configure relationships
        builder.HasMany(e => e.DayPrayers)
            .WithOne(e => e.Novena)
            .HasForeignKey(e => e.NovenaId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasMany(e => e.Completions)
            .WithOne(e => e.Novena)
            .HasForeignKey(e => e.NovenaId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Seed initial data
        builder.HasData(
            new Novena
            {
                Id = 1,
                Title = "Novena to Our Lady of Perpetual Help",
                Description = "A nine-day prayer to Our Lady of Perpetual Help",
                DaysDuration = 9
            }
        );
    }
}
