using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheParkingLot.Models;

namespace TheParkingLot.ViewModels.Home
{
    public class ScheduleViewModel
    {
        //public List<Round> Schedule { get; set; }
        public List<SelectListItem> Seasons { get; set; }
    }
}
