namespace WinnersLeague.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Models.Enums;
    using WinnersLeague.Services.Mapping.Contracts;

    public class OddViewModel : IMapFrom<Odd>
    {
        public string Id { get; set; }

        public OddType Type { get; set; }

        public decimal OddValue { get; set; }

        public bool IsWinning { get; set; }
    }
}
