using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NovenaTracker.Infrastructure.Data;

/// <summary>
/// Factory for creating DbContext instances at design-time for migrations
/// </summary>
public class NovenaTrackerDbContextFactory : IDesignTimeDbContextFactory<NovenaTrackerDbContext>
{
    public NovenaTrackerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NovenaTrackerDbContext>();
        
        // Use SQLite for migrations
        optionsBuilder.UseSqlite("Data Source=novenatracker.db");

        return new NovenaTrackerDbContext(optionsBuilder.Options);
    }
}
