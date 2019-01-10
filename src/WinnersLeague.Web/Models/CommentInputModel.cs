using System.ComponentModel.DataAnnotations;

namespace WinnersLeague.Web.Models
{
    public class CommentInputModel
    {
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        public string MatchId { get; set; }
    }
}
