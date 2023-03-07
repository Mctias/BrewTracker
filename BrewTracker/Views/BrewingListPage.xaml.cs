using BrewTracker.ViewModels;

namespace BrewTracker.Views;

public partial class BrewingListPage : ContentPage
{
    BrewingListViewModel vm;
    public BrewingListPage(BrewingListViewModel vm)
	{
		InitializeComponent();
        this.vm = vm; 
		BindingContext = vm;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        vm.PopulateBrewList();
    }
}