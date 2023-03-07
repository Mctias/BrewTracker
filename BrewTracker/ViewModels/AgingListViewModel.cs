using BrewTracker.Database;
using BrewTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewTracker.ViewModels
{
    public partial class AgingListViewModel : BaseViewModel
    {
        public ObservableCollection<Brew> AgingList { get; } = new();

        BrewDatabase brewDatabase;

        public AgingListViewModel(BrewDatabase brewDatabase)
        {
            this.brewDatabase = brewDatabase;
        }

        [RelayCommand]
        public async void PopulateBrewList()
        {
            AgingList.Clear();

            try
            {
                var dbBrews = await brewDatabase.GetBottledBrewsAsync();
                foreach (var brew in dbBrews)
                {
                    brew.DaysAging = Math.Abs((DateTime.Today.Date - brew.BottlingDate.Date).TotalDays);
                    AgingList.Add(brew);
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
        int daysAging;

        [ObservableProperty]
        bool isRefreshing = false;
    }
}
