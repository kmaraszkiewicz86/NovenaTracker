namespace NovenaTracker.Model.Models;

/// <summary>
/// Data transfer object for Novena
/// </summary>
public class NovenaDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DaysDuration { get; set; }

    public List<NovenaDayPrayerDto> DayPrayers { get; set; } = [];
}