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
            
        builder.Property(e => e.NovenaDayPrayerId)
            .IsRequired();
            
        builder.Property(e => e.IsCompleted)
            .IsRequired();
        
        // Configure relationship to NovenaDayPrayer
        builder.HasOne(e => e.NovenaDayPrayer)
            .WithMany(p => p.Completions)
            .HasForeignKey(e => e.NovenaDayPrayerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Create unique index to prevent duplicate completions for same day prayer
        builder.HasIndex(e => e.NovenaDayPrayerId)
            .IsUnique();
    }
}
