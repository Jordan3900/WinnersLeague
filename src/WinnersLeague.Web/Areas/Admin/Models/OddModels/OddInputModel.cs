namespace WinnersLeague.Web.Areas.Admin.Models.OddModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Models.Enums;

    public class OddInputModel
    {
        public OddType Type { get; set; }

        public decimal OddValue { get; set; }

        public string MatchId { get; set; }

        public bool IsWinning { get; set; }
    }
}
