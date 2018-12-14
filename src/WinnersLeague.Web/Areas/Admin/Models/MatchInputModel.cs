namespace WinnersLeague.Web.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Models.Enums;


    public class MatchInputModel
    {
        public string Id { get; set; }

        [Display(Name ="Home Team")]
        virtual public string HomeTeam { get; set; }

        [Display(Name = "Away Team")]
        virtual public string AwayTeam { get; set; }

        virtual public string League { get; set; }

        public string Description { get; set; }

        [Display(Name = "Our Bet Suggestion")]
        [EnumDataType(typeof(OddType))]
        public OddType OurBetSuggestion { get; set; }

        [Display(Name = "Match Start")]
        public DateTime MatchStart { get; set; }

        public int? HomeScore { get; set; } = 0;

        public int? AwayScore { get; set; } = 0;

        [Display(Name = "Match Phase")]
        [EnumDataType(typeof(MatchStatus))]
        public MatchStatus Status { get; set; }

        
        [Display(Name = "Match Type")]
        [EnumDataType(typeof(MatchType))]
        public MatchType Type { get; set; }
    }
}
