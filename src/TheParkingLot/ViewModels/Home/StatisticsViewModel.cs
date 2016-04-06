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
        public List<GolferRound> YearStatistics { get; set; }
        public List<GolferRound> AllStatistics { get; set; }
    }
}
