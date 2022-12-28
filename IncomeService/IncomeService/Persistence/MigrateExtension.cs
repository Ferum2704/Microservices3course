﻿using Microsoft.EntityFrameworkCore;

namespace IncomeService.Persistence
{
    public static class MigrateExtension
    {
        public static IApplicationBuilder Migrate(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IncomeDbContext>();
            context.Database.Migrate();

            return builder;
        }
    }
}
