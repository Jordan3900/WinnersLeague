namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Models;

    public interface IHomeService
    {
         ICollection<MatchViewModel> Matches();
         Bet MyBet { get; }
    }
}
