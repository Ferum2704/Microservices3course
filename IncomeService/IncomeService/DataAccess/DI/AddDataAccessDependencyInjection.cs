using IncomeService.Persistence;

namespace IncomeService.DataAccess.DI;

public static class AddDataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddDbContext<IncomeDbContext>();
        return services;
    }
}