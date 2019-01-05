namespace WinnersLeague.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Common;
    using WinnersLeague.Models;
    using WinnersLeague.Services.Data.Contracts;
    using WinnersLeague.Services.Models;

    [Area("Admin")]
    public class StadiumsController : Controller
    {
        private readonly IStadiumService stadiumService;
        private readonly ITeamService teamService;
        private readonly IRepository<Stadium> stadiumRepository;
        private readonly IMapper mapper;


        public StadiumsController(IStadiumService stadiumService,
            ITeamService teamService,
            IRepository<Stadium> stadiumRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.stadiumService = stadiumService;
            this.teamService = teamService;
            this.stadiumRepository = stadiumRepository;
        }

        public IActionResult All()
        {
            var stadiums = stadiumService.GetAll();

            return View(stadiums);
        }

        public IActionResult Edit(string id)
        {
            var stadium = stadiumService
                .GetAll()
                .FirstOrDefault(x => x.Id == id);

            var teams = this.teamService
                .GetAll()
                .Select(x => x.Name)
                .ToList();

            this.ViewData["Teams"] = teams;

            return View(stadium);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StadiumViewModel model)
        {
            var stadium = this.stadiumRepository.All()
                 .FirstOrDefault(x => x.Id == model.Id);
            var team = this.teamService.GetTeam(model.Team);

            mapper.Map(model, stadium);
            stadium.Team = team;

            await this.stadiumRepository.SaveChangesAsync();

            return this.RedirectToAction("All", "Stadiums");
        }
    }
}
