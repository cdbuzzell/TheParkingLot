using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TheParkingLot.Models;
using Microsoft.Extensions.OptionsModel;

namespace TheParkingLot.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoundController : Controller
    {
        private ApplicationDbContext _context;
        private IOptions<AppSettings> _appSettings;

        public RoundController(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
