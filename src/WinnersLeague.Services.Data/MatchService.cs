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
    using System.Threading.Tasks;
    using WinnersLeague.Models.Enums;

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

        public Match GetMatch(string matchId)
        {
            return this.matchRepository.All()
                .FirstOrDefault(x => x.Id == matchId);
        }

        public async Task CheckingLeagueMatchesAsync()
        {
            var matchesForChecking = this.matchRepository.All()
                .Where(x => !x.IsMatchChecked && x.Type == MatchType.League && x.Status == MatchStatus.Finished)
                .ToList();

            foreach (var match in matchesForChecking)
            {
                if (match.AwayScore > match.HomeScore)
                {
                    match.AwayTeam.Wins++;
                    match.AwayTeam.Points += 3;

                    match.HomeTeam.Losses++;
                }
                else if (match.AwayScore < match.HomeScore)
                {
                    match.HomeTeam.Wins++;
                    match.HomeTeam.Points += 3;

                    match.AwayTeam.Losses++;
                }
                else
                {
                    match.HomeTeam.Draws++;
                    match.HomeTeam.Points++;

                    match.AwayTeam.Points++;
                    match.AwayTeam.Draws++;
                }
                match.IsMatchChecked = true;
            }

            await this.matchRepository.SaveChangesAsync();
        }
    }
}
