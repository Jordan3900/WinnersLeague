﻿namespace WinnersLeague.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Stadium
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int YearFound { get; set; }

        public int Capacity { get; set; }

        public string TeamId { get; set; }
        virtual public Team Team { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
