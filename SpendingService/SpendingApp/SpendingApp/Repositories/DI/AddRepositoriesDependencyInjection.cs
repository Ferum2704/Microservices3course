using SpendingApp.Repositories.Interfaces;

namespace SpendingApp.Repositories.DI;

public static class AddRepositoriesDependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}