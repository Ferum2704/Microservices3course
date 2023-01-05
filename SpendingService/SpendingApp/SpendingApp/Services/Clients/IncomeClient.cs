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
        Uri uri = new("https://localhost:7089/income/total1");

        await _httpClient.GetAsync("/income/total", ct);

        var response = await _httpClient.GetAsync(uri, ct);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("server error");
        }

        var result = await response.Content.ReadAsStringAsync(ct);
        return int.Parse(result);
    }

    public async Task<(string retryMessage, string brokenCircuitMessage)> TryGetFailuresAsync(CancellationToken ct)
    {
        var numberOfRetries = 0;
        var brokenCircuitMessage = string.Empty;
        for (var i = 0; i < 3; i++)
        {
            try
            {
                Uri uri = new($"https://localhost:7089/income/failure/{i}");
                await _httpClient.GetAsync(uri, ct);
                numberOfRetries++;
            }
            catch (BrokenCircuitException)
            {
                brokenCircuitMessage = nameof(BrokenCircuitException);
            }
        }

        return ($"number of retries: {numberOfRetries}", brokenCircuitMessage);
    }
}