using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VRP.DAL.Core;

namespace VRP.DAL {
    public static class ServicesCollectionExtensions {

        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            return services;
        }

        public static IApplicationBuilder SetupMigrations(this IApplicationBuilder app, ApplicationDbContext context) {
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            return app;
        }

    }
}
