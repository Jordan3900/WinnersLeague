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

        public Bet GetCurrentBet(string username)
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
    }
}
