namespace NovenaTracker.Domain.Entities;

/// <summary>
/// Domain entity representing a daily prayer for a specific day of a novena
/// </summary>
public class NovenaDayPrayer
{
    public int Id { get; set; }
    public int NovenaId { get; set; }
    public int DayNumber { get; set; }
    public string PrayerText { get; set; } = string.Empty;
    public string? PrayerTitle { get; set; }
    
    // Navigation properties
    public Novena Novena { get; set; } = null!;
    public ICollection<NovenaCompletion> Completions { get; set; } = new List<NovenaCompletion>();
}
