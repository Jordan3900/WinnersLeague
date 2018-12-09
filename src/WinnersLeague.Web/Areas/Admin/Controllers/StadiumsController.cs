namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Services.Data.Contracts;

    public class StadiumsController : Controller
    {
        private readonly IStadiumService stadiumService;

        public StadiumsController(IStadiumService stadiumService)
        {
            this.stadiumService = stadiumService;
        }

        [Area("Admin")]
        public IActionResult All()
        {
            var stadiums = stadiumService.GetAll();

            return View(stadiums);
        }
    }
}
