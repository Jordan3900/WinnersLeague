namespace WinnersLeague.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WinnersLeague.Common;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Data.Contracts;
    using WinnersLeague.Services.Mapping;
    using WinnersLeague.Services.Models;

    public class OddService : IOddService
    {
        private readonly IRepository<Odd> oddRepository;

        public OddService(IRepository<Odd> oddRepository)
        {
            this.oddRepository = oddRepository;
        }

        public IEnumerable<OddViewModel> GetAll()
        {
            var odds = this.oddRepository.All().To<OddViewModel>();

            return odds;
        }

        public bool IsOddIdValid(string oddId)
        {
            return this.oddRepository.All().Any(x => x.Id == oddId);
        }
    }
}
