using SimpleCqrs;
using NovenaTracker.Infrastructure.Queries;
using NovenaTracker.Model.Queries;

namespace NovenaTracker.ApplicationLayer.Handlers.QueryHandlers;

/// <summary>
/// Handler for GetAllNovenasQuery
/// </summary>
public class GetAllNovenasQueryHandler : IAsyncQueryHandler<GetAllNovenasQuery, List<NovenaDto>>
{
    private readonly NovenaDbQuery _novenaDbQuery;

    public GetAllNovenasQueryHandler(NovenaDbQuery novenaDbQuery)
    {
        _novenaDbQuery = novenaDbQuery;
    }

    public async Task<List<NovenaDto>> HandleAsync(GetAllNovenasQuery query, CancellationToken cancellationToken)
    {
        return await _novenaDbQuery.GetAllNovenasAsync(cancellationToken);
    }
}
