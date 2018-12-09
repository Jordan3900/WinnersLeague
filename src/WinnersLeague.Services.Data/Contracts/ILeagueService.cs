namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Services.Models;

    public interface ILeagueService
    {
        IEnumerable<LeagueViewModel> GetAll();

        bool IsTeamIdValid(string leagueId);

        string GetTeamId(string name);
    }
}
