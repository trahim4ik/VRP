using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VRP.DAL;

namespace VRP.Application.Extensions {
    public static class ApplicationBuilderExtensions {
        public static IApplicationBuilder SetupMigrations(this IApplicationBuilder app) {
            try {
                var context = app.ApplicationServices.GetService<ApplicationDbContext>();
                context.Database.Migrate();
            } catch (Exception) { }
            return app;
        }

        public static IApplicationBuilder UseCustomSwaggerApi(this IApplicationBuilder app) {
            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VRP V1 Docs");
            });

            return app;
        }

        public static IApplicationBuilder AddDevMiddlewares(this IApplicationBuilder app) {
            var env = app.ApplicationServices.GetRequiredService<IHostingEnvironment>();
            var loggerFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseCustomSwaggerApi();
            }

            return app;
        }

    }
}
