using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WinnersLeague.Models;
using WinnersLeague.Web.Areas.Identity.Data;

namespace WinnersLeague.Web.Models
{
    public class WinnersLeagueContext : IdentityDbContext<WinnersLeagueUser>
    {
        public WinnersLeagueContext(DbContextOptions<WinnersLeagueContext> options)
            : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Stadium> Stadiums { get; set; }

        public DbSet<Odd> Odds { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Stadium>()
            .HasOne(a => a.Team)
            .WithOne(a => a.Stadium)
            .HasForeignKey<Team>(c => c.StadiumId);

            base.OnModelCreating(builder);
        }
    }
}
