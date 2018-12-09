﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WinnersLeague.Services.Data.Contracts;

namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [Area("Admin")]
        public IActionResult All()
        {
            var articles = articleService.GetAll();

            return View(articles);
        }
    }
}