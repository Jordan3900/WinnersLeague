namespace WinnersLeague.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Data.Contracts;
    using WinnersLeague.Services.Models;

    public class HomeService : IHomeService
    {
        private readonly IMatchService matchService;

        public HomeService(IMatchService matchService)
        {
            this.matchService = matchService;
            this.MyBet = new Bet();
        }

        public Bet MyBet { get; }

        public ICollection<MatchViewModel> Matches()
        {
            return this.matchService.GetAll()
                .Where(x => x.Odds.Count() > 0)
                .ToList();
        }

        public ICollection<Odd> Odds()
        {
            return this.MyBet.Odds.ToList();
        }
    }
}
