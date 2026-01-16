using Microsoft.EntityFrameworkCore;
using NovenaTracker.Domain.Entities;
using NovenaTracker.Infrastructure.DbConfiguration;

namespace NovenaTracker.Infrastructure.Data;

/// <summary>
/// Database context for NovenaTracker application
/// </summary>
public class NovenaTrackerDbContext : DbContext
{
    public NovenaTrackerDbContext(DbContextOptions<NovenaTrackerDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Novena> Novenas { get; set; } = null!;
    public DbSet<NovenaDayPrayer> NovenaDayPrayers { get; set; } = null!;
    public DbSet<NovenaCompletion> NovenaCompletions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all entity configurations from the DbConfiguration namespace
        modelBuilder.ApplyConfiguration(new NovenaConfiguration());
        modelBuilder.ApplyConfiguration(new NovenaDayPrayerConfiguration());
        modelBuilder.ApplyConfiguration(new NovenaCompletionConfiguration());
    }
}
