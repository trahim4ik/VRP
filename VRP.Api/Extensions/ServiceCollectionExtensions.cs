using Microsoft.Extensions.DependencyInjection;

namespace VRP.Application.Extensions {
	public static class ServiceCollectionExtensions {

		public static IServiceCollection AddCustomIdentity(this IServiceCollection services) {
			//services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
			//	// options for user and password can be set here
			//	// options.Password.RequiredLength = 4;
			//	// options.Password.RequireNonAlphanumeric = false;
			//})
			//.AddEntityFrameworkStores<ApplicationDbContext>()
			//.AddDefaultTokenProviders();

			return services;
		}

		public static IServiceCollection AddCustomDbContext(this IServiceCollection services) {
			// Add framework services.
			//services.AddDbContextPool<ApplicationDbContext>(options => {
			//	string useSqLite = Startup.Configuration["Data:useSqLite"];
			//	string useInMemory = Startup.Configuration["Data:useInMemory"];
			//	if (useInMemory.ToLower() == "true") {
			//		options.UseInMemoryDatabase("AspNetCoreSpa"); // Takes database name
			//	} else if (useSqLite.ToLower() == "true") {
			//		options.UseSqlite(Startup.Configuration["Data:SqlLiteConnectionString"]);
			//	} else {
			//		options.UseSqlServer(Startup.Configuration["Data:SqlServerConnectionString"]);
			//	}
			//	options.UseOpenIddict();
			//});
			return services;
		}

		public static IServiceCollection RegisterCustomServices(this IServiceCollection services) {
			// New instance every time, only configuration class needs so its ok
			//services.AddSingleton<IStringLocalizerFactory, EFStringLocalizerFactory>();
			//services.AddTransient<IEmailSender, AuthMessageSender>();
			//services.AddTransient<IApplicationDataService, ApplicationDataService>();
			//services.AddTransient<ApplicationDbContext>();
			//services.AddScoped<UserResolverService>();
			//services.AddScoped<ApiExceptionFilter>();
			return services;
		}
		
	}
}
