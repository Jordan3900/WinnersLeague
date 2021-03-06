﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinnersLeague.Models;
using WinnersLeague.Services.Models;
using WinnersLeague.Web.Areas.Admin.Models;
using WinnersLeague.Web.Areas.Admin.Models.ArticleModels;
using WinnersLeague.Web.Areas.Admin.Models.OddModels;
using WinnersLeague.Web.Models;
using WinnersLeague.Web.Models.UserModels;

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

            CreateMap<WinnersLeagueUser, UserViewModel>()
                .ReverseMap()
               .ForMember(x => x.Avatar, y => y.Ignore());

            CreateMap<Match, MatchInputModel>()
                .ReverseMap()
                .ForMember(x => x.Odds, y => y.Ignore())
                .ForMember(x => x.Comments, y => y.Ignore())
                .ForMember(x => x.HomeTeam, y => y.Ignore())
                .ForMember(x => x.AwayTeam, y => y.Ignore())
                .ForMember(x => x.League, y => y.Ignore());

            CreateMap<League, LeagueViewModel>().ReverseMap();

            CreateMap<Comment, CommentInputModel>().ReverseMap()
                .ForMember(x => x.Author, y => y.Ignore())
                .ForMember(x => x.Match, y => y.Ignore());

            CreateMap<Article, ArticleInputModel>()
                .ReverseMap()
                .ForMember(x => x.Author, y => y.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Match, MatchViewModel>()
                   .ForMember(x => x.League,
                  m => m.MapFrom(c => c.League.Name))
                  .ReverseMap();

            CreateMap<Stadium, StadiumViewModel>()
                 .ReverseMap()
                 .ForMember(x => x.Team, y => y.Ignore());

            CreateMap<Odd, OddInputModel>()
                .ReverseMap()
                .ForMember(x => x.Match, y => y.Ignore());
        }
    }
}
