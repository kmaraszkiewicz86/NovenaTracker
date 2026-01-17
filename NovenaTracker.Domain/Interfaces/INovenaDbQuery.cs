
using NovenaTracker.Model.Models;

namespace NovenaTracker.Domain.Interfaces;

public interface INovenaDbQuery
{
    Task<List<NovenaDto>> GetAllNovenasAsync(CancellationToken cancellationToken = default);
}
