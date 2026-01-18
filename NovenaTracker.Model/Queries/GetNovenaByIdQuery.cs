using NovenaTracker.Model.Models;
using SimpleCqrs;

namespace NovenaTracker.Model.Queries;

/// <summary>
/// Query to get a single novena by ID
/// </summary>
public class GetNovenaByIdQuery : IQuery<NovenaDto?>
{
    public int Id { get; set; }
}
