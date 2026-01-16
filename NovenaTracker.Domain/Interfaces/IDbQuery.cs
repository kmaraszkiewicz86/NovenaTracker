namespace NovenaTracker.Domain.Interfaces;

/// <summary>
/// Interface for querying data from the database
/// </summary>
public interface IDbQuery
{
    /// <summary>
    /// Gets a queryable collection of entities
    /// </summary>
    IQueryable<T> Query<T>() where T : class;
}
