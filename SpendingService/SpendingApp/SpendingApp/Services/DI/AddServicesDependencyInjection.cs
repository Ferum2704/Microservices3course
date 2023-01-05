using Polly;
using SpendingApp.Services.Clients;
using SpendingApp.Services.Interfaces;

namespace SpendingApp.Services.DI;

public static class AddServicesDependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<ISpendingService, SpendingService>()
            .AddScoped<IStatisticsService, StatisticsService>()
            .AddIncomeClient();

        return services;
    }

    private static IServiceCollection AddIncomeClient(this IServiceCollection services)
    {
        var circuitBreakerPolicy = GetCircuitBreakerPolicy();
        var retryPolicy = GetRetryPolicy();

        services.AddHttpClient<IIncomeClient, IncomeClient>()
            .AddPolicyHandler(circuitBreakerPolicy)
            .AddPolicyHandler(retryPolicy);

        return services;
    }

    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return Policy
            .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .CircuitBreakerAsync(2, TimeSpan.FromSeconds(10));
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return Policy
            .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .RetryAsync(4);
    }
}