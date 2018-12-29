namespace WinnersLeague.Web.Areas.Admin.Models.ArticleModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ArticleInputModel
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public string Source { get; set; }
    }
}
