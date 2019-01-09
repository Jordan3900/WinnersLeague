namespace WinnersLeague.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WinnersLeague.Services.Data.Contracts;


    public class TeamsController : Controller
    {
        private readonly ITeamService teamService;

        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public IActionResult Details(string id)
        {
            var team = this.teamService
                .GetAll()
                .FirstOrDefault(x => x.Id == id);


            return View(team);
        }
    }
}