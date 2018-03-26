using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using VRP.Services.Core;
using VRP.Services.Implementation;
using VRP.Services.Interfaces;

namespace VRP.Services {
    public static class ServicesCollectionExtensions {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddAutoMapper();

            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));

            services.AddScoped(typeof(IDataSetItemService), typeof(DataSetItemService));
            services.AddScoped(typeof(IDataSetService), typeof(DataSetService));
            services.AddScoped(typeof(IRealtyService), typeof(RealtyService));

            services.AddScoped(typeof(IUserService), typeof(UserService));

            return services;
        }

    }
}
