using Microsoft.EntityFrameworkCore;
using NovenaTracker.Domain.Entities;
using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Infrastructure.Data;
using NovenaTracker.Model.Models;

namespace NovenaTracker.Infrastructure.Queries;

/// <summary>
/// Query class for retrieving Novena data
/// </summary>
public class NovenaDbQuery : INovenaDbQuery
{
    private readonly NovenaTrackerDbContext _context;

    public NovenaDbQuery(NovenaTrackerDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets novena titles only (for list display)
    /// </summary>
    public async Task<List<NovenaDto>> GetNovenaTitlesAsync(CancellationToken cancellationToken = default)
        => await _context.Novenas
            .Select(n => new NovenaDto
            {
                Id = n.Id,
                Title = n.Title
            })
            .ToListAsync(cancellationToken);

    /// <summary>
    /// Gets a single novena by ID with full details
    /// </summary>
    public async Task<NovenaDto?> GetNovenaByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Novena? novenna = await _context.Novenas
            .Include(n => n.DayPrayers)
            .Include(n => n.Completions)
            .Where(n => n.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (novenna == null) return null;

        return new NovenaDto
        {
            Id = novenna.Id,
            Title = novenna.Title,
            Description = novenna.Description,
            DaysDuration = novenna.DaysDuration,
            DayPrayers = [.. novenna.DayPrayers.Where(p => !p.Completions.Any()).Select(p => new NovenaDayPrayerDto
            {
                Id = p.Id,
                NovenaId = p.NovenaId,
                DayNumber = p.DayNumber,
                PrayerText = p.PrayerText,
                PrayerTitle = p.PrayerTitle,
                IsCompleted = novenna.Completions.Any(c => c.NovenaDayPrayerId == p.Id)
            })]
        };
    }
}
