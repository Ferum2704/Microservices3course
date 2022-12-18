namespace SpendingApp.Persistence.DI;

public static class AddPersistenceDependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<SpendingContext>();
        return services;
    }
}