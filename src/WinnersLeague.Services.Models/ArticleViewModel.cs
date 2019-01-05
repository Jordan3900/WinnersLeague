namespace WinnersLeague.Services.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Mapping.Contracts;

    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        [Required]
        public string Picture { get; set; }

        public string Source { get; set; }

        public string ShortContent => Content.Substring(0, 30) + "...";

        public string ShortTitle => Title.Substring(0, 10) + "...";

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Article, ArticleViewModel>()
                .ForMember(x => x.Author,
                    m => m.MapFrom(c => c.Author.FullName));
        }
    }
}
