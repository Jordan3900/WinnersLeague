using System;
using System.Collections.Generic;
using System.Linq;
using WinnersLeague.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinnersLeague.Services.Data.Contracts;
using WinnersLeague.Services.Models;

namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IMatchService matchService;
        private readonly ITeamService teamService;

        public MatchesController(IMatchService matchService, ITeamService teamService)
        {
            this.matchService = matchService;
            this.teamService = teamService;
        }

        [Area("Admin")]
        public IActionResult Create()
        {
            var teamNames = this.teamService.GetAll()
                .Select(x => x.Name)
                .ToList();

            this.ViewData["Teams"] = teamNames;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Match model)
        {
            var match = model;

            return View();
        }
    }
}