namespace NovenaTracker.Domain.Entities;

/// <summary>
/// Domain entity representing a Novena
/// </summary>
public class Novena
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DaysDuration { get; set; }
    public DateTime CreatedDate { get; set; }
    
    // Navigation properties
    public ICollection<NovenaDayPrayer> DayPrayers { get; set; } = new List<NovenaDayPrayer>();
    public ICollection<NovenaCompletion> Completions { get; set; } = new List<NovenaCompletion>();
}
