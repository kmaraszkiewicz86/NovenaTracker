using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Infrastructure.Data;
using NovenaTracker.Infrastructure.Queries;
using SimpleCqrs;

namespace NovenaTracker.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring NovenaTracker services
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures NovenaTracker services including EF Core and SimpleCqrs
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="handlersAssembly">Assembly containing CQRS handlers</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection ConfigureNovenaTracker(
        this IServiceCollection services, 
        System.Reflection.Assembly handlersAssembly)
    {
        // Register DbContext (requires connection string configuration from app)
        // Example: services.AddDbContext<NovenaTrackerDbContext>(options => 
        //     options.UseSqlite(connectionString));
        
        // Register DbQuery
        services.AddScoped<IDbQuery, DbQuery>();
        
        // Register NovenaDbQuery
        services.AddScoped<NovenaDbQuery>();
        
        // Configure SimpleCqrs
        services.ConfigureSimpleCqrs(handlersAssembly);
        
        return services;
    }
    
    /// <summary>
    /// Configures NovenaTracker services with SQLite database
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="connectionString">SQLite connection string</param>
    /// <param name="handlersAssembly">Assembly containing CQRS handlers</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection ConfigureNovenaTrackerWithSqlite(
        this IServiceCollection services,
        string connectionString,
        System.Reflection.Assembly handlersAssembly)
    {
        // Register DbContext with SQLite
        services.AddDbContext<NovenaTrackerDbContext>(options =>
            options.UseSqlite(connectionString));
        
        // Register DbQuery
        services.AddScoped<IDbQuery, DbQuery>();
        
        // Register NovenaDbQuery
        services.AddScoped<NovenaDbQuery>();
        
        // Configure SimpleCqrs
        services.ConfigureSimpleCqrs(handlersAssembly);
        
        return services;
    }
}
