using Polly.CircuitBreaker;
using SpendingApp.Services.Interfaces;

namespace SpendingApp.Services.Clients;

public class IncomeClient : IIncomeClient
{
    private readonly HttpClient _httpClient;

    public IncomeClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetTotalIncome(CancellationToken ct)
    {
        Uri uri = new("http://local-income:8080/income/total");

        var response = await _httpClient.GetAsync(uri, ct);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.StatusCode.ToString());
        }

        var result = await response.Content.ReadAsStringAsync(ct);
        return int.Parse(result);
    }

    public async Task<int> TryGetRetriesAsync(CancellationToken ct)
    {
        Uri uri = new("http://local-income:8080/income/failure?isForRetries=true");

        var response = await _httpClient.GetAsync(uri, ct);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("server error");
        }

        var numberOfRetries = await response.Content.ReadAsStringAsync(ct);
        return int.Parse(numberOfRetries);
    }

    public async Task<bool> TryGetTimeoutAsync()
    {
        Uri uri = new("http://local-income:8080/income/failure");
        try
        {
            var ct = new CancellationTokenSource(TimeSpan.FromMilliseconds(500)).Token;
            await _httpClient.GetAsync(uri, ct);
        }
        catch (TaskCanceledException)
        {
            return true;
        }

        return false;
    }

    public async Task<(int NumberOfRetriesBeforeFailure, bool IsCircuitBrkoen)> TryGetBrokenCircuitAsync(
        CancellationToken ct)
    {
        var numberOfRetriesBeforeFailure = 0;
        var isCircuitBroken = false;

        try
        {
            for (var i = 0; i < 3; i++)
            {
                Uri uri = new("http://local-income:8080/income/failure");
                await _httpClient.GetAsync(uri, ct);
                numberOfRetriesBeforeFailure++;
            }
        }
        catch (BrokenCircuitException)
        {
            isCircuitBroken = true;
        }

        return (numberOfRetriesBeforeFailure, isCircuitBroken);
    }
}