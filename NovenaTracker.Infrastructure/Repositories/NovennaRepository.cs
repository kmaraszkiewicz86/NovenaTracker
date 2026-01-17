using Microsoft.EntityFrameworkCore;
using NovenaTracker.Domain.Entities;
using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Infrastructure.Data;

namespace NovenaTracker.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing Novena completion data
/// </summary>
public class NovennaRepository : INovennaRepository
{
    private readonly NovenaTrackerDbContext _context;

    public NovennaRepository(NovenaTrackerDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Sets the completion status for a specific day of a novena
    /// </summary>
    public async Task SetDayCompleteAsync(int novenaId, int novenaDayPrayerId, bool isCompleted, CancellationToken cancellationToken = default)
    {
        var completion = await _context.NovenaCompletions
            .FirstOrDefaultAsync(c => c.NovenaDayPrayerId == novenaDayPrayerId, cancellationToken);

        if (completion != null)
        {
            // Update existing completion status
            completion.IsCompleted = isCompleted;
            
            if (!isCompleted)
            {
                // Remove completion if unchecking
                _context.NovenaCompletions.Remove(completion);
            }
        }
        else if (isCompleted)
        {
            // Create new completion
            completion = new NovenaCompletion
            {
                NovenaId = novenaId,
                NovenaDayPrayerId = novenaDayPrayerId,
                IsCompleted = true
            };
            _context.NovenaCompletions.Add(completion);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Gets the completion status for a specific day prayer
    /// </summary>
    public async Task<NovenaCompletion?> GetCompletionAsync(int novenaDayPrayerId, CancellationToken cancellationToken = default)
    {
        return await _context.NovenaCompletions
            .FirstOrDefaultAsync(c => c.NovenaDayPrayerId == novenaDayPrayerId, cancellationToken);
    }
}
