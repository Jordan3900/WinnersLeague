namespace WinnersLeague.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Services.Models;

    public interface IArticleService
    {
        IEnumerable<ArticleViewModel> GetAll();

        bool IsArtilcleIdValid(string articleId);

        string GetArticleId(string title);
    }
}
