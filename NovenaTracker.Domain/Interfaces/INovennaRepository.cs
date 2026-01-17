using NovenaTracker.Domain.Entities;

namespace NovenaTracker.Domain.Interfaces;

/// <summary>
/// Repository interface for managing Novena completion data
/// </summary>
public interface INovennaRepository
{
    /// <summary>
    /// Sets the completion status for a specific day of a novena
    /// </summary>
    Task SetDayCompleteAsync(int novenaId, int novenaDayPrayerId, bool isCompleted, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets the completion status for a specific day prayer
    /// </summary>
    Task<NovenaCompletion?> GetCompletionAsync(int novenaDayPrayerId, CancellationToken cancellationToken = default);
}
