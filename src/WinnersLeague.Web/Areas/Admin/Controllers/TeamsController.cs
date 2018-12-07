using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinnersLeague.Services.Data.Contracts;

namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    public class TeamsController : Controller
    {

        private readonly ITeamService teamService;

        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [Area("Admin")]
        public IActionResult All()
        {
            var teams = teamService.GetAll();

            return View(teams);
        }
    }
}