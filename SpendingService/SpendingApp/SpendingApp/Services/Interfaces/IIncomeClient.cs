namespace SpendingApp.Services.Interfaces;

public interface IIncomeClient
{
    Task<int> GetTotalIncome(CancellationToken ct);
    Task<(string retryMessage, string brokenCircuitMessage)> TryGetFailuresAsync(CancellationToken ct);
}