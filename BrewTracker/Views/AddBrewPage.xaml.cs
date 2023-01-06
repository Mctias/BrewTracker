namespace BrewTracker.Views;

public partial class AddBrewPage : ContentPage
{
	public AddBrewPage(AddBrewViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}