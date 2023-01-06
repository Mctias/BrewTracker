using BrewTracker.Views;

namespace BrewTracker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(BrewDetailsPage), typeof(BrewDetailsPage));
		Routing.RegisterRoute(nameof(AddBrewPage), typeof(AddBrewPage));
	}
}
