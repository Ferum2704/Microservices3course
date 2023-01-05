namespace SpendingApp.Services.Interfaces;

public interface IStatisticsService
{
    Task<int> GetTotalProfitAsync(CancellationToken ct);
    Task<(string retryMessage, string brokenCircuitMessage)> TryGetFailuresAsync(CancellationToken ct);
}