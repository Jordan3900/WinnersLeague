namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WinnersLeague.Common;
    using WinnersLeague.Models;

    [Area("Admin")]
    public class BetsController : Controller
    {
        private readonly IRepository<Bet> betRepository;

        public BetsController(IRepository<Bet> betRepository)
        {
            this.betRepository = betRepository;
        }

        public IActionResult All()
        {
            var bets = this.betRepository
                .All()
                .OrderByDescending(x => x.Date)
                .ToList();

            return View(bets);
        }

        public IActionResult Details(string id)
        {
            var bet = this.betRepository
                .All()
                .FirstOrDefault(x => x.Id == id);
                

            return View(bet);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var bets = this.betRepository
                .All()
                .ToList();

            var bet = bets
                .FirstOrDefault(x => x.Id == id);

            this.betRepository.Delete(bet);

            await this.betRepository.SaveChangesAsync();

            return RedirectToAction("All", bets);
        }
    }
}