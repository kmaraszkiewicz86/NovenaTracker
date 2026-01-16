using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovenaTracker.Domain.Entities;

namespace NovenaTracker.Infrastructure.DbConfiguration;

/// <summary>
/// Entity configuration for NovenaCompletion entity
/// </summary>
public class NovenaCompletionConfiguration : IEntityTypeConfiguration<NovenaCompletion>
{
    public void Configure(EntityTypeBuilder<NovenaCompletion> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.NovenaId)
            .IsRequired();
            
        builder.Property(e => e.DayNumber)
            .IsRequired();
            
        builder.Property(e => e.IsCompleted)
            .IsRequired();
            
        builder.Property(e => e.CreatedDate)
            .IsRequired();
        
        // Create unique index to prevent duplicate completions for same day
        builder.HasIndex(e => new { e.NovenaId, e.DayNumber })
            .IsUnique();
    }
}
