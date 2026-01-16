using Microsoft.EntityFrameworkCore;
using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Infrastructure.Data;

namespace NovenaTracker.Infrastructure.Queries;

/// <summary>
/// Implementation of IDbQuery for querying data from the database
/// </summary>
public class DbQuery : IDbQuery
{
    private readonly NovenaTrackerDbContext _context;

    public DbQuery(NovenaTrackerDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a queryable collection of entities with no tracking
    /// </summary>
    public IQueryable<T> Query<T>() where T : class
    {
        return _context.Set<T>().AsNoTracking();
    }
}
