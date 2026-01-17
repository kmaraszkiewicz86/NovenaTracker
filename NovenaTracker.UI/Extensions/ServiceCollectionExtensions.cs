using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovenaTracker.ApplicationLayer.Handlers.QueryHandlers;
using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Infrastructure.Data;
using NovenaTracker.Infrastructure.Queries;
using NovenaTracker.Presentation.ViewModels;
using SimpleCqrs;

namespace NovenaTracker.Configuration.Extensions;

/// <summary>
/// Extension methods for configuring NovenaTracker services
/// </summary>
public static class ServiceCollectionExtensions
{    
    /// <summary>
    /// Configures NovenaTracker view models
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection ConfigureNovenaTrackerViewModels(
        this IServiceCollection services)
    {
        services.AddTransient<NovennaListPageViewModel>();
        
        return services;
    }
}
