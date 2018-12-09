namespace WinnersLeague.Services.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Mapping.Contracts;

    public class LeagueViewModel : IMapFrom<League>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public int CountOfTeams { get; set; }

        public int CountOfMatches { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<League, LeagueViewModel>()
                .ForMember(x => x.CountOfTeams,
                    m => m.MapFrom(c => c.Teams.Count));

            configuration.CreateMap<League, LeagueViewModel>()
                .ForMember(x => x.CountOfMatches,
                    m => m.MapFrom(c => c.Matches.Count));
        }
    }
}
