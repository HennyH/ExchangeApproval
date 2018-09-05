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
            var datasource = Environment.GetEnvironmentVariable("DATABASE");
            builder.UseSqlite($"Data Source={datasource}");
            return new ExchangeDbContext(builder.Options);
        }
    }
}