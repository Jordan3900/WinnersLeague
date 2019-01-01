namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using WinnersLeague.Common;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Data.Contracts;
    using WinnersLeague.Web.Areas.Admin.Models.OddModels;

    [Area("Admin")]
    public class OddsController : Controller
    {
        private readonly IOddService oddService;
        private readonly IMatchService matchService;
        private readonly IRepository<Odd> oddRepository;
        private readonly IMapper mapper;


        public OddsController(IOddService oddService,
            IMatchService matchService,
            IRepository<Odd> oddRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.oddRepository = oddRepository;
            this.matchService = matchService;
            this.oddService = oddService;
        }

        public IActionResult All()
        {
            var odds = this.oddService.GetAll();

            return this.View(odds);
        }

        public IActionResult Create()
        {
            var matches = this.matchService.GetAll()
                .Select(x => new SelectMatchViewModel
                {
                    Id = x.Id,
                    MatchName = $"{x.HomeTeam.Name} vs {x.AwayTeam.Name}"
                }).ToList();

            this.ViewData["Matches"] = matches;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OddInputModel oddInputModel)
        {
            var matchId = oddInputModel.MatchId;

            var isMatchValid = this.matchService.IsMatchIdValid(matchId);

            if (!isMatchValid)
            {
                return this.BadRequest();
            }

            var matchViewModel = this.matchService
                .GetAll()
                .FirstOrDefault(x => x.Id == matchId);

            var match = this.matchService.GetMatch(matchId);

            var odd = new Odd
            {
                Match = match,
                OddValue = oddInputModel.OddValue,
                Type = oddInputModel.Type
            };

           await this.oddRepository.AddAsync(odd);
           await this.oddRepository.SaveChangesAsync();


            return this.RedirectToAction("All","Odds");
        }
    }
}