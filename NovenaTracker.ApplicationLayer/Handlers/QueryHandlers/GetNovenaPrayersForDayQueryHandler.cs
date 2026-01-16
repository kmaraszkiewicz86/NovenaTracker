using SimpleCqrs;
using NovenaTracker.Infrastructure.Queries;
using NovenaTracker.Model.Queries;

namespace NovenaTracker.ApplicationLayer.Handlers.QueryHandlers;

/// <summary>
/// Handler for GetNovenaPrayersForDayQuery
/// </summary>
public class GetNovenaPrayersForDayQueryHandler : IAsyncQueryHandler<GetNovenaPrayersForDayQuery, NovenaDayPrayerDto?>
{
    private readonly NovenaDbQuery _novenaDbQuery;

    public GetNovenaPrayersForDayQueryHandler(NovenaDbQuery novenaDbQuery)
    {
        _novenaDbQuery = novenaDbQuery;
    }

    public async Task<NovenaDayPrayerDto?> HandleAsync(GetNovenaPrayersForDayQuery query, CancellationToken cancellationToken)
    {
        return await _novenaDbQuery.GetNovenaPrayersForDayAsync(query.NovenaId, query.DayNumber, cancellationToken);
    }
}
