namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Models.Enums;

    public class Match
    {
        public Match()
        {
            this.Odds = new HashSet<Odd>();
            this.Comments = new HashSet<Comments>();
        }

        public string Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public League League { get; set; }

        public string Description { get; set; }

        public OddType OurBetSuggestion { get; set; }

        public DateTime MatchStart { get; set; }

        public int HomeScore { get; set; } = 0;

        public int AwayScore { get; set; } = 0;

        public MatchStatus Status { get; set; }

        public MatchType Type { get; set; }

        public ICollection<Odd> Odds { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
