using SimpleCqrs;

namespace NovenaTracker.Model.Queries;

/// <summary>
/// Query to get novena prayers for a specific day
/// </summary>
public class GetNovenaPrayersForDayQuery : IQuery<NovenaDayPrayerDto?>
{
    public int NovenaId { get; set; }
    public int DayNumber { get; set; }
}

/// <summary>
/// Data transfer object for Novena Day Prayer
/// </summary>
public class NovenaDayPrayerDto
{
    public int Id { get; set; }
    public int NovenaId { get; set; }
    public int DayNumber { get; set; }
    public string PrayerText { get; set; } = string.Empty;
    public string? PrayerTitle { get; set; }
}
