using CommunityToolkit.Mvvm.ComponentModel;
using NovenaTracker.Model.Models;
using NovenaTracker.Model.Queries;
using SimpleCqrs;
using System.Collections.ObjectModel;

namespace NovenaTracker.Presentation.ViewModels;

/// <summary>
/// ViewModel for displaying a single Novena with its day prayers using MAUI MVVM.
/// </summary>
public partial class NovennaListPageViewModel(ISimpleMediator simpleMediator) : ObservableObject
{
    public NovenaDto? Novena
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public ObservableCollection<NovenaDayPrayerDto> DayPrayers { get; } = [];

    /// <summary>
    /// Loads one Novena and its DayPrayers using SimpleMediator.
    /// Call this from the page lifecycle (e.g. OnAppearing).
    /// </summary>
    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        var novenas = await simpleMediator
            .GetQueryAsync(new GetAllNovenasQuery(), cancellationToken)
            .ConfigureAwait(false);

        Novena = novenas.FirstOrDefault();

        DayPrayers.Clear();
        if (Novena?.DayPrayers is { Count: > 0 } prayers)
        {
            foreach (var prayer in prayers)
            {
                DayPrayers.Add(prayer);
            }
        }
    }
}
