namespace WinnersLeague.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WinnersLeague.Common;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Data.Contracts;
    using WinnersLeague.Services.Mapping;
    using WinnersLeague.Services.Models;

    public class LeagueService : ILeagueService
    {
        private readonly IRepository<League> leagueRepository;

        public LeagueService(IRepository<League> leagueRepository)
        {
            this.leagueRepository = leagueRepository;
        }

        public IEnumerable<LeagueViewModel> GetAll()
        {
            var leagues = this.leagueRepository.All()
                .OrderBy(x => x.Name).To<LeagueViewModel>();

            return leagues;
        }

        public string GetTeamId(string name)
        {
            var league = this.leagueRepository.All()
                .FirstOrDefault(x => x.Name == name);

            return league.Id;
        }

        public bool IsTeamIdValid(string leagueId)
        {
            return this.leagueRepository.All()
                .Any(x => x.Id == leagueId);
        }
    }
}
