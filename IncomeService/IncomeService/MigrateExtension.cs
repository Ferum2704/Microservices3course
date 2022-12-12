using IncomeService.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace IncomeService
{
    public static class MigrateExtension
    {
        public static IApplicationBuilder Migrate(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }
            return builder;
        }
    }
}
