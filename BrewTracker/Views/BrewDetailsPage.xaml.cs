namespace BrewTracker.Views;

public partial class BrewDetailsPage : ContentPage
{
	public BrewDetailsPage(BrewDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}