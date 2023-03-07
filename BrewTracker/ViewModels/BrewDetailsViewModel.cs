using BrewTracker.Database;
using BrewTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewTracker.ViewModels
{
    [QueryProperty("Brew", "Brew")]

    public partial class BrewDetailsViewModel : BaseViewModel
    {
        BrewDatabase brewDatabase;

        public BrewDetailsViewModel(BrewDatabase brewDatabase) 
        { 
            this.brewDatabase = brewDatabase;
        }

        [ObservableProperty]
        Brew brew;

        [RelayCommand]
        public async void BottleBrewAsync()
        {
            Brew.BottlingDate = DateTime.Today;
            Brew.BrewingState = BrewingState.Aging;
            await brewDatabase.SaveBrewAsync(brew);
            //TODO: Go to BottleBrewPage
            await Shell.Current.GoToAsync($"//{nameof(AgingListPage)}");
        }
    }
}
