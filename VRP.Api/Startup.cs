using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using VRP.Application.Extensions;

namespace VRP.Api {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddMvc();

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new Info { Title = "VRP Application", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

			app.AddDevMiddlewares();

			if (env.IsProduction()) {
				app.UseResponseCompression();
			}

			app.SetupMigrations();

			app.UseAuthentication();

			app.UseStaticFiles();

			app.UseMvc();

		}
	}
}
