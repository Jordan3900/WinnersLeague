using System;
using System.Collections.Generic;
using System.Text;


namespace WinnersLeague.Models
{
    public class Article
    {
        public string Id { get; set; }

        virtual public WinnersLeagueUser Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Source { get; set; }
    }
}
