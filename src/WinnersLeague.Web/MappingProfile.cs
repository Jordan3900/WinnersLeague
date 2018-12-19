using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinnersLeague.Models;
using WinnersLeague.Services.Models;
using WinnersLeague.Web.Areas.Admin.Models;

namespace WinnersLeague.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<League, LeagueViewModel>().ReverseMap();
            CreateMap<Team, TeamViewModel>()
                .ReverseMap()
                .ForMember(x => x.Stadium, y => y.Ignore());

            CreateMap<Match, MatchInputModel>()
                .ReverseMap()
                .ForMember(x => x.Odds, y => y.Ignore())
                .ForMember(x => x.Comments, y => y.Ignore())
                .ForMember(x => x.HomeTeam, y => y.Ignore())
                .ForMember(x => x.AwayTeam, y => y.Ignore())
                .ForMember(x => x.League, y => y.Ignore());

            CreateMap<Match, MatchViewModel>()
                   .ForMember(x => x.League,
                  m => m.MapFrom(c => c.League.Name));
        }
    }
}
