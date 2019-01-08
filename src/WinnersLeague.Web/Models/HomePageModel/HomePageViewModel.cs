namespace WinnersLeague.Web.Models.HomePageModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Models;

    public class HomePageViewModel
    {

        public ICollection<MatchViewModel> Matches { get; set; }

        public Bet MyBet { get; set; }
    }
}
