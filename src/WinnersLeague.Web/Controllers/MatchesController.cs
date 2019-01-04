namespace WinnersLeague.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WinnersLeague.Services.Data.Contracts;

    public class MatchesController : Controller
    {
        private readonly IMatchService matchService;

        public MatchesController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        public IActionResult Details(string id)
        {
            var match = this.matchService
                .GetAll()
                .FirstOrDefault(x => x.Id == id);


            return View(match);
        }
    }
}