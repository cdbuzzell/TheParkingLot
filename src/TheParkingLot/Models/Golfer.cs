using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheParkingLot.Models
{
    public class Golfer
    {
        [Key]
        public Guid GolferId { get; set; }

        public string Alias { get; set; }
        
        [Display(Name = "Golfer")]
        public string Name { get; set; }

        public byte[] Avatar { get; set; }

        public string FullName { get; set; }

        public bool Enabled { get; set; }

        public bool BringsBeer { get; set; }
    }
}
