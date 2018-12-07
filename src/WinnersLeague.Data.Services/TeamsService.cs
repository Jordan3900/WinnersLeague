using System;
using System.Collections.Generic;
using System.Linq;
using WinnersLeague.Data.Services.Contracts;
using WinnersLeague.Models;
using WinnersLeague.Services.Models;
using WinnersLeague.Services.Mapping;
using WinnersLeague.Data;

namespace WinnersLeague.Data.Services
{
    public class TeamsService : ITeamsService
    {
       

        public TeamsService()
        {
          
        }

        public IEnumerable<TeamViewModel> GetAll()
        {

            return null;
          
        }

        public string GetTeamId(string name)
        {

            return null;
       
        }

        public bool IsTeamIdValid(string teamId)
        {
            return true;
        }
    }
}
