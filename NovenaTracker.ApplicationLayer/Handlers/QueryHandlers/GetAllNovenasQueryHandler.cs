using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Model.Models;
using NovenaTracker.Model.Queries;
using SimpleCqrs;

namespace NovenaTracker.ApplicationLayer.Handlers.QueryHandlers;

/// <summary>
/// Handler for GetAllNovenasQuery
/// </summary>
public class GetAllNovenasQueryHandler : IAsyncQueryHandler<GetAllNovenasQuery, List<NovenaDto>>
{
    private readonly INovenaDbQuery _novenaDbQuery;

    public GetAllNovenasQueryHandler(INovenaDbQuery novenaDbQuery)
    {
        _novenaDbQuery = novenaDbQuery;
    }

    public async Task<List<NovenaDto>> HandleAsync(GetAllNovenasQuery query, CancellationToken cancellationToken)
    {
        return await _novenaDbQuery.GetAllNovenasAsync(cancellationToken);
    }
}
