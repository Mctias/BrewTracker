using BrewTracker.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BrewTracker.Views;
using BrewTracker.Database;

namespace BrewTracker.ViewModels;

public partial class BrewingListViewModel : BaseViewModel
{
    public ObservableCollection<Brew> BrewingList { get; } = new();

    BrewDatabase brewDatabase;

    public BrewingListViewModel(BrewDatabase brewDatabase)
    {
        this.brewDatabase = brewDatabase;
        PopulateBrewList();
    }

    [RelayCommand]
    public async void PopulateBrewList()
    {
        BrewingList.Clear();

        try
        {
            var dbBrews = await brewDatabase.GetFermentingBrewsAsync();
            foreach (var brew in dbBrews)
            {
                brew.DaysFermenting = Math.Abs((DateTime.Today - brew.StartDate).TotalDays);
                BrewingList.Add(brew);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", "Something went wrong when loading your brews", "OK");
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    async Task GoToBrew(Brew brew)
    {
        if (brew == null)
        {
            return;
        }
        await Shell.Current.GoToAsync($"{nameof(BrewDetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Brew", brew}
            });
    }

    [RelayCommand]
    async Task GoToAddBrew()
    {
        await Shell.Current.GoToAsync($"{nameof(AddBrewPage)}", true);
    }


    [ObservableProperty]
    bool isRefreshing = false;
}