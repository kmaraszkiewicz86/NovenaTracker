using SimpleCqrs;
using NovenaTracker.Infrastructure.Queries;
using NovenaTracker.Model.Queries;

namespace NovenaTracker.ApplicationLayer.Handlers.QueryHandlers;

/// <summary>
/// Handler for GetNovenaByIdQuery
/// </summary>
public class GetNovenaByIdQueryHandler : IAsyncQueryHandler<GetNovenaByIdQuery, NovenaDto?>
{
    private readonly NovenaDbQuery _novenaDbQuery;

    public GetNovenaByIdQueryHandler(NovenaDbQuery novenaDbQuery)
    {
        _novenaDbQuery = novenaDbQuery;
    }

    public async Task<NovenaDto?> HandleAsync(GetNovenaByIdQuery query, CancellationToken cancellationToken)
    {
        return await _novenaDbQuery.GetNovenaByIdAsync(query.Id, cancellationToken);
    }
}
