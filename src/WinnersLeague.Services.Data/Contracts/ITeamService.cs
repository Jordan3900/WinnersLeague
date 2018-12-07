namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Services.Models;

    public interface ITeamService
    {
        IEnumerable<TeamViewModel> GetAll();

        bool IsTeamIdValid(string teamId);

        string GetTeamId(string name);
    }
}
