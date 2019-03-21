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


            return this.View(team);
        } 

        public IActionResult All(string searchText)
        {
            searchText = searchText ?? "";
            searchText = searchText.Trim();

            var teams = this.teamService.GetAll()
                .Where(x => x.Name.ToLower()
                .Contains(searchText.ToLower()));

            return this.View(teams);
        }
    }
}