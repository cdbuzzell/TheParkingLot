using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheParkingLot.Models;

namespace TheParkingLot.ViewModels.Home
{
    public class StatisticsViewModel
    {
        public List<GolferSeasonTotal> Leaderboard { get; set; }
        public List<GolferRound> SeasonStatistics { get; set; }
        public List<GolferSeasonTotal> AllStatistics { get; set; }
        public List<SelectListItem> Seasons { get; set; }
        public List<Golfer> Golfers { get; set; }
    }
}
