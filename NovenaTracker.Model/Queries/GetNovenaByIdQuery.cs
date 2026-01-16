using SimpleCqrs;

namespace NovenaTracker.Model.Queries;

/// <summary>
/// Query to get a novena by ID
/// </summary>
public class GetNovenaByIdQuery : IQuery<NovenaDto?>
{
    public int Id { get; set; }
}

/// <summary>
/// Data transfer object for Novena
/// </summary>
public class NovenaDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DaysDuration { get; set; }
    public DateTime CreatedDate { get; set; }
}
