using Microsoft.EntityFrameworkCore;
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
    /// Gets all novenas with full details
    /// </summary>
    public async Task<List<NovenaDto>> GetAllNovenasAsync(CancellationToken cancellationToken = default)
        => await _context.Novenas
            .Include(n => n.DayPrayers)
            .Include(n => n.Completions)
            .Select(n => new NovenaDto
            {
                Id = n.Id,
                Title = n.Title,
                Description = n.Description,
                DaysDuration = n.DaysDuration,
                DayPrayers = n.DayPrayers.Select(p => new NovenaDayPrayerDto
                {
                    Id = p.Id,
                    NovenaId = p.NovenaId,
                    DayNumber = p.DayNumber,
                    PrayerText = p.PrayerText,
                    PrayerTitle = p.PrayerTitle,
                    IsCompleted = n.Completions.Any(c => c.NovenaDayPrayerId == p.Id)
                }).ToList()
            })
            .ToListAsync(cancellationToken);

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
        => await _context.Novenas
            .Include(n => n.DayPrayers)
            .Include(n => n.Completions)
            .Where(n => n.Id == id)
            .Select(n => new NovenaDto
            {
                Id = n.Id,
                Title = n.Title,
                Description = n.Description,
                DaysDuration = n.DaysDuration,
                DayPrayers = n.DayPrayers.Select(p => new NovenaDayPrayerDto
                {
                    Id = p.Id,
                    NovenaId = p.NovenaId,
                    DayNumber = p.DayNumber,
                    PrayerText = p.PrayerText,
                    PrayerTitle = p.PrayerTitle,
                    IsCompleted = n.Completions.Any(c => c.NovenaDayPrayerId == p.Id)
                }).ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);
}
