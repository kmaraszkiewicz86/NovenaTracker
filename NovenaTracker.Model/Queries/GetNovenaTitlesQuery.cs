using NovenaTracker.Model.Models;
using SimpleCqrs;

namespace NovenaTracker.Model.Queries;

/// <summary>
/// Query to get novena titles for list display
/// </summary>
public class GetNovenaTitlesQuery : IQuery<List<NovenaDto>>
{
}
