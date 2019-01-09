namespace WinnersLeague.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WinnersLeague.Common;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Data.Contracts;

    public class BetService : IBetService
    {
        private readonly IRepository<Bet> betRepository;
        private readonly IRepository<WinnersLeagueUser> userRepository;


        public BetService(IRepository<Bet> betRepository, IRepository<WinnersLeagueUser> userRepository)
        {
            this.betRepository = betRepository;
            this.userRepository = userRepository;
        }

        public ICollection<Bet> GetAll()
        {
            var bets = this.betRepository.All().ToList();

            return bets;
        }

        public  Bet GetCurrentBet(string username)
        {
            var currentbet = betRepository
                .All()
                .FirstOrDefault(x => x.IsCurrentBet && username == x.User.UserName);

            if (currentbet == null)
            {
               currentbet = CreateCurrentBet(username).Result;
                
            }

            return currentbet;
        }

        private async Task<Bet> CreateCurrentBet(string username)
        {
            var user = this.userRepository
                .All()
                .FirstOrDefault(x => x.UserName == username);

           var currentbet = new Bet
           {
               IsCurrentBet = true,
               User = user,
               IsWinning = false,
               IsPaid = false
           };

           await this.betRepository.AddAsync(currentbet);
           await this.betRepository.SaveChangesAsync();

            return currentbet;
        }

        public async Task AddingAmountOfWinAsync(string username, string betId)
        {
            var bet = betRepository
                .All()
                .FirstOrDefault(x => x.Id == betId);

            var amountOfWin = bet.AmountOfWin;

            var user = this.userRepository
                .All()
                .FirstOrDefault(x => x.UserName == username);

            user.Points += amountOfWin;
            bet.IsPaid = true;

            await this.userRepository.SaveChangesAsync();
        }

        public async Task CalculatingWinRatesAsync()
        {
            var users = this.userRepository
                .All()
                .ToList();

            foreach (var user in users)
            {
                decimal winnigBets = user
                  .Bets
                  .Where(x => x.IsWinning && !x.IsCurrentBet).Count();

                decimal allBets = user.Bets.Where(x => !x.IsCurrentBet).Count();

                decimal winStats = winnigBets / allBets;

                user.WinStats = winStats * 100;
            }

            await this.userRepository.SaveChangesAsync();
        }

        public async Task CheckingIsWiningBetsAsync()
        {
            var bets = this.betRepository.All()
                .Where(x => !x.IsPaid && !x.IsCurrentBet && x.Odds.Count > 0)
                .OrderByDescending(x => x.Date)
                .ToList();

            foreach (var bet in bets)
            {
                bet.IsWinning = bet.Odds.All(x => x.IsWinning);
            }

            await this.betRepository.SaveChangesAsync();
        }
    }
}
