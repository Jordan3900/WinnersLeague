﻿using System;
using System.Collections.Generic;
using System.Text;
using WinnersLeague.Web.Areas.Identity.Data;

namespace WinnersLeague.Models
{
    public class Article
    {
        public string Id { get; set; }

        public WinnersLeagueUser Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Source { get; set; }
    }
}
