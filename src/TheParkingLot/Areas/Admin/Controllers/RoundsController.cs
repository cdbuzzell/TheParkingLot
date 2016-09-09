using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheParkingLot.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TheParkingLot.DataAccess;
using TheParkingLot.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;

namespace TheParkingLot.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Administrator")]
    public class RoundsController : Controller
    {
        private ApplicationDbContext _context;
        private IOptions<AppSettings> _appSettings;

        public RoundsController(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            string connectionString = _context.Database.GetDbConnection().ConnectionString;
            HomeDataAccess da = new HomeDataAccess(connectionString);

            RoundsViewModel model = new RoundsViewModel
            {
                Rounds = da.GetSchedule(_appSettings.Value.CurrentSeason)
            };

            return View(model);
        }

        public IActionResult Scores()
        {
            return View();
        }
    }
}
