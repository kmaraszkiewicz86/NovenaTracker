using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Model.Models;
using NovenaTracker.Model.Queries;
using SimpleCqrs;

namespace NovenaTracker.ApplicationLayer.Handlers.QueryHandlers;

/// <summary>
/// Handler for GetNovenaByIdQuery
/// </summary>
public class GetNovenaByIdQueryHandler(INovenaDbQuery _novenaDbQuery) : IAsyncQueryHandler<GetNovenaByIdQuery, NovenaDto?>
{
    public async Task<NovenaDto?> HandleAsync(GetNovenaByIdQuery query, CancellationToken cancellationToken) 
        => await _novenaDbQuery.GetNovenaByIdAsync(query.Id, cancellationToken);
}
