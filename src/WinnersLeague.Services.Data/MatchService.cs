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
    using AutoMapper;

    public class MatchService : IMatchService
    {
        private readonly IRepository<Match> matchRepository;
        private readonly IMapper mapper;

        public MatchService(IRepository<Match> matchRepository, IMapper mapper)
        {
            this.matchRepository = matchRepository;
            this.mapper = mapper;
        }

        public IEnumerable<MatchViewModel> GetAll()
        { 

           var matches = this.matchRepository.All().ToList();

           var matchesViewModels = mapper.Map<List<Match>, List<MatchViewModel>>(matches);


            return matchesViewModels;
        }

        public bool IsMatchIdValid(string matchId)
        {
            return this.matchRepository.All().Any(x => x.Id == matchId);
        }
    }
}
