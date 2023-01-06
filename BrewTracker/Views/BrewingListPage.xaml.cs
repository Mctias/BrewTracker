using BrewTracker.ViewModels;

namespace BrewTracker.Views;

public partial class BrewingListPage : ContentPage
{
	public BrewingListPage(BrewingListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		Console.WriteLine("Heej");
    }
}