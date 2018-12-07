namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class Comments
    {
        public string Id { get; set; }

        virtual public WinnersLeagueUser Author { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        virtual public Match Match { get; set; }
    }
}
