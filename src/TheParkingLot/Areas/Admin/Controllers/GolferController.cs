using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheParkingLot.Models;
using Microsoft.Extensions.Options;

namespace TheParkingLot.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GolferController : Controller
    {
        private ApplicationDbContext _context;
        private IOptions<AppSettings> _appSettings;

        public GolferController(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Notify()
        {
            return View();
        }
    }
}
