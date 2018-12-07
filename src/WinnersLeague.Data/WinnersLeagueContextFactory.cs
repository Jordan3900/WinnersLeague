namespace WinnersLeague.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using WinnersLeague.Models;
    

    public class WinnersLeagueContextFactory : IDesignTimeDbContextFactory<WinnersLeagueContext>
    {
        public WinnersLeagueContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<WinnersLeagueContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseLazyLoadingProxies().UseSqlServer(connectionString);

            // Stop client query evaluation
            builder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new WinnersLeagueContext(builder.Options);
        }
    }
}
