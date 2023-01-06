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
        public BrewDetailsViewModel() 
        { 

        }

        [ObservableProperty]
        Brew brew;
    }
}
