namespace WinnersLeague.Web.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Data;
    using WinnersLeague.Models;

    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;
        private const string JSON_FILE = @"Teams.json";

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(
            HttpContext context,
            WinnersLeagueContext dbContext,
            UserManager<WinnersLeagueUser> usermanager,
            RoleManager<IdentityRole> roleManager)
        {

            if (!dbContext.Roles.Any())
            {
                await this.SeedRoles(usermanager, roleManager);
            }

            if (!dbContext.Teams.Any())
            {
                 this.SeedTeams(dbContext);
            }

            await this.next(context);
        }

        private void SeedTeams(WinnersLeagueContext dbContext)
        {
            var json = File.ReadAllText(JSON_FILE);
            
            var deserializer = JsonConvert.DeserializeObject<Team[]>(json);

            dbContext.Teams.AddRange(deserializer);
            dbContext.SaveChanges();
        }

        private async Task SeedRoles(
           UserManager<WinnersLeagueUser> usermanager,
           RoleManager<IdentityRole> roleManager)
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (result.Succeeded && usermanager.Users.Any())
            {
                var firstUser = usermanager.Users.FirstOrDefault();
                await usermanager.AddToRoleAsync(firstUser, "Admin");
            }

        }
    }
}
