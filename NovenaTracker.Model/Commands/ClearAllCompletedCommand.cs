using SimpleCqrs;

namespace NovenaTracker.Model.Commands;

public class ClearAllCompletedCommand : ICommand<bool>
{
    public int NovenaId { get; set; }
}
