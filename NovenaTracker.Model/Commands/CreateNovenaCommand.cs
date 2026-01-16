using SimpleCqrs;

namespace NovenaTracker.Model.Commands;

/// <summary>
/// Command to create a new novena
/// </summary>
public class CreateNovenaCommand : ICommand<int>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DaysDuration { get; set; }
}
