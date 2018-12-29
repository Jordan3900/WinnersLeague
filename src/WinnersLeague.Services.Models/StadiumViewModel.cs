namespace WinnersLeague.Services.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Mapping.Contracts;

    public class StadiumViewModel : IMapFrom<Stadium>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int YearFound { get; set; }

        public int Capacity { get; set; }

        public string Team { get; set; }

        public string ShortDescription => this.Description.Substring(0, 100) + " ...";

        public string Picture { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Stadium, StadiumViewModel>()
                .ForMember(x => x.Team,
                    m => m.MapFrom(c => c.Team.Name));
        }
    }
}
