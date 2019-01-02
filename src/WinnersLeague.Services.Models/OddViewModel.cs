namespace WinnersLeague.Services.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Models.Enums;
    using WinnersLeague.Services.Mapping.Contracts;

    public class OddViewModel : IMapFrom<Odd>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public OddType Type { get; set; }

        public decimal OddValue { get; set; }

        public string Match { get; set; }

        public bool IsWinning { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Odd, OddViewModel>()
                .ForMember(x => x.Match,
                    m => m.MapFrom(c => $"{c.Match.HomeTeam.Name} vs {c.Match.AwayTeam.Name}"));
        }
    }
}
