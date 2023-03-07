namespace BrewTracker.Views;

public partial class AgingListPage : ContentPage
{
	public AgingListPage(AgingListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}