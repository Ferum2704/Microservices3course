namespace SpendingApp.Services.Interfaces;

public interface IIncomeClient
{
    Task<int> GetTotalIncome(CancellationToken ct);

    Task<int> TryGetRetriesAsync(CancellationToken ct);

    Task<bool> TryGetTimeoutAsync();

    Task<(int NumberOfRetriesBeforeFailure, bool IsCircuitBrkoen)> TryGetBrokenCircuitAsync(CancellationToken ct);
}