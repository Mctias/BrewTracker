using BrewTracker.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BrewTracker.Views;

namespace BrewTracker.ViewModels;

public partial class BrewingListViewModel : BaseViewModel
{
	public ObservableCollection<Brew> BrewingList { get; set; }

    public BrewingListViewModel()
    {
        BrewingList = new ObservableCollection<Brew>
        {
            new Brew { Name = "Öl", Description = "Smakar gott", Image = "https://driveinbottleshop.dk/wp-content/uploads/2021/01/9764G-155723051749-600x600.png.webp" },
            new Brew { Name = "Cider", Description = "Smakar också ok", Image = "https://www.burkbolaget.com/4361-thickbox_default/kopparberg-pear-cider-45-vol-24-x-033-ltr.jpg" },
            new Brew { Name = "Annan öl", Description = "Smakar meh", Image = "https://cdn.abicart.com/shop/11011/art11/h2703/183242703-origpic-9e4af1.jpg" }
        };
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
    int daysToBottling = 5;
}