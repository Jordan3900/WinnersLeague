namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Web.Areas.Identity.Data;

    public class Comments
    {
        public string Id { get; set; }

        public WinnersLeagueUser Author { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public Match Match { get; set; }
    }
}
