using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace VRP.Api.Extensions {
    public static class ApplicationBuilderExtensions {

        public static IApplicationBuilder UseCustomSwaggerApi(this IApplicationBuilder app) {

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VRP V1 Docs");
            });

            return app;
        }

        public static IApplicationBuilder AddDevMiddlewares(this IApplicationBuilder app) {
            var env = app.ApplicationServices.GetRequiredService<IHostingEnvironment>();

            if (!env.IsDevelopment()) return app;

            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseCustomSwaggerApi();

            return app;
        }

    }
}
