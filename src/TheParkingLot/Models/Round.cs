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

        public string RoundName { get; set; }

        public string Details { get; set; }

        public string Game { get; set; }

        public string CourseName { get; set; }

        public string CourseUrl { get; set; }

        public Guid BeerDutyGolferId { get; set; }

        public string Username { get; set; }

        [Display(Name = "Beer Duty")]
        public string GolferName { get; set; }

        public byte[] Avatar { get; set; }

        //public Course Course { get; set; }

        //public Golfer BeerDuty { get; set; }
    }
}
