namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Models.Enums;
    using WinnersLeague.Services.Mapping.Contracts;


    public class Match 
    {
        public Match()
        {
            this.Odds = new HashSet<Odd>();
            this.Comments = new HashSet<Comment>();
        }

        public string Id { get; set; }

        virtual public Team HomeTeam { get; set; }
     
        virtual public Team AwayTeam { get; set; }
      
        virtual public League League { get; set; }

        public string Description { get; set; }

        public bool IsMatchChecked { get; set; }

        public OddType OurBetSuggestion { get; set; }

        public DateTime MatchStart { get; set; }

        public int HomeScore { get; set; } = 0;

        public int AwayScore { get; set; } = 0;

        public MatchStatus Status { get; set; }

        public MatchType Type { get; set; }

        virtual public ICollection<Odd> Odds { get; set; }
        virtual public ICollection<Comment> Comments { get; set; }
    }
}
