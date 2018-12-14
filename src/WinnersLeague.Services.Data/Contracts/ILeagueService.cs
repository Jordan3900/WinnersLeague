namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Models;

    public interface ILeagueService
    {
        IEnumerable<LeagueViewModel> GetAll();

        bool IsLeagueIdValid(string leagueId);

        string GetLeagueId(string name);

        League GetLeague(string name);
    }
}
