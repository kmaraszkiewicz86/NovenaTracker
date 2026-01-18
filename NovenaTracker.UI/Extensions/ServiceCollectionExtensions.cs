using Microsoft.EntityFrameworkCore;
using NovenaTracker.Presentation.ViewModels;
using NovenaTracker.Presentation.Views;

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
        // Register ViewModels
        services.AddTransient<NovennaListPageViewModel>();
        services.AddTransient<NovennaStartPageViewModel>();

        // Register Pages
        services.AddTransient<NovennaListPage>();
        services.AddTransient<NovennaStartPage>();

        return services;
    }
}
