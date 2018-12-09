using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinnersLeague.Common;
using WinnersLeague.Models;
using WinnersLeague.Services.Data.Contracts;
using WinnersLeague.Services.Mapping;
using WinnersLeague.Services.Models;

namespace WinnersLeague.Services.Data
{
    public class StadiumService : IStadiumService
    {
        private readonly IRepository<Stadium> stadiumRepository;

        public StadiumService(IRepository<Stadium> stadiumRepository)
        {
            this.stadiumRepository = stadiumRepository;
        }

        public IEnumerable<StadiumViewModel> GetAll()
        {
            var stadiums = this.stadiumRepository.All()
                .OrderBy(x => x.Name)
                .To<StadiumViewModel>();

            return stadiums;

        }

        public string GetTeamId(string name)
        {
            var team = this.stadiumRepository.All()
                .FirstOrDefault(x => x.Name == name);

            return team.Id;
        }

        public bool IsTeamIdValid(string stadiumId)
        {
            return this.stadiumRepository.All().Any(x => x.Id == stadiumId);
        }
    }
}
