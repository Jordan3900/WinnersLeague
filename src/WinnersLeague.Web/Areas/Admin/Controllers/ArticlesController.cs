using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WinnersLeague.Common;
using WinnersLeague.Models;
using WinnersLeague.Services.Data.Contracts;
using WinnersLeague.Services.Models;
using WinnersLeague.Web.Areas.Admin.Models.ArticleModels;

namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IMapper mapper;
        private readonly IRepository<Article> articleRepository;
        private readonly IRepository<WinnersLeagueUser> userRepository;

        public ArticlesController(IArticleService articleService,
            IMapper mapper,
            IRepository<Article> articleRepository,
            IRepository<WinnersLeagueUser> userRepository )
        {
            this.articleService = articleService;
            this.mapper = mapper;
            this.articleRepository = articleRepository;
            this.userRepository = userRepository;
        }

        
        public IActionResult All()
        {
            var articles = articleService.GetAll();

            return View(articles);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ArticleInputModel model)
        {
            var author = this.userRepository
                .All()
                .FirstOrDefault(x => x.UserName == model.Author);



            var article = mapper.Map<Article>(model);
            article.Author = author;


            this.articleRepository.AddAsync(article);
            this.articleRepository.SaveChangesAsync();

            return this.RedirectToAction("All", "Articles");
        }

    }
}