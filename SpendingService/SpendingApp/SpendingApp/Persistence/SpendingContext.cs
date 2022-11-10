using Microsoft.EntityFrameworkCore;

namespace SpendingApp.Persistence;

public class SpendingContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public DbSet<PingItem> Pings { get; set; }

    public SpendingContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Spending"));
    }
}

public class PingItem
{
    public PingItem(int counter)
    {
        Counter = counter;
    }

    public int Id { get; set; }
    public int Counter { get; set; }
};