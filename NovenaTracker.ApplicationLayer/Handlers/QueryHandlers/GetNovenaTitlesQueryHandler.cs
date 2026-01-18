using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Model.Models;
using NovenaTracker.Model.Queries;
using SimpleCqrs;

namespace NovenaTracker.ApplicationLayer.Handlers.QueryHandlers;

/// <summary>
/// Handler for GetNovenaTitlesQuery
/// </summary>
public class GetNovenaTitlesQueryHandler(INovenaDbQuery _novenaDbQuery) : IAsyncQueryHandler<GetNovenaTitlesQuery, List<NovenaDto>>
{
    public async Task<List<NovenaDto>> HandleAsync(GetNovenaTitlesQuery query, CancellationToken cancellationToken)
        => await _novenaDbQuery.GetNovenaTitlesAsync(cancellationToken);
}
