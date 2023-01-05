using IncomeService.DataAccess.IRepository;
using IncomeService.Models;
using IncomeService.Services.Interfaces;

namespace IncomeService.Services;

public class IncomeRecordsService : IIncomeRecordsService
{
    private readonly IUnitOfWork _unitOfWork;

    public IncomeRecordsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IncomeRecord> AddAsync(IncomeRecord spending, CancellationToken ct)
    {
        var added = _unitOfWork.IncomeRecords.Add(spending);
        await _unitOfWork.SaveChangesAsync(ct);

        return added;
    }

    public async Task RemoveByIdAsync(int id, CancellationToken ct)
    {
        _unitOfWork.IncomeRecords.Delete(x => x.Id == id);
        await _unitOfWork.SaveChangesAsync(ct);
    }

    public IncomeRecord? GetByIdAsync(int id, CancellationToken ct)
    {
        return _unitOfWork.IncomeRecords.GetFirstOrDefault(x => x.Id == id);
    }
    public IEnumerable<IncomeRecord> GetAllAsync(CancellationToken ct)
    {
        return _unitOfWork.IncomeRecords.GetAll();
    }
    public async Task<IncomeRecord> UpdateAsync(IncomeRecord spending, CancellationToken ct)
    {
        var updated = _unitOfWork.IncomeRecords.Update(spending);
        await _unitOfWork.SaveChangesAsync(ct);

        return updated;
    }

    public int GetTotal()
    {
        var incomes = _unitOfWork.IncomeRecords.GetAll();
        return decimal.ToInt32(incomes.Select(x => x.Sum).Sum());
    }
}