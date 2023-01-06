using BrewTracker.ViewModels;

namespace BrewTracker.Views;

public partial class BrewingListPage : ContentPage
{
	public BrewingListPage(BrewingListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}