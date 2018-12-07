namespace WinnersLeague.Data.Services.Contracts
{
    using System.Collections.Generic;
    using WinnersLeague.Services.Models;

    public interface ITeamsService
    {
        IEnumerable<TeamViewModel> GetAll();

        bool IsTeamIdValid(string teamId);

        string GetTeamId(string name);
    }
}
