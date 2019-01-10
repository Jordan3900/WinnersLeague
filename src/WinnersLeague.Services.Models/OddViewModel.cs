namespace WinnersLeague.Services.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Models.Enums;
    using WinnersLeague.Services.Mapping.Contracts;

    public class OddViewModel : IMapFrom<Odd>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public OddType Type { get; set; }

        [Display(Name = "Odd Value")]
        [Range(typeof(decimal), "1.01", "79228162514264337593543950335", ErrorMessage = "Value must be at least 1.01")]
        public decimal OddValue { get; set; }

        public string Match { get; set; }

        [Display(Name = "Is Winning")]
        public bool IsWinning { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Odd, OddViewModel>()
                .ForMember(x => x.Match,
                    m => m.MapFrom(c => $"{c.Match.HomeTeam.Name} vs {c.Match.AwayTeam.Name}"));
        }
    }
}
