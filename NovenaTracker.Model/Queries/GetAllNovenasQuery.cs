using SimpleCqrs;

namespace NovenaTracker.Model.Queries;

/// <summary>
/// Query to get all novenas
/// </summary>
public class GetAllNovenasQuery : IQuery<List<NovenaDto>>
{
}
