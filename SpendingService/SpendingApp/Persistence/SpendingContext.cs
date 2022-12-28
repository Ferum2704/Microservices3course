using Microsoft.EntityFrameworkCore;

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
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Spending"));
    }
}

public class Spending
{
    public int Id { get; set; }
    public Currency Currency { get; set; }
    public int Value { get; set; }
    public string Item { get; set; }
}

public enum Currency : byte
{
    Uah,
    Usd,
    Eur,
}