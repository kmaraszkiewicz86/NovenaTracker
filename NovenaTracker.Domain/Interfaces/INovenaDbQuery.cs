
using NovenaTracker.Model.Models;

namespace NovenaTracker.Domain.Interfaces;

public interface INovenaDbQuery
{    
    Task<List<NovenaDto>> GetNovenaTitlesAsync(CancellationToken cancellationToken = default);
    
    Task<NovenaDto?> GetNovenaByIdAsync(int id, CancellationToken cancellationToken = default);
}
