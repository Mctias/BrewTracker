using BrewTracker.Database;
using BrewTracker.ViewModels;
using BrewTracker.Views;

namespace BrewTracker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		
		
		//builder.Services.AddSingleton<FinishedListViewModel>();
		//builder.Services.AddSingleton<FinishedListViewModel>();

		builder.Services.AddSingleton<BrewingListPage>();
        builder.Services.AddSingleton<BrewingListViewModel>();

        builder.Services.AddSingleton<AgingListPage>();
        builder.Services.AddSingleton<AgingListViewModel>();

        builder.Services.AddSingleton<FinishedListPage>();
        builder.Services.AddSingleton<FinishedListViewModel>();


        builder.Services.AddSingleton<AddBrewPage>();
		builder.Services.AddSingleton<AddBrewViewModel>();

		builder.Services.AddTransient<BrewDetailsPage>();
		builder.Services.AddTransient<BrewDetailsViewModel>();

		builder.Services.AddSingleton<BrewDatabase>();

        return builder.Build();
	}
}
