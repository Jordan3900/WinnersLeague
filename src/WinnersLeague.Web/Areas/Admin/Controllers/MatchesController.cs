using System;
using System.Collections.Generic;
using System.Linq;
using WinnersLeague.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinnersLeague.Services.Data.Contracts;
using WinnersLeague.Services.Models;
using WinnersLeague.Web.Areas.Admin.Models;
using AutoMapper;
using WinnersLeague.Common;
using WinnersLeague.Data;

namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MatchesController : Controller
    {
        private readonly IMatchService matchService;
        private readonly ITeamService teamService;
        private readonly ILeagueService leagueService;
        private readonly IMapper mapper;
        private readonly IRepository<Match> repository;

        public MatchesController(IMatchService matchService,
            ILeagueService leagueService, IRepository<Match> repository,
            ITeamService teamService, IMapper mapper)
        {
            this.matchService = matchService;
            this.teamService = teamService;
            this.leagueService = leagueService;
            this.mapper = mapper;
            this.repository = repository;
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult All()
        {
            var matches = this.matchService.GetAll();
          
           
            return View(matches);
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult Create()
        {
            var teamNames = this.teamService.GetAll()
                .Select(x => x.Name)
                .ToList();

            this.ViewData["Teams"] = teamNames;

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(MatchInputModel model)
        {
            var league = this.leagueService.GetLeague(model.League);
            var homeTeam = this.teamService.GetTeam(model.HomeTeam);
            var awayTeam = this.teamService.GetTeam(model.AwayTeam);
            var match = mapper.Map<Match>(model);

            match.HomeTeam = homeTeam;
            match.AwayTeam = awayTeam;
            match.League = league;
           
            await this.repository.AddAsync(match);
            await this.repository.SaveChangesAsync();

            return this.RedirectToAction("Create", "Matches");
        }
    }
}