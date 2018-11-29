namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
using WinnersLeague.Models.Enums;

    public class Odd
    {
        public string Id { get; set; }

        public OddType Type { get; set; }

        public decimal OddValue { get; set; }

        public Match Match { get; set; }

        public bool IsWinning { get; set; }
    }
}
