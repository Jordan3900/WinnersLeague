namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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

        [Range(typeof(decimal), "0.40", "79228162514264337593543950335", ErrorMessage = "Value must be at least 0.40")]
        public decimal BetAmount { get; set; }

        public bool IsCurrentBet { get; set; }

        public DateTime Date { get; set; }

        public virtual WinnersLeagueUser User { get; set; }
       
        public decimal AmountOfWin { get; set; }

        public bool IsPaid { get; set; }

        virtual public ICollection<Odd> Odds { get; set; }
    }
}
