namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;



// Add profile data for application users by adding properties to the WinnersLeagueUser class
public class WinnersLeagueUser : IdentityUser
    {
        public WinnersLeagueUser()
        {
            this.Bets = new HashSet<Bet>();
        }

        public string FullName { get; set; }

        public byte[] Avatar { get; set; }

        public decimal Points { get; set; } = 200;

        virtual public ICollection<Bet> Bets { get; set; }

        public decimal WinStats { get; set; }
    }
}
