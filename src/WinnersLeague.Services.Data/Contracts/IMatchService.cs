namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Models;

    public interface IMatchService
    {
        IEnumerable<MatchViewModel> GetAll();

        bool IsMatchIdValid(string matchId);

        Task CheckingLeagueMatchesAsync();

        Match GetMatch(string matchId);
    }
}
