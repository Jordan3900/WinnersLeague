namespace WinnersLeague.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WinnersLeague.Data;
    using WinnersLeague.Services.Data.Contracts;
    using WinnersLeague.Web.Models;
    using WinnersLeague.Web.Models.HomePageModel;
    using WinnersLeague.Models.Enums;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        private readonly IBetService betService;

        public HomeController(IHomeService homeService, IBetService betService)
        {
            this.homeService = homeService;
            this.betService = betService;
        }

        public IActionResult Index()
        {
            var isAuthenticated = this.User.Identity.IsAuthenticated;

            var homeModel = new HomePageViewModel
            {
                Matches = this.homeService.Matches()
                .Where(x => x.Status != MatchStatus.Finished).ToList()
            };

            if (isAuthenticated)
            {
                var username = this.User.Identity.Name;
                homeModel.MyBet = this.betService.GetCurrentBet(username);
            }
           
            return View(homeModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
