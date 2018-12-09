using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinnersLeague.Services.Data.Contracts;

namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly ILeagueService leagueService;

        public LeaguesController(ILeagueService leagueService)
        {
            this.leagueService = leagueService;
        }

        [Area("Admin")]
        public IActionResult All()
        {
            var leagues = leagueService.GetAll();

            return View(leagues);
        }
    }
}