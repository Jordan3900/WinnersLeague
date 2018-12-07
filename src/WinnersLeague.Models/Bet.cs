namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Bet
    {
        public Bet()
        {
            this.Odds = new HashSet<Odd>();
        }

        public string Id { get; set; }

        public bool IsWinning { get; set; }

        public decimal BetAmount { get; set; }

        public decimal AmountOfWin { get; set; }

        virtual public ICollection<Odd> Odds { get; set; }
    }
}
