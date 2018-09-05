using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ExchangeDbContext : DbContext
    {
        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options)
            : base(options)
        { }

        public DbSet<University> Universities { get; set; }
        public DbSet<UniversityUnit> Units { get; set; }
        public DbSet<ExchangeUnit> ExchangeUnits { get; set; }
    }
}