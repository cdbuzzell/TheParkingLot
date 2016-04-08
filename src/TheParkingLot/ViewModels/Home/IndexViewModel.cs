using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheParkingLot.Models;

namespace TheParkingLot.ViewModels.Home
{
    public class IndexViewModel
    {
        public List<GolferSeasonTotal> Leaderboard { get; set; }
        public List<Round> Schedule { get; set; }
        //public Golfer BeerDuty { get; set; }
    }
}
