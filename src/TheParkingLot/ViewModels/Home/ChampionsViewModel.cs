using System.Collections.Generic;
using TheParkingLot.Models;

namespace TheParkingLot.ViewModels.Home
{
    public class ChampionsViewModel
    {
        public List<SeasonChampion> Champions { get; set; }
    }

    public class SeasonChampion
    {
        public int Season { get; set; }
        public GolferSeasonTotal Champion { get; set; }
        public GolferSeasonTotal RunnerUp { get; set; }
        public GolferSeasonTotal SecondRunnerUp { get; set; }
    }
}
