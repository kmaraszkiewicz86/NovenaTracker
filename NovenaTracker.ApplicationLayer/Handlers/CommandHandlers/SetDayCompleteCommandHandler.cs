using NovenaTracker.Domain.Interfaces;
using NovenaTracker.Model.Commands;
using SimpleCqrs;

namespace NovenaTracker.ApplicationLayer.Handlers.CommandHandlers;

/// <summary>
/// Handler for SetDayCompleteCommand
/// </summary>
public class SetDayCompleteCommandHandler : IAsyncCommandHandler<SetDayCompleteCommand, bool>
{
    private readonly INovennaRepository _novennaRepository;

    public SetDayCompleteCommandHandler(INovennaRepository novennaRepository)
    {
        _novennaRepository = novennaRepository;
    }

    public async Task<bool> HandleAsync(SetDayCompleteCommand command, CancellationToken cancellationToken)
    {
        await _novennaRepository.SetDayCompleteAsync(
            command.NovenaId,
            command.NovenaDayPrayerId,
            command.IsCompleted,
            cancellationToken);
        
        return true;
    }
}
