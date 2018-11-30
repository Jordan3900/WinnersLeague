namespace WinnersLeague.Web.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WinnersLeague.Data;
    using WinnersLeague.Models;

    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

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

            await this.next(context);
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
