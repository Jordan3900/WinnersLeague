namespace WinnersLeague.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WinnersLeague.Common;
    using WinnersLeague.Models;
    using WinnersLeague.Web.Models.UserModels;
    using WinnersLeague.Services.Mapping;

    public class LeaderboardsController : Controller
    {
        private readonly IRepository<WinnersLeagueUser> userRepository;
        private readonly IRepository<League> leagueRepository;

        public LeaderboardsController(IRepository<WinnersLeagueUser> userRepository, IRepository<League> leagueRepository)
        {
            this.userRepository = userRepository;
            this.leagueRepository = leagueRepository;
        }

        public IActionResult UsersList()
        {
            var users = this.userRepository
                .All().To<UserViewModel>()
                .OrderByDescending(x => x.WinStats)
                .ThenByDescending(x => x.Points)
                .ToList();
               

            return this.View(users);
        }

        public IActionResult LeagueList(string name)
        {
            var league = this.leagueRepository
                .All()
                .FirstOrDefault(x => x.Name == name);

            return this.View(league);
        }
    }
}