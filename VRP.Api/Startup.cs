using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using VRP.DAL;
using System;
using VRP.Api.Extensions;
using VRP.Services;

namespace VRP.Api {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddCustomDbContext(Configuration);

            services.AddCustomIdentity();

            services.AddCustomServices();

            services.AddRepositories();

            services.AddApplicationServices();

            services.AddCustomFilters();

            services.AddAuthorization()
                .AddAuthentication()
                .AddCookie();

            services.AddMvc()
                .AddJsonOptions(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "VRP Application", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider) {

            app.AddDevMiddlewares();

            if (env.IsProduction()) {
                app.UseResponseCompression();
            }

            app.SetupMigrations(serviceProvider.GetRequiredService<ApplicationDbContext>());

            app.UseAuthentication();

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");

            app.UseDefaultFiles(options);

            app.UseStaticFiles();

            app.UseMvc();

            DbInitializer.Initialize(serviceProvider);

        }
    }
}
