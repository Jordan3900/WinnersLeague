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

        virtual public string HomeTeam { get; set; }

        virtual public string AwayTeam { get; set; }

        virtual public string League { get; set; }

        public string Description { get; set; }

        [EnumDataType(typeof(OddType))]
        public OddType OurBetSuggestion { get; set; }

        public DateTime MatchStart { get; set; }

        public int HomeScore { get; set; } = 0;

        public int AwayScore { get; set; } = 0;

        public MatchStatus Status { get; set; }

        public MatchType Type { get; set; }
    }
}
