using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheParkingLot.Models;

namespace TheParkingLot.ViewModels.Admin
{
    public class RoundsViewModel
    {
        public List<Round> Rounds { get; set; }
    }
}
