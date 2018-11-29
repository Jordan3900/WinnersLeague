namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class League
    {
        public League()
        {
            this.Matches = new HashSet<Match>();
            this.Teams = new HashSet<Team>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public int CountOfTeams { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Match> Matches { get; set; }

    }
}
