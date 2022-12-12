using Microsoft.EntityFrameworkCore;

namespace SpendingApp.Persistence.Migrations.Helpers;

public static class MigrationsHelper
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SpendingContext>();

        /*if (!app.Environment.IsProduction())
        {
            return;
        }*/

        try
        {
            app.Logger.LogError("Migrations applying started!");
            dbContext.Database.Migrate();
            app.Logger.LogError("Migrations applying ended!");
        }
        catch (Exception ex)
        {
            app.Logger.LogError($"Could not apply migrations. {ex.Message}");
            throw;
        }
    }
}