using NovenaTracker.Presentation.ViewModels;

namespace NovenaTracker.Presentation.Views;

public partial class NovennaListPage : ContentPage
{
	public NovennaListPage(NovennaListPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}