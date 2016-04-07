using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace TheParkingLot.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<GolferPointTotal> Leaderboard { get; set; }
        public DbSet<Round> Schedule { get; set; }
        public DbSet<GolferRound> Statistics { get; set; }

        public List<GolferPointTotal> GetLeaderboard(int season)
        {
            //TODO: this can't be the right way to do this, are we binding data twice?
            var result = Leaderboard.FromSql("dbo.GetLeaderboard @Season = {0}", season);
            return result.ToList<GolferPointTotal>();
        }

        public List<Round> GetSchedule(int season)
        {
            var result = Schedule.FromSql("dbo.GetSchedule @Season = {0}", season);
            return result.ToList<Round>();
        }

        public List<GolferRound> GetStatistics(string golfer, int season)
        {
            var result = Statistics.FromSql("dbo.GetGolferRounds @Golfer={0}, @Season = {1}", golfer, season);
            //TODO: this returns 2 results sets
            return result.ToList<GolferRound>();
        }
    }
}
