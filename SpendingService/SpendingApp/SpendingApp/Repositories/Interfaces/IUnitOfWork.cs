namespace SpendingApp.Repositories.Interfaces;

public interface IUnitOfWork
{
    ISpendingRepository Spendings { get; }

    void SaveChanges();

    Task SaveChangesAsync(CancellationToken ct);
}