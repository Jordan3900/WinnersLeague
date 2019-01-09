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
    using WinnersLeague.Services.Data.Contracts;

    public class LeaderboardsController : Controller
    {
        private readonly IRepository<WinnersLeagueUser> userRepository;
        private readonly IRepository<League> leagueRepository;
        private readonly IBetService betService;
        private readonly IMatchService matchService;

        public LeaderboardsController(IRepository<WinnersLeagueUser> userRepository,
            IRepository<League> leagueRepository,  IBetService betService
            , IMatchService matchService)
        {
            this.matchService = matchService;
            this.userRepository = userRepository;
            this.leagueRepository = leagueRepository;
            this.betService = betService;
        }

        public IActionResult UsersList()
        {
            var users = this.userRepository
                .All().To<UserViewModel>()
                .OrderByDescending(x => x.WinStats)
                .ThenByDescending(x => x.Points)
                .ToList();

            this.betService.CheckingIsWiningBetsAsync();
            

            return this.View(users);
        }

        public async Task<IActionResult> LeagueList(string name)
        {
            var league = this.leagueRepository
                .All()
                .FirstOrDefault(x => x.Name == name);

            await this.matchService.CheckingLeagueMatchesAsync();

            return this.View(league);
        }
    }
}