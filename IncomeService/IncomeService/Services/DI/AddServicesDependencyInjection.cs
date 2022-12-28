using IncomeService.Services.Interfaces;

namespace IncomeService.Services.DI;

public static class AddServicesDependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IIncomeRecordsService, IncomeRecordsService>();
        return services;
    }
}