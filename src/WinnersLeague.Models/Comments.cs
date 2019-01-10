namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;


    public class Comment
    {
        public string Id { get; set; }

        virtual public WinnersLeagueUser Author { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        public string Title { get; set; }

        virtual public Match Match { get; set; }
    }
}
