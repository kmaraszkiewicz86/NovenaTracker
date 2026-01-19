using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NovenaTracker.Model.Commands;
using NovenaTracker.Model.Models;
using NovenaTracker.Model.Queries;
using SimpleCqrs;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NovenaTracker.Presentation.ViewModels;

/// <summary>
/// ViewModel for displaying a single Novena with its day prayers using MAUI MVVM.
/// </summary>
[QueryProperty(nameof(NovenaId), "novenaId")]
public partial class NovennaListPageViewModel(ISimpleMediator simpleMediator) : ObservableObject
{
    public int NovenaId
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public NovenaDto? Novena
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public string FirstPrayer
    {
        get => field;
        set => SetProperty(ref field, value);
    } = string.Empty;

    public ObservableCollection<NovenaDayPrayerDto> DayPrayers { get; } = [];

    public int DaysRemaining
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public string ErrorMessage
    {
        get => field;
        set => SetProperty(ref field, value);
    } = string.Empty;

    public ICommand LoadCommand => new Command(async () => await LoadNovenaAsync());
    public ICommand ClearAllSelectionCommand => new Command(async () => await ClearAllSelection());

    private async Task ClearAllSelection()
    {
        await simpleMediator.SendCommandAsync(new ClearAllCompletedCommand { NovenaId = NovenaId });
        await LoadNovenaAsync();
    }

    /// <summary>
    /// Loads a specific Novena by ID using SimpleMediator.
    /// </summary>
    private async Task LoadNovenaAsync(CancellationToken cancellationToken = default)
    {
        var novena = await simpleMediator
            .GetQueryAsync(new GetNovenaByIdQuery { Id = NovenaId }, cancellationToken);

        Novena = novena;
        FirstPrayer = Novena?.DayPrayers.FirstOrDefault()?.PrayerText ?? string.Empty;

        DayPrayers.Clear();
        if (Novena?.DayPrayers is { Count: > 0 } prayers)
        {
            foreach (var prayer in prayers.Skip(1))
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
        ErrorMessage = string.Empty;

        if (dayPrayer == null)
        {
            ErrorMessage = "Dane modlitwy są niedostępne. Spróbuj ponownie.";
            return;
        }

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

        DaysRemaining = DayPrayers.Count;
    }
}
