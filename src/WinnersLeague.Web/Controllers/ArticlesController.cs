namespace WinnersLeague.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WinnersLeague.Services.Data.Contracts;

    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [Route("/Articles/All", Name ="AllArticles")]
        public IActionResult All()
        {
            var articales = this.articleService.GetAll()
                .ToArray();

            return View(articales);
        }

        public IActionResult Details(string id)
        {
            var articles = this.articleService.GetAll()
                .FirstOrDefault(x => x.Id == id);

            return View(articles);
        }
    }
}