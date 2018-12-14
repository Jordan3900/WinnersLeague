namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Models;

    public interface ITeamService
    {
        IEnumerable<TeamViewModel> GetAll();

        bool IsTeamIdValid(string teamId);

        Team GetTeam(string name);

        string GetTeamId(string name);
    }
}
