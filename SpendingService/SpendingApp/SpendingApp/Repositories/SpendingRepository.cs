using SpendingApp.Models;
using SpendingApp.Persistence;
using SpendingApp.Repositories.Interfaces;

namespace SpendingApp.Repositories;

public class SpendingRepository : Repository<Spending>, ISpendingRepository
{
    public SpendingRepository(SpendingContext context) : base(context) { }
}