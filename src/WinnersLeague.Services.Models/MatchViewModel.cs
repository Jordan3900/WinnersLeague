namespace WinnersLeague.Services.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Models.Enums;
    using WinnersLeague.Services.Mapping.Contracts;

    public class MatchViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public string League { get; set; }

        public string Description { get; set; }

        public OddType OurBetSuggestion { get; set; }

        public DateTime MatchStart { get; set; }

        public int HomeScore { get; set; } = 0;

        public int AwayScore { get; set; } = 0;

        public MatchStatus Status { get; set; }

        public MatchType Type { get; set; }

        virtual public ICollection<Odd> Odds { get; set; }
        virtual public ICollection<Comments> Comments { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
           
        }
    }
}
