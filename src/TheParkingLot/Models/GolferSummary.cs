using System;
using System.ComponentModel.DataAnnotations;

namespace TheParkingLot.Models
{
    public class GolferSummary
    {
        public Golfer Golfer { get; set; }

        public GolferTotals CurrentTotals { get; set; }

        public GolferTotals CareerTotals { get; set; }

        //public string BestFinish { get; set; }
    }

    public class GolferTotals
    {
        public double? AverageToPar { get; set; }

        [Display(Name = "Par3s")]
        public int Par3Wins { get; set; }

        [Display(Name = "Wins")]
        public int GameWins { get; set; }

        //[Display(Name = "Behind")]
        //public double PointsBehind { get; set; }
    }
}
