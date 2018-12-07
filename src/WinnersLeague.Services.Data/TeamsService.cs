namespace WinnersLeague.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WinnersLeague.Common;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Data.Contracts;
    using WinnersLeague.Services.Mapping;
    using WinnersLeague.Services.Models;

    public class TeamsService : ITeamService
    {
        private readonly IRepository<Team> teamRepository;

        public TeamsService(IRepository<Team> teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public IEnumerable<TeamViewModel> GetAll()
        {
            var teams = this.teamRepository.All().OrderBy(x => x.Name)
                .To<TeamViewModel>().ToList();

            return teams;
        }

        public string GetTeamId(string name)
        {
            var team = this.teamRepository.All().FirstOrDefault(x => x.Name == name);

            return team.Id;
        }

        public bool IsTeamIdValid(string teamId)
        {
            return this.teamRepository.All().Any(x => x.Id == teamId);
        }
    }
}
