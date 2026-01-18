using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovenaTracker.ApplicationLayer.Handlers.QueryHandlers;
using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Infrastructure.Data;
using NovenaTracker.Infrastructure.Queries;
using NovenaTracker.Infrastructure.Repositories;
using SimpleCqrs;

namespace NovenaTracker.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring NovenaTracker services
/// </summary>
public static class ServiceCollectionExtensions
{    
    /// <summary>
    /// Configures NovenaTracker services with SQLite database
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="connectionString">SQLite connection string</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection ConfigureNovenaTracke(
        this IServiceCollection services,
        string connectionString)
    {
        // Register DbContext with SQLite
        services.AddDbContext<NovenaTrackerDbContext>(options =>
            options.UseSqlite(connectionString));

        services.MigrateDatabase();

        // Register NovenaDbQuery
        services.AddScoped<INovenaDbQuery, NovenaDbQuery>();
        
        // Register NovennaRepository
        services.AddScoped<INovennaRepository, NovennaRepository>();
        
        // Configure SimpleCqrs with handlers from ApplicationLayer
        services.ConfigureSimpleCqrs(typeof(GetAllNovenasQueryHandler).Assembly);
        
        return services;
    }

    private static void MigrateDatabase(this IServiceCollection services)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<NovenaTrackerDbContext>();
        db.Database.Migrate();
    }
}
