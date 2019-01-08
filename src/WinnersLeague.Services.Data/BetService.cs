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
                .FirstOrDefault(x => x.IsCurrentBet);

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
               User = user
           };

           await this.betRepository.AddAsync(currentbet);
           await this.betRepository.SaveChangesAsync();

            return currentbet;
        }

        public  async Task AddingAmountOfWin(string username)
        {
            var user = this.userRepository
                .All()
                .FirstOrDefault(x => x.UserName == username);

            var bets = this.betRepository.All()
                .Where(x => !x.IsPaid && !x.IsCurrentBet && x.Odds.Count > 0)
                .ToList();
               
            foreach (var bet in bets)
            {
                bet.IsWinning = bet.Odds.All(x => x.IsWinning);
            }

            var amountOfWin = bets
                .Sum(x => x.AmountOfWin);

            user.Points += amountOfWin;

            foreach (var bet in bets)
            {
                bet.IsPaid = true;
            }
            var winStats = (user
                .Bets
                .Where(x => x.IsWinning && !x.IsCurrentBet).Count() / 
                user.Bets.Where(x => !x.IsCurrentBet).Count() * 100);

            user.WinStats = winStats;

            await this.userRepository.SaveChangesAsync();
        }
    }
}
