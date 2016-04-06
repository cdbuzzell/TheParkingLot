using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheParkingLot.Models
{
    public class GolferPointTotal
    {
        [Key]
        public Guid GolferId { get; set; }

        public Int64 Rank { get; set; }

        [Display(Name = "Golfer")]
        public string GolferName { get; set; }
        
        public string Alias { get; set; }

        [Display(Name = "Points")]
        public double TotalPoints { get; set; }

        [Display(Name = "Behind")]
        public double PointsBehind { get; set; }
    }
}
