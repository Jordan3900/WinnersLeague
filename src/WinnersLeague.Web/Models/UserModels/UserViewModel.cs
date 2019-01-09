namespace WinnersLeague.Web.Models.UserModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Mapping.Contracts;

    public class UserViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public decimal WinStats { get; set; }

        public decimal Points { get; set; }

        public ICollection<Bet> Bets;

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<WinnersLeagueUser, UserViewModel>()
                .ReverseMap()
                .ForMember(x => x.Avatar,
                   y => y.Ignore());
        }
    }
}
