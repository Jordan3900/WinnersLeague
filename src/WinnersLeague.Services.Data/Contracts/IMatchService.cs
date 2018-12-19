namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Models;

    public interface IMatchService
    {
        IEnumerable<MatchViewModel> GetAll();

        bool IsMatchIdValid(string matchId);
    }
}
