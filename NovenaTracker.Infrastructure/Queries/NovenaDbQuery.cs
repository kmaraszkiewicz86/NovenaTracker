using Microsoft.EntityFrameworkCore;
using NovenaTracker.Domain.Entities;
using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Model.Queries;

namespace NovenaTracker.Infrastructure.Queries;

/// <summary>
/// Query class for retrieving Novena data
/// </summary>
public class NovenaDbQuery
{
    private readonly IDbQuery _dbQuery;

    public NovenaDbQuery(IDbQuery dbQuery)
    {
        _dbQuery = dbQuery;
    }

    /// <summary>
    /// Gets a novena by ID
    /// </summary>
    public async Task<NovenaDto?> GetNovenaByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var novena = await _dbQuery.Query<Novena>()
            .Where(n => n.Id == id)
            .Select(n => new NovenaDto
            {
                Id = n.Id,
                Title = n.Title,
                Description = n.Description,
                DaysDuration = n.DaysDuration
            })
            .FirstOrDefaultAsync(cancellationToken);

        return novena;
    }

    /// <summary>
    /// Gets all novenas
    /// </summary>
    public async Task<List<NovenaDto>> GetAllNovenasAsync(CancellationToken cancellationToken = default)
    {
        var novenas = await _dbQuery.Query<Novena>()
            .Select(n => new NovenaDto
            {
                Id = n.Id,
                Title = n.Title,
                Description = n.Description,
                DaysDuration = n.DaysDuration
            })
            .ToListAsync(cancellationToken);

        return novenas;
    }

    /// <summary>
    /// Gets novena prayers for a specific day
    /// </summary>
    public async Task<NovenaDayPrayerDto?> GetNovenaPrayersForDayAsync(int novenaId, int dayNumber, CancellationToken cancellationToken = default)
    {
        var prayer = await _dbQuery.Query<NovenaDayPrayer>()
            .Where(p => p.NovenaId == novenaId && p.DayNumber == dayNumber)
            .Select(p => new NovenaDayPrayerDto
            {
                Id = p.Id,
                NovenaId = p.NovenaId,
                DayNumber = p.DayNumber,
                PrayerText = p.PrayerText,
                PrayerTitle = p.PrayerTitle
            })
            .FirstOrDefaultAsync(cancellationToken);

        return prayer;
    }
}
