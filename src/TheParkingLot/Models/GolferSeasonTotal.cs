using System;
using System.ComponentModel.DataAnnotations;

namespace TheParkingLot.Models
{
    public class GolferSeasonTotal
    {
        public Golfer Golfer { get; set; }

        public Int64 Rank { get; set; }

        [Display(Name = "Par3s")]
        public int Par3Wins { get; set; }

        [Display(Name = "Wins")]
        public int GameWins { get; set; }

        [Display(Name = "Points")]
        public double TotalPoints { get; set; }

        [Display(Name = "Behind")]
        public double PointsBehind { get; set; }

        public int Season { get; set; }

        public double? AverageToPar { get; set; }
    }
}
