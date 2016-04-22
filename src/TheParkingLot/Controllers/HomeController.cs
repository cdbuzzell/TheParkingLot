using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using TheParkingLot.Models;
using TheParkingLot.ViewModels.Home;
using TheParkingLot.DataAccess;


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
            string connectionString = _context.Database.GetDbConnection().ConnectionString;
            HomeDataAccess da = new HomeDataAccess(connectionString);

            // get year from appSettings
            int season = _appSettings.Value.CurrentSeason;

            List<GolferSeasonTotal> leaderboard = da.GetLeaderboard(season);

            // filter schedule to upcoming dates only
            List<Round> schedule = da.GetSchedule(season).Where(round => round.Date.Ticks >= DateTime.Now.Ticks).ToList();

            IndexViewModel model = new IndexViewModel
            {
                Leaderboard = leaderboard,
                Schedule = schedule
            };

            return View(model);
        }

        public IActionResult Schedule()
        {
            string connectionString = _context.Database.GetDbConnection().ConnectionString;
            HomeDataAccess da = new HomeDataAccess(connectionString);

            ScheduleViewModel model = new ScheduleViewModel
            {
                Seasons = GetSeasons()
            };

            return View(model);
        }
        
        public JsonResult ScheduleAjax(int season)
        {
            string connectionString = _context.Database.GetDbConnection().ConnectionString;
            HomeDataAccess da = new HomeDataAccess(connectionString);
            
            List<Round> schedule = da.GetSchedule(season);

            return Json(schedule);
        }

        public IActionResult Statistics()
        {
            string connectionString = _context.Database.GetDbConnection().ConnectionString;
            HomeDataAccess da = new HomeDataAccess(connectionString);

            StatisticsViewModel model = new StatisticsViewModel
            {
                //TODO: I don't like only populating part of the model
                Seasons = GetSeasons(),
                Golfers = da.GetGolfers()
            };

            return View(model);
        }

        public JsonResult StatisticsAjax(int season, string golfer)
        {
            string connectionString = _context.Database.GetDbConnection().ConnectionString;
            HomeDataAccess da = new HomeDataAccess(connectionString);

            StatisticsViewModel model = new StatisticsViewModel
            {
                //TODO: I don't like only populating part of the model
                Leaderboard = da.GetLeaderboard(season),
                SeasonStatistics = da.GetGolferRounds(golfer, season),
                AllStatistics = da.GetGolferTotals(golfer)
            };

            return Json(model);
        }

        public IActionResult Error()
        {
            return View();
        }

        private List<SelectListItem> GetSeasons()
        {
            int currentSeason = _appSettings.Value.CurrentSeason;
            int firstSeason = _appSettings.Value.FirstSeason;

            List<SelectListItem> seasons = new List<SelectListItem>();

            for (int s = currentSeason; s >= firstSeason; s--)
            {
                // add every season between the last and first
                seasons.Add(new SelectListItem { Value = s.ToString(), Text = s.ToString() });
            }

            return seasons;
        }
    }
}
