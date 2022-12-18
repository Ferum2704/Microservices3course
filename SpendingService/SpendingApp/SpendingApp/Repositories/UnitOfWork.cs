using SpendingApp.Persistence;

namespace SpendingApp.Repositories.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly SpendingContext _context;

    public UnitOfWork(SpendingContext context)
    {
        _context = context;
        Spendings = new SpendingRepository(_context);
    }

    public ISpendingRepository Spendings { get; }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct);
    }
}