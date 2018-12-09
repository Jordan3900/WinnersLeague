namespace WinnersLeague.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WinnersLeague.Common;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Data.Contracts;
    using WinnersLeague.Services.Mapping;
    using WinnersLeague.Services.Models;

    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> articleRepository;

        public ArticleService(IRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public IEnumerable<ArticleViewModel> GetAll()
        {
            var articles = this.articleRepository.All()
                .OrderBy(x => x.Title).To<ArticleViewModel>();

            return articles;
        }

        public string GetArticleId(string title)
        {
            var article = this.articleRepository.All()
                .FirstOrDefault(x => x.Title == title);

            return article.Id;
        }

        public bool IsArtilcleIdValid(string articleId)
        {
            return this.articleRepository.All()
                .Any(x => x.Id == articleId);
        }
    }
}
