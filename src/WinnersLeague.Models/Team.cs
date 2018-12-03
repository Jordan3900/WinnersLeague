namespace WinnersLeague.Models
{
    public class Team
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Initials { get; set; }

        public League League { get; set; }

        public string StadiumId { get; set; }
        public Stadium Stadium { get; set; }

        public string Logo { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Draws { get; set; }

        public int YearFound { get; set; }

        public int Points { get; set; }
    }
}
