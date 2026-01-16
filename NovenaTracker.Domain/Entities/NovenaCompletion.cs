namespace NovenaTracker.Domain.Entities;

/// <summary>
/// Domain entity representing the completion status of a specific day of a novena
/// </summary>
public class NovenaCompletion
{
    public int Id { get; set; }
    public int NovenaId { get; set; }
    public int DayNumber { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedDate { get; set; }
    public DateTime CreatedDate { get; set; }
    
    // Navigation property
    public Novena Novena { get; set; } = null!;
}
