using SpendingApp.Models;

namespace SpendingApp.Services.Interfaces;

public interface ISpendingService
{
    Task<Spending> AddAsync(Spending spending, CancellationToken ct);

    Task RemoveByIdAsync(int id, CancellationToken ct);

    Task<Spending?> GetByIdAsync(int id, CancellationToken ct);
    Task<List<Spending>> GetByAllAsync(CancellationToken ct);

    Task<Spending> UpdateAsync(Spending spending, CancellationToken ct);
}