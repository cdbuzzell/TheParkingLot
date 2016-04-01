using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TheParkingLot.Models;
using Microsoft.Extensions.OptionsModel;
using TheParkingLot.ViewModels.Home;
using Microsoft.AspNet.Mvc.Rendering;

namespace TheParkingLot.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private IOptions<AppSettings> _appSettings;

        public HomeController(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            // get year from appSettings
            int season = _appSettings.Value.CurrentSeason;

            List<GolferPointTotal> leaderboard = _context.GetLeaderboard(season);

            // filter schedule to upcoming dates only
            List<Round> schedule = _context.GetSchedule(season).Where(round => round.Date >= DateTime.Now).ToList();

            IndexViewModel model = new IndexViewModel
            {
                Leaderboard = leaderboard,
                Schedule = schedule
            };

            return View(model);
        }

        public IActionResult Schedule(string season)
        {
            // get seasons
            int currentSeason = _appSettings.Value.CurrentSeason;
            int firstSeason = _appSettings.Value.FirstSeason;

            List<SelectListItem> seasons = new List<SelectListItem>();
            for(int s = currentSeason; s >= firstSeason; s--)
            {
                // add every season between the last and first
                seasons.Add(new SelectListItem { Value = s.ToString(), Text = s.ToString() });
            }

            ScheduleViewModel model = new ScheduleViewModel
            {
                Seasons = seasons,
                Schedule = _context.GetSchedule(currentSeason)
                //Schedule = season.HasValue ? _context.GetSchedule(currentSeason) : _context.GetSchedule(season.Value)
            };

            return View(model);
        }

        public IActionResult Statistics()
        {
            ViewData["Message"] = "Statistics by golfer. Select Golfer and Season, show list of weekly stats. New: charts.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
