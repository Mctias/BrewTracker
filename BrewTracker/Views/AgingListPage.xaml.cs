namespace BrewTracker.Views;

public partial class AgingListPage : ContentPage
{
	AgingListViewModel vm;

    public AgingListPage(AgingListViewModel vm)
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