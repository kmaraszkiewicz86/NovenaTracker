namespace NovenaTracker.Model.Models;

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

    public bool IsCompleted { get; set; }
    public bool IsFirstPrayer { get; set; }
}
