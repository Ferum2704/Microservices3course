using IncomeService.Models;

namespace IncomeService.Services.Interfaces;

public interface IIncomeRecordsService
{
    Task<IncomeRecord> AddAsync(IncomeRecord spending, CancellationToken ct);
    Task RemoveByIdAsync(int id, CancellationToken ct);
    IncomeRecord? GetByIdAsync(int id, CancellationToken ct);
    IEnumerable<IncomeRecord> GetAllAsync(CancellationToken ct);
    Task<IncomeRecord> UpdateAsync(IncomeRecord spending, CancellationToken ct);
    int GetTotal();
}