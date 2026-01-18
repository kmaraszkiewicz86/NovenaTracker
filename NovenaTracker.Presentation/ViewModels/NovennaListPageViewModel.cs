using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NovenaTracker.Model.Commands;
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

    public int DaysRemaining
    {
        get => field;
        set => SetProperty(ref field, value);
    }

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

        UpdateDaysRemaining();
    }

    /// <summary>
    /// Toggles the completion status of a day prayer
    /// </summary>
    [RelayCommand]
    private async Task ToggleDayCompleteAsync(NovenaDayPrayerDto dayPrayer)
    {
        if (Novena == null) return;

        var newCompletionStatus = !dayPrayer.IsCompleted;
        
        var command = new SetDayCompleteCommand
        {
            NovenaId = Novena.Id,
            NovenaDayPrayerId = dayPrayer.Id,
            IsCompleted = newCompletionStatus
        };

        await simpleMediator.SendCommandAsync(command);
        
        // Update the local state for immediate UI feedback
        var prayerToUpdate = DayPrayers.FirstOrDefault(p => p.Id == dayPrayer.Id);
        if (prayerToUpdate != null)
        {
            prayerToUpdate.IsCompleted = newCompletionStatus;
            
            // Find the index and replace to trigger collection change notification
            var index = DayPrayers.IndexOf(prayerToUpdate);
            if (index >= 0)
            {
                DayPrayers.RemoveAt(index);
                DayPrayers.Insert(index, prayerToUpdate);
            }
        }
        
        UpdateDaysRemaining();
    }

    private void UpdateDaysRemaining()
    {
        if (Novena == null)
        {
            DaysRemaining = 0;
            return;
        }

        var completedDays = DayPrayers.Count(p => p.IsCompleted);
        DaysRemaining = Novena.DaysDuration - completedDays;
    }
}
