using IncomeService.Models;
using Microsoft.EntityFrameworkCore;

namespace IncomeService.Persistence
{
    public class IncomeDbContext : DbContext
    {
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<IncomeRecord> IncomeRecords { get; set; }
        protected readonly IConfiguration Configuration;

        public IncomeDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("IncomeDb"));
        }
    }
}
