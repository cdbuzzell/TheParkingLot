using System;

namespace TheParkingLot.Models
{
    public class GolferRound
    {
        public Guid GolferRoundId { get; set; }

        public Round Round { get; set; }

        public Course Course { get; set; }

        public Golfer Golfer { get; set; }

        public double? Points { get; set; }

        public int? Score { get; set; }

        public int? Par3sWon { get; set; }

        public bool WonGame { get; set; }

        public string Comments { get; set; }
    }
}
