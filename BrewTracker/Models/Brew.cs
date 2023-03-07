using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewTracker.Models
{
    public class Brew
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public BrewingState BrewingState {get; set;}
        public string Subtype { get; set; }
        public int OriginalGravity { get; set; }    
        public int Litres { get; set; }
        public DateTime StartDate { get; set; }
        public double DaysFermenting { get; set; }
        public DateTime BottlingDate { get; set; }
        public double DaysAging { get; set; }
        public DateTime EndDate { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
        public string Recipe { get; set; }
        public string Image { get; set; } = "https://img.freepik.com/free-vector/six-beers-drinks-set-icons_603843-1939.jpg?w=1380&t=st=1673020078~exp=1673020678~hmac=f20d149b2e5adf4b3016e123b8da3a46da5b84f0baac810dab80cc343d940e62";
    }

    public enum BrewingState
    {
        Fermenting = 0,
        Aging = 1,
        Done = 2
    }
}
