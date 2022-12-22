using Microsoft.EntityFrameworkCore;
using SpendingApp.Models;

namespace SpendingApp.Persistence;

public class SpendingContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public DbSet<Spending> Spendings { get; set; }

    public SpendingContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SpendingDb"));
    }
}