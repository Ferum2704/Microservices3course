using IncomeService.Models;
using Microsoft.EntityFrameworkCore;

namespace IncomeService.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<IncomeCategory> incomeCategories;
        public DbSet<IncomeRecord> incomeRecords;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
