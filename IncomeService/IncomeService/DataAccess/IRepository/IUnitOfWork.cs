namespace IncomeService.DataAccess.IRepository;

public interface IUnitOfWork
{
    IIncomeRecordsRepository IncomeRecords { get; }

    void SaveChanges();

    Task SaveChangesAsync(CancellationToken ct);

}