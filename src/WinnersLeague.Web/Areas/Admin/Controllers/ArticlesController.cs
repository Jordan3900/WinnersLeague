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
        public async Task<IActionResult> Create(ArticleInputModel model)
        {
            var author = this.userRepository
                .All()
                .FirstOrDefault(x => x.UserName == model.Author);


            var article = mapper.Map<Article>(model);
            article.Author = author;


            await this.articleRepository.AddAsync(article);
            await this.articleRepository.SaveChangesAsync();

            return this.RedirectToAction("All", "Articles");
        }

        public IActionResult Edit(string id)
        {
            var article = this.articleService.GetAll()
                .FirstOrDefault(x => x.Id == id);

            var authors = this.userRepository.All()
               .Select(x => x.UserName)
               .ToList();

            ViewData["Authors"] = authors;

            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleInputModel model, string id)
        {
            var author = this.userRepository
                .All()
                .FirstOrDefault(x => x.UserName == model.Author);

            var article = this.articleRepository.All()
                .FirstOrDefault(x => x.Id == id);

            mapper.Map(article, model);
            article.Author = author;

            await this.articleRepository.SaveChangesAsync();

            return  this.RedirectToAction("All", "Articles");
        }
    }
}