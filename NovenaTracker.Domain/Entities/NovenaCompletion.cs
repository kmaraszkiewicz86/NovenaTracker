namespace NovenaTracker.Domain.Entities;

/// <summary>
/// Domain entity representing the completion status of a specific day of a novena
/// </summary>
public class NovenaCompletion
{
    public int Id { get; set; }
    public int NovenaId { get; set; }
    public int NovenaDayPrayerId { get; set; }
    public bool IsCompleted { get; set; }
    
    // Navigation properties
    public Novena Novena { get; set; } = null!;
    public NovenaDayPrayer NovenaDayPrayer { get; set; } = null!;
}
