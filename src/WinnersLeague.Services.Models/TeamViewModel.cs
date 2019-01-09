using AutoMapper;
using WinnersLeague.Models;
using WinnersLeague.Services.Mapping.Contracts;

namespace WinnersLeague.Services.Models
{
    public class TeamViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Stadium { get; set; }

        public string Initials { get; set; }

        public string Logo { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Draws { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Team, TeamViewModel>()
                .ForMember(x => x.Stadium,
                    m => m.MapFrom(c => c.Stadium.Name));
        }
    }
}
