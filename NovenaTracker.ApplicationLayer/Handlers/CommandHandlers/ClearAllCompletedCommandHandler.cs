using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Model.Commands;
using SimpleCqrs;

namespace NovenaTracker.ApplicationLayer.Handlers.CommandHandlers;

public class ClearAllCompletedCommandHandler(INovennaRepository _novennaRepository) : IAsyncCommandHandler<ClearAllCompletedCommand, bool>
{
    public async Task<bool> HandleAsync(ClearAllCompletedCommand command, CancellationToken cancellationToken)
    {
        await _novennaRepository.ClearAllSelection(
            command.NovenaId,
            cancellationToken);

        return true;
    }
}
