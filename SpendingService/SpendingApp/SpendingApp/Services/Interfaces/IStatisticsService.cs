using SpendingApp.Models;

namespace SpendingApp.Services.Interfaces;

public interface IStatisticsService
{
    Task<int> GetTotalProfitAsync(CancellationToken ct);

    Task<FailureModel> TryGetFailuresAsync(CancellationToken ct);
}