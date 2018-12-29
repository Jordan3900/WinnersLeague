namespace WinnersLeague.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WinnersLeague.Services.Data.Contracts;

    public class StadiumsController : Controller
    {
        private readonly IStadiumService stadiumService;

        public StadiumsController(IStadiumService stadiumService)
        {
            this.stadiumService = stadiumService;
        }

        [Route("/Stadiums/All", Name = "AllStadiums")]
        public IActionResult All()
        {
            var stadiums = this.stadiumService
                .GetAll()
                .ToArray();

            return View(stadiums);
        }
    }
}