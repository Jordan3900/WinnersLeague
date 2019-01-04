using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WinnersLeague.Data;
using WinnersLeague.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using WinnersLeague.Services;
using WinnersLeague.Web.Middlewares.MiddlewareExtansions;
using WinnersLeague.Common;
using WinnersLeague.Services.Data.Contracts;
using WinnersLeague.Services.Data;
using AutoMapper;
using WinnersLeague.Services.Mapping;
using WinnersLeague.Services.Models;

namespace WinnersLeague.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.RegisterMappings(
               typeof(TeamViewModel).Assembly
           );

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<WinnersLeagueContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

            services.AddIdentity<WinnersLeagueUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequiredLength = 3;
            })
                .AddEntityFrameworkStores<WinnersLeagueContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(options =>
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddTransient<IEmailSender, EmailSender>();


            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAutoMapper();

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddScoped<ITeamService, TeamsService>();
            services.AddScoped<IStadiumService, StadiumService>();
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IOddService, OddService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSeedDataMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}"
                  );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
