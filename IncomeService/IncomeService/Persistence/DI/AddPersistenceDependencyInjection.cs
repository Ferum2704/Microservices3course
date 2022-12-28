using IncomeService.DataAccess.IRepository;
using IncomeService.Persistence.Repository;

namespace IncomeService.Persistence.DI;

public static class AddPersistenceDependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}