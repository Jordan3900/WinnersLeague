using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinnersLeague.Common;
using WinnersLeague.Models;
using WinnersLeague.Services.Data.Contracts;
using WinnersLeague.Web.Models.BetModels;
using WinnersLeague.Web.Models.HomePageModel;

namespace WinnersLeague.Web.Controllers
{
    [Authorize]
    public class BetsController : Controller
    {
        private readonly IOddService oddService;
        private readonly IRepository<Odd> oddRepository;
        private readonly IHomeService homeService;
        private readonly IBetService betService;
        private readonly IRepository<Bet> betRepository;

        public BetsController(IRepository<Odd> oddRepository,
            IOddService oddService,
            IHomeService homeService,
            IBetService betService,
            IRepository<Bet> betRepository)
        {
            this.oddRepository = oddRepository;
            this.oddService = oddService;
            this.homeService = homeService;
            this.betService = betService;
            this.betRepository = betRepository;
        }


        public async Task<IActionResult> AddOdd(string oddId, string matchId)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }
            var username = this.User.Identity.Name;
            var currentBet = this.betService.GetCurrentBet(username);
            var odd = this.oddRepository.All().FirstOrDefault(x => x.Id == oddId);

            currentBet.Odds.Add(odd);
            await this.oddRepository.SaveChangesAsync();

            var homeModel = new HomePageViewModel
            {
                Matches = this.homeService.Matches(),
                MyBet = currentBet
            };

            return this.RedirectToAction("Index", "Home", homeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BetInputModel model)
        {
            var currentBet = this.betRepository
                .All()
                .FirstOrDefault(x => x.Id == model.Id);

            currentBet.IsCurrentBet = false;
            currentBet.BetAmount = model.BetAmount;
            currentBet.AmountOfWin = currentBet.Odds.Sum(x => x.OddValue) * currentBet.BetAmount;
            currentBet.Date = DateTime.UtcNow;
            currentBet.User.Points -= model.BetAmount;

            await this.betService.AddingAmountOfWin(currentBet.User.UserName);
            await this.betRepository.SaveChangesAsync();
            var nextCurrentBet = this.betService.GetCurrentBet(currentBet.User.UserName);


            var homeModel = new HomePageViewModel
            {
                Matches = this.homeService.Matches(),
                MyBet = nextCurrentBet
            };

            return this.RedirectToAction("Index", "Home", homeModel);
        }

        public async Task<IActionResult> RemoveOdd(string oddId)
        {
            var username = this.User.Identity.Name;
            var currentBet = this.betService.GetCurrentBet(username);
            var odd = this.oddRepository
                .All()
                .FirstOrDefault(x => x.Id == oddId);

            currentBet.Odds.Remove(odd);
            await this.oddRepository.SaveChangesAsync();

            var homeModel = new HomePageViewModel
            {
                Matches = this.homeService.Matches(),
                MyBet = currentBet
            };

            return this.RedirectToAction("Index", "Home", homeModel);
        }

        public async Task<IActionResult> RemoveAllOdds()
        {
            var username = this.User.Identity.Name;
            var currentBet = this.betService.GetCurrentBet(username);

            currentBet.Odds.Clear();
            await oddRepository.SaveChangesAsync();

            var homeModel = new HomePageViewModel
            {
                Matches = this.homeService.Matches(),
                MyBet = currentBet
            };

            return this.RedirectToAction("Index", "Home", homeModel);
        }

        public IActionResult Details()
        {


            return this.View();
        }

        public async Task<IActionResult> All()
        {

            var username = this.User.Identity.Name;
            var bets = this.betRepository
                .All()
                .Where(x => x.User.UserName == username && !x.IsCurrentBet)
                .OrderByDescending(x => x.Date)
                .ToList();

            await this.betService.AddingAmountOfWin(username);

            return this.View(bets);
        }

    }
}