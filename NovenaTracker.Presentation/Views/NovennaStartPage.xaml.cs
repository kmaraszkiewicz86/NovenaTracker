using NovenaTracker.Presentation.ViewModels;

namespace NovenaTracker.Presentation.Views;

public partial class NovennaStartPage : ContentPage
{
	private readonly NovennaStartPageViewModel _viewModel;

	public NovennaStartPage(NovennaStartPageViewModel novennaStartPageViewModel)
	{
		InitializeComponent();
		_viewModel = novennaStartPageViewModel;
		BindingContext = _viewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.InitializeAsync();
	}
}