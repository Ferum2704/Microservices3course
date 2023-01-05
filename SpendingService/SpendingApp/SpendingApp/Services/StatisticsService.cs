using SpendingApp.Services.Interfaces;

namespace SpendingApp.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IIncomeClient _incomeClient;
    private readonly ISpendingService _spendingService;

    public StatisticsService(IIncomeClient incomeClient, ISpendingService spendingService)
    {
        _incomeClient = incomeClient;
        _spendingService = spendingService;
    }

    public async Task<int> GetTotalProfitAsync(CancellationToken ct)
    {
        var spendings = await _spendingService.GetAllAsync(ct);
        var totalSpendingValue = spendings.Select(x => x.Value).Sum();

        var totalIncomeValue = await _incomeClient.GetTotalIncome(ct);

        return totalIncomeValue - totalSpendingValue;
    }

    public async Task<(string retryMessage, string brokenCircuitMessage)> TryGetFailuresAsync(CancellationToken ct)
    {
        return await _incomeClient.TryGetFailuresAsync(ct);
    }
}