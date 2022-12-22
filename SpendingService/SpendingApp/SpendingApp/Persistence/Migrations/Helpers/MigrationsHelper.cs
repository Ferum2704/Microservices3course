using Microsoft.EntityFrameworkCore;

namespace SpendingApp.Persistence.Migrations.Helpers;

public static class MigrationsHelper
{
    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SpendingContext>();
            context.Database.Migrate();
        }
        return builder;
    }
}