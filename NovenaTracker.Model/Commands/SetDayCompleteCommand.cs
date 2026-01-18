using SimpleCqrs;

namespace NovenaTracker.Model.Commands;

/// <summary>
/// Command to mark a specific day of a novena as completed
/// </summary>
public class SetDayCompleteCommand : ICommand<bool>
{
    public int NovenaId { get; set; }
    public int NovenaDayPrayerId { get; set; }
    public bool IsCompleted { get; set; }
}
