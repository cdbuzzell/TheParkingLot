using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            DateTime today = DateTime.Now.AddHours(-5); //TODO: azure sql server is local while DateTime.Now is UTC, so this is a hack until I figure out how to get it to work the right way
            List<Round> schedule = da.GetSchedule(season).Where(round => DateTime.Compare(round.Date, today) >= 0).ToList();

            //ViewData["tempdebug"] = String.Format("schedule = {0}, now = {1}, compare = {2}", 
            //    schedule[0].Date.ToString(), 
            //    today.ToString(), 
            //    DateTime.Compare(schedule[0].Date, today));

            List<SeasonChampion> champions = new List<SeasonChampion>();
            // only display past champions if we have <10 rounds remaining this year to fill the page
            if (schedule.Count < 10)
            {
                champions = GetChampions();
            }

            IndexViewModel model = new IndexViewModel
            {
                Leaderboard = leaderboard,
                Schedule = schedule,
                Champions = champions
            };

            return View(model);
        }

        public IActionResult Schedule()
        {
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

        public IActionResult Champions()
        {
            List<SeasonChampion> champions = GetChampions();

            ChampionsViewModel model = new ChampionsViewModel
            {
                Champions = champions
            };

            return View(model);
        }

        public IActionResult Members()
        {
            string connectionString = _context.Database.GetDbConnection().ConnectionString;
            HomeDataAccess da = new HomeDataAccess(connectionString);

            MembersViewModel model = new MembersViewModel
            {
                GolferSummaries = da.GetGolferSummaries(_appSettings.Value.CurrentSeason)
            };

            return View(model);
        }

        private List<SeasonChampion> GetChampions()
        {
            // get year from appSettings
            int season = _appSettings.Value.CurrentSeason;

            // get champs for all seasons, then filter out current season because we may not be done yet
            string connectionString = _context.Database.GetDbConnection().ConnectionString;
            HomeDataAccess da = new HomeDataAccess(connectionString);

            // filter to exclude current season because it may still be in-progress
            List<GolferSeasonTotal> golfers = da.GetChampions().Where(golfer => !golfer.Season.Equals(season)).ToList();

            List<SeasonChampion> champions = new List<SeasonChampion>();

            for (int i = 0; i <= golfers.Count-3; i = i+3)
            {
                // group 3 golfers into a single object
                champions.Add(new SeasonChampion
                {
                    Season = golfers[i].Season,
                    Champion = golfers[i],
                    RunnerUp = golfers[i+1],
                    SecondRunnerUp = golfers[i+2]
                });
            }

            return champions;
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
