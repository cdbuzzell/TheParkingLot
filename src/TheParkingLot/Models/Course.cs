using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheParkingLot.Models
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Zip { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Par { get; set; }

        public double? Rating { get; set; }

        public int? Slope { get; set; }
    }
}
