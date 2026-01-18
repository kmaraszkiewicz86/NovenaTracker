using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NovenaTracker.Model.Models;
using NovenaTracker.Model.Queries;
using SimpleCqrs;
using System.Collections.ObjectModel;

namespace NovenaTracker.Presentation.ViewModels;

public partial class NovennaStartPageViewModel(ISimpleMediator simpleMediator) : ObservableObject
{
    public ObservableCollection<NovenaDto> NovenaItems { get; } = [];

    /// <summary>
    /// Loads novena titles for display in the list
    /// </summary>
    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        var novenas = await simpleMediator
            .GetQueryAsync(new GetNovenaTitlesQuery(), cancellationToken)
            .ConfigureAwait(false);

        NovenaItems.Clear();
        foreach (var novena in novenas)
        {
            NovenaItems.Add(novena);
        }
    }

    /// <summary>
    /// Navigates to the novena detail page
    /// </summary>
    [RelayCommand]
    private async Task NavigateToNovenaAsync(NovenaDto novena)
    {
        await Shell.Current.GoToAsync($"NovennaListPage?novenaId={novena.Id}");
    }
}
