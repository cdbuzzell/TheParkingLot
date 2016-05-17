using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheParkingLot.Models
{
    public class Round
    {
        [Key]
        public Guid RoundId { get; set; }

        public DateTime Date { get; set; }
        
        public string Name { get; set; }

        public string Details { get; set; }

        public string Game { get; set; }

        public Course Course { get; set; }

        public Golfer BeerDuty { get; set; }
    }
}
