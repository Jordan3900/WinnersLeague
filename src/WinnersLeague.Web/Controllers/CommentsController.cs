namespace WinnersLeague.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WinnersLeague.Common;
    using WinnersLeague.Models;
    using WinnersLeague.Web.Models;

    [Authorize]
    public class CommentsController : Controller
    {
        private readonly IRepository<Comment> commentRepository;
        private readonly IRepository<Match> matchRepository;
        private readonly IRepository<WinnersLeagueUser> userRepository;
        private readonly IMapper mapper;

        public CommentsController(IRepository<Comment> commentRepository,
            IRepository<WinnersLeagueUser> userRepository,
            IMapper mapper,
            IRepository<Match> matchRepository)
        {
            this.commentRepository = commentRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.matchRepository = matchRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentInputModel model)
        {
            var author = this.userRepository
                .All().
                FirstOrDefault(x => x.UserName == this.User.Identity.Name);

            var match = this.matchRepository.All()
                .FirstOrDefault(x => x.Id == model.MatchId);

            var comment = mapper.Map<Comment>(model);

            comment.Author = author;
            match.Comments.Add(comment);

            await this.commentRepository.SaveChangesAsync();


            return this.RedirectToAction("Details", "Matches", match);
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(string id, string matchId)
        {
            var match = this.matchRepository
                .All()
                .FirstOrDefault(x => x.Id == matchId);

            var comment = this.commentRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            this.commentRepository.Delete(comment);
            await this.commentRepository.SaveChangesAsync();

            return this.RedirectToAction("Details", "Matches", match);
        }
    }
}