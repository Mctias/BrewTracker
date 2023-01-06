using BrewTracker.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewTracker.ViewModels
{
    public partial class AddBrewViewModel : BaseViewModel
    {
        BrewDatabase brewDatabase;
        public AddBrewViewModel(BrewDatabase brewDatabase) 
        {
            this.brewDatabase = brewDatabase;
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBrewAsyncCommand))]
        string name;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddBrewAsyncCommand))]
        string type;

        [ObservableProperty]
        string subtype;

        [ObservableProperty]
        int originalGravity;

        [ObservableProperty]
        int litres;

        [ObservableProperty]
        DateTime startDate = DateTime.Today;

        [ObservableProperty]
        DateTime bottlingDate = DateTime.Today.AddDays(7) ;

        [ObservableProperty]
        DateTime endDate = DateTime.Today.AddDays(14);

        [ObservableProperty]
        string notes;

        [RelayCommand(CanExecute = nameof(ValidateBrew))]
        public async void AddBrewAsync() 
        {
            IsBusy = true;
            Brew brew = new Brew
            {
                Name = name,
                Type = type,
                Subtype = subtype,
                OriginalGravity = originalGravity,
                Litres = litres,
                StartDate = startDate,
                BottlingDate = bottlingDate,
                EndDate = endDate,
                Notes = notes
            };
            try
            {
                await brewDatabase.SaveBrewAsync(brew);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Something went wrong when adding your brew", "OK");
            }
            IsBusy = false;
            ResetData();
            await Shell.Current.GoToAsync("..");
        }

        private void ResetData()
        {
            Name = string.Empty;
            Type = string.Empty;
            Subtype = string.Empty;
            Litres = 0;
            OriginalGravity = 0;
            StartDate = DateTime.Today;
            BottlingDate = DateTime.Today.AddDays(7);
            EndDate = DateTime.Today.AddDays(14);
        }

        private bool ValidateBrew()
        {
            if(name == null || type == null)
            {
                return false;
            }
            return true;
        }
    }
}
