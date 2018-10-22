using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ExchangeApproval.Data
{
    class DesignTimeDbFactory : IDesignTimeDbContextFactory<ExchangeDbContext>
    {
        public ExchangeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExchangeDbContext>();
            var url = Environment.GetEnvironmentVariable("DATABASE_URL");
            var (scheme, connectionString) = DatabaseUrlHelpers.ParseDatabaseUrl(url);
            if (scheme == "mysql") {
                builder.UseMySql(connectionString);
            } else {
                throw new ArgumentOutOfRangeException($"Unsupported scheme {scheme}");
            }
            return new ExchangeDbContext(builder.Options);
        }
    }
}