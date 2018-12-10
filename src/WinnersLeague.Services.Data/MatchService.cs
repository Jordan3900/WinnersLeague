namespace WinnersLeague.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Common;
    using WinnersLeague.Services.Data.Contracts;
    using WinnersLeague.Services.Models;
    using System.Linq;
    using WinnersLeague.Services.Mapping;

    public class MatchService : IMatchService
    {
        private readonly IRepository<Match> matchRepository;

        public MatchService(IRepository<Match> matchRepository)
        {
            this.matchRepository = matchRepository;
        }

        public IEnumerable<MatchViewModel> GetAll()
        {
            var matches = this.matchRepository.All()
                .OrderBy(x => x.MatchStart).To<MatchViewModel>();

            return matches;
        }

        public bool IsMatchIdValid(string matchId)
        {
            return this.matchRepository.All().Any(x => x.Id == matchId);
        }
    }
}
