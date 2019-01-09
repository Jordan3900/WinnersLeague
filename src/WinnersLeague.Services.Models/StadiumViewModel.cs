namespace WinnersLeague.Services.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Mapping.Contracts;

    public class StadiumViewModel : IMapFrom<Stadium>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be at least 1")]
        public int YearFound { get; set; }

        [Required]
        [Range(100, int.MaxValue, ErrorMessage = "Value must be at least 100")]
        public int Capacity { get; set; }

        [Required]
        public string Team { get; set; }

        public string ShortDescription => this.Description.Substring(0, 100) + " ...";

        public string Picture { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Stadium, StadiumViewModel>()
                .ForMember(x => x.Team,
                    m => m.MapFrom(c => c.Team.Name));
        }
    }
}
