using SpendingApp.Services.Interfaces;

namespace SpendingApp.Services.DI;

public static class AddServicesDependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISpendingService, SpendingService>();
        return services;
    }
}