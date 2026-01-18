using NovenaTracker.Presentation.ViewModels;

namespace NovenaTracker.Presentation.Views;

public partial class NovennaStartPage : ContentPage
{
	public NovennaStartPage(NovennaStartPageViewModel novennaStartPageViewModel)
	{
		InitializeComponent();
		BindingContext = novennaStartPageViewModel;
	}
}