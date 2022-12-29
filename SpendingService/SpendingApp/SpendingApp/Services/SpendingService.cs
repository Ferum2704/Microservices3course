using SpendingApp.Models;
using SpendingApp.Repositories.Interfaces;
using SpendingApp.Services.Interfaces;

namespace SpendingApp.Services;

public class SpendingService : ISpendingService
{
    private readonly IUnitOfWork _unitOfWork;

    public SpendingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Spending> AddAsync(Spending spending, CancellationToken ct)
    {
        var added = await _unitOfWork.Spendings.AddAsync(spending, ct);
        await _unitOfWork.SaveChangesAsync(ct);

        return added;
    }

    public async Task RemoveByIdAsync(int id, CancellationToken ct)
    {
        var spendingToRemove = await _unitOfWork.Spendings.GetByIdAsync(id, ct);
        if (spendingToRemove is null)
        {
            return;
        }

        _unitOfWork.Spendings.Remove(spendingToRemove);
        await _unitOfWork.SaveChangesAsync(ct);
    }

    public async Task<Spending?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await _unitOfWork.Spendings.GetByIdAsync(id, ct);
    }

    public async Task<List<Spending>> GetByAllAsync(CancellationToken ct)
    {
        return await _unitOfWork.Spendings.GetAllAsync(ct);
    }

    public async Task<Spending> UpdateAsync(Spending spending, CancellationToken ct)
    {
        var updated = _unitOfWork.Spendings.Update(spending);
        await _unitOfWork.SaveChangesAsync(ct);

        return updated;
    }
}