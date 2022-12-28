using IncomeService.DataAccess.IRepository;

namespace IncomeService.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly IncomeDbContext _context;

    public UnitOfWork(IncomeDbContext context)
    {
        _context = context;
        IncomeRecords = new IncomeRecordsRepository(_context);
    }

    public IIncomeRecordsRepository IncomeRecords { get; }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct);
    }
}