using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinnersLeague.Data;
using WinnersLeague.Services.Data.Contracts;
using WinnersLeague.Web.Models;

namespace WinnersLeague.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMatchService matchService;

        public HomeController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        public IActionResult Index()
        {
            var matches = this.matchService.GetAll().Where(x => x.Id == "5b9b8596-62cb-42ee-acef-a3a44b8393f6");

            return View(matches);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
