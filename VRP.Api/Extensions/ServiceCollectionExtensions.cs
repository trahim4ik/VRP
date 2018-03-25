using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VRP.DAL;
using VRP.Entities;

namespace VRP.Api.Extensions {
    public static class ServiceCollectionExtensions {

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services) {

            services.AddIdentity<User, Role>(options => {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("VRP")));

            return services;
        }

        public static IServiceCollection RegisterCustomServices(this IServiceCollection services) {
            services.AddScoped<ApplicationDbContext>();
            return services;
        }

    }
}
