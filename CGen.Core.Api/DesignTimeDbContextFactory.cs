using System;
using System.IO;
using CGen.Core.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CGen.Core.Api
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CGenContext>
    {
        public CGenContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json")
                .AddEnvironmentVariables()
                .Build();
            var builder = new DbContextOptionsBuilder<CGenContext>();
            var connectionString = configuration.GetConnectionString("CGenConnection");

            builder.UseSqlServer(connectionString);
            
            return new CGenContext(builder.Options);
        }
    }
}