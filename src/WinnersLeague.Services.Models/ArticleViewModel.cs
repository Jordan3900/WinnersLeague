namespace WinnersLeague.Services.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Mapping.Contracts;

    public class ArticleViewModel : IMapFrom<League>, IHaveCustomMappings
    {
        public string Id { get; set; }

        virtual public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Source { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Article, ArticleViewModel>()
                .ForMember(x => x.Author,
                    m => m.MapFrom(c => c.Author.FullName));
        }
    }
}
